using PropertyChanger.DataAccess;
using PropertyChanger.Services;
using PropertyChanger.Services.CommonServices;
using PropertyChanger.Services.Contracts;
using System;
using System.Windows.Forms;

namespace PropertyChanger.Presenter
{
    internal class RootComposition
    {
        private MainView _mainView;
        private MP3FileService _mp3FileService;
        private MP3DataRepository _mp3FileRepository;
        private ModelDataAnnotationCheck _modelDataAnnotationCheck;

        public RootComposition()
        {
            SetupMainScreen();

            Application.Run(_mainView);
        }

        private void SetupMainScreen()
        {
            _mainView = new MainView();
            _mp3FileRepository = new MP3DataRepository();
            _modelDataAnnotationCheck = new ModelDataAnnotationCheck();
            _mp3FileService = new MP3FileService(_mp3FileRepository,_modelDataAnnotationCheck);
            var mainScreenPresenter = new PropertyChangerPresenter(_mp3FileService, _mainView);
        }
    }
}