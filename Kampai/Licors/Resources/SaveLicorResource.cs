using System.ComponentModel.DataAnnotations;

namespace Kampai.Licors.Resources;

public class SaveLicorResource
{
    [Required]
    public int Id { get; set; }
    [Required]
    [MaxLength(50)]
    public String name { get; set; }
    [Required]
    public String description { get; set; }
    [Required]
    public int price { get; set; }
}