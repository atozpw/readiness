namespace ReadinessIntelligenceApi.Models
{
    public class MergeDraftResponse : BaseEntity
    {
        public int Id { get; set; }
        public int? DraftResponseId { get; set; }
        public int? PlanTypeId { get; set; }
    }
}