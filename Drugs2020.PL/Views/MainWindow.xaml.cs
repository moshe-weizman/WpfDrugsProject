using Drugs2020.PL.ViewModels;
using System.Windows;

namespace Drugs2020.PL.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainWidowViewModel viewModel;    
        public MainWindow()
        {
            InitializeComponent();
            viewModel = new MainWidowViewModel();
            this.DataContext = viewModel; 
        }
    }
}
