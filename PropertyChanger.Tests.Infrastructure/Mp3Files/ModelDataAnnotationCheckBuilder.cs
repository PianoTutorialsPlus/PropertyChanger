using PropertyChanger.Services.CommonServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyChanger.Tests.Infrastructure.Mp3Files
{
    public class ModelDataAnnotationCheckBuilder : TestDataBuilder<ModelDataAnnotationCheck>
    {
        public override ModelDataAnnotationCheck Build()
        {
            return new ModelDataAnnotationCheck();
        }
    }
}
