namespace ReadinessIntelligenceApi.Models
{
    public class PriorityActionDetail: BaseEntity
    {
        public int Id { get; set; }
        public int PriorityActionId { get; set; }
        public string Action { get; set; } = string.Empty;
        public int EstimatedCost { get; set; }
        public DateOnly? EstimatedPeriod { get; set; }
        public string File { get; set; } = string.Empty;
    }
}