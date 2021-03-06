﻿using System;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;

namespace Client
{
    public partial class Login : Form
    {
        TcpClient client;
        private NetworkStream nstream;

        public Login()
        {
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
        }

        public NetworkStream nStream
        {
            get
            {
                return nstream;
            }
        }

        public string Username
        {
            get
            {
                return textBox1.Text;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Connect_Login();
        }

        private void Connect_Login()
        {
            client = new TcpClient();
            try
            {
                client.Connect(IPAddress.Parse("127.0.0.1"), 5000);
                if (client.Connected)
                {
                    nstream = client.GetStream();
                    DialogResult = DialogResult.OK;
                }
            }
            catch (Exception ex)
            {
                DialogResult ConfirmResult = MessageBox.Show("Server not available !\n" + ex.Message,
                                        "Server disconnected",
                                        MessageBoxButtons.RetryCancel);
                if (ConfirmResult == DialogResult.Retry)
                {
                    Connect_Login();
                }
                else
                {
                    DialogResult = DialogResult.Cancel;
                }
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }


        private void Exit_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }



        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
