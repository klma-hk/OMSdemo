using CommunityToolkit.Mvvm.ComponentModel;

namespace WpfApp1
{
    public partial class OrderViewModel : ObservableObject
    {
        [ObservableProperty]
        private int _orderId;

        [ObservableProperty]
        private string _symbol = string.Empty;

        [ObservableProperty]
        private int _quantity;

        [ObservableProperty]
        private double _price;

        [ObservableProperty]
        private string _status = "Draft";
    }
}
