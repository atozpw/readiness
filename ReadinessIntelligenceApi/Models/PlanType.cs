namespace ReadinessIntelligenceApi.Models
{
    public class PlanType : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Year { get; set; }
    }
}