using System;

public abstract class Party : IComparable
{
    public Guid Id { get; } = Guid.NewGuid();
    protected const int CostOfFoodPerPerson = 180;
    public DateTime Date { get; set; }
    public int NumberOfPeople { get; set; }
    public bool IsFancy { get; set; } = false;
    public virtual decimal CalculateCost() 
    {
        decimal totalCost = NumberOfPeople * CostOfFoodPerPerson;
        totalCost += NumberOfPeople * (IsFancy ? 100.00M : 50.00M) + (IsFancy ? 300M : 200M);
        totalCost += NumberOfPeople >= 12 ? 100 : 0;
        return totalCost;
    }

    public override string ToString()
    {
        return $"{this.GetType()} on {Date.Date:d}";
    }

    public int CompareTo(object obj)
    {
        if (obj == null) return 1;

        Party otherParty = obj as Party;
        if (otherParty != null)
            return this.Date.CompareTo(otherParty.Date);
        else
            throw new ArgumentException("Object is not a Party");
    }
}