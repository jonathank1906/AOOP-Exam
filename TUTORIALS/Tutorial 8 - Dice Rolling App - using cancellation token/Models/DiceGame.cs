namespace MultiDice.Models;

using MultiDice.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;

using Avalonia;
using Avalonia.Media.Imaging; 

public class DiceGame 
{
    private CancellationTokenSource? _cts;
    private readonly MainWindowViewModel _viewModel;

    public DiceGame(MainWindowViewModel viewModel)
    {
        _viewModel = viewModel;
    }

    public async Task Start()
    {
        if (_cts != null && !_cts.IsCancellationRequested) return;
        
        _cts = new CancellationTokenSource();
        await DiceRolling(_cts.Token);
    }

    public void Stop()
    {
        _cts?.Cancel();
        _cts?.Dispose();
        _cts = null;
    }

    private Task DiceRolling(CancellationToken cancellationToken)
    {
        return Task.Run( async () =>
        {
            try 
            {
                Dice dice = new Dice();
                while (!cancellationToken.IsCancellationRequested && !dice.EqualsMax())
                {
                    await Task.Delay(100, cancellationToken);
                    dice.ThrowDice();

                    await _viewModel.Update(dice.Die1, dice.Die2, dice.Count);
                } 

                Stop();
            }
            catch (OperationCanceledException)
            {
                // Expected when task is cancelled
            }
            catch (Exception ex)
            {
                Console.WriteLine($"DiceGame Task Error: {ex.Message}");
            }
        }, cancellationToken);
    }
}