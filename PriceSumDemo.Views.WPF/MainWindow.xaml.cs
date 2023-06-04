using System.Windows;
using PriceSumDemo.ViewModels;

namespace PriceSumDemo.Views.WPF;

/// <summary>
///     Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        DataContext = new CartViewModel();
    }
}