namespace Infrastructure.Entities;

public class CategoryEntity : BaseAuditEntity
{
    public int Id { get; set; }
    public string? Name { get; set; }

    // Foreign key
    public int? ParentCategoryId { get; set; }
    public required CategoryEntity ParentCategory { get; set; }
}
