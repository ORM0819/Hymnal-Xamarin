using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Hymnal.Views;

namespace Hymnal.ViewModels;

public sealed partial class NumberViewModel : BaseViewModel
{
    [ObservableProperty]
    private string hymnNumber;


    public NumberViewModel()
    {
#if DEBUG
        hymnNumber = 255.ToString();
#endif
    }


    [RelayCommand]
    private async void OpenHymnAsync(string number)
    {
        //await Shell.Current.GoToAsync($"{nameof(ModalNavigationPage)}/{nameof(HymnPage)}",
        await Shell.Current.GoToAsync(nameof(HymnPage),
            new Dictionary<string, object>
            {
                ["Parameter"] = new HymnIdParameter()
                {
                    Number = int.Parse(number),
                    SaveInRecords = true,
                    HymnalLanguage = InfoConstants.HymnsLanguages.First(),
                }
            });
    }
}
