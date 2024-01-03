using AutoMapper;
using API.Model;
using API.Model.Request;
using API.Model.Response;

namespace API.Map;

public class MapperProfile : Profile
{
	public MapperProfile() 
	{
		CreateMap<Category,CategoryResponse>();
		CreateMap<CategoryRequest, Category>();
	}
}