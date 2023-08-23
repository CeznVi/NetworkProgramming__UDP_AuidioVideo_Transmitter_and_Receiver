using AForge.Video;
using AForge.Video.DirectShow;
using NAudio.CoreAudioApi;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Media;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;

namespace AudioVidou
{
    public partial class TransmitterForm : Form
    {

        ///-------------Clases for VIDEO---------------------------/
        private FilterInfoCollection videoDevicesInfo;
        private VideoCaptureDevice videoDevice;
        ///-------------Clases for AUDIO---------------------------/
        private IEnumerable<MMDevice> CaptureDevices { set; get; }
        private MMDevice selectedDevice;



        ///-------------NETWORK for VIDEO CLIENT---------------------------/
        private UdpClient _udpVideoClient;
        private IPEndPoint _ipEndPointVideo;
        private bool _isVideoTransmit = false;
        ///-------------NETWORK for AUDIO CLIENT---------------------------/
        private UdpClient _udpAudioClient;
        private IPEndPoint _ipEndPointAudio;
        private bool _isAudioTransmit = false;

        ///-----------------------------CONSTRUCTOR----------------------------------------\\\
        public TransmitterForm()
        {
            InitializeComponent();
            InitVideoDevice();
            InitAudioDevice();
        }

        /// <summary>
        /// Initialization video device
        /// </summary>
        private void InitVideoDevice()
        {
            ///init video device
            videoDevicesInfo = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            if (videoDevicesInfo.Count == 0)
            {
                toolStripStatusLabel.ForeColor = Color.Red;
                toolStripStatusLabel.Text = "Video Device Not Found";
                return;
            }
            foreach (FilterInfo item in videoDevicesInfo)
            {
                comboBoxVideoDev.Items.Add(item.Name);
            }
        }
        /// <summary>
        /// Initialization audio device
        /// </summary>
        private void InitAudioDevice()
        {
            /////init audio device
            var enumerator = new MMDeviceEnumerator();
            CaptureDevices = enumerator.EnumerateAudioEndPoints(DataFlow.Capture, DeviceState.Active).ToArray();

            ///this is KOSTIL
            if (CaptureDevices.ToArray().Length == 0)
            {
                toolStripStatusLabel.ForeColor = Color.Red;
                toolStripStatusLabel.Text = "Video Device Not Found";
                return;
            }

            foreach (MMDevice item in CaptureDevices)
            {
                comboBoxAudioDev.Items.Add(item.FriendlyName);
            }
        }

        ///====================EVENTS WITH COMBOBOX====================\\\
        private void comboBoxVideoDev_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValueNam = comboBoxVideoDev.SelectedItem.ToString();
            foreach (FilterInfo item in videoDevicesInfo)
            {
                if(selectedValueNam == item.Name)
                {
                    videoDevice = new VideoCaptureDevice(item.MonikerString);
                    videoDevice.NewFrame += VideoDevice_NewFrame;
                }
            }
        }

        private void comboBoxAudioDev_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach(MMDevice item in CaptureDevices)
            {
                if (item.ToString() == comboBoxAudioDev.SelectedItem.ToString())
                    selectedDevice = item;
            }
        }
        ///==================== END EVENTS WITH COMBOBOX====================\\\

        ///====================EVENTS WITH CLIK BUTTON====================\\\

        /// <summary>
        /// Turn on webcam
        /// </summary>
        private void buttonVideoStart_Click(object sender, EventArgs e)
        {
            try
            {
                if (videoDevice != null && videoDevice.IsRunning)
                {
                    videoDevice.Stop();
                    buttonVideoStart.Text = "Start";

                    comboBoxVideoDev.Enabled = true;

                    pictureBox_TV.Image = null; ///clear frame translation
                    pictureBox_TV.BackgroundImage = new Bitmap(Resource1._375);
                    pictureBox_TV.BackgroundImageLayout = ImageLayout.Zoom;
                    pictureBox_TV.Refresh();
                }
                else
                {
                    if (comboBoxVideoDev.SelectedItem != null)
                    {
                        videoDevice.Start();
                        buttonVideoStart.Text = "Stop";
                        toolStripStatusLabel.Text = "RUN";
                        comboBoxVideoDev.Enabled = false;
                    }
                    else
                    {
                        toolStripStatusLabel.ForeColor = Color.Red;
                        toolStripStatusLabel.Text = "Video Device Not Found";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        /// <summary>
        /// Turn on microphone
        /// </summary>
        private void buttonAudioStart_Click(object sender, EventArgs e)
        {

        }

        ///==================== END EVENTS WITH CLIK BUTTON====================\\\


        private void VideoDevice_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
           Bitmap bitmap = new Bitmap(eventArgs.Frame, pictureBox_TV.Width, pictureBox_TV.Height);
            pictureBox_TV.Image = bitmap;     

        }


        private void buttonVideoTransmittControl_Click(object sender, EventArgs e)
        {
            try
            {
                if(videoDevice != null && videoDevice.IsRunning && _isVideoTransmit == false)
                {
                    IPAddress iPAddress;

                    if(IPAddress.TryParse(textBox_IpAddress.Text, out iPAddress)) 
                    { 
                        _ipEndPointVideo = new IPEndPoint(iPAddress, Convert.ToInt32(textBox_Port.Text));
                        _udpVideoClient = new UdpClient();
                        _isVideoTransmit = true;

                        textBox_IpAddress.ReadOnly = true;
                        textBox_Port.ReadOnly = true;

                        videoDevice.NewFrame += _videoDevice_NewFrame;

                        toolStripStatusLabel.ForeColor = Color.Green;
                        toolStripStatusLabel.Text = "Video translation STARTED";
                        buttonVideoTransmittControl.BackColor = Color.Lime;

                    }
                    else
                    {
                        toolStripStatusLabel.ForeColor = Color.Red;
                        toolStripStatusLabel.Text = "IP adress is not valid";
                        return;
                    }

                }
                else if(_isVideoTransmit)
                {
                    //stop video translation
                    _isVideoTransmit = false;
                    videoDevice.Stop();

                    toolStripStatusLabel.ForeColor = Color.Green;
                    toolStripStatusLabel.Text = "Video translation stoped";
                    buttonVideoTransmittControl.BackColor = Color.Red;
                    buttonVideoStart.Text = "Start";

                    comboBoxVideoDev.Enabled = true;
                    pictureBox_TV.Image = null; ///clear frame translation
                    pictureBox_TV.BackgroundImage = new Bitmap(Resource1._375);
                    pictureBox_TV.BackgroundImageLayout = ImageLayout.Zoom;
                    pictureBox_TV.Refresh();

                }
                else
                {
                    toolStripStatusLabel.ForeColor = Color.Red;
                    toolStripStatusLabel.Text = "Need select video device for start";
                }

            }
            catch(Exception ex) 
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void _videoDevice_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            ///Передача данніх по сеті
            
            if(_isVideoTransmit)
            {
                Bitmap bitmap = new Bitmap(eventArgs.Frame, pictureBox_TV.Width, pictureBox_TV.Height);
                MemoryStream memoryStream = new MemoryStream();

                bitmap.Save(memoryStream, ImageFormat.Jpeg);
                
                byte[] buffer = memoryStream.ToArray();
                _udpVideoClient.Send(buffer, buffer.Length, _ipEndPointVideo);
                memoryStream.Close();
            }
        }

        private void TransmitterForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(videoDevice != null && videoDevice.IsRunning)
            {
                videoDevice.Stop();
                _isVideoTransmit = false;
            }
        }


    }
}
