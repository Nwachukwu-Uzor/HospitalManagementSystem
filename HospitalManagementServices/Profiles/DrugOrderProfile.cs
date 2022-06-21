using AutoMapper;
using HospitalManagementDomain.Models;
using HospitalManagementServices.Dtos.Outgoing.DrugOrder;

namespace HospitalManagementServices.Profiles
{
    public class DrugOrderProfile : Profile
    {
        public DrugOrderProfile()
        {
            CreateMap<DrugOrder, DrugOrderDto>()
                .ForMember(dest => dest.StaffName, opt => opt.MapFrom(src => $"{src.Staff.FirstName} {src.Staff.LastName}"))
                .ForMember(dest => dest.StaffId, opt => opt.MapFrom(src => src.Staff.IdentificationNumber))
                .ForMember(dest => dest.Drug, opt => opt.MapFrom(src => src.Drug.Name))
                .ForMember(dest => dest.UnitPrice, opt => opt.MapFrom(src => src.Drug.Price));
        }
    }
}
