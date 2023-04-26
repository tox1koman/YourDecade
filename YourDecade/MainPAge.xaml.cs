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
            var groupContainer = new AbsoluteLayout() { HeightRequest = 180, WidthRequest = 180};
            groupContainer.Children.Add(new Image() { Source = "group_box.png" }, new Rectangle(0.5, 0.5, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize), AbsoluteLayoutFlags.PositionProportional);
            groupContainer.Children.Add(new Label() { Text = groupName, FontFamily = "SF-Bold" }, new Rectangle(0.5, 0.71, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize), AbsoluteLayoutFlags.PositionProportional);

            var bt = new Button()
            {
                BackgroundColor = Color.Transparent,
            };
            bt.Clicked += OpenGroup;
            groupContainer.Children.Add
                (bt,
                new Rectangle(0.5, 0.5, 0.75, 0.75),
                AbsoluteLayoutFlags.All
                );

            flexLayout.Children.Insert(1, groupContainer);

            if (flexLayout.Children.Count > 15 )
                addNewGroupButton.IsVisible = false;

        }

        private async void OpenGroup(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new ShowGoals());
        }
    }

}