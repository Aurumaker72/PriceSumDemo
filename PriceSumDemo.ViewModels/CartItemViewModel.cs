﻿using CommunityToolkit.Mvvm.ComponentModel;

namespace PriceSumDemo.ViewModels;

public class CartItemViewModel : ObservableObject
{
    public string Name { get; init; }
    public int Price { get; init; }
}