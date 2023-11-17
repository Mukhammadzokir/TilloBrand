using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TilloBrand.Data.IRepositories;
using TilloBrand.Domain.Entities;
using TilloBrand.Service.Configurations;
using TilloBrand.Service.DTOs.Users;
using TilloBrand.Service.Exceptions;
using TilloBrand.Service.Extensions;
using TilloBrand.Service.Interfaces;

namespace TilloBrand.Service.Services;

public class UserService : IRepository
{
    private readonly IMapper _mapper;
    private readonly IRepository<User> _userRepository;

    public UserService(IMapper mapper, IRepository<User> userRepository)
    {
        this._mapper = mapper;
        this._userRepository = userRepository;
    }
    public async Task<UserForResultDto> CreateAsync(UserForCreationDto dto)
    {
        var data = await this._userRepository.SelectAll().
            Where(e => e.Email == dto.Email && e.Password == dto.Password).
            FirstOrDefaultAsync();
        if(data is not null)
            throw new CustomException(409, "This User is already exist");    
        
        var MappedData = this._mapper.Map<User>(dto);
        var result = await this._userRepository.InsertAsync(MappedData);    
        return this._mapper.Map<UserForResultDto>(result);
        
    }

    public async Task<IEnumerable<UserForResultDto>> GetAllAsync(PaginationParams @params)
    {
        var data = await  this._userRepository
            .SelectAll()
            .AsNoTracking()
            .ToPagedList(@params)
            .ToListAsync();
        return this._mapper.Map<IEnumerable<UserForResultDto>>(data);

    }

    public async Task<UserForResultDto> GetByIdAsync(long id)
    {
        var data = await this._userRepository.SelectByIdAsync(id);
        if(data == null)
            throw new CustomException(404, "Not Found");
        return this._mapper.Map<UserForResultDto>(data);
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var data = await this._userRepository.SelectAll().Where(e => e.Id == id).FirstOrDefaultAsync();
        if (data == null)
            throw new CustomException(404, "Not Found");
        return await this._userRepository.DeleteAsync(id);
    }

    public async Task<UserForResultDto> UpdateAsync(long id, UserForUpdateDto dto)
    {
        var data = await this._userRepository.SelectAll().
            Where(e => e.Id == id).
            FirstOrDefaultAsync();
        if (data == null)
            throw new CustomException(404, "Not Found");
        var MappedData = this._mapper.Map(dto, data);
        var result = await this._userRepository.UpdateAsync(MappedData);
        return this._mapper.Map<UserForResultDto>(result);
    }
}
