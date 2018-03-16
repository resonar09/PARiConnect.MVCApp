using AutoMapper;

public class MappingsProfile : Profile
{
    public MappingsProfile()
    {
        CreateMap<CoreServiceDevReference.Client, PARiConnect.MVCApp.Models.Client>().ReverseMap();
        CreateMap<CoreServiceDevReference.ClientGroup, PARiConnect.MVCApp.Models.Group>().ReverseMap();
    }
}