using System.Data.SqlClient;
using System.Web.Mvc;
using BusinessLayer.Services;
using DataAccessLayer.Repository;
using EmployeeTrainingRegistration.DataService;
using Unity;
using Unity.Mvc5;

namespace EmployeeTrainingRegistration
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IDataAccessLayer, EmployeeTrainingRegistration.DataService.DataAccessLayer>();
            container.RegisterType<ILoginService, LoginService>();
            container.RegisterType<ILoginRepository, LoginRepository>();
            container.RegisterType<IRegisterService, RegisterService>();
            container.RegisterType<IRegisterRepository, RegisterRepository>();
            container.RegisterType<ITrainingRepository, TrainingRepository>();
            container.RegisterType<ITrainingService, TrainingService>();
            container.RegisterType<IApplicationService, ApplicationService>();
            container.RegisterType<IApplicationRepository, ApplicationRepository>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));

        }
    }
}