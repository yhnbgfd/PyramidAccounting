﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PA.View.ResourceDictionarys.MessageBox
{
    /// <summary>
    /// Interaction logic for MessageBox_Del.xaml
    /// </summary>
    public partial class MessageBoxDel : Window
    {
        public MessageBoxDel()
        {
            InitializeComponent();
        }

        public new string Title
        {
            get { return this.lblTitle.Text; }
            set { this.lblTitle.Text = value; }
        }

        public string Message
        {
            get { return this.lblMsg.Text; }
            set { this.lblMsg.Text = value; }
        }
        /// <summary>
        /// 静态方法 模拟MESSAGEBOX.Show方法
        /// </summary>
        /// <param name="title">标题</param>
        /// <param name="msg">消息</param>
        /// <returns></returns>
        public static bool? Show(string title, string msg)
        {

            var msgBox = new MessageBoxDel();
            msgBox.Title = title;
            msgBox.Message = msg;
            return msgBox.ShowDialog();
        }
        private void Yes_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DialogResult = true;
            this.Close();
        }

        private void No_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }

        private void main_Loaded(object sender, RoutedEventArgs e)
        {
            this.PreviewKeyDown += new KeyEventHandler(main_PreviewKeyDown);
        }

        private void main_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Y||e.Key==Key.Enter)
            {
                Yes_MouseLeftButtonDown(this, null);
            }
            if (e.Key == Key.N)
            {
                No_MouseLeftButtonDown(this, null);
            }
        }
    }
}
