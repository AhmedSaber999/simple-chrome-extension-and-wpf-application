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
using System.Windows.Shapes;

namespace Dev_Cell_Task.View
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class Page1 : Window
    {
        public Page1()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var page2 = new Page2
            {
                Top = 100,
                Left = 300
            };
            page2.Show();
            this.Close();
        }

        private void Main_Screen_btn_Click(object sender, RoutedEventArgs e)
        {
            var main_screen = new MainWindow(true)
            {
                Top = 100,
                Left = 300
            };
            main_screen.Show();
            this.Close();
        }
    }
}
