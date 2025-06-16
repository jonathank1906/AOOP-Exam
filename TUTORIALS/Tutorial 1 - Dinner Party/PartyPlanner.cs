using Avalonia;
using Avalonia.Controls;
using Avalonia.Layout;
using Avalonia.Interactivity;
using Avalonia.Media;
using Avalonia.PropertyStore;

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Globalization;

public class PartyPlanner 
{
    private Window win;
    private List<Party> parties = new ();
    private ViewPartiesPanel viewPartiesPanel;

    public PartyPlanner() 
    {
        win = new Window
        {
            Title = "Dinnerparty",
            Width = 1200,
            Height = 1200,
        };

        var tabControl = new TabControl();

        // Tab for adding a new dinner party
        var dinner_PartyPanel = new CreateDinnerPartyPanel(this);

        var dinner_Tab = new TabItem 
        {
            Header = "Dinner Party",
            Content = dinner_PartyPanel,
        };

        // Tab for adding a new birthday party
        var birthday_PartyPanel = new CreateBirthdayPartyPanel(this);

        var birthday_Tab = new TabItem 
        {
            Header = "Birthday Party",
            Content = birthday_PartyPanel,
        };

        viewPartiesPanel = new ViewPartiesPanel(parties);

        var view_Tab = new TabItem 
        {
            Header = "View Parties",
            Content = viewPartiesPanel,
        };

        tabControl.ItemsSource = new TabItem[] {view_Tab, dinner_Tab, birthday_Tab};

        win.Content = tabControl;
        win.Show();
    }

    public void AddParty(Party party) 
    {
        parties.Add(party);
        parties.Sort();
        viewPartiesPanel.Refresh(parties);
    }

    public Window Win 
    {
        get => win;
    }
}