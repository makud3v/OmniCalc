namespace OmniCalc.Views.PercentageCalculation;

public partial class PercentageCalculationPage : ContentPage
{
	public PercentageCalculationPage()
	{
        InitializeComponent();

        BindingContext = new PercentageCalculationViewModel();
    }
}