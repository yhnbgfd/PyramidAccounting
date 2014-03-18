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
using PA.Model.ComboBox;
using PA.Helper.DataBase;
using PA.Helper.DataDefind;
using PA.ViewModel;
using PA.View.Windows;

namespace PA
{
    public partial class Win_SignIn : Window
    {
        public Win_SignIn()
        {
            InitializeComponent();
            new PA.Helper.DataBase.StartUpInit().Init();
            InitComboBox();
        }
        private void InitComboBox()
        {
            ComboBox_账套.ItemsSource = new ComboBox_Common().GetComboBox_账套();
            ComboBox_账套.DisplayMemberPath = "账套名称";
            ComboBox_账套.SelectedValuePath = "ID";
            ComboBox_账套.Text = new StartUpInit().LoadBookName();
        }
        private void Button_Min_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = System.Windows.WindowState.Minimized;
        }

        private void Button_Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_登陆_Click(object sender, RoutedEventArgs e)
        {
            CommonInfo.账薄号 = ComboBox_账套.SelectedValue.ToString();
            string UserName = TextBox_登陆用户名.Text.Trim();
            string Password = Secure.TranslatePassword(PasswordBox_登陆密码.SecurePassword);
            if (new ViewModel_用户().ValidateAccount(UserName,Password))
            {
                if (ComboBox_账套.SelectedValue.ToString().Equals("0"))
                {
                    Win_账套页面 w = new Win_账套页面();
                    w.Show();
                }
                else
                {
                    MainWindow mw = new MainWindow();
                    mw.Show();
                }
                this.Close();
            }
            else
            {
                TextBlock_登陆警告信息.Text = "账号或密码错误。";
            }

        }

    }
}