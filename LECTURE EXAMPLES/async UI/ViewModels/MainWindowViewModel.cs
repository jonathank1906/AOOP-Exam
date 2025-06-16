namespace AsyncUIExample.ViewModels;

using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Avalonia.Controls;
using Avalonia.Threading;


public partial class MainWindowViewModel : ViewModelBase
{
    [ObservableProperty]
    private string? result = "Nothing";

    [ObservableProperty]
    private bool? enabled = true;

    [RelayCommand]
    private async Task DoSomething()
    {
        await Task.Run( () => 
        {
            Result = string.Empty;
            foreach(char c in "Something")
            {
                Thread.Sleep(500);
                Result += c;
            }
            Thread.Sleep(500);
        });   

        Result = "Nothing";

    }

}
