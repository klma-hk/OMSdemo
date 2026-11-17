// this is a custom control that wraps a TextBox and provides additional functionality,
// such as automatically selecting all text when the control gains focus,
// and moving focus to the next control when the Enter key is pressed.
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for OMSTextbox.xaml
    /// </summary>
    public partial class OMSTextbox : UserControl
    {
        public static readonly DependencyProperty TextProperty =
           DependencyProperty.Register(nameof(Text), typeof(string), typeof(OMSTextbox),
               new FrameworkPropertyMetadata(string.Empty, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }

        public OMSTextbox()
        {
            InitializeComponent();
        }

        public bool FocusInput()
        {
            return InnerTextBox.Focus();
        }

        // 1. Enter key moves to the next entry control
        private void InnerTextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                var request = new TraversalRequest(FocusNavigationDirection.Next);
                InnerTextBox.MoveFocus(request);
                e.Handled = true;
            }
        }

        private void InnerTextBox_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            InnerTextBox.SelectAll();
        }

        // 3. Catch mouse clicks so they don't break the 'SelectAll'
        private void InnerTextBox_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (!InnerTextBox.IsKeyboardFocusWithin)
            {
                InnerTextBox.Focus();
                e.Handled = true;
            }
        }
    }
}
