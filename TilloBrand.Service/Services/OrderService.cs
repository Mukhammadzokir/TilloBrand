using AutoMapper;
using TilloBrand.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using TilloBrand.Data.IRepositories;
using TilloBrand.Service.Exceptions;
using TilloBrand.Service.Interfaces;
using TilloBrand.Service.DTOs.Orders;

namespace TilloBrand.Service.Services;

public class OrderService : IOrderService
{
    private readonly IRepository<Order> _orderRepository;
    private readonly IMapper _mapper;
    public OrderService(IMapper mapper, IRepository<Order> orderRepository)
    {
        this._mapper = mapper;
        this._orderRepository = orderRepository;
    }

    public async Task<OrderForResultDto> CreateAsync(OrderForCreationDto dto)
    {
        var data = await this._orderRepository.SelectAll().
            Where(o => o.UserId == dto.UserId).
            FirstOrDefaultAsync();
        if(data is not null)
            throw new CustomException(409,"Order is already exist");

        var mappedOrder = this._mapper.Map<Order>(dto);
        var result = await this._orderRepository.InsertAsync(mappedOrder);
        return this._mapper.Map<OrderForResultDto>(result);
    }

    public async Task<IEnumerable<OrderForResultDto>> GetAllAsync()
    {
        var data = await this._orderRepository.SelectAll().AsNoTracking().ToListAsync();
        return this._mapper.Map<IEnumerable<OrderForResultDto>>(data);
    }

    public async Task<OrderForResultDto> GetByIdAsync(long id)
    {
        var data = await this._orderRepository.SelectByIdAsync(id);
        if (data is null)
           throw new CustomException(404,"Order is not found");
        return this._mapper.Map<OrderForResultDto>(data);
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var data = await this._orderRepository.SelectByIdAsync(id);
        if (data is null)
            throw new CustomException(404,"Order is not found");
        return await this._orderRepository.DeleteAsync(id);
    }

    public async Task<OrderForResultDto> UpdateAsync(long id, OrderForUpdateDto dto)
    {
        var data = await this._orderRepository.SelectByIdAsync(id);
        if (data is null)
            throw new CustomException(404, "Order is not found");
        var mappedOrder = this._mapper.Map(dto, data);
        var result = await this._orderRepository.UpdateAsync(mappedOrder);
        return this._mapper.Map<OrderForResultDto>(result);
    } 
}
