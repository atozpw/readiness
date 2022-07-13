namespace ReadinessIntelligenceApi.Models
{
    public class Plan : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool IsSubmitted { get; set; } = false;
    }
}