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

namespace WpfApp20
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {

        string[] files;
        List<string> pictures = new List<string>();
        int index = 0;
        string n;
        string d;
        string a;
        public MainWindow()
        {
            InitializeComponent();
            files = Directory.GetFiles("C:\\1");
            for (int i = 0; i < files.Length; i++)
            {
                if (files[i].Contains(".jpg") || files[i].Contains(".png"))
                    pictures.Add(files[i]);
            }
            n = name.Content.ToString();
            d = date.Content.ToString();
            a = author.Content.ToString();
            img.Source = new BitmapImage(new Uri(pictures[index]));
            name.Content = n + pictures[index].Substring(pictures[index].LastIndexOf('\\') + 1);
            date.Content = d + File.GetCreationTime(pictures[index]).ToShortDateString();
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            if(index < pictures.Count - 1)
                index++;
            img.Source = new BitmapImage(new Uri(pictures[index]));
            name.Content = n + pictures[index].Substring(pictures[index].LastIndexOf('\\') + 1);
            date.Content = d + File.GetCreationTime(pictures[index]).ToShortDateString();
        }

        private void Prev_Click(object sender, RoutedEventArgs e)
        {
            if (index > 0)
                index--;
            img.Source = new BitmapImage(new Uri(pictures[index]));
            name.Content = n + pictures[index].Substring(pictures[index].LastIndexOf('\\') + 1);
            date.Content = d + File.GetCreationTime(pictures[index]).ToShortDateString();
        }

        private void First_Click(object sender, RoutedEventArgs e)
        {
            index = 0;
            img.Source = new BitmapImage(new Uri(pictures[index]));
            name.Content = n + pictures[index].Substring(pictures[index].LastIndexOf('\\') + 1);
            date.Content = d + File.GetCreationTime(pictures[index]).ToShortDateString();
        }

        private void Last_Click(object sender, RoutedEventArgs e)
        {
            index = pictures.Count - 1;
            img.Source = new BitmapImage(new Uri(pictures[index]));
            name.Content = n + pictures[index].Substring(pictures[index].LastIndexOf('\\') + 1);
            date.Content = d + File.GetCreationTime(pictures[index]).ToShortDateString();
        }
    }
}
