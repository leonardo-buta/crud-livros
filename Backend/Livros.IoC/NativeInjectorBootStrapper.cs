using Livros.Application.Interfaces;
using Livros.Application.Services;
using Livros.Authentication.Authorization;
using Livros.Authentication.Services;
using Livros.Bus;
using Livros.Data.Repository;
using Livros.Data.UoW;
using Livros.Domain.CommandHandlers;
using Livros.Domain.Commands;
using Livros.Domain.Core.Bus;
using Livros.Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;

namespace Livros.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // (Mediator)
            services.AddScoped<IMediatorHandler, InMemoryBus>();

            // Authorization
            services.AddSingleton<IAuthorizationHandler, ClaimsRequirementHandler>();

            // Application
            services.AddScoped<ILivroAppService, LivroAppService>();

            // Commands
            services.AddScoped<IRequestHandler<RegisterNewLivroCommand, bool>, LivroCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateLivroCommand, bool>, LivroCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveLivroCommand, bool>, LivroCommandHandler>();

            // Data
            services.AddScoped<ILivroRepository, LivroRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // JWT
            services.AddSingleton<IJwtFactory, JwtFactory>();
        }
    }
}
