using Autofac;
using CarsMultilayer.CarsRepository.Common;
using CarsMultilayer.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsMultilayer.CarsRepository
{
    public class CarRepositoryModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CarsRepositoryClass>()
                    .As<ICarsRepository>()
                    .WithParameter("connectionString", "Server=localhost;port=5432;User Id=postgres;Password=admin;Database=cars")
                    .InstancePerDependency();
        }
    }
}
