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
    /// Interaction logic for setting.xaml
    /// </summary>
    public partial class setting3 : Page
    {
        public setting3()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged3(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click3(object sender, RoutedEventArgs e)
        {
            display.name = txtName.Text;
            this.NavigationService.Navigate(new Uri("display3.xaml", UriKind.RelativeOrAbsolute));
        }
    }
}
