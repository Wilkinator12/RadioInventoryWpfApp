using RadioInventoryLibrary.DataAccess;
using RadioInventoryLibrary.DatabaseAccess;
using RadioInventoryLibrary.Factories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddRadioInventoryServices(this IServiceCollection services)
        {
            services.AddTransient<ISqlDatabaseAccess, SqlDatabaseAccess>();
            services.AddTransient<IDataAccess, SqlDataAccess>();
            services.AddTransient<IDepartmentRadioTemplateFactory, DepartmentRadioTemplateFactory>();
            services.AddTransient<IRadioFactory, RadioFactory>();

            return services;
        }
    }
}
