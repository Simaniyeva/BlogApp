using AutoMapper;

namespace BusinessLogicLayer.Utilities.Profiles;

public class Mapper : Profile
{
    public Mapper()
    {
        //Auth
        CreateMap<RegisterDto, AppUser>();
        CreateMap<LoginDto, UserGetDto>();
        CreateMap<AppUser, UserGetDto>().ReverseMap();


        //Blog
        CreateMap<Blog, BlogGetDto>();
        CreateMap<BlogPostDto, Blog>();
        CreateMap<BlogUpdateDto, Blog>()
            .ForMember(x => x.CreatedDate, opt => opt.MapFrom(src => DateTime.UtcNow));
        CreateMap<BlogGetDto, BlogUpdateDto>();

        //SavedItem
        CreateMap<SavedItem, SavedItemGetDto>();
        CreateMap<SavedItemPostDto, SavedItem>();
        CreateMap<SavedItemUpdateDto, SavedItem>();
        CreateMap<SavedItemGetDto, SavedItemUpdateDto>();

        //Tag
        CreateMap<Tag, TagGetDto>();
        CreateMap<TagPostDto, Tag>();
        CreateMap<TagUpdateDto, Tag>()
            .ForMember(x => x.CreatedDate, opt => opt.MapFrom(src => DateTime.UtcNow));
        CreateMap<TagGetDto, TagUpdateDto>();

        //BlogTag
        CreateMap<BlogTag, BlogTagGetDto>();
        CreateMap<BlogTagPostDto, BlogTag>();
        CreateMap<BlogTagUpdateDto, BlogTag>();
        CreateMap<BlogTagGetDto, BlogTagUpdateDto>();

        //Review
        CreateMap<Review, ReviewGetDto>();
        CreateMap<ReviewPostDto, Review>();
        CreateMap<ReviewUpdateDto, Review>()
            .ForMember(x => x.CreatedDate, opt => opt.MapFrom(src => DateTime.UtcNow));
        CreateMap<ReviewGetDto, ReviewUpdateDto>();

        //Role
        CreateMap<IdentityRole, RoleGetDto>();
        CreateMap<RolePostDto, IdentityRole>();
        CreateMap<RoleUpdateDto, IdentityRole>();
        CreateMap<RoleGetDto, RoleUpdateDto>();

    }
}
