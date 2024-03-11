using System.Net.Security;

namespace OmniCalc.Views;

public partial class StartPage : ContentPage
{
	public StartPage()
	{
        InitializeComponent();
	}

    private void NavigatePythTheoClicked(object sender, EventArgs e)
    {
        Application.Current.MainPage = new PythagoreanTheoremPage();
    }

    private void NavigatePercentClicked(object sender, EventArgs e)
    {
        Application.Current.MainPage = new PercentageCalculationPage();
    }

    private void NavigateAverageClicked(object sender, EventArgs e)
    {
        Application.Current.MainPage = new AverageCalcPage();
    }
}