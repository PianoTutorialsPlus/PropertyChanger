using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyChanger.Services.Contracts
{
    public interface IModelDataAnnotationCheck
    {
        void ValidateModelDataAnnotations<TDomainModel>(TDomainModel domainModel);
    }
}
