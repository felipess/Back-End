using Stocks.Data;
using Stocks.Data.Dtos;
using Stocks.Models;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc; 
namespace Stocks.Controllers;

[ApiController]
[Route("[controller]")]
public class StocksController : ControllerBase 
{

    private StockContext _context;
    private IMapper _mapper;
    public StocksController(StockContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult AddStock(
        [FromBody] CreateStockDto stockDto)
    {
        Stock stock = _mapper.Map<Stock>(stockDto); 

        _context.Stocks.Add(stock);
        _context.SaveChanges();

        return CreatedAtAction(nameof(GetTicker),
            new { ticker = stock.Ticker },
            stock);
    }

    [HttpGet]
    public IEnumerable<ReadStockDto> GetStocks(
        [FromQuery] int skip = 0,
        [FromQuery] int take = 50) 
    {
        return _mapper.Map<List<ReadStockDto>>(_context.Stocks
            .Skip(skip)
            .Take(take)); 
    }

    [HttpGet("{ticker}")] 
    public IActionResult GetTicker(string ticker) 
    {
        var stock = _context.Stocks.FirstOrDefault(stock => stock.Ticker == ticker);

        if (stock == null) return NotFound();
        var stockDto = _mapper.Map<ReadStockDto>(stock);
        return Ok(stockDto);
    }

    [HttpPut("{ticker}")]
    public IActionResult UpdateStock(string ticker, 
        [FromBody] UpdateStockDto stockDto)
    {
        var stock = _context.Stocks.FirstOrDefault(
            stock => stock.Ticker == ticker);
        if (stock == null) return NotFound(); 
        _mapper.Map(stockDto, stock); 
        _context.SaveChanges();
        return NoContent(); 
    }

    [HttpPatch("{ticker}")]
    public IActionResult UpdateStockPartial(string ticker, 
        JsonPatchDocument<UpdateStockDto> patch)

    {
        var stock = _context.Stocks.FirstOrDefault(
            stock => stock.Ticker == ticker);
        if (stock == null) return NotFound();

        var stockToUpdate = _mapper.Map<UpdateStockDto>(stock);
        patch.ApplyTo(stockToUpdate, ModelState);
        if (!TryValidateModel(stockToUpdate))
        {
            return ValidationProblem(ModelState);
        }
        _mapper.Map(stockToUpdate, stock);
        _context.SaveChanges();
        return NoContent(); 
    }

    [HttpDelete("{ticker}")]
    public IActionResult DeleteStock(string ticker)
    {
        var stock = _context.Stocks.FirstOrDefault(
            stock => stock.Ticker == ticker);
        if (stock == null) return NotFound();

        _context.Remove(stock);
        _context.SaveChanges();
        return NoContent();
    }
}
