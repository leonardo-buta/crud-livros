using Livros.Application.Interfaces;
using Livros.Application.Services;
using Livros.Bus;
using Livros.Data.Repository;
using Livros.Data.UoW;
using Livros.Domain.CommandHandlers;
using Livros.Domain.Commands;
using Livros.Domain.Core.Bus;
using Livros.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Livros.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Domain Bus (Mediator)
            services.AddScoped<IMediatorHandler, InMemoryBus>();

            // ASP.NET Authorization Polices
            //services.AddSingleton<IAuthorizationHandler, ClaimsRequirementHandler>();

            // Application
            services.AddScoped<ILivroAppService, LivroAppService>();

            // Domain - Commands
            services.AddScoped<IRequestHandler<RegisterNewLivroCommand, bool>, LivroCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateLivroCommand, bool>, LivroCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveLivroCommand, bool>, LivroCommandHandler>();

            // Infra - Data
            services.AddScoped<ILivroRepository, LivroRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // Infra - Identity
            //services.AddScoped<IUser, AspNetUser>();
            //services.AddSingleton<IJwtFactory, JwtFactory>();
        }
    }
}
