using Stocks.Data.Dtos;
using Stocks.Models;
using AutoMapper;

namespace Stocks.Profiles;

public class StockProfile : Profile
{
    public StockProfile()
    {
        CreateMap<CreateStockDto, Stock>(); 
                                            
        CreateMap<UpdateStockDto, Stock>();
        
        CreateMap<Stock, UpdateStockDto>();
       
        CreateMap<Stock, ReadStockDto>();
    }
}
