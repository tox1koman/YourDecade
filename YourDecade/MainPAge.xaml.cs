using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.Xaml;

namespace YourDecade
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        Grid solvinGrid = new Grid();
        FlexLayout flexLayout = new FlexLayout() 
        { 
            Wrap = FlexWrap.Wrap, 
            JustifyContent = FlexJustify.SpaceEvenly, 
            Direction = FlexDirection.Row, 
            AlignContent = FlexAlignContent.Start,
            BackgroundColor = Color.Transparent
        };
        ScrollView scrollView = new ScrollView() { BackgroundColor = Color.Transparent } ;
        Button addNewGroupButton = new Button()
        {
            BackgroundColor = Color.Transparent,
            ImageSource = "add_group_box.png",
            HeightRequest = 180,
            WidthRequest = 180,
        };
        public MainPage()
        {
            InitializeComponent();
            scrollView.Content = flexLayout;
            solvinGrid.Children.Add(scrollView);
            Content = solvinGrid;
            BackgroundImageSource = "background2.png";
            flexLayout.Children.Add(addNewGroupButton);
            addNewGroupButton.Clicked += AddGroup;
        }

        private async void AddGroup(object sender, EventArgs e)
        {
            string groupName = await DisplayPromptAsync("Новая группа", "Введите название группы");
            if (groupName == null || groupName == "" || groupName.Length > 20)
                return;
            var bt = new Button()
            {
                BackgroundColor = Color.Transparent,
                ImageSource = "group_box.png",
                Text = groupName,
                ContentLayout = new Button.ButtonContentLayout(Button.ButtonContentLayout.ImagePosition.Top, 0),
                HeightRequest = 180,
                WidthRequest = 180,
                Padding = 0,
                Margin = 0,
            };
            bt.Clicked += OpenGroup;
            flexLayout.Children.Insert(1, bt);

            if (flexLayout.Children.Count > 15 )
                addNewGroupButton.IsVisible = false;

        }

        private async void OpenGroup(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new ShowGoals());
        }
    }

}