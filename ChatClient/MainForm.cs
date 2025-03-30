using NetMQ;
using NetMQ.Sockets;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatClient
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            this.FormClosing += MainForm_FormClosing; // Gắn sự kiện

        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (pusher != null && subscriber != null)
            {
                pusher.Close();
                pusher.Dispose();

                subscriber.Close();
                subscriber.Dispose();
            }
        }

        SubscriberSocket subscriber;
        PushSocket pusher;

        bool isConnected = false;

        private void ConnectBtn_Click(object sender, EventArgs e)
        {

            subscriber = new SubscriberSocket(">tcp://localhost:5556");
            pusher = new PushSocket(">tcp://localhost:5557");// Gửi tin về server (PUSH)

            if (subscriber != null && pusher != null && !subscriber.IsDisposed && !pusher.IsDisposed)
            {
                isConnected = true;

                subscriber.Subscribe(""); // Nhận tất cả tin nhắn

                pusher.SendFrame($"joined:{UserNameTxtBox.Text}");


                new Thread(() =>
                {
                    while (isConnected)
                    {
                        //receivedMessage = "message:<user>:<message_body>"                   
                        
                     
                        string receivedMessage = subscriber.ReceiveFrameString(); // Nhận tin nhắn mới

                        if(receivedMessage.Contains("message"))
                        {
                            string user = receivedMessage.Split(':')[1];

                            // Kiểm tra đó là tin nhắn từ người khác 
                            if (user != UserNameTxtBox.Text)
                            {
                                messageChatBox.Invoke(new Action(() =>
                                {
                                    messageChatBox.Text += $"\n{receivedMessage}";
                                }));
                            }
                        }
                     

                    }
                }).Start();
            }
            else
            {
                MessageBox.Show("Kết nối thất bại");
            }


        }

        private void DisconnectBtn_Click(object sender, EventArgs e)
        {
            isConnected = false;

            if (subscriber != null && pusher != null)
            {
                pusher.SendFrame($"left:{UserNameTxtBox.Text}");
                //subscriber.Close();
                //pusher.Close();
                subscriber.Dispose();
                pusher.Dispose();
               
            }
        }

        private void SendBtn_Click(object sender, EventArgs e)
        {

            if (!(pusher == null))
            {
                string message = $"{UserNameTxtBox.Text}:{messageTxtBox.Text}";
                messageChatBox.Invoke(new Action(() =>
                {
                    messageChatBox.Text += $"\n{message}";
                }));
                pusher.SendFrame(message);
            }
            else
            {
                MessageBox.Show("Kết nối thất bại");
            }

        }

    }
}
