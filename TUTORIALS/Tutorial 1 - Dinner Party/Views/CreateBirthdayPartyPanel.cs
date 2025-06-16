using Avalonia;
using Avalonia.Controls;

using System;
using System.Globalization;

public class CreateBirthdayPartyPanel : CreatePartyPanel 
{
    private ComboBox cakeSizeComboBox;

    public CreateBirthdayPartyPanel(PartyPlanner planner) : base(planner)
    {
        var cakeSizeLabel = new Label { Content = "Cake Size:" };
        cakeSizeComboBox = new ComboBox { ItemsSource = BirthdayParty.CakeSizeOptions, SelectedItem = BirthdayParty.CakeSizeOptions[1] };

        extraControlsPanel.Children.Add(cakeSizeLabel);
        extraControlsPanel.Children.Add(cakeSizeComboBox);

        cakeSizeComboBox.SelectionChanged += (sender, e) => UpdateCost();
        UpdateCost();
    }

    protected override void UpdateCost()
    {
        var numberOfPeople = (int)numberOfPeopleNumericUpDown.Value;
        var isFancy = isFancyCheckBox.IsChecked ?? false;
        var cakeSize = cakeSizeComboBox.SelectedItem as string;
        var tempParty = new BirthdayParty
        {
            NumberOfPeople = numberOfPeople,
            IsFancy = isFancy,
            CakeSize = cakeSize
        };
        var cost = tempParty.CalculateCost();
        var danish = new CultureInfo("da-DK");
        costTextBox.Text = $"Current Cost: {cost.ToString("C", danish)}";
    }

    protected override void CreateParty()
    {
        var newParty = new BirthdayParty
        {
            Date = datePicker.SelectedDate.HasValue ? datePicker.SelectedDate.Value.DateTime : DateTime.Now,
            NumberOfPeople = (int)numberOfPeopleNumericUpDown.Value,
            IsFancy = isFancyCheckBox.IsChecked ?? false,
            CakeSize = cakeSizeComboBox.SelectedItem as string
        };
        planner.AddParty(newParty);
    }
}