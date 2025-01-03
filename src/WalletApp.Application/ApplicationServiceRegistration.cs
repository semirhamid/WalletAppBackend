﻿using System.Reflection;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using WalletApp.Application.DTOs.TransactionDTOs.Validators;


namespace WalletApp.Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(Assembly.GetExecutingAssembly());
        services.AddValidatorsFromAssemblyContaining<CreateTransationDtoValidator>(ServiceLifetime.Transient);
            
        return services;
    }
    
}