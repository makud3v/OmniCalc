namespace OmniCalc.Views;

public partial class PythagoreanTheoremPage : ContentPage
{

	private Dictionary<string, Entry> _calcEntries = new();

	public PythagoreanTheoremPage()
	{
		InitializeComponent();

		foreach (Element item in Content.GetVisualTreeDescendants())
		{
			string? id = item?.ClassId;
			if (id == null || !id.StartsWith("CalcEntry")) continue;
			Entry entry = item as Entry;
			id = id.Replace("CalcEntry:", "");
            _calcEntries[id] = entry;
		}
        Application.Current.UserAppTheme = AppTheme.Light;
    }

	private float GetCalcVar(string id)
	{
		float v = 0f;
		if (!_calcEntries.ContainsKey(id)) return v;
		float.TryParse(_calcEntries[id].Text, out v);

		return v;
	}

	private void SetCalcVar(string id, float value)
	{
		if (!_calcEntries.ContainsKey(id)) return;
		_calcEntries[id].Text = value > 0 ? Math.Round(value, 2).ToString() : "";
    }

	private void OnCalculateClicked(object sender, EventArgs e)
	{
		float A = GetCalcVar("A");
		float B = GetCalcVar("B");
		float C = GetCalcVar("C");

		float A2 = A > 0 ? (float)A*A : 0;
		float B2 = B > 0 ? (float)B*B : 0;
		float C2 = C > 0 ? (float)C*C : 0;

        if (A > 0 && C > A && B <= 0)
		{
			SetCalcVar("B", (float)Math.Sqrt(C2 - A2));
		}
		if (A > 0 && B > 0 && C <= 0)
		{
			SetCalcVar("C", (float)Math.Sqrt(A2 + B2));
		}

		if (B > 0 && C > 0 && A <= 0)
		{
			SetCalcVar("A", (float)Math.Sqrt(C2 - B2));
		}

        if (A > 0 && B > 0)
        {
            SetCalcVar("Area", (float)(A * B * 0.5f));
        }

        if (A > 0 && B > 0 && C > 0)
        {
            SetCalcVar("Perimeter", (float)(A + B + C));
        }
    }
    private void OnClearClicked(object sender, EventArgs e)
    {
		SetCalcVar("A", 0.0f);
		SetCalcVar("B", 0.0f);
		SetCalcVar("C", 0.0f);
		SetCalcVar("Area", 0.0f);
		SetCalcVar("Perimeter", 0.0f);
    }

    private void OnBackClicked(object sender, EventArgs e)
    {
        Application.Current.MainPage = new NavigationPage(new StartPage());
    }
}