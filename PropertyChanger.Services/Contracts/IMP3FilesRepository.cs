using PropertyChanger.Model.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyChanger.Services.Contracts
{
    public interface IMP3FilesRepository
    {
        IEnumerable<IMP3File> GetAllFiles();

        void LoadFile(string path);
        void ChangeProperties();
        string GetFileName(string path);
        void AddFileToChangedList(string filename);
        IMP3File Create(string filename);
        void Add(IMP3File file);
    }
}
