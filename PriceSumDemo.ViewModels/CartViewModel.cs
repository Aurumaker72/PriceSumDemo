using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceSumDemo.ViewModels
{
    public partial class CartViewModel : ObservableObject
    {
        public ObservableCollection<CartItemViewModel> CartItems { get; } = new();
        public int PriceSum { get; private set; }

        public CartViewModel()
        {
            CartItems.CollectionChanged += (o, e) =>
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
    }
}
