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
        Grid grid = new Grid();
        ScrollView scrollView = new ScrollView();
        StackLayout stackLayout = new StackLayout();
        Button addBt = new Button()
        {
            BackgroundColor = new Color(204, 248, 233, 0.6),
            ImageSource = "plus.png"
        };

        Button goBackButton = new Button() { ImageSource = "arrow_go_back.png", BackgroundColor = Color.Transparent, HorizontalOptions = LayoutOptions.StartAndExpand };

        public ShowGoals()
        {
            InitializeComponent();
            goBackButton.Clicked += GoPreviousPage;
            Content = grid;
            grid.Children.Add(scrollView);
            scrollView.Content = stackLayout;
            BackgroundImageSource = "background2.png";
            CreateGoals();
        }

        public void CreateGoals()
        {
            addBt.Clicked += AddGoal;
            stackLayout.Children.Add(goBackButton);
            stackLayout.Children.Add(addBt);
        }

        private async void AddGoal(object sender, EventArgs e)
        {
            string goalName = await DisplayPromptAsync("Новая цель", "Введите название цели");
            if (goalName == null || goalName == "")
                return;
            var bt = new Button()
            {
                ContentLayout = new Button.ButtonContentLayout(Button.ButtonContentLayout.ImagePosition.Left, 5),
                ImageSource = "bucket.png",
                BackgroundColor = new Color(204, 248, 233, 0.5),
                Text = goalName
            };
            bt.Clicked += OpenGoal;
            stackLayout.Children.Insert(stackLayout.Children.Count - 1, bt);
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