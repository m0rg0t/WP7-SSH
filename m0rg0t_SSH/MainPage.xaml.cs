using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using System.IO;
using System.Xml;
using System.Threading; 

namespace m0rg0t_SSH
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }

        // Load data for the ViewModel Items
        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
        }

        private void PivotItem_BindingValidationError(object sender, ValidationErrorEventArgs e)
        {
        }

        private void Sendcommand_Click(object sender, RoutedEventArgs e)
        {
            this.CommandOutput.Text += this.Commandline.Text + "\r\n";
            WebClient web = new WebClient();
            web.DownloadStringAsync(new Uri("http://m0rg0t.com/connect?message=" + this.Commandline.Text));
            web.DownloadStringCompleted += new DownloadStringCompletedEventHandler(web_DownloadStringCompleted);
        }

        string GetDataFromXML(string type, DownloadStringCompletedEventArgs e)
        {
            string data = "";
            XmlReader r = XmlReader.Create(new MemoryStream(System.Text.UnicodeEncoding.UTF8.GetBytes(e.Result)));
            while (r.ReadToFollowing(type))
            {
                data = data + r.ReadElementContentAsString();
            };
            r.Close();
            return data;
        }

        void web_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            lock (this)
            {
                try
                {
                    string s = e.Result;
                    this.CommandOutput.Text = GetDataFromXML("message_text",e) + "\n";
                }
                catch (System.Net.WebException)
                {
                    MessageBox.Show("Can't get data about hero, sorry");
                }
            }
        }

    }
}