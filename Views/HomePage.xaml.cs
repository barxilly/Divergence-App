using Divergence_App.ViewModels;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Navigation;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Divergence_App.Views;

public sealed partial class HomePage : Page
{
    public HomeViewModel ViewModel
    {
        get;
    }

    public HomePage()
    {
        ViewModel = App.GetService<HomeViewModel>();
        InitializeComponent();
        S1.Click += S1_click;
        Kat.Click += Kat_click;
    }

    private void S1_click(object sender, RoutedEventArgs e)
    {
        System.Diagnostics.Process.Start("cmd", "/c start https://drive.usercontent.google.com/download?id=1LIxNJVkE6x7FCBAJHTKxb7Bq4IjC3fKi&export=download&authuser=0");
    }

    private void Kat_click(object sender, RoutedEventArgs e)
    {
        // Go to Members Page
       //  Frame.Navigate(typeof(MembersPage));
    }
}
