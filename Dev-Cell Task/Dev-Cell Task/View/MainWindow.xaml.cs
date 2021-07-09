using Dev_Cell_Task.View;
using Dev_Cell_Task.ViewModel;
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

namespace Dev_Cell_Task
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            pages_button.Visibility = Visibility.Hidden;
            close_button.IsEnabled = false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainPageViewModel.IntialoizeListener();
            pages_button.Visibility = Visibility.Visible;
            close_button.IsEnabled = true;
            start_button.IsEnabled = false;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainPageViewModel.CloseListener();
            pages_button.Visibility = Visibility.Hidden;
            close_button.IsEnabled = false;
            start_button.IsEnabled = true;
        }

        private void pages_button_Click(object sender, RoutedEventArgs e)
        {
            var page1 = new Page1();
            page1.Show();
        }
    }
}
