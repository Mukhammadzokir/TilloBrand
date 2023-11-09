using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TilloBrand.Data.IRepositories;
using TilloBrand.Domain.Entities;
using TilloBrand.Service.DTOs.Markets;
using TilloBrand.Service.Exceptions;
using TilloBrand.Service.Interfaces;

namespace TilloBrand.Service.Services;

public class MarketService : IMarketService
{
    private readonly IMapper _mapper;
    private readonly IRepository<Market> _marketRepository;

    public MarketService(IMapper mapper, IRepository<Market> marketRepository)
    {
        this._mapper = mapper;
        this._marketRepository = marketRepository;
    }

    public async Task<MarketForResultDto> CreateAsync(MarketForCreationDto dto)
    {
        var data = await this._marketRepository.SelectAll().
              Where(m => m.Name.ToLower() == dto.Name.ToLower()).
              FirstOrDefaultAsync();
        if (data is not null)
            throw new CustomException(409, "Market is already exist");
        var mappedMarket = this._mapper.Map<Market>(dto);
        var result = await this._marketRepository.InsertAsync(mappedMarket);
        return this._mapper.Map<MarketForResultDto>(result);
    }

    public async Task<IEnumerable<MarketForResultDto>> GetAllAsync()
    {
        var data = await this._marketRepository.SelectAll().AsNoTracking().ToListAsync();
        return this._mapper.Map<IEnumerable<MarketForResultDto>>(data);
    }

    public async Task<MarketForResultDto> GetByIdAsync(long id)
    {
        var data = await this._marketRepository.SelectByIdAsync(id);
        if (data is null)
            throw new CustomException(404, "Market is not found");
        return this._mapper.Map<MarketForResultDto>(data);
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var data = await this._marketRepository.SelectByIdAsync(id);
        if (data is null)
            throw new CustomException(404, "Market is not found");
        return await this._marketRepository.DeleteAsync(id);
    }

    public async Task<MarketForResultDto> UpdateAsync(long id, MarketForUpdateDto dto)
    {
        var data = await this._marketRepository.SelectAll().
            Where(m => m.Id == id).
            FirstOrDefaultAsync();
        if (data is null)
            throw new CustomException(404, "Market is not found");
        var mappedMarket = this._mapper.Map(dto, data);
        var result = await this._marketRepository.UpdateAsync(mappedMarket);
        return this._mapper.Map<MarketForResultDto>(result);
    }
}
