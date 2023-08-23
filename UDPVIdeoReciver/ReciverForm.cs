using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace UDPVIdeoReciver
{
    public partial class ReciverForm : Form
    {
        private UdpClient _udpVideoClient;
        private IPEndPoint _ipEndPointVideo;
        private bool _isVideoRecieve = false;

        public ReciverForm()
        {
            InitializeComponent();
        }

        private void button_videoControl_Click(object sender, EventArgs e)
        {
            if (!_isVideoRecieve)
            { //start

                try
                {
                    IPAddress iPAddress;
                    if (IPAddress.TryParse(textBox_ipAdress.Text, out iPAddress))
                    {
                        _ipEndPointVideo = new IPEndPoint(iPAddress, Convert.ToInt32(textBox_port.Text));

                        _isVideoRecieve = true;
                        textBox_port.ReadOnly = true;
                        textBox_ipAdress.ReadOnly = true;

                        toolStripStatusLabel_Info.Text = "Starting video data recieve";
                        toolStripStatusLabel_Info.ForeColor = Color.Green;

                        ReciveVideoContentAsync();

                        //if(_udpVideoClient != null) _udpVideoClient.Close();

                    }
                    else
                    {
                        toolStripStatusLabel_Info.ForeColor = Color.Red;
                        toolStripStatusLabel_Info.Text = "IP is not valid";
                        return;
                        
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            else
            { //stop
                _isVideoRecieve = false;

                textBox_port.ReadOnly = false;
                textBox_ipAdress.ReadOnly = false;

                pictureBox_TV.Image = null;
                pictureBox_TV.Refresh();

                toolStripStatusLabel_Info.Text = "STOPED video data recieve";
                toolStripStatusLabel_Info.ForeColor = Color.Red;
                
            }

        }

        private async void ReciveVideoContentAsync()
        {
            await Task.Run(async () => 
            {
                try
                {
                    _udpVideoClient = new UdpClient(_ipEndPointVideo);

                    ////////////// БАГ-Фича майкрософта, у сокета открытого по ЮДП таймаут 3 мин, фикс таймаутов
                    _udpVideoClient.Client.SendTimeout = 10;
                    _udpVideoClient.Client.ReceiveTimeout = 10;
                    //////////////

                    while (_isVideoRecieve)
                    {
                        var data = await _udpVideoClient.ReceiveAsync();
                        MemoryStream memoryStream = new MemoryStream(data.Buffer);

                        pictureBox_TV.Image = new Bitmap(memoryStream);

                        pictureBox_TV.Invalidate();

                    }

                    _udpVideoClient.Close();
                }
                catch (SocketException ex)
                {
                    ////////////// если ловим екзепшен то ничего не делаем, баг-фича с таймаутом 3мин

                }
                catch (Exception ex) 
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            });
            

        }
    }
}
