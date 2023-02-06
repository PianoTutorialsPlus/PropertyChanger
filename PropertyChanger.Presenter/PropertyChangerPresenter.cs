using PropertyChanger.Model.Contracts;
using PropertyChanger.Services;
using PropertyChanger.Services.Contracts;
using PropertyChanger.View.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyChanger.Presenter
{
    public class PropertyChangerPresenter
    {
        private IMP3FileService _mp3FileService;
        private IMainView _mainView;

        public PropertyChangerPresenter(
            IMP3FileService mp3FileService, 
            IMainView mainView)
        {
            _mp3FileService = mp3FileService;
            _mainView = mainView;

            ConnectEvents();
            RefreshFiles();
        }

        private void RefreshFiles()
        {
            var files = _mp3FileService.GetAllFiles();

            _mainView.Files = files != null
                ? files.Select(file => file.Name).ToList()
                : new List<string>();

            List<string[]> test = new List<string[]>();

            foreach (IMP3File file in files)
            {
                test.Add(new string[]
                {
                    file.TitleNumber.ToString(),
                    file.Title
                });
            }

            _mainView.Properties = test;
            //_mainView.Properties = files != null
            //    ? files.Select(file => file.Title).ToList()
            //    : new List<string>();
        }

        private void ConnectEvents()
        {
            _mainView.OnFileOpened += OpenFiles;
            _mainView.OnPropertiesChanged += ChangeProperty;
        }

        private void ChangeProperty()
        {
            _mp3FileService.ChangeProperty();
            RefreshFiles();
        }

        private void OpenFiles(string[] paths)
        {
            foreach (string path in paths)
            {
                _mp3FileService.LoadFile(path);
            }
            
            RefreshFiles();
        }
    }
}
