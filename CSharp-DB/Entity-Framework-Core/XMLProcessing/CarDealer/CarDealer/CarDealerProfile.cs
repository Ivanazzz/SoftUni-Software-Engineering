namespace CarDealer
{
    using AutoMapper;
    using CarDealer.DTOs.Export;
    using DTOs.Import;
    using Models;
    using System.Globalization;

    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            // Supplier
            CreateMap<ImportSupplierDto, Supplier>();
            CreateMap<Supplier, ExportLocalSupplierDto>()
                .ForMember(d => d.PartsCount,
                    opt => opt.MapFrom(src => src.Parts.Count));

            // Part
            // ForMember mapping is done because one is nullable int and the other is not nullable int
            CreateMap<ImportPartDto, Part>()
                .ForMember(d => d.SupplierId,
                    opt => opt.MapFrom(src => src.SupplierId!.Value));
            CreateMap<Part, ExportCarPartDto>();

            // Car
            CreateMap<ImportCarDto, Car>()
                .ForSourceMember(src => src.Parts, opt => opt.DoNotValidate());
            CreateMap<Car, ExportCarDto>();
            CreateMap<Car, ExportCarBmwDto>();
            CreateMap<Car, ExportCarWithPartsDto>()
                .ForMember(d => d.Parts,
                    opt => opt.MapFrom(src => src.PartsCars
                        .Select(pc => pc.Part)
                        .OrderByDescending(p => p.Price)
                        .ToArray()));

            // Customer
            CreateMap<ImportCustomerDto, Customer>()
                .ForMember(d => d.BirthDate,
                    opt => opt.MapFrom(src => DateTime.Parse(src.BirthDate, CultureInfo.InvariantCulture)));

            // Sale
            CreateMap<ImportSaleDto, Sale>()
                .ForMember(d => d.CarId,
                    opt => opt.MapFrom(src => src.CarId!.Value));
        }
    }
}
