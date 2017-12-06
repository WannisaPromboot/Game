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

namespace GAME
{
    /// <summary>
    /// Interaction logic for result.xaml
    /// </summary>
    public partial class result : Page
    {
        public result()
        {
            InitializeComponent();
        }
        public static string textResult = "";

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            txtResult.Content = textResult;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("home.xaml", UriKind.RelativeOrAbsolute));
        }
    }
}
