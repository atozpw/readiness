namespace ReadinessIntelligenceApi.Models
{
    public class DraftResponse: BaseEntity
    {
        public int Id { get; set; }
        public string Action { get; set; } = string.Empty;
        public int EstimatedCost { get; set; }
        public bool IsSelected { get; set; } = false;
        public int? DomainId { get; set; }
        public int PlanId { get; set; }
        public int? PlanTypeId { get; set; }
        public DateOnly? EstimatedPeriod { get; set; }
        public bool IsMerged { get; set; } = false;
    }
}