using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace YourDecade
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NameAndAgePage : ContentPage
    {
        Entry nameEntry = new Entry()
        {
            Placeholder = "Введите здесь ваше имя",
            BackgroundColor = Color.Transparent
        };

        Entry ageEntry = new Entry()
        {
            Placeholder = "Введите здесь ваш возраст",
            BackgroundColor = Color.Transparent,
            Keyboard = Keyboard.Numeric
        };

        Label nameErrorLabel = new Label()
        {
            Text = "Имя введено неверно!",
            IsVisible = false,
            TextColor = Color.Red
        };

        Label logo = new Label()
        {
            Text = "YourDecade",
            FontSize = 48,
            TextColor = Color.Black
        };

        Label ageErrorLabel = new Label()
        {
            Text = "Возраст введён неверно!",
            IsVisible = false,
            TextColor = Color.Red
        };

        int age = -10;
        string name = null;

        Image textFieldImg = new Image() { Source = "text_box", Scale = 0.88 };
        Image textFieldImg2 = new Image() { Source = "text_box", Scale = 0.88 };

        Button button = new Button()
        {
            BackgroundColor = Color.Transparent,
            ImageSource = ImageSource.FromFile("arrow_next.png")
        };

        public NameAndAgePage()
        {
            
            var layout = new AbsoluteLayout();
            
            Content = layout;
            
            BackgroundImageSource = "background2.png";
            InitializeComponent();

            AbsoluteLayout.SetLayoutBounds(nameEntry, new Rectangle(0.5, 0.35, 0.8, 0.05));
            AbsoluteLayout.SetLayoutBounds(textFieldImg, new Rectangle(0.5, 0.343, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));
            AbsoluteLayout.SetLayoutBounds(nameErrorLabel, new Rectangle(0.5, 0.39, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));

            AbsoluteLayout.SetLayoutBounds(ageEntry, new Rectangle(0.5, 0.45, 0.8, 0.05));
            AbsoluteLayout.SetLayoutBounds(textFieldImg2, new Rectangle(0.5, 0.443, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));
            AbsoluteLayout.SetLayoutBounds(ageErrorLabel, new Rectangle(0.5, 0.49, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));

            AbsoluteLayout.SetLayoutBounds(logo, new Rectangle(0.5, 0.15, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));

            AbsoluteLayout.SetLayoutBounds(button, new Rectangle(0.5, 0.73, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));

            AbsoluteLayout.SetLayoutFlags(nameEntry, AbsoluteLayoutFlags.All);
            AbsoluteLayout.SetLayoutFlags(ageEntry, AbsoluteLayoutFlags.All);
            AbsoluteLayout.SetLayoutFlags(nameErrorLabel, AbsoluteLayoutFlags.PositionProportional);
            AbsoluteLayout.SetLayoutFlags(ageErrorLabel, AbsoluteLayoutFlags.PositionProportional);
            AbsoluteLayout.SetLayoutFlags(textFieldImg, AbsoluteLayoutFlags.PositionProportional);
            AbsoluteLayout.SetLayoutFlags(textFieldImg2, AbsoluteLayoutFlags.PositionProportional);
            AbsoluteLayout.SetLayoutFlags(logo, AbsoluteLayoutFlags.PositionProportional);
            AbsoluteLayout.SetLayoutFlags(button, AbsoluteLayoutFlags.PositionProportional);

            layout.Children.Add(textFieldImg);
            layout.Children.Add(textFieldImg2);
            layout.Children.Add(nameEntry);
            layout.Children.Add(ageEntry);
            layout.Children.Add(nameErrorLabel);
            layout.Children.Add(ageErrorLabel);
            layout.Children.Add(logo);
            layout.Children.Add(button);

            nameEntry.TextChanged += ShowNameInfo;
            ageEntry.TextChanged += ShowAgeInfo;
            button.Clicked += Button_Clicked;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new MainPage());
        }

        //private async void TryGoNext(object sender, EventArgs e)
        //{



        //    if (nameEntry.Text == null || !CheckName(name)) 
        //    {
        //        await DisplayAlert("Неверно введено имя!", "Проверьте правильность ввода имени", "OK");
        //        return;
        //    }
        //        name = CutSpaces(nameEntry.Text);
        //    if ((age < 0 || age > 140) || ageEntry.Text == null)
        //    {
        //        await DisplayAlert("Неверно введен возраст!", "Проверьте правильность ввода возраста", "OK");
        //        return;
        //    }
        //        age = int.Parse(ageEntry.Text);
        //    tryGoNextButton.IsEnabled = false;
        //    tryGoNextButton.IsVisible = false;

        //    goNextButton.IsEnabled = true;
        //    goNextButton.IsVisible = true;

        //}

        private bool CheckName(string name) 
        {
            var containsLetters = false;
            if (name.Length < 2)
                return false;
            foreach (var c in name)
            {
                if (!(char.IsLetter(c) || char.IsWhiteSpace(c))&& c != '-')
                    return false;
                if (char.IsLetter(c)) containsLetters = true;
            }
            return containsLetters;
        }

        //private string CutSpaces(string str)
        //{
        //    str = str.Trim();
        //    var result = "";
        //    for (var i = 0; i < str.Length - 1; i++)
        //    {
        //        if (char.IsWhiteSpace(str[i]) && char.IsWhiteSpace(str[i + 1]))
        //            continue;
        //        result += str[i];
        //    }
        //    result += str[str.Length - 1];
        //    return result;
        //}

        private void ShowNameInfo(object sender, EventArgs e)
        {
            var str = nameEntry.Text;
            if (str == null)
            {
                ShowErrorNameMessage();
                return;
            }

            if  (!CheckName(str))
            {
                ShowErrorNameMessage();
                return;
            }

            HideErrorNameMessage();
        }
        
        private void ShowErrorNameMessage()
        {
            nameErrorLabel.IsVisible = true;
        }

        private void HideErrorNameMessage()
        {
            nameErrorLabel.IsVisible = false;
        }

        private void ShowAgeInfo(object sender, EventArgs e)
        {
            var num = ageEntry.Text;
            if (num == null)
            {
                ShowErrorAgeMessage();
                return;
            }

            try
            {
                int.Parse(num);
            }

            catch(Exception exc) 
            {
                ShowErrorAgeMessage();
                return;
            }

            if (int.Parse(num) < 0 || int.Parse(num) > 140) 
            {
                ShowErrorAgeMessage();
                return;
            }
            HideErrorAgeMessage();
        }

        private void ShowErrorAgeMessage()
        {
            ageErrorLabel.IsVisible = true;
        }

        private void HideErrorAgeMessage()
        {
            ageErrorLabel.IsVisible = false;
        }
    }
}