namespace AgentPlanner.Entities.Billing
{
    public class BillingRateConfiguration
    {
        public int Id { get; set; }
        public double NightTimePercentageIncrease { get; set; }
        public double WeekendPercentageIncrease { get; set; }
        public double HolidayPercentageIncrease { get; set; }
    }
}
