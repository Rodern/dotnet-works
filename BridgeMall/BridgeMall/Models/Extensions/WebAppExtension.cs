using Microsoft.EntityFrameworkCore;
using BridgeMall.Models.CRUD;
using BridgeMall.Contexts.RDB;
using BridgeMall.Models.Profiles;
using BridgeMall.Models.Configuration;
using BridgeMall.Contexts;

namespace BridgeMall.Models.Extensions
{
    public static class WebAppExtension
	{
		public static string GetConnectionString(this IConfiguration configuration)
		{
			string currentConnectionStringName = configuration.GetRequiredSection("CurrentConnectionString").Value!;
			return configuration.GetConnectionString(currentConnectionStringName)!;
		}

		public static void AddModels(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddDbContext<BridgeMallDbContext>(options =>
			{
				options.UseMySQL(GetConnectionString(configuration));
			});

            // Register Utility classes
            services.AddScoped<HostUrls>(sp => {
                string currentHost = configuration.GetRequiredSection("CurrentHostUrl").Value!;
                var hostUrl = configuration.GetRequiredSection(nameof(HostUrls)).Get<HostUrls>()!;
                hostUrl.CurrentBase = configuration.GetSection(nameof(HostUrls))[currentHost]!;
                hostUrl.Current = $"{hostUrl.CurrentBase}/api";
                return hostUrl;
            });

            services.AddScoped<ServerAppDataFolders>(sp => new(configuration.GetRequiredSection(nameof(ServerAppDataFolders)).Get<ServerAppDataFolders>()!));
            services.AddScoped<AppInfo>(sp =>
            {
                return configuration.GetRequiredSection(nameof(AppInfo)).Get<AppInfo>()!;
            });
            services.AddScoped<JwtConfig>(sp =>
            {
                return configuration.GetRequiredSection(nameof(JwtConfig)).Get<JwtConfig>()!;
            });
            services.AddScoped<AppStorageContext>();

            services.AddAutoMapper(configAction =>
			{
				configAction.AddProfile<ModelsProfile>();
			});


			services.AddScoped<ICrud, Crud>();

		}
	}
}
