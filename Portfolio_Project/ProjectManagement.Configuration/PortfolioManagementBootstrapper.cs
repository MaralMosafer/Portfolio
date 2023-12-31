﻿using _1_PortfolioQuery.Contracts.BiographyModel;
using _1_PortfolioQuery.Contracts.EducationModel;
using _1_PortfolioQuery.Contracts.ExperienceModel;
using _1_PortfolioQuery.Contracts.InformationModel;
using _1_PortfolioQuery.Contracts.PortfolioCateoryModel;
using _1_PortfolioQuery.Contracts.PortfolioModel;
using _1_PortfolioQuery.Contracts.ServiceModel;
using _1_PortfolioQuery.Contracts.SkillModel;
using _1_PortfolioQuery.Query;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PortfolioManagement.Application;
using PortfolioManagement.Application.Contracts.Biography;
using PortfolioManagement.Application.Contracts.Education;
using PortfolioManagement.Application.Contracts.Experience;
using PortfolioManagement.Application.Contracts.Information;
using PortfolioManagement.Application.Contracts.Service;
using PortfolioManagement.Application.Contracts.Skill;
using PortfolioManagement.Application.Contracts.WorkSample;
using PortfolioManagement.Application.Contracts.WorkSampleCategory;
using PortfolioManagement.Domain.BiographyAgg;
using PortfolioManagement.Domain.EducationAgg;
using PortfolioManagement.Domain.ExperienceAgg;
using PortfolioManagement.Domain.InformationAgg;
using PortfolioManagement.Domain.ServiceAgg;
using PortfolioManagement.Domain.SkillAgg;
using PortfolioManagement.Domain.WorkSampleAgg;
using PortfolioManagement.Infrastructure.Repositories;
using ProjectManagement.Infrastructure;
using ProjectManagement.Infrastructure.Repositories;

namespace ProjectManagement.Configuration
{
    public class PortfolioManagementBootstrapper
    {
        public static void Configure(IServiceCollection services, string ConnectionString)
        {
            services.AddDbContext<PortfolioContext>(options =>
            {
                options.UseSqlServer(ConnectionString);
            });
            services.AddTransient<IInformationApplication, InformationApplication>();
            services.AddTransient<IInformationRepository, InformationRepository>();

            services.AddTransient<IBiographyApplication, BiographyApplication>();
            services.AddTransient<IBiographyRepository, BiographyRepository>();

            services.AddTransient<IEducationApplication, EducationApplication>();
            services.AddTransient<IEducationRepository, EducationRepository>();

            services.AddTransient<IExperienceApplication, ExperienceApplication>();
            services.AddTransient<IExperienceRepository, ExperienceRepository>();

            services.AddTransient<ISkillApplication, SkillApplication>();
            services.AddTransient<ISkillRepository, SkillRepository>();

            services.AddTransient<IServiceApplication, ServiceApplication>();
            services.AddTransient<IServiceRepository, ServiceRepository>();

            services.AddTransient<IWorkSampleCategoryApplication, WorkSampleCategoryApplication>();
            services.AddTransient<IWorkSampleCategoryRepository,  WorkSampleCategoryRepository>();

            services.AddTransient<IWorkSampleApplication, WorkSampleApplication>();
            services.AddTransient<IWorkSampleRepository, WorkSampleRepository>();

			services.AddTransient<IInformationQuery, InformationQuery>();
			services.AddTransient<IBiographyQuery, BiographyQuery>();
			services.AddTransient<IEducationQuery, EducationQuery>();
			services.AddTransient<IExperienceQuery, ExperienceQuery>();
			services.AddTransient<ISkillQuery, SkillQuery>();
			services.AddTransient<IServiceQuery, ServiceQuery>();
			services.AddTransient<IPortfolioQuery, PortfolioQuery>();
			services.AddTransient<ICategoryQuery, PortfolioCategoryQuery>();
		}
    }
}