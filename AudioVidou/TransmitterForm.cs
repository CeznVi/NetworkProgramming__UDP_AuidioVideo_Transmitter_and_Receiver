using AForge.Video;
using AForge.Video.DirectShow;
using NAudio.Wave;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
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
        private bool _isAudioTransmit = false;
        ////поток для нашей речи
        WaveIn input;
        ///-------------NETWORK for VIDEO CLIENT---------------------------/
        private UdpClient _udpVideoClient;
        private IPEndPoint _ipEndPointVideo;
        private bool _isVideoTransmit = false;
        ///-------------NETWORK for AUDIO CLIENT---------------------------/
        private UdpClient _udpAudioClient;
        private IPEndPoint _ipEndPointAudio;
        
     

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
            ///////init audio device
            if (videoDevicesInfo.Count == 0)
            {
                buttonAudioStart.Visible = false;
                return;
            }
            for (int i = 0; i < WaveIn.DeviceCount; i++)
            {
                WaveInCapabilities capabilities = WaveIn.GetCapabilities(i);
                comboBoxAudioDev.Items.Add(capabilities.ProductName);
            }
            buttonAudioStart.BackColor = Color.Red;
            buttonAudioStart.Text = "Start Audio";
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
            if (comboBoxAudioDev.Items.Count == 0)
            {
                toolStripStatusLabel.ForeColor = Color.Red;
                toolStripStatusLabel.Text = "Audio Device Not Found";
                return;
            }
            else if (comboBoxAudioDev.SelectedIndex == -1)
            {
                toolStripStatusLabel.ForeColor = Color.Red;
                toolStripStatusLabel.Text = "Audio Device Not Selected";
                return;
            }
            else
            {
                if(_isAudioTransmit == false)
                {
                    try
                    {
                        IPAddress iPAddress;
                        if(IPAddress.TryParse(textBox_IpAddress.Text, out iPAddress))
                        {
                            _ipEndPointAudio = new IPEndPoint(iPAddress, Convert.ToInt32(textBox_Port.Text)+1);
                            _udpAudioClient = new UdpClient();

                            textBox_IpAddress.ReadOnly = true;
                            textBox_Port.ReadOnly = true;

                            input = new WaveIn();
                            input.WaveFormat = new WaveFormat(8000, 16, 1);
                            input.DeviceNumber = comboBoxAudioDev.SelectedIndex;
                            input.DataAvailable += Voice_Input;
                            input.StartRecording();

                            _isAudioTransmit = true;
                            ////интерфейс
                            buttonAudioStart.BackColor = Color.Green;
                            buttonAudioStart.Text = "Stop Audio";
                            toolStripStatusLabel.ForeColor = Color.Green;
                            toolStripStatusLabel.Text = "Audio translation STARTED";
                            comboBoxAudioDev.Enabled = false;
                        }
                        else
                        {
                            toolStripStatusLabel.ForeColor = Color.Red;
                            toolStripStatusLabel.Text = "IP adress is not valid";
                            return;
                        }
                        
                    }
                    catch (Exception ex) 
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    try
                    {
                        if (input != null)
                        {
                            input.StopRecording();
                            input = null;
                        }
                    }
                    catch (Exception ex) 
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    _isAudioTransmit = false;
                    ////интерфейс
                    buttonAudioStart.BackColor = Color.Red;
                    buttonAudioStart.Text = "Start Audio";
                    toolStripStatusLabel.ForeColor = Color.Red;
                    toolStripStatusLabel.Text = "Audio translation STOPED";
                    comboBoxAudioDev.Enabled = true;
                }

            }
        }

        //AUDIO EVENT HANDLER
        private void Voice_Input(object sender, WaveInEventArgs e)
        {
            _udpAudioClient.Send(e.Buffer, e.Buffer.Length, _ipEndPointAudio);
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

            if(_isAudioTransmit = true && input != null)
            {
                input.StopRecording();
                _isAudioTransmit = false;
            }
        }


    }
}
