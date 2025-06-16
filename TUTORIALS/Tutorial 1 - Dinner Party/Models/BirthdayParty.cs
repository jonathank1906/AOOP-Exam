using System.Collections.Generic;

public class BirthdayParty : Party 
{
    public string CakeSize { get; set; }
    public string CakeFlavor { get; set; }
    public static List<string> CakeSizeOptions { get; } = new List<string> { "Small", "Medium", "Large" };

    public override decimal CalculateCost()
    {   
        decimal totalCost = base.CalculateCost();
        totalCost += CakeSize switch {
            "Small" => 112M,
            "Medium" => 210M,
            "Large" => 350M,
            _ => 0
        };
        return totalCost;
    }
}