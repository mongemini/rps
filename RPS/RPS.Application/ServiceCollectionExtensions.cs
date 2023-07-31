using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using RPS.Application.Behaviors;
using RPS.Application.Services;
using RPS.Application.Validators;
using RPS.Contracts.Services;
using System.Reflection;

namespace RPS.Application
{
    public static class ServiceCollectionExtensions
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddValidatorsFromAssemblyContaining<JoinViewModelValidator>();

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ExceptionBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidatorBehavior<,>));

            services.AddTransient<IGamesService, GamesService>();
        }
    }
}
