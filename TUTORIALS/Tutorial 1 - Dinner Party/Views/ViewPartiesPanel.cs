using Avalonia.Controls;
using System.Collections.Generic;
using Avalonia;
using Avalonia.Layout;
using Avalonia.Media;

public class ViewPartiesPanel : StackPanel 
{
    private ListBox partyListView;
    private TextBlock selectedPartyDetails;
    private TextBlock selectedPartyCost;

    public ViewPartiesPanel(List<Party> parties) 
    {
        Orientation = Orientation.Vertical;
        HorizontalAlignment = HorizontalAlignment.Center;
        VerticalAlignment = VerticalAlignment.Center;
        Margin = new Thickness(20);
        RenderTransform = new ScaleTransform(2, 2);

        var headingLabel = new Label 
        {
            Content = "Party Planner",
            HorizontalAlignment = HorizontalAlignment.Center,
            Margin = new Thickness(0, 0, 0, 10),
        };

        partyListView = new ListBox();
        partyListView.ItemsSource = parties;
        partyListView.SelectionChanged += (sender, e) => 
        {
            if (partyListView.SelectedItem is Party selectedParty) 
            {
                selectedPartyDetails.Text = $"Date: {selectedParty.Date.Date:d}\n" +
                                            $"Number of People: {selectedParty.NumberOfPeople}\n" +
                                            $"Is Fancy: {selectedParty.IsFancy}\n";
                selectedPartyCost.Text = $"Cost: {selectedParty.CalculateCost():C}";
            } else 
            {
                selectedPartyDetails.Text = string.Empty;
                selectedPartyCost.Text = string.Empty;
            }
        };

        selectedPartyDetails = new TextBlock 
        {
            Margin = new Thickness(0, 10, 0, 0)
        };

        selectedPartyCost = new TextBlock 
        {
            Margin = new Thickness(0, 10, 0, 0)
        };

        this.Children.Add(headingLabel);
        this.Children.Add(partyListView);
        this.Children.Add(selectedPartyDetails);
        this.Children.Add(selectedPartyCost);
    }

    public void Refresh(List<Party> parties) 
    {
        partyListView.ItemsSource = null; // Reset the ItemsSource to refresh the ListBox
        partyListView.ItemsSource = parties;
    }
}