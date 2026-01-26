using AutoManage.Application.Commands;
using AutoManage.Application.Interfaces.Commands;
using AutoManage.Application.Interfaces.Queries;
using AutoManage.Application.Queries;
using AutoManage.Domain.Interfaces.Repositories;
using AutoManage.Domain.Interfaces.UnitOfWork;
using AutoManage.Domain.Notifications;
using AutoManage.Infra.CrossCutting.Notifications;
using AutoManage.Infra.Data.Context;
using AutoManage.Infra.Data.Repositories;
using AutoManage.Infra.Data.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AutoManage.Infra.CrossCutting.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAutoManageDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AutoManageContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("AutoManageConnection")));

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IDomainNotificationHandler, DomainNotificationHandler>();

            services.AddScoped<IOwnerRepository, OwnerRepository>();
            services.AddScoped<ISellerRepository, SellerRepository>();
            services.AddScoped<IVehicleRepository, VehicleRepository>();
            services.AddScoped<ISaleRepository, SaleRepository>();

            services.AddScoped<IOwnerCommand, OwnerCommand>();
            services.AddScoped<ISellerCommand, SellerCommand>();
            services.AddScoped<IVehicleCommand, VehicleCommand>();
            services.AddScoped<ISaleCommand, SaleCommand>();

            services.AddScoped<IOwnerQuery, OwnerQuery>();
            services.AddScoped<ISellerQuery, SellerQuery>();
            services.AddScoped<IVehicleQuery, VehicleQuery>();
            services.AddScoped<ISaleQuery, SaleQuery>();

            return services;
        }
    }
}
