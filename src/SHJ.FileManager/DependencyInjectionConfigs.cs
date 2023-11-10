using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using SHJ.FileManager.Contracts;
using SHJ.FileManager.Options;
using SHJ.FileManager.SQL;
using Microsoft.AspNetCore.StaticFiles;
namespace SHJ.FileManager;

public static class DependencyInjectionConfigs
{
    
    public static IServiceCollection AddFileManager(this IServiceCollection services,Action<FileManagerOptions> option)
    {
        services.Configure<FileManagerOptions>(option);
        services.AddScoped<IFileManagerService, FileManagerService>();
        return services;
    }

    

    /// <summary>
    /// 
    /// </summary>
    /// <param name="app"></param>
    /// <returns></returns>
    public static IApplicationBuilder UseFileManager(this IApplicationBuilder app)
    {
        
        return app;
    }
}
