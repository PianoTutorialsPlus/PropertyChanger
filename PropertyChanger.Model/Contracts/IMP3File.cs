using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyChanger.Model.Contracts
{
    public interface IMP3File
    {
        string Name { get; set; }
        string Title { get; set; }
        int TitleNumber { get; set; }
    }
}
