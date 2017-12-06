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
using System.Windows.Threading;

namespace GAME
{
    /// <summary>
    /// Interaction logic for home.xaml
    /// </summary>
    public partial class home : Page
    {
        public home()
        {
            InitializeComponent();
        }

        DispatcherTimer timer = new DispatcherTimer();
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            
            timer.Tick += new EventHandler(dispatTick);
            timer.Interval = new TimeSpan(0, 0, 0, 0, 100);
            timer.Start();
        }
        int status = 1;

        public object Player { get; private set; }

        private void dispatTick(object sender, EventArgs e)
        {
         //   string temp = "";
            

            //ยืนอยู่เฉยๆ แต่ขยับ
         //   if (status == 1)
         //   {
         //       Player.Source = new BitmapImage(new Uri(@"\res\" + temp + "2.png", UriKind.Relative));
         //       status = 2;
         //   }
         //   else if (status == 2)
         //   {
         //       Player.Source = new BitmapImage(new Uri(@"\res\" + temp + "3.png", UriKind.Relative));
         //       status = 3;
         //   }
         //   else if (status == 3)
         //   {
         //       Player.Source = new BitmapImage(new Uri(@"\res\" + temp + "4.png", UriKind.Relative));
          //      status = 4;
         //   }
        //    else if (status == 4)
         //   {
         //       Player.Source = new BitmapImage(new Uri(@"\res\" + temp + "1.png", UriKind.Relative));
         //       status = 1;
          //  }
        }

        private void homebt1_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("display.xaml", UriKind.RelativeOrAbsolute));
            timer.Stop();
        }

        private void homebt2_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("setting.xaml", UriKind.RelativeOrAbsolute));
            timer.Stop();
        }

        private void homebt3_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("setting.xaml", UriKind.RelativeOrAbsolute));
            timer.Stop();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("setting2.xaml", UriKind.RelativeOrAbsolute));
            timer.Stop();
        }
         
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("setting3.xaml", UriKind.RelativeOrAbsolute));
         //   timer.Stop();
        }

        
    }
}
