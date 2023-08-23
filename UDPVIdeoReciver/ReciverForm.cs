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
using NAudio.Wave;

namespace UDPVIdeoReciver
{
    public partial class ReciverForm : Form
    {
        private UdpClient _udpVideoClient;
        private IPEndPoint _ipEndPointVideo;
        private bool _isVideoRecieve = false;

        private UdpClient _udpAudioClient;
        private IPEndPoint _ipEndPointAudio;
        private bool _isAudioRecieve = false;
        private WaveOut output;
        private BufferedWaveProvider bufferStream;

        public ReciverForm()
        {
            InitializeComponent();
            button_videoControl.BackColor = Color.Red;
            button_audioControl.BackColor = Color.Red;
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
                        button_videoControl.BackColor = Color.Green;

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
                button_videoControl.BackColor = Color.Red;
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
                    Bitmap bitmap = null;
                    MemoryStream memoryStream = null;
                    pictureBox_TV.SizeMode = PictureBoxSizeMode.StretchImage;

                    while (_isVideoRecieve)
                    {
                        var data = await _udpVideoClient.ReceiveAsync();

                        memoryStream = new MemoryStream(data.Buffer);
                        bitmap = new Bitmap(memoryStream);

                        pictureBox_TV.Image = bitmap;
                        
                        pictureBox_TV.Invalidate();
                    }

                    pictureBox_TV.Image = null;
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

        private void button_audioControl_Click(object sender, EventArgs e)
        {
            if (!_isAudioRecieve)
            { //start

                try
                {
                    IPAddress iPAddress;
                    if (IPAddress.TryParse(textBox_ipAdress.Text, out iPAddress))
                    {
                        _ipEndPointAudio = new IPEndPoint(iPAddress, Convert.ToInt32(textBox_port.Text) + 1);

                        _isAudioRecieve = true;
                        textBox_port.ReadOnly = true;
                        textBox_ipAdress.ReadOnly = true;

                        toolStripStatusLabel_Info.Text = "Starting audio data recieve";
                        toolStripStatusLabel_Info.ForeColor = Color.Green;
                        button_audioControl.BackColor = Color.Green;
                        ReciveAudioContentAsync();
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
                _isAudioRecieve = false;

                textBox_port.ReadOnly = false;
                textBox_ipAdress.ReadOnly = false;

                if (output != null)
                {
                    output.Stop();
                    output = null;
                }

                toolStripStatusLabel_Info.Text = "STOPED audio data recieve";
                toolStripStatusLabel_Info.ForeColor = Color.Red;
                button_audioControl.BackColor = Color.Red;
            }

        }

        private async void ReciveAudioContentAsync()
        {
            await Task.Run(async () =>
            {
                try
                {
                    _udpAudioClient = new UdpClient(_ipEndPointAudio);
                    ////////////// БАГ-Фича майкрософта, у сокета открытого по ЮДП таймаут 3 мин, фикс таймаутов
                    _udpAudioClient.Client.SendTimeout = 10;
                    _udpAudioClient.Client.ReceiveTimeout = 10;
                    //////////////

                    output = new WaveOut();
                    bufferStream = new BufferedWaveProvider(new WaveFormat(8000, 16, 1));
                    output.Init(bufferStream);

                    //начинаем воспроизводить входящий звук
                    output.Play();

                    while (_isAudioRecieve)
                    {
                        var data = await _udpAudioClient.ReceiveAsync();

                        bufferStream.AddSamples(data.Buffer, 0, data.Buffer.Length);
                    }

                    _udpAudioClient.Close();
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
