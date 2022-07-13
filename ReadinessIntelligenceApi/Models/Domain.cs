namespace ReadinessIntelligenceApi.Models
{
    public class Domain: BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public ICollection<DraftResponse>? DraftResponses { get; }
    }
}