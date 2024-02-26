namespace OmniCalc.Views;


public partial class AverageCalcPage : ContentPage
{
	public AverageCalcPage()
	{
		InitializeComponent();
	}

    private string On_Calculated(object sender, EventArgs e)
    {
		var result = "";
		foreach (var child in Content.GetVisualTreeDescendants())
		{

			string? id = (child as Entry)?.ClassId;

			if (id != null || id != "AverageEntry") continue;
			Entry c = child as Entry;
			result += c.Text;
			
		}
		return result;
    }
}

