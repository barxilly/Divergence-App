using Divergence_App.ViewModels;

using Microsoft.UI.Xaml.Controls;

namespace Divergence_App.Views;

public sealed partial class MembersPage : Page
{
    public MembersViewModel ViewModel
    {
        get;
    }

    public MembersPage()
    {
        ViewModel = App.GetService<MembersViewModel>();
        InitializeComponent();
    }
}
