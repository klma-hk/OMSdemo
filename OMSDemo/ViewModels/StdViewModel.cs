// this view model is demonstrating the use of INotifyPropertyChanged to reduce boilerplate code for WPF MVVM applications
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace WpfApp1.ViewModels
{
    public class StdViewModel : INotifyPropertyChanged
    {
        private OrderViewModel _newOrder = new();

        public ObservableCollection<OrderViewModel> ActiveOrders { get; } = new();

        public OrderViewModel NewOrder
        {
            get => _newOrder;
            set
            {
                if (ReferenceEquals(_newOrder, value))
                {
                    return;
                }

                _newOrder = value;
                OnPropertyChanged();
            }
        }

        public ICommand SubmitOrderCommand { get; }

        public event PropertyChangedEventHandler? PropertyChanged;

        public StdViewModel()
        {
            SubmitOrderCommand = new DelegateCommand(SubmitOrder);
            LoadMockBlotter();
        }

        private void SubmitOrder()
        {
            if (string.IsNullOrEmpty(NewOrder.Symbol) || NewOrder.Quantity <= 0)
            {
                return;
            }

            NewOrder.OrderId = ActiveOrders.Count + 1;
            NewOrder.Status = "Pending Execution";
            ActiveOrders.Add(NewOrder);
            // Actual implementation would send the order to the OMS for execution here
            NewOrder = new OrderViewModel();
        }

        private void LoadMockBlotter()
        {
            // in a real application, this would be loaded from the OMS or database
            ActiveOrders.Add(new OrderViewModel { OrderId = 1, Symbol = "AAPL", Quantity = 150, Price = 175.25, Status = "Fully Executed" });
            ActiveOrders.Add(new OrderViewModel { OrderId = 2, Symbol = "MSFT", Quantity = 50, Price = 420.00, Status = "Working in Market" });
        }

        private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private sealed class DelegateCommand : ICommand
        {
            private readonly Action _execute;

            public DelegateCommand(Action execute)
            {
                _execute = execute;
            }

            public event EventHandler? CanExecuteChanged;

            public bool CanExecute(object? parameter) => true;

            public void Execute(object? parameter) => _execute();
        }
    }
}
