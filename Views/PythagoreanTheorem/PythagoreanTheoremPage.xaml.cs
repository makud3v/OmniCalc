namespace OmniCalc.Views.PythagoreanTheorem;

class CalcVar
{
    public Entry Entry { get; set; }
    public float Value { get; set; }
    public Func<float, object> Callback { get; set; }
};

public partial class PythagoreanTheoremPage : ContentPage
{
    private Dictionary<string, CalcVar> _vars = new();

    public PythagoreanTheoremPage()
    {
        InitializeComponent();
        foreach (var child in Content.GetVisualTreeDescendants())
        {
            string? id = (child as Entry)?.ClassId;
            if (id is null || !id.StartsWith("Calc:")) continue;

            BindEntry(child as Entry, id.Replace("Calc:", ""));
        };

        BindCallback("A", (valueA) =>
        {
            float valueB = GetVar("B");
            if (valueB > 0)
            {
                CalculateC(valueA, GetVar("B"));
            }

            return null;
        });

        BindCallback("B", (valueB) =>
        {
            float valueA = GetVar("A");
            float valueC = GetVar("C");
            if (valueA > 0 && valueC <= 0)
            {
                CalculateC(valueA, valueB);
            }
            else if (valueA <= 0 && valueC >= 0 && valueB > 0)
            {
                CalculateA(valueB, valueC);
            }


            return null;
        });

        BindCallback("C", (valueC) =>
        {
            float valueA = GetVar("A");



            return null;
        });
    }


    private void CalculateA(float b, float c)
    {
        float b2 = b * b;
        float c2 = c * c;
        float a2 = c2 - b2;

        SetVar("A", (float)Math.Round(Math.Sqrt(a2), 2), true);
    }

    private void CalculateB(float a, float c)
    {
        float a2 = a * a;
        float c2 = c * c;
        float b2 = c2 - a2;

        SetVar("B", (float)Math.Round(Math.Sqrt(b2), 2), true);
    }

    private void CalculateC(float a, float b)
    {
        float c = (float)Math.Sqrt((a * a) + (b * b));

        SetVar("C", (float)Math.Round(c, 2), true);
    }




    private void BindCallback(string varId, Func<float, object?> callback)
    {
        varId = varId.ToLower();
        if (!_vars.ContainsKey(varId)) return;
        _vars[varId].Callback = callback;
    }

    private void BindEntry(Entry entry, string varId)
    {
        CalcVar calcVar = new()
        {
            Entry = entry
        };

        varId = varId.ToLower();
        _vars[varId] = calcVar;
        entry.TextChanged += (sender, e) =>
        {
            try
            {
                float value = float.Parse(e.NewTextValue);

                calcVar.Value = value;
                SetVar(varId, value);
            }
            catch { }
        };
    }

    private float GetVar(string varId, float defaultValue = 0)
    {
        varId = varId.ToLower();
        return _vars.ContainsKey(varId) ? _vars[varId].Value : defaultValue;
    }

    private void SetVar(string varId, float value, bool noCallback = false)
    {
        if (value is float.NaN)
            value = 0.0f;

        varId = varId.ToLower();
        if (!_vars.ContainsKey(varId)) return;

        CalcVar var = _vars[varId];
        var.Value = value;

        var.Entry.Text = value.ToString();
        if (noCallback || var.Callback is null) return;
        var.Callback(var.Value);
    }
}