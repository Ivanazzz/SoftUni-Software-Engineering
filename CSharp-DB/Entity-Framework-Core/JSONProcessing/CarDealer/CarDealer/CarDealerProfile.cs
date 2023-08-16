namespace CarDealer
{
    using AutoMapper;

    using DTOs.Import;
    using Models;

    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            // Supplier
            CreateMap<ImportSupplierDTO, Supplier>();

            // Part
            CreateMap<ImportPartDTO, Part>();

            // Car
            CreateMap<ImportCarDTO, Car>();

            // Customer
            CreateMap<ImportCustomerDTO, Customer>();

            // Sale
            CreateMap<ImportSaleDTO, Sale>();
        }
    }
}
