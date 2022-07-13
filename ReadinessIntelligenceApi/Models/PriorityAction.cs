namespace ReadinessIntelligenceApi.Models
{
    public class PriorityAction: BaseEntity
    {
        public int Id { get; set; }
        public int PlanId { get; set; }
        public int DomainId { get; set; }
    }
}