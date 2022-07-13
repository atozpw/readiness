namespace ReadinessIntelligenceApi.Models
{
    public class OnMerge: BaseEntity
    {
        public int Id { get; set; }
        public int? PlanTypeId { get; set; }
        public string Action { get; set; } = string.Empty;
        public int EstimatedCost { get; set; } = 0;
        public string? EstimatedPeriod { get; set; }
        public string File { get; set; } = string.Empty;
        public int? DraftResponseId { get; set; }
        public int? DomainId { get; set; }
    }
}