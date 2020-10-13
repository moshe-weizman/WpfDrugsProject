using Drugs2020.PL.ViewModels;
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

namespace Drugs2020.PL.Views
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : UserControl
    {

        private LogInViewModel viewModel;
        public int PhysicianId { get; set; }
        public string Password { get; set; }
        public Login()
        {
            InitializeComponent();

            viewModel = new LogInViewModel();
            DataContext = viewModel;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            PhysicianId = int.Parse(((TextBox)sender).Text);
        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            Password = ((TextBox)sender).Text;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            //}

            //private void Button_Click_1(object sender, RoutedEventArgs e)
            //{

            //}
        }
    }
}
