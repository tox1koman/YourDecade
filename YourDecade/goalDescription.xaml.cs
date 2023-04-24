using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.Xaml;

namespace YourDecade
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GoalDescription : ContentPage
    {
        string goalName = "Цель";
        Grid grid = new Grid
        {
            RowDefinitions =
            {
                new RowDefinition { Height = new GridLength(0.1, GridUnitType.Star) },
                new RowDefinition { Height = new GridLength(0.13, GridUnitType.Star) },
                new RowDefinition { Height = new GridLength(0.13, GridUnitType.Star) },
                new RowDefinition { Height = new GridLength(0.5, GridUnitType.Star)},
                new RowDefinition { Height = new GridLength(1, GridUnitType.Star) }
            },
            ColumnDefinitions =
            {
                new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                new ColumnDefinition { Width = new GridLength(0.2, GridUnitType.Star) },
            }
        };

        Grid subgoalsGrid = new Grid();
        AbsoluteLayout subgoalsAbsoluteLayout = new AbsoluteLayout() { BackgroundColor = Color.Transparent};
        Xamarin.Forms.ScrollView subgoalScrollView = new Xamarin.Forms.ScrollView() { BackgroundColor = Color.Transparent};
        StackLayout subgoalsStackLayout = new StackLayout() { BackgroundColor = Color.Transparent, Margin = 10};

        Image notesBg = new Image()
        {
            Source = "notes_background",
        };

        // Календарь ----------------------------

        Xamarin.Forms.DatePicker calend = new Xamarin.Forms.DatePicker();

        // Календарь ----------------------------

        Button goBackButton = new Button() { ImageSource = "arrow_go_back.png", BackgroundColor = Color.Transparent };

        public GoalDescription()
        {
            InitializeComponent();
            goBackButton.Clicked += GoPreviousPage;
            Content = grid;
            BackgroundImageSource = "background2.png";
            subgoalsGrid.Children.Add(subgoalsAbsoluteLayout);
            subgoalsAbsoluteLayout.Children.Add(new Image() { Source = "subgoals_background.png"}, new Rectangle(0.5, 0.5, 1, 1), AbsoluteLayoutFlags.All);
            subgoalsAbsoluteLayout.Children.Add(subgoalScrollView, new Rectangle(0.5, 0.5, 1, 1), AbsoluteLayoutFlags.All);
            subgoalScrollView.Content = subgoalsStackLayout;
            CreateAddButton();
            var goalNameContainer = new AbsoluteLayout();
            goalNameContainer.Children.Add
                (
                new Image() { Source = "group_name_box.png" }, 
                new Rectangle(0.5, 0.5, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize), 
                AbsoluteLayoutFlags.PositionProportional
                );
            goalNameContainer.Children.Add(
                new Label() { Text = goalName, FontSize = 32, FontAttributes = FontAttributes.Bold, TextColor = Color.Black }, 
                new Rectangle(0.5, 0.5, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize), 
                AbsoluteLayoutFlags.PositionProportional
                );

            var notes = new AbsoluteLayout();
            notes.Children.Add ( notesBg, new Rectangle(0.5, 0.5, 0.91, 1), AbsoluteLayoutFlags.All );
            notes.Children.Add 
                (
                    new Editor() 
                    { 
                        TextColor = Color.Black, 
                        Placeholder = "Заметки по вашей цели", 
                        BackgroundColor = Color.Transparent 
                    },
                    new Rectangle
                    (
                        0.5,
                        0.5,
                        0.86,
                        0.86
                    ),
                    AbsoluteLayoutFlags.All
                );



            var statusIndicator = new Image() { Source = "status_inprogress.png" , BackgroundColor = Color.Transparent };
            var calendButton = new Button() { ImageSource = "calend_icon.png" , BackgroundColor = Color.Transparent};

            grid.Children.Add(goBackButton, 0, 0);
            grid.Children.Add(goalNameContainer, 0, 1);
            grid.Children.Add(notes, 0, 3);
            grid.Children.Add(subgoalsGrid, 0, 4);
            grid.Children.Add(statusIndicator, 1, 1);
            grid.Children.Add(calendButton, 1, 2);

            Grid.SetRowSpan(goalNameContainer, 2);
            Grid.SetColumnSpan(notes, 2);
            Grid.SetColumnSpan(subgoalsGrid, 2);
        }

        private async void AddSubgoal(object sender, EventArgs e)
        {
            string subgoalName = await DisplayPromptAsync("Новая подцель", "Введите название подцели");
            if (subgoalName == null || subgoalName == "" || subgoalName.Length > 20)
                return;

            var boxedSubGoal = new AbsoluteLayout() { BackgroundColor = Color.Transparent, HeightRequest = 80};
            boxedSubGoal.Children.Add
                (new Image() { Source = "subgoal_background" }, new Rectangle(0.5, 0.5, 0.8, 0.8), AbsoluteLayoutFlags.All);

            boxedSubGoal.Children.Add
                (
                 new Label()
                    {
                        BackgroundColor = Color.Transparent,
                        Text = subgoalName,
                        TextColor = Color.Black,
                        FontSize = 28,
                    },
                    new Rectangle(0.5, 0.5, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize),
                    AbsoluteLayoutFlags.PositionProportional
                );

            subgoalsStackLayout.Children.Insert
                (
                subgoalsStackLayout.Children.Count - 1,
                boxedSubGoal
                );
        }

        private void CreateAddButton()
        {
            var box = new AbsoluteLayout() { BackgroundColor = Color.Transparent, HeightRequest = 80 };
            var button = new Button() { ImageSource = "plus.png", BackgroundColor = Color.Transparent};
            button.Clicked += AddSubgoal;
            box.Children.Add(new Image() { Source = "subgoal_background" }, new Rectangle(0.5, 0.5, 0.8, 0.8), AbsoluteLayoutFlags.All);
            box.Children.Add(button, new Rectangle(0.5, 0.5, 1, 1), AbsoluteLayoutFlags.All);
            subgoalsStackLayout.Children.Add(box);        
        }

        private async void GoPreviousPage(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}