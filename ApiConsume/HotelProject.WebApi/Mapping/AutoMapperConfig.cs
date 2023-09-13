using AutoMapper;
using HotelProject.DtoLayer.Dtos.RoomDto;
using HotelProject.EntityLayer.Concrete;

namespace HotelProject.WebApi.Mapping
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            //This part matching dto and classes which are in etities
            CreateMap<AddRoomDto, Room>();
            CreateMap<Room, AddRoomDto>();

            // If I use REverse so we no need more to write one sentecen down for reversing
            CreateMap<UpdateRoomDto, Room>().ReverseMap();
            
        }
    }
}
