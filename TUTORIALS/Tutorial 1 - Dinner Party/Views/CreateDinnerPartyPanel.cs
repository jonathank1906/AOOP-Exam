using Avalonia;
using Avalonia.Controls;

using System;
using System.Globalization;

public class CreateDinnerPartyPanel : CreatePartyPanel
{
    private CheckBox healthyOptionCheckBox;

    public CreateDinnerPartyPanel(PartyPlanner planner) : base(planner)
    {
        var healthyOptionLabel = new Label { Content = "Healthy Option:" };
        healthyOptionCheckBox = new CheckBox();

        healthyOptionCheckBox.IsChecked = false;

        extraControlsPanel.Children.Add(healthyOptionLabel);
        extraControlsPanel.Children.Add(healthyOptionCheckBox);

        healthyOptionCheckBox.IsCheckedChanged += (sender, e) => UpdateCost();

        UpdateCost();
    }

    protected override void UpdateCost()
    {
        var numberOfPeople = (int)numberOfPeopleNumericUpDown.Value;
        var isFancy = isFancyCheckBox.IsChecked ?? false;
        var isHealthy = healthyOptionCheckBox.IsChecked ?? false;
        var tempParty = new DinnerParty
        {
            NumberOfPeople = numberOfPeople,
            IsFancy = isFancy,
            IsHealthy = isHealthy
        };
        var cost = tempParty.CalculateCost();
        var danish = new CultureInfo("da-DK");
        costTextBox.Text = $"Current Cost: {cost.ToString("C", danish)}";
    }

    protected override void CreateParty()
    {
        var newParty = new DinnerParty
        {
            Date = datePicker.SelectedDate.HasValue ? datePicker.SelectedDate.Value.DateTime : DateTime.Now,
            NumberOfPeople = (int)numberOfPeopleNumericUpDown.Value,
            IsFancy = isFancyCheckBox.IsChecked ?? false,
            IsHealthy = healthyOptionCheckBox.IsChecked ?? false
        };
        planner.AddParty(newParty);
    }   
}