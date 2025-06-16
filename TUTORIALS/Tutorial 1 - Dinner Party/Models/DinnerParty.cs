public class DinnerParty : Party 
{
    public bool IsHealthy { get; set; }

    public override decimal CalculateCost() 
    {
        decimal totalCost = base.CalculateCost();
        totalCost += NumberOfPeople * (IsHealthy ? 35.00M : 145.00M);
        totalCost *= IsHealthy ? 0.95m : 1; // 5% discount
        return totalCost;
    }
}