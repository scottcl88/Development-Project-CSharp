namespace Application.Models;

public class MetadataModel : BaseAuditModel
{
    public int Id { get; set; }
    public string Key { get; set; }
    public string Value { get; set; }
    // Foreign key
    public int ProductId { get; set; }
    public required ProductModel Product { get; set; }
}
