﻿using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Text;
using System.Xml.Serialization;
using Finance.Model;

namespace Finance.ViewModel
{
    public class MainVM : INotifyPropertyChanged
    {
        public Posts Blog
        {
            get;
            set;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public MainVM()
        {
            ReadRss();
        }

        public void ReadRss()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Posts));

            using (WebClient client = new WebClient())
            {
                // string xml = Encoding.Default.GetString(client.DownloadData("https://www.finzen.mx/blog-feed.xml"));
                // string xml = Encoding.Default.GetString(client.DownloadData("https://www.nasa.gov/rss/dyn/educationnews.rss"));
                string xml = Encoding.Default.GetString(client.DownloadData("https://www.theguardian.com/uk/rss"));

                using (Stream reader = new MemoryStream(Encoding.UTF8.GetBytes(xml)))
                {
                    Blog = (Posts)serializer.Deserialize(reader);
                }
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
