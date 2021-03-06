﻿using Microsoft.ProjectOxford.Vision;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ComputerVision
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            DisableAllButtons();
            try
            {
                Cursor = Cursors.AppStarting;
                var client = new VisionServiceClient("");
                using (var file = new FileStream("Pictures\\surface2.jpg", FileMode.Open))
                {
                    var result = await client.DescribeAsync(file);

                    txtResults.Text = JsonConvert.SerializeObject(result, Formatting.Indented);
                }
                Cursor = Cursors.Arrow;
            }
            finally
            {
                EnableAllButtons();
            }
        }

        private async void LakeButton_Click(object sender, RoutedEventArgs e)
        {
            DisableAllButtons();
            try
            {
                Cursor = Cursors.AppStarting;
                var client = new VisionServiceClient("");
                using (var file = new FileStream("Pictures\\lake.jpg", FileMode.Open))
                {
                    var result = await client.DescribeAsync(file);

                    txtResults.Text = JsonConvert.SerializeObject(result, Formatting.Indented);
                }
                Cursor = Cursors.Arrow;
            }
            finally
            {
                EnableAllButtons();
            }
        }

        private async void GardenButton_Click(object sender, RoutedEventArgs e)
        {
            DisableAllButtons();
            try
            {
                Cursor = Cursors.AppStarting;
                var client = new VisionServiceClient("");
                using (var file = new FileStream("Pictures\\garden.jpg", FileMode.Open))
                {
                    var result = await client.GetTagsAsync(file);

                    txtResults.Text = JsonConvert.SerializeObject(result, Formatting.Indented);
                }
                Cursor = Cursors.Arrow;
            }
            finally
            {
                EnableAllButtons();
            }
        }

        void DisableAllButtons()
        {
            gardenBtn.IsEnabled = false;
            lakeBtn.IsEnabled = false;
            surfaceBtn.IsEnabled = false;
        }

        void EnableAllButtons()
        {
            gardenBtn.IsEnabled = true;
            lakeBtn.IsEnabled = true;
            surfaceBtn.IsEnabled = true;
        }
    }
}
