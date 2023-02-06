using PropertyChanger.Model.Contracts;
using PropertyChanger.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyChanger.Services
{
    public class MP3FileService : IMP3FileService
    {
        private IMP3FilesRepository _mP3FilesRepository;
        private IModelDataAnnotationCheck _modelDataAnnotationCheck;


        public MP3FileService(
            IMP3FilesRepository mP3FilesRepository,
            IModelDataAnnotationCheck modelDataAnnotationCheck)
        {
            _mP3FilesRepository = mP3FilesRepository;
            _modelDataAnnotationCheck = modelDataAnnotationCheck;
        }

        public void ChangeProperty()
        {
            _mP3FilesRepository.ChangeProperties();
        }

        public IEnumerable<IMP3File> GetAllFiles()
        {
            return _mP3FilesRepository.GetAllFiles();
        }

        public void LoadFile(string path)
        {
            _mP3FilesRepository.LoadFile(path);
            string filename = _mP3FilesRepository.GetFileName(path);
            _mP3FilesRepository.AddFileToChangedList(filename);

            IMP3File file = _mP3FilesRepository.Create(filename);
            Add(file);
        }

        private void Add(IMP3File file)
        {
            ValidateModel(file);
            _mP3FilesRepository.Add(file);
        }

        private void ValidateModel(IMP3File file)
        {
            _modelDataAnnotationCheck.ValidateModelDataAnnotations(file);
        }

    }
}
