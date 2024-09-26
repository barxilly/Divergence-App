using Divergence_App.ViewModels;

using Microsoft.UI.Xaml.Controls;

namespace Divergence_App.Views;

public sealed partial class LinksPage : Page
{
    public LinksViewModel ViewModel
    {
        get;
    }

    public LinksPage()
    {
        ViewModel = App.GetService<LinksViewModel>();
        InitializeComponent();
    }
}
