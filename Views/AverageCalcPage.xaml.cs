namespace OmniCalc.Views;


public partial class AverageCalcPage : ContentPage
{
	public AverageCalcPage()
	{
		InitializeComponent();
	}

    private void On_Calculated(object sender, EventArgs e)
    {
        int entryCount = 0;
        float totalSum = 0;
        foreach (var child in Content.GetVisualTreeDescendants())
        {
            string? id = (child as Entry)?.ClassId;

            if (id == null || id != "AverageEntry") continue;
            Entry c = child as Entry;

            try
            {
                float convertedEntry = float.Parse(c.Text);
                entryCount += 1;
                totalSum += convertedEntry;
            }
            catch { }
        }
        
        float result = totalSum / entryCount;
        string resultAsString = result.ToString();


        foreach (Element child in Content.GetVisualTreeDescendants().Cast<Element>())
        {
            string? id = child?.ClassId;

            if (id == null || id != "Result") continue;
            Label l = child as Label;
            l.Text = resultAsString;

        }
    }

}

