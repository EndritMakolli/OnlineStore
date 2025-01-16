using Application.Products;
using Application.Core;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Application.Interfaces;
using FluentValidation.AspNetCore;
using FluentValidation;
using API.Services;
using Application.OrderAggregate;


namespace API.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services,
            IConfiguration config)
        {
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddDbContext<DataContext>(opt => // now we've got access to this particular method (AddDbContext) and we tell it about what class we're using (DataContext)
            {
                opt.UseSqlite(config.GetConnectionString("DefaultConnection")); //  we're going to specify that we want to use SQL lights, our database needs a connection string.
            });
            services.AddCors(opt =>
            {
                opt.AddPolicy("CorsPolicy", policy =>
                {
                    policy.AllowAnyMethod().AllowAnyHeader().WithOrigins("http://localhost:3000");
                });
            });
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(List.Handler).Assembly)); // adding the mediaR service
            services.AddAutoMapper(typeof(MappingProfiles).Assembly);
            services.AddFluentValidationAutoValidation();
            services.AddValidatorsFromAssemblyContaining<Create>();

            // Add AdvancedOrderProcessor and related services
            
            services.AddScoped<IPaymentService, PaymentService>();
            services.AddScoped<INotificationService, NotificationService>();
            services.AddScoped<AdvancedOrderProcessor>();
            services.AddScoped<IInventoryService, InventoryService>();

            return services;
        }
    }
}
