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

            userOnline.Items.Add("all");
            userOnline.Refresh();
            userOnline.SelectedIndex = 0;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (pusher != null && subscriber != null)
            {
                pusher.Dispose();
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
                        //receivedMessage = "message:<sender>:<receiver>:<message_body>"                   


                        string receivedMessage = subscriber.ReceiveFrameString(); // Nhận tin nhắn mới


                        if (receivedMessage.Contains("message"))
                        {
                            string userSender = receivedMessage.Split(':')[1];
                            string userReceiver = receivedMessage.Split(':')[2];

                            string body = receivedMessage.Split(':')[3];

                            // Kiểm tra đó là tin nhắn từ người khác gui cho minh
                            if (userSender != UserNameTxtBox.Text && userReceiver == UserNameTxtBox.Text || userReceiver == "all")
                            {
                                messageChatBox.Invoke(new Action(() =>
                                {
                                    messageChatBox.Text += $"\n{userSender}:{body}";
                                }));
                            }
                        }
                        if (receivedMessage.Contains("list:"))
                        {
                            List<string> userList = receivedMessage.Split(':')[1].Split('|').ToList();

                            userOnline.Invoke(new Action(() =>
                            {
                                userOnline.Items.Clear();
                                userOnline.Items.Add("all");
                                userOnline.Refresh();
                                userOnline.SelectedIndex = 0;

                                foreach (string user in userList)
                                {
                                    if (user != UserNameTxtBox.Text)
                                    {

                                        userOnline.Items.Add(user);
                                        userOnline.Refresh();


                                    }
                                }
                            }));

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
            //sendingMessage = "message:<sender>:<receiver>:<message_body>"                   


            if (!(pusher == null))
            {
                string message = $"message:{UserNameTxtBox.Text}:{userOnline.SelectedItem}:{messageTxtBox.Text}";
                messageChatBox.Invoke(new Action(() =>
                {
                    messageChatBox.Text += $"\n{UserNameTxtBox.Text}:{messageTxtBox.Text}";
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
