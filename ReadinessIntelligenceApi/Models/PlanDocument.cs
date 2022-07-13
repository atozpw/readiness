namespace ReadinessIntelligenceApi.Models
{
    public class PlanDocument: BaseEntity
    {
        public int Id { get; set; }
        public int PlanId { get; set; }
        public int PlanTypeId { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Size { get; set; }
        public string File { get; set; } = string.Empty;
    }
}