using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyChanger.View.Contracts
{
    public interface IMainView
    {
        List<string> Files { get; set; }
        List<string[]> Properties { get; set; }

        event Action<string[]> OnFileOpened;
        event Action OnPropertiesChanged;
    }
}
