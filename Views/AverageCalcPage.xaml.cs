namespace OmniCalc.Views;


public partial class AverageCalcPage : ContentPage
{
    private int entryCount = 0;
    private List<Entry> entries = new();
    private Label resultLabel { get; set; }
    private VerticalStackLayout entryContainer;


	public AverageCalcPage()
	{
		InitializeComponent();

        entryContainer = FindFirstByClass("EntryContainer") as VerticalStackLayout;
        resultLabel = FindFirstByClass("Result") as Label;

        // initialize the first two entries
        AddAverageEntry();
        AddAverageEntry();
    }

    private void On_Calculated(object sender, EventArgs e)
    {
        int validEntryCount = 0;

        float totalSum = 0;
        foreach (Entry entry in entries)
        {
            // try to convert the content of the entry to a float
            // if it's valid, take it into account in the final calculation
            // otherwise ignore it
            float f;

            if (float.TryParse(entry.Text, out f))
            {
                validEntryCount++;
                totalSum += f;
            }
        }
        
        float result = totalSum / validEntryCount;
        string resultAsString = result is float.NaN ? "" : result.ToString()    ;

        resultLabel.Text = resultAsString;
    }

    // add an entry for the user to enter a number
    // if the entry is the last entry created, and it's text changes,
    // a new entry will be created
    private Entry AddAverageEntry()
    {
        var res = Application.Current.Resources.MergedDictionaries.ElementAt(1);

        Entry entry = new()
        {
            Placeholder = $"Enter number #{entryCount + 1}",
            Style = res["AverageEntryStyle"] as Style
        };

        // add new text entry if the last entry has a valid input and the text has changed
        entry.TextChanged += (sender, e) =>
        {
            if (entry.Placeholder.Contains($"#{(entryCount)}"))
            {
                float f;

                if (float.TryParse(entry.Text, out f))
                {
                    AddAverageEntry();
                }
            }
        };


        // add the current entry to the list of entries
        entryCount++;
        entries.Add(entry);
        entryContainer.Children.Add(entry);
        return entry;
    }


    private List<Element> FindByClass(string classId)
    {
        List<Element> elements = new();

        foreach (Element element in Content.GetVisualTreeDescendants().Cast<Element>())
        {
            if (element.ClassId == classId) 
                elements.Add(element);
        }

        return elements;
    }

    private Element FindFirstByClass(string classId)
    {
        return FindByClass(classId).FirstOrDefault();
    }

    private void OnBackClicked(object sender, EventArgs e)
    {
        Application.Current.MainPage = new StartPage();
    }
}

