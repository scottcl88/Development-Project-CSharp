namespace Application.Models;

public class ProductModel : BaseAuditModel
{
    public int Id { get; set; }
    public required string Name { get; set; }

    public List<MetadataModel>? Metadata { get; set; }
    public List<CategoryModel>? Categories { get; set; }

}
