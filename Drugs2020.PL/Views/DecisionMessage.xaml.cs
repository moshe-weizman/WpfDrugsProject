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
    /// Interaction logic for DecisionMessage.xaml
    /// </summary>
    public partial class DecisionMessage : UserControl
    {
        public DecisionMessage()
        {
            InitializeComponent();
        }
        
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        public static readonly DependencyProperty DecisionCommandProperty =
         DependencyProperty.Register("DecisionCommand", typeof(ICommand), typeof(DecisionMessage), new
            PropertyMetadata(default(ICommand), new PropertyChangedCallback(OnDecisionCommandChanged)));

        public ICommand DecisionCommand
        {
            get { return GetValue(DecisionCommandProperty) as ICommand; }
            set { SetValue(DecisionCommandProperty, value); }
        }

        private static void OnDecisionCommandChanged(DependencyObject d,
           DependencyPropertyChangedEventArgs e)
        {
            DecisionMessage DecisionMessageControl = d as DecisionMessage;
            DecisionMessageControl.OnDecisionCommandChanged(e);
        }

        private void OnDecisionCommandChanged(DependencyPropertyChangedEventArgs e)
        {
            YesButton.Command = e.NewValue as ICommand;
            NoButton.Command = e.NewValue as ICommand;
        }
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        public static readonly DependencyProperty DecisionMessageVisibilityProperty =
                DependencyProperty.Register("DecisionMessageVisibility", typeof(Visibility), typeof(DecisionMessage), new
                   PropertyMetadata(default(Visibility), new PropertyChangedCallback(OnDecisionMessageVisibilityChanged)));

        public Visibility DecisionMessageVisibility
        {
            get { return (Visibility)GetValue(DecisionMessageVisibilityProperty); }
            set { SetValue(DecisionMessageVisibilityProperty, value); }
        }

        private static void OnDecisionMessageVisibilityChanged(DependencyObject d,
           DependencyPropertyChangedEventArgs e)
        {
            DecisionMessage DecisionMessageControl = d as DecisionMessage;
            DecisionMessageControl.OnDecisionMessageVisibilityChanged(e);
        }

        private void OnDecisionMessageVisibilityChanged(DependencyPropertyChangedEventArgs e)
        {
            switch (e.NewValue)
            {
                case Visibility.Visible:
                    MainGrid.Visibility = Visibility.Visible;
                    break;
                case Visibility.Collapsed:
                    MainGrid.Visibility = Visibility.Collapsed;
                    break;
            }
        }
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        public static readonly DependencyProperty MessageProperty =
                       DependencyProperty.Register("Message", typeof(string), typeof(DecisionMessage), new
                          PropertyMetadata("", new PropertyChangedCallback(OnMessageChanged)));

        public string Message
        {
            get { return GetValue(MessageProperty).ToString(); }
            set { SetValue(MessageProperty, value); }
        }

        private static void OnMessageChanged(DependencyObject d,
           DependencyPropertyChangedEventArgs e)
        {
            DecisionMessage DecisionMessageControl = d as DecisionMessage;
            DecisionMessageControl.OnMessageChanged(e);
        }

        private void OnMessageChanged(DependencyPropertyChangedEventArgs e)
        {
            MessageTextBlock.Text = e.NewValue.ToString();
        }
    }
}
