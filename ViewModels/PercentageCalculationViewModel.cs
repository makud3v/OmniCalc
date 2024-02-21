using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace OmniCalc.ViewModels
{
    [INotifyPropertyChanged]
    internal partial class PercentageCalculationViewModel
    {
        [ObservableProperty]
        private string a = string.Empty;

    }
}
