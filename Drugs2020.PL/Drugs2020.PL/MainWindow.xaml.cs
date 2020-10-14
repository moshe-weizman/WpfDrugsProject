using System.Windows;
using Drugs2020.BLL;

namespace Drugs2020.PL
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SaveAndRetrive sAr;
        public MainWindow()
        {
            sAr = new SaveAndRetrive();
            InitializeComponent();
        }

        public void Button_Click(object sender, RoutedEventArgs e)
        {
            sAr.Save();
           // sAr.SaveImage();
        }
    }
}
