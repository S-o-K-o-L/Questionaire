﻿using Microsoft.AspNetCore.Mvc;

namespace Questionnaire.WebAPI.AppConfiguration.ServicesExtensions
{

    public static partial class ServicesExtensions
    {
        /// <summary>
        /// Configure versioning
        /// </summary>
        /// <param name="services"></param>
        public static void AddVersioningConfiguration(this IServiceCollection services)
        {
            services.AddVersionedApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });

            services.AddApiVersioning(options =>
            {
                options.ReportApiVersions = true;
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new ApiVersion(1, 0);
            });
        }
    }

}