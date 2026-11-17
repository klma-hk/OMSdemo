using System.Windows;
using System.Windows.Controls;
using WpfApp1.ViewModels;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for OMSWindows.xaml
    /// </summary>
    public partial class OMSWindows : Window
    {
        public OMSWindows()
        {
            InitializeComponent();
            ViewModelSelector.SelectionChanged += ViewModelSelector_SelectionChanged;
            DataContext = new MainViewModel();
            // the following code is allowed user just using the keyboard to input 
            Loaded += (s, e) =>
            {
                Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.ContextIdle,
                                       new Action(() => PrdTicBox.FocusInput()));
            };
           // this is UI behavior, so it should be in the view, not in the view model. The view model should not know about the UI elements.
        }

        // the following code is allowed user just using the keyboard to input 
        private void SubmitOrderButton_Click(object sender, RoutedEventArgs e)
        {
            Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.ContextIdle,
                                   new Action(() => PrdTicBox.FocusInput()));
            // this is UI behavior, so it should be in the view, not in the view model. The view model should not know about the UI elements.
        }

        private void ViewModelSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataContext = ViewModelSelector.SelectedIndex switch
            {
                0 => new MainViewModel(),
                1 => new StdViewModel(),
                _ => throw new InvalidOperationException("Select a valid view model.")
            };
            // just for demonstration purposes, you can remove this if you want to keep the same view model for all views.
        }
    }
}
