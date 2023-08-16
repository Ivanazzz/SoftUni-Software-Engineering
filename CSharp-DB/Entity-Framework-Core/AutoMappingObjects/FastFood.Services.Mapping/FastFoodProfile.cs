namespace FastFood.Services.Mapping
{
    using AutoMapper;

    using Models;
    using Web.ViewModels.Categories;
    using Web.ViewModels.Items;
    using Web.ViewModels.Positions;

    public class FastFoodProfile : Profile
    {
        public FastFoodProfile()
        {
            // Positions
            CreateMap<CreatePositionInputModel, Position>()
                .ForMember(d => d.Name, opt => opt.MapFrom(src => src.PositionName));

            CreateMap<Position, PositionsAllViewModel>()
                .ForMember(d => d.Name, opt => opt.MapFrom(src => src.Name));

            // Category
            CreateMap<CreateCategoryInputModel, Category>()
                .ForMember(d => d.Name, opt => opt.MapFrom(src => src.CategoryName));

            CreateMap<Category, CategoryAllViewModel>();
            
            // Items
            CreateMap<Category, CreateItemViewModel>()
                .ForMember(d => d.CategoryId, opt => opt.MapFrom(src => src.Id))
                .ForMember(d => d.CategoryName, opt => opt.MapFrom(src => src.Name));

            CreateMap<CreateItemInputModel, Item>();

            CreateMap<Item, ItemsAllViewModel>()
                .ForMember(d => d.Category, opt => opt.MapFrom(src => src.Category.Name));
        }
    }
}
