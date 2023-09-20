using System.ComponentModel.DataAnnotations;

namespace Stocks.Models;
public class Stock
{
    [Key]
    [Required(ErrorMessage ="Ticker is Required")]
    [MaxLength(30, ErrorMessage = "Maximum length 30 characters")]
    public string Ticker { get; set; }
    public string? Name { get; set; }

    [Required]
    [MaxLength(30)]
    public string Type { get; set; }
    public string? Sector { get; set; }
    public string? Subsector { get; set; }

    [Required(ErrorMessage = "Segment is Required")]
    [MaxLength(50)]
    public string Segment { get; set; }
}
