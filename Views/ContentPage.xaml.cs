using Divergence_App.ViewModels;

using Microsoft.UI.Xaml.Controls;

namespace Divergence_App.Views;

// To learn more about WebView2, see https://docs.microsoft.com/microsoft-edge/webview2/.
public sealed partial class ContentPage : Page
{
    public ContentViewModel ViewModel
    {
        get;
    }

    public ContentPage()
    {
        ViewModel = App.GetService<ContentViewModel>();
        InitializeComponent();

        ViewModel.WebViewService.Initialize(WebView);
    }
}
