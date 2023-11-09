using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TilloBrand.Data.IRepositories;
using TilloBrand.Data.Repositories;
using TilloBrand.Domain.Entities;
using TilloBrand.Service.DTOs.Assets;
using TilloBrand.Service.DTOs.Products;
using TilloBrand.Service.DTOs.Users;
using TilloBrand.Service.Exceptions;
using TilloBrand.Service.Interfaces;

namespace TilloBrand.Service.Services;

public class ProductService : IProductService
{
    private readonly IMapper _mapper;
    private readonly IRepository<Product> _productRepository;
    private readonly IFileUploadService _fileUploadService;
    public ProductService(IMapper mapper, IRepository<Product> productRepository, IFileUploadService fileUploadService)
    {
        this._mapper = mapper;
        this._productRepository = productRepository;
        _fileUploadService = fileUploadService;
    }
    public async Task<ProductForResultDto> CreateAsync(ProductForCreationDto dto)
    {
        var data = await this._productRepository.SelectAll().
            Where(p => p.Name.ToLower() == dto.Name.ToLower()).
            FirstOrDefaultAsync();
        if(data is not null)
            throw new CustomException(409,"Product is already exist");

        var AssetDetails = new AssetForCreationDto()
        {
            FolderPath = "Product",
            FormFile = dto.Image,
        };
        var SavedFile = await this._fileUploadService.FileUploadAsync(AssetDetails);
        var MappedData = this._mapper.Map<Product>(dto);
        MappedData.Image = SavedFile.AssetPath;
        var result = await this._productRepository.InsertAsync(MappedData);
        return this._mapper.Map<ProductForResultDto>(result);
    }

    public async Task<IEnumerable<ProductForResultDto>> GetAllAsync()
    {
        var data = await this._productRepository.SelectAll().AsNoTracking().ToListAsync();
        foreach (var info in data)
        {
            if (info.Image != null)
            {
                info.Image = $"https://localhost:7016/{info.Image.Replace('\\', '/').TrimStart('/')}";
            };
        }
        return this._mapper.Map<IEnumerable<ProductForResultDto>>(data);
    }

    public async Task<ProductForResultDto> GetByIdAsync(long id)
    {
        var data = await this._productRepository.SelectByIdAsync(id);
        if (data is null)
            throw new CustomException(404, "Product is not found");
            if (data.Image != null)
            {
                data.Image = $"https://localhost:7016/{data.Image.Replace('\\', '/').TrimStart('/')}";
            }
            return this._mapper.Map<ProductForResultDto>(data);
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var data = await this._productRepository.SelectByIdAsync(id);
        if (data is null)
            throw new CustomException(404, "Product is not found");
        await this._fileUploadService.DeleteFileAsync(data.Image);
        return await this._productRepository.DeleteAsync(id);
    }

    public async Task<ProductForResultDto> UpdateAsync(long id, ProductForUpdateDto dto)
    {
        var CheckingData = await _productRepository.SelectAll().Where(e => e.Id == id).FirstOrDefaultAsync();
        if (CheckingData != null)
        {
            await _fileUploadService.DeleteFileAsync(CheckingData.Image);

            var NewImageUploadMapping = new AssetForCreationDto()
            {
                FolderPath = "Product",
                FormFile = dto.Image,
            };

            var NewImageUpload = await this._fileUploadService.FileUploadAsync(NewImageUploadMapping);
            var MappedData = this._mapper.Map(dto, CheckingData);  
            MappedData.UpdatedAt = DateTime.UtcNow;
            MappedData.Image = NewImageUpload.AssetPath;

            var result = await this._productRepository.UpdateAsync(CheckingData);

            return this._mapper.Map<ProductForResultDto>(result);

        }
        throw new CustomException(404, "NotFound");

    }
}
