
using BusinessLogicLayer.Services.Concrete;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace BusinessLogicLayer.Utilities.Extensions;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddBusinessConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddFluentValidationAutoValidation(opt =>
        {
            opt.DisableDataAnnotationsValidation = true;
            opt.ImplicitlyValidateChildProperties = true;
        }).AddFluentValidationClientsideAdapters();
        services.AddControllersWithViews();
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IAccountService, AccountManager>();
        services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();

        services.AddScoped<IBlogService, BlogManager>();
        services.AddScoped<ITagService, TagManager>();
        services.AddScoped<IReviewService, ReviewManager>();
        services.AddScoped<ISavedItemService, SavedItemManager>();
        services.AddScoped<IRoleService, RoleManager>();


        services.AddAuthentication();
        services.AddAuthorization();
        services.AddDbContext<AppDbContext>(opt =>
        {
            opt.UseSqlServer(configuration.GetConnectionString("Default"));
        });
        services.AddIdentity<AppUser, IdentityRole>().AddEntityFrameworkStores<AppDbContext>();
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        return services;
    }
}