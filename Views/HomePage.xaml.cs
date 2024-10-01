using Divergence_App.ViewModels;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Media.Imaging;
using Newtonsoft.Json;
using System.Net.Http.Headers;
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
        Diggin.Click += Diggin_click;
        Amanchoo.Click += Amanchoo_click;
        Maj.Click += Maj_click;
        BadRabbit.Click += Maj_click;

        // If no Internet show a alert and close the app, check every 3 seconds
        while (!CheckForInternet())
        {
            var dialog = new ContentDialog
            {
                Title = "No Internet Connection",
                Content = "Please connect to the internet to use this app.",
                CloseButtonText = "Close"
            };
            dialog.CloseButtonClick += (sender, args) => { Application.Current.Exit(); };
            dialog.ShowAsync();
            System.Threading.Thread.Sleep(3000);
        }

    }

    private bool CheckForInternet()
    {
        try
        {
            using (var client = new System.Net.WebClient())
            using (client.OpenRead("http://clients3.google.com/generate_204"))
            {
                return true;
            }
        }
        catch
        {
            return false;
        }
    }

    private void S1_click(object sender, RoutedEventArgs e)
    {
        // Go to https://drive.usercontent.google.com/download?id=1LIxNJVkE6x7FCBAJHTKxb7Bq4IjC3fKi&export=download&authuser=0
        var psi = new System.Diagnostics.ProcessStartInfo
        {
            FileName = "cmd",
            Arguments = "/c start https://drive.usercontent.google.com/download?id=1LIxNJVkE6x7FCBAJHTKxb7Bq4IjC3fKi&export=download&authuser=0",
            CreateNoWindow = true,
            UseShellExecute = false
        };
        System.Diagnostics.Process.Start(psi);
    }

    private void Kat_click(object sender, RoutedEventArgs e)
    {
        // Go to the "Kat" page
        Frame.Navigate(typeof(MembersPage));
    }

    private void Diggin_click(object sender, RoutedEventArgs e)
    {
        // Go to the "Diggin" page
        Frame.Navigate(typeof(Diggin));
    }

    private void Amanchoo_click(object sender, RoutedEventArgs e)
    {
        // Go to the "Amanchoo" page
        Frame.Navigate(typeof(Amanchoo));
    }

    private void Maj_click(object sender, RoutedEventArgs e)
    {
        // Go to the "Maj" page
        Frame.Navigate(typeof(Maj));
    }
}

public class yt
{

    public async void getYouTubeContent(string channel, StackPanel cp)
    {
        var client = new HttpClient();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        // Check channel UCQAp47kpE5oCU6b3u6OwIJw

        var response = await client.GetAsync(new Uri("https://www.googleapis.com/youtube/v3/search?key=AIzaSyBtLsoAEBrKdbQvw0A32P72gX__ribzT18&order=date&channelId=" + channel+"&part=snippet&maxResults=10"));

        var content = await response.Content.ReadAsStringAsync();
        dynamic json = JsonConvert.DeserializeObject<YouTubeResponse>(content);
        if (json.Items == null) { 
            var errorText = new TextBlock();
            errorText.Text = "Error loading content, please try again later.";
            errorText.FontSize = 20;

            cp.Children.Add(errorText);
            return;
        }

            foreach (var item in json.Items)
        {
            var button = new Button();
            button.HorizontalAlignment = HorizontalAlignment.Stretch;
            button.HorizontalContentAlignment = HorizontalAlignment.Left;
            button.Height = 200;
            button.Margin = new Thickness(5);
            button.Click += (sender, e) =>
            {
                var psi = new System.Diagnostics.ProcessStartInfo
                {
                    FileName = "cmd",
                    Arguments = $"/c start https://youtube.com/watch?v={item.Id.VideoId}",
                    CreateNoWindow = true,
                    UseShellExecute = false
                };
                System.Diagnostics.Process.Start(psi);
            };
            var textBlock = new TextBlock();
            textBlock.Text = item.Snippet.Title;
            textBlock.FontSize = 20;
            var image = new Image
            {
                Source = new BitmapImage(new Uri(item.Snippet.Thumbnails.Medium.Url)),
                Height = 170,
                Margin = new Thickness(10)
            };
            button.Content = new StackPanel
            {
                Children =
                {
                    image,
                    textBlock
                },
                Orientation = Orientation.Horizontal
            };
            cp.Children.Add(button);
        }
    }
}

public class YouTubeResponse
{
    [JsonProperty("items")]
    public List<YouTubeItem> Items
    {
        get; set;
    }
}

public class YouTubeItem
{
    [JsonProperty("id")]
    public YouTubeId Id
    {
        get; set;
    }

    [JsonProperty("snippet")]
    public YouTubeSnippet Snippet
    {
        get; set;
    }
}

public class YouTubeId
{
    [JsonProperty("videoId")]
    public string VideoId
    {
        get; set;
    }
}

public class YouTubeSnippet
{
    [JsonProperty("title")]
    public string Title
    {
        get; set;
    }

    [JsonProperty("thumbnails")]
    public YouTubeThumbnails Thumbnails
    {
        get; set;
    }
}

public class YouTubeThumbnails
{
    [JsonProperty("medium")]
    public YouTubeThumbnail Medium
    {
        get; set;
    }
}

public class YouTubeThumbnail
{
    [JsonProperty("url")]
    public string Url
    {
        get; set;
    }
}
