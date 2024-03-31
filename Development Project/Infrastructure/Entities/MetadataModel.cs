namespace Infrastructure.Entities;

public class MetadataEntity : BaseAuditEntity
{
    public int Id { get; set; }
    public string Key { get; set; }
    public string Value { get; set; }
    // Foreign key
    public int ProductId { get; set; }
    public required ProductEntity Product { get; set; }
}
