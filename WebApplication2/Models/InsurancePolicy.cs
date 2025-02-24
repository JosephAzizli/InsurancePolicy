namespace WebApplication2.Models
{
    public class InsurancePolicy
    {
            public int Id { get; set; }
            public string PolicyNumber { get; set; }
            public string PolicyHolderName { get; set; }
            public string PolicyType { get; set; }
            public DateTime StartDate { get; set; }
            public DateTime EndDate { get; set; }
            public decimal Amount { get; set; }

    }
}
