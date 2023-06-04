using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace PriceSumDemo.ViewModels;

public partial class CartViewModel : ObservableObject
{
    public CartViewModel()
    {
        CartItems.CollectionChanged += (_, _) =>
        {
            PriceSum = CartItems.Sum(x => x.Price);
            OnPropertyChanged(nameof(PriceSum));
        };

        CartItems.Add(new CartItemViewModel
        {
            Name = "Burger",
            Price = 399
        });
        CartItems.Add(new CartItemViewModel
        {
            Name = "Pizza",
            Price = 899
        });
    }

    public ObservableCollection<CartItemViewModel> CartItems { get; } = new();

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(PriceSum))]
    [NotifyCanExecuteChangedFor(nameof(RemoveSelectedCartItemCommand))]
    private CartItemViewModel? _selectedCartItem;

    public int PriceSum { get; private set; }

    public bool IsCartItemSelected => SelectedCartItem != null;

    [RelayCommand]
    private void AddRandomItem()
    {
        CartItems.Add(new CartItemViewModel
        {
            Name = Random.Shared.NextInt64().ToString(),
            Price = Random.Shared.Next(399, 5999)
        });
    }

    [RelayCommand(CanExecute = nameof(IsCartItemSelected))]
    private void RemoveSelectedCartItem()
    {
        CartItems.Remove(SelectedCartItem!);
    }
}