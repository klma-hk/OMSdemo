using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

// this view model is demonstrating the use of CommunityToolkit.Mvvm to reduce boilerplate code for WPF MVVM applications
namespace WpfApp1
{
    public partial class MainViewModel : ObservableObject
    {
        public ObservableCollection<OrderViewModel> ActiveOrders { get; } = new();

        // Generates public property 'NewOrder' and triggers UI updates automatically
        [ObservableProperty]
        private OrderViewModel _newOrder = new();

        public MainViewModel()
        {
            LoadMockBlotter();
        }

        // Generates an ICommand named 'SubmitOrderCommand' bound automatically in XAML
        [RelayCommand]
        private void SubmitOrder()
        {
            if (string.IsNullOrEmpty(NewOrder.Symbol) || NewOrder.Quantity <= 0) return;

            // Finalize order details
            NewOrder.OrderId = ActiveOrders.Count + 1;
            NewOrder.Status = "Pending Execution";

            // Push to observable tracker grid
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
    }
}
