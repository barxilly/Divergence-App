using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography.X509Certificates;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Divergence_App.Views;
/// <summary>
/// An empty page that can be used on its own or navigated to within a Frame.
/// </summary>
public sealed partial class DinoPage : Page
{
    public DinoPage()
    {
        this.InitializeComponent();
        Button1.Click += StartGame;
        Button2.Click += OkThen;
        Reset.Click += (s, e) =>
        {
            Save(0);
            // Reload the page
            Frame.Navigate(typeof(DinoPage));
        };

        if (Windows.Storage.ApplicationData.Current.LocalFolder != null)
        {
            if (Windows.Storage.ApplicationData.Current.LocalSettings.Values["Dino"] != null)
            {
                var i = (int)Windows.Storage.ApplicationData.Current.LocalSettings.Values["Dino"];
                if (i != 0)
                {
                    Disclaimer.Visibility = Visibility.Collapsed;
                }
                if (i == 1)
                {
                    StartGame(null, null);
                }
                else if (i == 2)
                {
                    PickKat(null, null);
                }
                else if (i == 3)
                {
                    PickSilly(null, null);
                }
                else if (i == 4)
                {
                    KatShow(null, null);
                }
                else if (i == 5)
                {
                    SillyFight(null, null);
                }
                else if (i == 6)
                {
                    SillyFight2(null, null);
                }
            }
        }

        void RemoveAllButtonEvents()
        {
            Button1.Click -= StartGame;
            Button1.Click -= OkThen;
            Button1.Click -= PickKat;
            Button1.Click -= PickSilly;
            Button1.Click -= KatShow;
            Button1.Click -= SillyFight;
            Button1.Click -= SillyFight2;
            Button2.Click -= OkThen;
            Button2.Click -= PickKat;
            Button2.Click -= PickSilly;
            Button2.Click -= KatShow;
            Button2.Click -= SillyFight;
            Button2.Click -= SillyFight2;
        }

        async void SlowType(string text, int delay = 30, bool b1 = true, bool b2 = true)
        {
            Button1.IsEnabled = false;
            Button2.IsEnabled = false;
            Text.Text = "";
            foreach (var c in text)
            {
                Text.Text += c;
                await Task.Delay(delay);
            }
            Button1.IsEnabled = b1;
            Button2.IsEnabled = b2;
        }

        void NoButton2()
        {
            Button2.Visibility = Visibility.Collapsed;
            buttholder.Width = new GridLength(0);
        }

        void Button2Back()
        {
            Button2.Visibility = Visibility.Visible;
            buttholder.Width = new GridLength(1, GridUnitType.Star);
        }

        void Save(int i)
        {
            var localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
            localSettings.Values["Dino"] = i;
        }

        void StartGame(object? sender, RoutedEventArgs? e)
        {
            Disclaimer.Visibility = Visibility.Collapsed;
            SlowType("You've just spawned into the Divergence server, Kat and Silly are waiting for you. Who would you like to talk to first?");
            Button1.Content = "Kat";
            Button2.Content = "Silly";
            RemoveAllButtonEvents();
            Button1.Click += PickKat;
            Button2.Click += PickSilly;
            Save(1);
        }

        void OkThen(object? sender, RoutedEventArgs? e)
        {
            SlowType("Ok Then...");
            Button1.Visibility = Visibility.Collapsed;
            Button2.Visibility = Visibility.Collapsed;
        }

        void PickKat(object? sender, RoutedEventArgs? e)
        {
            SlowType("Kat: 'Took you long enough! Come on, I got something to show you!'");
            Button1.Content = "Alright";
            RemoveAllButtonEvents();
            Button1.Click += KatShow;
            NoButton2();
            Save(2);
        }

        void PickSilly(object? sender, RoutedEventArgs? e)
        {
            SlowType("Silly: 'Right, I'm happy you're here, I need someone to help me kill a wither I may or may not have spawned...'");
            Button1.Content = "Sure???";
            Button2.Content = "I think I'll go chat to Kat, thanks for the offer...";
            RemoveAllButtonEvents();
            Button1.Click += SillyFight;
            Button2.Click += PickKat;
            Save(3);
        }

        void KatShow(object? sender, RoutedEventArgs? e)
        {
            Button2Back();
            SlowType("Kat: 'I've been working on this project for a while now, I think you'll like it! Say, do you like dinosaurs?'");
            Button1.Content = "I love dinosaurs!";
            Button2.Content = "I'm not a fan...";
            RemoveAllButtonEvents();
            Button1.Click += DinoYes;
            //Button2.Click += DinoNo;
            Save(4);
        }

        void SillyFight(object? sender, RoutedEventArgs? e)
        {
            SlowType("Silly: 'Great! To the wither cage!'");
            Button1.Content = "Oh god...";
            RemoveAllButtonEvents();
            Button1.Click += SillyFight2;
            NoButton2();
            Save(5);
        }

        void SillyFight2(object? sender, RoutedEventArgs? e)
        {
            Button2Back();
            SlowType("Silly: 'Say hello to my masterpiece!'");
            Button1.Content = "It's... beautiful?";
            Button2.Content = "What am I looking at?";
            RemoveAllButtonEvents();
            //Button1.Click += SillyBeautiful;
            //Button2.Click += SillyWhat;
            Save(6);
        }

        void DinoYes(object? sender, RoutedEventArgs? e)
        {
            SlowType("Kat: 'Great! I've been working on a dinosaur game for a while now, I think you'll like it!'");
            Button1.Content = "Let's play!";
            Button2.Content = "I'm not interested...";
            RemoveAllButtonEvents();
            //Button1.Click += DinoPlay;
            //Button2.Click += DinoNo;
            Save(7);
        }
    }
}
