using System;
using System.Collections.Generic;
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
using System.Xml.Serialization;
using Assets;
using UnityEngine;

namespace LevelMake
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static List<GameObject> __list = new List<GameObject>();
        public MainWindow()
        {
            InitializeComponent();
        }
        
        private void opnBtn_Click(object sender, RoutedEventArgs e)
        {
            var ofd = new Microsoft.Win32.OpenFileDialog() { Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|PNG Files (*.png)|*.png" };
            var result = ofd.ShowDialog();
            if (result == false) return;
            pathBox.Text = ofd.FileName;
            loadBtn_Click(sender, e);
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void loadBtn_Click(object sender, RoutedEventArgs e)
        {
            if (pathBox.Text.Trim() != String.Empty)
            {
                BitmapImage __img = new BitmapImage();
                try
                {
                    __img.BeginInit();
                    __img.UriSource = new Uri(pathBox.Text);
                    __img.EndInit();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(" The image does not exist or is not encoded properly \n" + ex.Message.ToString());
                    return;
                }
                loadedImg.Source = __img;
            }            
        }
    }
}
