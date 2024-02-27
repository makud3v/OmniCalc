namespace OmniCalc.Views;

public partial class StartPage : ContentPage
{
	public StartPage()
	{
		InitializeComponent();
	}

    private void NavigatePythTheoClicked(object sender, EventArgs e)
    {
        Application.Current.MainPage = new NavigationPage(new StartPage());
    }
}