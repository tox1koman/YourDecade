﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
[assembly: ExportFont("SFProText-Bold.ttf", Alias = "SFProText")]
namespace YourDecade
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new FirstStartPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}