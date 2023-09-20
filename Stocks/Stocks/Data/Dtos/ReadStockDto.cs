using System.ComponentModel.DataAnnotations;

namespace Stocks.Data.Dtos;

public class ReadStockDto
{
    public string Ticker { get; set; }
    public string? Name { get; set; }
    public string Type { get; set; }
    public string? Sector { get; set; }
    public string? Subsector { get; set; }
    public string Segment { get; set; }
    public DateTime QueryTime { get; set;} = DateTime.Now;
}
