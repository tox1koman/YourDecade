using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace YourDecade
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ShowGoals : ContentPage
    {
        public Grid grid = new Grid();
        ScrollView scrollView = new ScrollView();
        StackLayout stackLayout = new StackLayout();
        

        Button goBackButton = new Button() { ImageSource = "arrow_go_back.png", BackgroundColor = Color.Transparent, HorizontalOptions = LayoutOptions.StartAndExpand };

        public ShowGoals()
        {
            InitializeComponent();
            goBackButton.Clicked += GoPreviousPage;
            Content = grid;
            grid.Children.Add(scrollView);
            scrollView.Content = stackLayout;
            BackgroundImageSource = "background2.png";
            CreateAddButton();
        }

        private void CreateAddButton()
        {
            var addBt = new Button() { BackgroundColor = Color.Transparent};

            addBt.Clicked += AddGoal;
            stackLayout.Children.Add(goBackButton);
            var btContainer = new AbsoluteLayout() { HeightRequest = 150 };
            btContainer.Children.Add(new Image() { Source = "goal_box.png" }, new Rectangle(0.5, 0.5, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize), AbsoluteLayoutFlags.PositionProportional);
            btContainer.Children.Add(new Image() { Source = "plus.png" }, new Rectangle(0.5, 0.42, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize), AbsoluteLayoutFlags.PositionProportional);
            btContainer.Children.Add(addBt, new Rectangle(0.5, 0.5, 0.8, 0.8), AbsoluteLayoutFlags.All);
            stackLayout.Children.Add(btContainer);

        }

        private async void AddGoal(object sender, EventArgs e)
        {
            string goalName = await DisplayPromptAsync("Новая цель", "Введите название цели");
            if (goalName == null || goalName == "")
                return;

            var groupContainer = new AbsoluteLayout() { HeightRequest = 150};

            groupContainer.Children.Add(new Image() { Source = "goal_box.png" }, new Rectangle(0.5, 0.53, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize), AbsoluteLayoutFlags.PositionProportional);
            groupContainer.Children.Add(new Image() { Source = "bucket.png" }, new Rectangle(0.15, 0.4, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize), AbsoluteLayoutFlags.PositionProportional);
            groupContainer.Children.Add(new Label() { Text = goalName, FontSize = 32, TextColor = Color.Black, FontFamily = "SF-Bold" }, new Rectangle(0.5, 0.4, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize), AbsoluteLayoutFlags.PositionProportional);

            var bt = new Button()
            {
                ContentLayout = new Button.ButtonContentLayout(Button.ButtonContentLayout.ImagePosition.Left, 5),
                BackgroundColor = Color.Transparent,
            };
            bt.Clicked += OpenGoal;

            groupContainer.Children.Add(bt, new Rectangle(0.5, 0.5, 0.8, 0.8), AbsoluteLayoutFlags.All);
            stackLayout.Children.Insert(stackLayout.Children.Count - 1, groupContainer);
        }

        private async void OpenGoal(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new GoalDescription());
        }

        private async void GoPreviousPage(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}