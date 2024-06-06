using Autofac;
using CarsMultilayer.CarsRepository.Common;
using CarsMultilayer.CarsRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarsMultilayer.CarService.Common;

namespace CarsMultilayer.CarService
{
    public class CarServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CarServiceClass>()
                    .As<ICarService>()
                    .InstancePerDependency();
        }
    }
}
