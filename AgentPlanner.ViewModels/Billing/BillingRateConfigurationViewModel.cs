namespace AgentPlanner.ViewModels.Billing
{
    public class BillingRateConfigurationViewModel
    {
        public int Id { get; set; }
        public double NightTimePercentageIncrease { get; set; }
        public double WeekendPercentageIncrease { get; set; }
        public double HolidayPercentageIncrease { get; set; }
    }
}