using Autofac;
using CarsMultilayer.CarMakeRepository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsMultilayer.CarMakeRepository
{
    public class CarMakeRepositoryModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CarMakeRepositories>()
                    .As<ICarMakeRepository>()
                    .WithParameter("connectionString", "Server=localhost;port=5432;User Id=postgres;Password=admin;Database=cars")
                    .InstancePerDependency();
        }
    }
}
