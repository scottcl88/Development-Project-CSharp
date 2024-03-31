using Application.Models;

namespace Application.Requests;

public class UpdateProductRequest
{
    public required int Id { get; set; }
    public required string Name { get; set; }
    public List<MetadataModel>? Metadata { get; set; }
    public List<CategoryModel>? Categories { get; set; }
}
