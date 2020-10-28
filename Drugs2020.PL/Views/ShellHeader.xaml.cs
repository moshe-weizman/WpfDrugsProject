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
    /// Interaction logic for ShellHeader.xaml
    /// </summary>
    public partial class ShellHeader : UserControl
    {
        public ShellHeader()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty UserNameProperty =
         DependencyProperty.Register("UserName", typeof(string), typeof(ShellHeader), new
            PropertyMetadata("", new PropertyChangedCallback(OnUserNameChanged)));

        public string UserName
        {
            get { return (string)GetValue(UserNameProperty); }
            set { SetValue(UserNameProperty, value); }
        }

        private static void OnUserNameChanged(DependencyObject d,
           DependencyPropertyChangedEventArgs e)
        {
            ShellHeader ShellHeaderControl = d as ShellHeader;
            ShellHeaderControl.OnUserNameChanged(e);
        }

        private void OnUserNameChanged(DependencyPropertyChangedEventArgs e)
        {
            UserNameTextBlock.Text = e.NewValue.ToString();
        }
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        public static readonly DependencyProperty SignOutCommandProperty =
         DependencyProperty.Register("SignOutCommand", typeof(ICommand), typeof(ShellHeader), new
            PropertyMetadata(default(ICommand), new PropertyChangedCallback(OnSignOutCommandChanged)));

        public ICommand SignOutCommand
        {
            get { return GetValue(SignOutCommandProperty) as ICommand; }
            set { SetValue(SignOutCommandProperty, value); }
        }

        private static void OnSignOutCommandChanged(DependencyObject d,
           DependencyPropertyChangedEventArgs e)
        {
            ShellHeader ShellHeaderControl = d as ShellHeader;
            ShellHeaderControl.OnSignOutCommandChanged(e);
        }

        private void OnSignOutCommandChanged(DependencyPropertyChangedEventArgs e)
        {
            SignOutButton.Command = e.NewValue as ICommand;
        }
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
 
        public static readonly DependencyProperty ProgressBarVisibilityProperty =
                DependencyProperty.Register("ProgressBarVisibility", typeof(Visibility), typeof(ShellHeader), new
                   PropertyMetadata(default(Visibility), new PropertyChangedCallback(OnProgressBarVisibilityChanged)));

        public Visibility ProgressBarVisibility
        {
            get { return (Visibility)GetValue(ProgressBarVisibilityProperty); }
            set { SetValue(ProgressBarVisibilityProperty, value); }
        }

        private static void OnProgressBarVisibilityChanged(DependencyObject d,
           DependencyPropertyChangedEventArgs e)
        {
            ShellHeader ShellHeaderControl = d as ShellHeader;
            ShellHeaderControl.OnProgressBarVisibilityChanged(e);
        }

        private void OnProgressBarVisibilityChanged(DependencyPropertyChangedEventArgs e)
        {
            switch (e.NewValue)
            {
                case Visibility.Visible:
                    ProgressBar.Visibility = Visibility.Visible;
                    break;
                case Visibility.Collapsed:
                    ProgressBar.Visibility = Visibility.Collapsed;
                    break;
            }
        }
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        public static readonly DependencyProperty MessageProperty =
                       DependencyProperty.Register("Message", typeof(string), typeof(ShellHeader), new
                          PropertyMetadata("", new PropertyChangedCallback(OnMessageChanged)));

        public string Message
        {
            get { return GetValue(MessageProperty).ToString(); }
            set { SetValue(MessageProperty, value); }
        }

        private static void OnMessageChanged(DependencyObject d,
           DependencyPropertyChangedEventArgs e)
        {
            ShellHeader ShellHeaderControl = d as ShellHeader;
            ShellHeaderControl.OnMessageChanged(e);
        }

        private void OnMessageChanged(DependencyPropertyChangedEventArgs e)
        {
            MessageTextBlock.Text = e.NewValue.ToString();
        }
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        public static readonly DependencyProperty SearchInputProperty =
                               DependencyProperty.Register("SearchInput", typeof(string), typeof(ShellHeader), new
                                  PropertyMetadata("", new PropertyChangedCallback(OnSearchInputChanged)));

        public string SearchInput
        {
            get { return GetValue(SearchInputProperty).ToString(); }
            set { SetValue(SearchInputProperty, value); }
        }

        private static void OnSearchInputChanged(DependencyObject d,
           DependencyPropertyChangedEventArgs e)
        {
            ShellHeader ShellHeaderControl = d as ShellHeader;
            ShellHeaderControl.OnSearchInputChanged(e);
        }

        private void OnSearchInputChanged(DependencyPropertyChangedEventArgs e)
        {
            SearchTextBox.Text = e.NewValue.ToString();
        }
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        public static readonly DependencyProperty SearchCommandProperty =
                                       DependencyProperty.Register("SearchCommand", typeof(ICommand), typeof(ShellHeader), new
                                          PropertyMetadata(default(ICommand), new PropertyChangedCallback(OnSearchCommandChanged)));

        public ICommand SearchCommand
        {
            get { return GetValue(SearchCommandProperty) as ICommand; }
            set { SetValue(SearchCommandProperty, value); }
        }

        private static void OnSearchCommandChanged(DependencyObject d,
           DependencyPropertyChangedEventArgs e)
        {
            ShellHeader ShellHeaderControl = d as ShellHeader;
            ShellHeaderControl.OnSearchCommandChanged(e);
        }

        private void OnSearchCommandChanged(DependencyPropertyChangedEventArgs e)
        {
            SearchButton.Command = e.NewValue as ICommand;
        }
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        public static readonly DependencyProperty SearchControlsVisibilityProperty =
         DependencyProperty.Register("SearchControlsVisibility", typeof(Visibility), typeof(ShellHeader), new
            PropertyMetadata(default(Visibility), new PropertyChangedCallback(OnSearchControlsVisibilityChanged)));

        public Visibility SearchControlsVisibility
        {
            get { return (Visibility)GetValue(SearchControlsVisibilityProperty); }
            set { SetValue(SearchControlsVisibilityProperty, value); }
        }

        private static void OnSearchControlsVisibilityChanged(DependencyObject d,
           DependencyPropertyChangedEventArgs e)
        {
            ShellHeader ShellHeaderControl = d as ShellHeader;
            ShellHeaderControl.OnSearchControlsVisibilityChanged(e);
        }

        private void OnSearchControlsVisibilityChanged(DependencyPropertyChangedEventArgs e)
        {
            SearchTextBox.Visibility = (Visibility)e.NewValue;
            SearchButton.Visibility = (Visibility)e.NewValue;
        }
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~



    }
}
