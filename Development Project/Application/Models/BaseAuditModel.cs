namespace Application.Models;

public class BaseAuditModel
{
    public required DateTime CreatedAt { get; set; }
    public required string CreatedBy { get; set; }
    public DateTime? ModifiedAt { get; set; }
    public string? ModifiedBy { get; set; }
    public DateTime? DeletedAt { get; set; }
    public string? DeletedBy { get; set; }
}
