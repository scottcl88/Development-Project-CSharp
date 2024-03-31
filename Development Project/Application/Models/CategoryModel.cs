namespace Application.Models;

public class CategoryModel : BaseAuditModel
{
    public int Id { get; set; }
    public string? Name { get; set; }

    // Foreign key
    public int? ParentCategoryId { get; set; }
    public required CategoryModel ParentCategory { get; set; }
}
