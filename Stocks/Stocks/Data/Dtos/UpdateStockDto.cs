using System.ComponentModel.DataAnnotations;

namespace Stocks.Data.Dtos;
public class UpdateStockDto
{
    [Key]
    [Required(ErrorMessage = "Ticker is Required")]
    [StringLength(30, ErrorMessage = "Maximum length 30 characters")]
    public string Ticker { get; set; }
    public string? Name { get; set; }

    [Required]
    [StringLength(30)]
    public string Type { get; set; }
    public string? Sector { get; set; }
    public string? Subsector { get; set; }

    [Required(ErrorMessage = "Segment is Required")]
    [StringLength(50)]
    public string Segment { get; set; }

}
