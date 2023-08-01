using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using MyWebBank.Application.Validators;
using System.Reflection;

namespace MyWebBank.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services.AddValidatorsFromAssemblyContaining<CardDtoValidator>();
            services.AddValidatorsFromAssemblyContaining<CreateCardDtoValidator>();
            services.AddValidatorsFromAssemblyContaining<UpdateCardDtoValidator>();
            services.AddValidatorsFromAssemblyContaining<AccountDtoValidator>();
            services.AddValidatorsFromAssemblyContaining<TransactionDtoValidator>();
            services.AddValidatorsFromAssemblyContaining<MakeTransactionDtoValidator>();

            return services;
        }
    }
}
