namespace Infrastructure.Entities;

public class ProductEntity : BaseAuditEntity
{
    public int Id { get; set; }
    public required string Name { get; set; }

    public List<MetadataEntity>? Metadata { get; set; }
    public List<CategoryEntity>? Categories { get; set; }

}
