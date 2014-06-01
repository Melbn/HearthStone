﻿using System;
using System.Threading;
using System.Windows.Forms;
namespace 火炉服务器
{
    public partial class ServerConfig : Form
    {
        public ServerConfig()
        {
            InitializeComponent();
        }
        Thread ServerThread; 
        /// <summary>
        /// 启动服务器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStart_Click(object sender, EventArgs e)
        {
            Card.CardUtility.Init(txtCardPath.Text);
            btnStart.Enabled = false;
            btnStop.Enabled = true;
            ServerThread = new Thread(Card.Server.ServerResponse.StartServer);
            ServerThread.IsBackground = true;
            ServerThread.Start();
        }
        /// <summary>
        /// 终止线程
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStop_Click(object sender, EventArgs e)
        {
            ServerThread.Abort();
            ServerThread = null;
            GC.Collect();
        }

        private void btnPickCard_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog cardPath = new FolderBrowserDialog();
            if (cardPath.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtCardPath.Text = cardPath.SelectedPath;
            }
        }

        private void ServerConfig_Load(object sender, EventArgs e)
        {
            //DEBUG
            txtCardPath.Text = @"C:\炉石Git\CardHelper\CardXML";
        }
    }
}
