using Avalonia;
using Avalonia.Controls;
using Avalonia.Layout;
using Avalonia.Media;

using System;

public abstract class CreatePartyPanel : StackPanel 
{
    protected PartyPlanner planner;
    protected DatePicker datePicker;
    protected NumericUpDown numberOfPeopleNumericUpDown;
    protected CheckBox isFancyCheckBox;
    protected StackPanel extraControlsPanel;
    protected TextBox costTextBox;

    public CreatePartyPanel(PartyPlanner planner) 
    {
        this.planner = planner;
        Orientation = Orientation.Vertical;
        HorizontalAlignment = HorizontalAlignment.Center;
        VerticalAlignment = VerticalAlignment.Center;
        Margin = new Thickness(20);
        RenderTransform = new ScaleTransform(3, 3);

        var dateLabel = new Label { Content = "Date:" };
        datePicker = new DatePicker();
        datePicker.SelectedDate = DateTime.Now;
    
        var numberOfPeopleLabel = new Label { Content = "Number of People:" };
        numberOfPeopleNumericUpDown = new NumericUpDown { Minimum = 1, Maximum = 100, Value = 5 };

        isFancyCheckBox = new CheckBox { Content = "Is Fancy?" };

        isFancyCheckBox.IsChecked = false;

        extraControlsPanel = new StackPanel();
        
        costTextBox = new TextBox { Margin = new Thickness(0, 10, 0, 0), IsEnabled = false };

        var AddPartyButton = new Button { Content = "Add Party" };
        AddPartyButton.Click += (sender, e) => { CreateParty(); };

        Children.Add(dateLabel);
        Children.Add(datePicker);
        Children.Add(numberOfPeopleLabel);
        Children.Add(numberOfPeopleNumericUpDown);
        Children.Add(isFancyCheckBox);
        Children.Add(extraControlsPanel);
        Children.Add(costTextBox);
        Children.Add(AddPartyButton);

        datePicker.SelectedDateChanged += (sender, e) => UpdateCost();
        numberOfPeopleNumericUpDown.ValueChanged += (sender, e) => UpdateCost();
        isFancyCheckBox.IsCheckedChanged += (sender, e) => UpdateCost();
    }

    protected abstract void UpdateCost();

    protected abstract void CreateParty();
}