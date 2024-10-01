using Divergence_App.ViewModels;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media.Imaging;
using Microsoft.UI.Xaml;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;

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
        var y = new yt();
        y.getYouTubeContent("UCQAp47kpE5oCU6b3u6OwIJw", ContentPanel);
    }

}
