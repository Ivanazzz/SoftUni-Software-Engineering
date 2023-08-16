namespace ProductShop
{
    using AutoMapper;

    using DTOs.Import;
    using Models;
    using ProductShop.DTOs.Export;

    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {
            // User
            CreateMap<ImportUserDTO, User>();

            // Product
            CreateMap<ImportProductDTO, Product>();
            CreateMap<Product, ExportProductInRangeDTO>()
                .ForMember(d => d.ProductName, opt => opt.MapFrom(src => src.Name))
                .ForMember(d => d.ProductPrice, opt => opt.MapFrom(src => src.Price))
                .ForMember(d => d.SellerName, opt => opt.MapFrom(src => $"{src.Seller.FirstName} {src.Seller.LastName}"));

            // Category
            CreateMap<ImportCategoryDTO, Category>();

            // CategoryProduct
            CreateMap<ImportCategoryProductDTO, CategoryProduct>();
        }
    }
}
