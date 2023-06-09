﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace YourDecade
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FirstStartPage : ContentPage
    {
        public FirstStartPage()
        {
            InitializeComponent();
            var layout = new StackLayout();
            this.BackgroundImageSource = "backgroundFirstStart.png";
            Content = layout;
            var label = new Label()
            {
                Text = "YourDecade",
                FontFamily = "SF-Heavy",
                FontSize = 48,
                TextColor = Color.Black,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
            };

            var buttonToNext = new Button()
            {
                Text = "Нажмите для продолжения",
                FontFamily = "SF-Regular-Italic",
                FontSize = 32,
                BackgroundColor = Color.Transparent,
                VerticalOptions = LayoutOptions.CenterAndExpand,
            };
            buttonToNext.Clicked += ToNextPage;
            layout.Children.Add(label);
            layout.Children.Add(buttonToNext);
            var image = new Image() { Source = "team_logo.png", Scale = 0.6, HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.End };
            layout.Children.Add(image);
        }

        private async void ToNextPage(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NameAndAgePage());
        }
    }
}