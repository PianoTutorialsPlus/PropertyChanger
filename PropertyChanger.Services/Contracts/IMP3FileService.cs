using PropertyChanger.Model.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyChanger.Services.Contracts
{
    public interface IMP3FileService
    {
        void ChangeProperty();
        IEnumerable<IMP3File> GetAllFiles();
        void LoadFile(string file);
    }
}
