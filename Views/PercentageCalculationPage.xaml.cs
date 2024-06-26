using System;
using Microsoft.Maui.Controls;

namespace OmniCalc.Views
{
    public partial class PercentageCalculationPage : ContentPage
    {
        public PercentageCalculationPage()
        {
            InitializeComponent();
        }

        private void Percentage1Button_Clicked(object sender, EventArgs e)
        {
            if (double.TryParse(PercentEntry.Text, out double percent) && double.TryParse(NumberEntry.Text, out double number))
            {
                double result = (percent / 100) * number;
                ResultEntry1.Text = result.ToString();
            }
            else
            {
                ResultEntry1.Text = "Invalid input";
            }
        }

        private void Percentage2Button_Clicked(object sender, EventArgs e)
        {
            if (double.TryParse(Number1Entry.Text, out double number1) && double.TryParse(Number2Entry.Text, out double number2))
            {
                double result = (number1 / number2) * 100;
                ResultEntry2.Text = result.ToString();
            }
            else
            {
                ResultEntry2.Text = "Invalid input";
            }
        }

        private void Percentage3Button_Clicked(object sender, EventArgs e)
        {
            if (float.TryParse(IncreaseDecreaseEntry.Text, out float valueX) && float.TryParse(FromEntry.Text, out float valueY))
            {
                float result = Math.Abs(100 - valueX  / valueY * 100);

                ResultEntry3.Text = Math.Round(result, 1)
                    .ToString() + "%";
            }
            else
            {
                ResultEntry3.Text = "Invalid input";
            }
        }

        private void OnBackClicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new StartPage();
        }
    }
}
