using AutoMapper;

namespace DenmarkExcursionsAPI.Profiles
{
    public class RegionsProfile : Profile
    {
        public RegionsProfile()
        {
            CreateMap<Models.Domain.Region, Models.DTO.Region>()
                .ReverseMap(); // En el caso de querer convertir desde DTO al Domain model
                // .ForMember(dest => dest.Id, options => options.MapFrom(src => src.RegionId);
                /* Para cuando la propiedad destino y la source no tienen el mismo nombre
                Se utiliza el ForMember para poder mapearlas correctamente*/
        }
    }
}
