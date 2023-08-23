using AForge.Video;
using AForge.Video.DirectShow;
using NAudio.CoreAudioApi;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Media;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace AudioVidou
{
    public partial class TransmitterForm : Form
    {

        ///-------------Clases for VIDEO---------------------------/
        
        private FilterInfoCollection videoDevicesInfo;
        private VideoCaptureDevice videoDevice;

        ///-------------Clases for AUDIO---------------------------/
        
        /// <summary>
        /// Колекция в которой хранятся устройства для записи аудио
        /// </summary>       
        //private IEnumerable<MMDevice> CaptureDevices { set; get; }
        /// <summary>
        /// Selected device
        /// </summary>
        //private MMDevice selectedDevice;
        //private WasapiCapture capture;


        WaveInCapabilities selectedDevice;


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
            ///////init audio device
            if(videoDevicesInfo.Count == 0) return;

            for (int i = 0; i < WaveIn.DeviceCount; i++)
            {
                WaveInCapabilities capabilities = WaveIn.GetCapabilities(i);
                comboBoxAudioDev.Items.Add(capabilities.ProductName);
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
            //try
            //{
            //capture = new WasapiCapture(selectedDevice);
            //capture.ShareMode = AudioClientShareMode.Shared;
            //capture.WaveFormat = new WaveFormat(16000, 32, 2);

            //capture.StartRecording();

                
            if (comboBoxAudioDev.Items.Count == 0)
            {
                toolStripStatusLabel.ForeColor = Color.Red;
                toolStripStatusLabel.Text = "Audio Device Not Found";
                return;
            }
            if (comboBoxAudioDev.SelectedIndex == -1)
            {
                toolStripStatusLabel.ForeColor = Color.Red;
                toolStripStatusLabel.Text = "Audio Device Not Selected";
                return;
            }

                ////поток для нашей речи
                WaveIn input;
                ////буфферный поток для передачи через сеть
                BufferedWaveProvider bufferStream;
                input = new WaveIn();
                input.WaveFormat = new WaveFormat(8000, 16, 1);
                input.DeviceNumber = comboBoxAudioDev.SelectedIndex;
                input.DataAvailable += Voice_Input;
                input.StartRecording();
                



            







            //SoundPlayer soundPlayer = new SoundPlayer();
            //soundPlayer.Stream = capture.CaptureState;



            ////поток для нашей речи
            //WaveIn input;
            ////поток для речи собеседника
            //WaveOut output;
            ////буфферный поток для передачи через сеть
            //BufferedWaveProvider bufferStream;

            //input = new WaveIn();
            ////определяем его формат - частота дискретизации 8000 Гц, ширина сэмпла - 16 бит, 1 канал - моно
            //input.WaveFormat = new WaveFormat(8000, 16, 1);
            ////добавляем код обработки нашего голоса, поступающего на микрофон
            //input.DataAvailable += Voice_Input;
            ////создаем поток для прослушивания входящего звука
            //output = new WaveOut();
            ////создаем поток для буферного потока и определяем у него такой же формат как и потока с микрофона
            //bufferStream = new BufferedWaveProvider(new WaveFormat(8000, 16, 1));
            ////привязываем поток входящего звука к буферному потоку
            //output.Init(bufferStream);


            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        //Обработка нашего голоса
        private void Voice_Input(object sender, WaveInEventArgs e)
        {
            WaveOut output;
            output = new WaveOut();
            BufferedWaveProvider bufferStream;
            bufferStream = new BufferedWaveProvider(new WaveFormat(8000, 16, 1));
            output.Init(bufferStream);

            byte[] data = e.Buffer;
            //получено данных
            int received = e.Buffer.Length;
            //добавляем данные в буфер, откуда output будет воспроизводить звук
            bufferStream.AddSamples(data, 0, received);
            output.Play();



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
