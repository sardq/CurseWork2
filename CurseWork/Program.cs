using BuisinessLogic.BusinessLogic;
using BusinessLogic.OfficePackage.Implements;
using BusinessLogic.OfficePackage;
using Contracts.BusinessLogicContracts;
using Contracts.BusinessLogicsContracts;
using Contracts.StorageContracts;
using Contracts.StoragesContracts;
using ElectronicShopBusinessLogic.BusinessLogics;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using System;

namespace Views
{
	internal static class Program
	{
		private static ServiceProvider? _serviceProvider;
		public static ServiceProvider? ServiceProvider => _serviceProvider;
		/// <summary>
		///  The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			// To customize application configuration such as set high DPI settings or default font,
			// see https://aka.ms/applicationconfiguration.
			ApplicationConfiguration.Initialize();
			var services = new ServiceCollection();
			ConfigureServices(services);
			_serviceProvider = services.BuildServiceProvider();
			Application.Run(_serviceProvider.GetRequiredService<FormAuthorization>());
		}
		private static void ConfigureServices(ServiceCollection services)
		{
			services.AddLogging(option =>
			{
				option.SetMinimumLevel(LogLevel.Information);
				option.AddNLog("nlog.config");
			});
			services.AddTransient<IDepartmentStorage, DepartmentStorage>();
			services.AddTransient<IOrderStorage, OrderStorage>();
			services.AddTransient<IGrantStorage, GrantStorage>();
			services.AddTransient<IClientStorage, ClientStorage>();
			services.AddTransient<IParticipantStorage, ParticipantStorage>();
			services.AddTransient<IScientificWorkStorage, ScientificWorkStorage>();
			services.AddTransient<ITeacherStorage, TeacherStorage>();


			services.AddTransient<IDepartmentLogic, DepartmentLogic>();
			services.AddTransient<IOrderLogic, OrderLogic>();
			services.AddTransient<IGrantLogic, GrantLogic>();
			services.AddTransient<IParticipantLogic, ParticipantLogic>();
			services.AddTransient<IClientLogic, ClientLogic>();
			services.AddTransient<IScientificWorkLogic, ScientificWorkLogic>();
			services.AddTransient<ITeacherLogic, TeacherLogic>();

			services.AddTransient<AbstractSaveToPdf, SaveToPdf>();

			services.AddTransient<FormAuthorization>();
			services.AddTransient<FormRegister>();
			services.AddTransient<FormMain>();
		}
	}
}