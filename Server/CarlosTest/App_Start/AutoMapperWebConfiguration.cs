using AutoMapper;
using CarlosTest.Dtos;
using DataDB.Models;

namespace CarlosTest.App_Start
{
    public static class AutoMapperWebConfiguration
    {
        public static IMapper Mapper;
        public static void Configure()
        {
            var config = new MapperConfiguration(cfg =>
            {
                #region User
                cfg.CreateMap<User, UserDto>()
               .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.Name))
               .ForMember(dest => dest.UserPassword, opt => opt.MapFrom(src => src.Password))
               .ReverseMap();
                #endregion

                #region Feed
                cfg.CreateMap<Feed, FeedDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.FeedName));
                #endregion

                #region FeedItem
                cfg.CreateMap<FeedItem, FeedItemDto>()
               .ForMember(dest => dest.ParentName, opt => opt.MapFrom(src => src.Feed.FeedName))
               .ForMember(dest => dest.ParentImage, opt => opt.MapFrom(src => src.Feed.Image));

                #endregion

            });
           Mapper = config.CreateMapper();

        }
    }
}