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
using NetMQ;
using NetMQ.Sockets;

namespace ChatServer
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        PublisherSocket publisher;
        PullSocket puller;

        bool isConnected = false;

        List<string> usersOnlineList = new List<string>();

        private void openConnection_Click(object sender, EventArgs e)
        {
            isConnected = true;

            publisher = new PublisherSocket("@tcp://*:5556");
            puller = new PullSocket("@tcp://*:5557"); // Pull nhận tin từ client

            new Thread(() =>
            {
                while (isConnected)
                {
                    //receivedMessage = "message:<user>:<message_body>"   //Message type = message
                    //receivedMessage = "joined:<user>"                   // Message type = joined
                    //receivedMessage = "left:<user>"                      // Message type =  left


                    string receivedMessage = puller.ReceiveFrameString(); // Nhận tin nhắn từ bất kỳ client
                    if (receivedMessage.Contains("joined"))
                    {
                        usersOnline.Invoke(new Action(() =>
                        {
                            usersOnline.Items.Add(receivedMessage.Split(':')[1]);
                            usersOnline.Refresh();

                        }));
                    }

                    if (receivedMessage.Contains("left"))
                    {
                        string username = receivedMessage.Split(':')[1];

                        usersOnline.Invoke(new Action(() =>
                        {
                            // Tìm ListViewItem cần xóa
                            usersOnline.Items.Remove(username);
                            usersOnline.Refresh();
                          
                        }));

                    }

                    publisher.SendFrame(receivedMessage); // Phân Phát tin nhắn đến các client


                }
            }).Start();

        }

        private void closeConnection_Click(object sender, EventArgs e)
        {
            //publisher.Close();
            //puller.Close();
            isConnected = false;
            publisher.Dispose();
            puller.Dispose();

        }
    }
}
