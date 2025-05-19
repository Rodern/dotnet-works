using AutoMapper;
using BridgeMall.Models.DTOs;
using BridgeMall.Models.Relational;

namespace BridgeMall.Models.Profiles
{
	public class ModelsProfile: Profile
	{
		public ModelsProfile()
		{
			CreateMap<Category, CategoryDTO>();
			CreateMap<CategoryDTO, Category>();

			CreateMap<Password, PasswordDTO>();
			CreateMap<PasswordDTO, User>();

			CreateMap<Product, ProductDTO>();
			CreateMap<ProductDTO, Product>();

			CreateMap<User, UserDTO>();
			CreateMap<UserDTO, User>();
			
			CreateMap<UserToken, UserTokenDTO>();
			CreateMap<UserTokenDTO, UserToken>();
		}
	}
}
