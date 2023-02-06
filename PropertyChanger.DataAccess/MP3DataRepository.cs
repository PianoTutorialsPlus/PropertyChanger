using ATL;
using PropertyChanger.Model;
using PropertyChanger.Model.Contracts;
using PropertyChanger.Services.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyChanger.DataAccess
{
    public class MP3DataRepository : IMP3FilesRepository
    {
        private List<IMP3File> _mP3Files= new List<IMP3File>();
        private List<IMP3File> _mP3FilesChanged = new List<IMP3File>();
        private List<Track> _trackList = new List<Track>();

        public void ChangeProperties()
        {
            foreach(Track track in _trackList)
            {
                track.Title = _mP3FilesChanged[_trackList.IndexOf(track)].Title;
                track.TrackNumber = _mP3FilesChanged[_trackList.IndexOf(track)].TitleNumber;
                track.Save();
            }
            _mP3Files = _mP3FilesChanged;
        }

        public IEnumerable<IMP3File> GetAllFiles()
        {
            return _mP3Files;
        }

        public void LoadFile(string path)
        {
            AddTrackToTracklist(path);
        }
        private void AddTrackToTracklist(string path)
        {
            Track track = new Track(path);
            _trackList.Add(track);
        }

        public void AddFileToChangedList(string filename)
        {
            var titleName = filename.Remove(0, 5).Split('.');
            var titleNumber = filename.Remove(3);

            var file = new MP3File
            {
                Name = filename,
                Title = titleName[0],
                TitleNumber = int.Parse(titleNumber)
            };

            _mP3FilesChanged.Add(file);
        }

        public string GetFileName(string path)
        {
            return Path.GetFileName(path);
        }

        public IMP3File Create(string filename)
        {
            return new MP3File
            {
                Name = filename,
                Title = _trackList.Last().Title,
                TitleNumber = (int)_trackList.Last().TrackNumber
                

            };
        }

        public void Add(IMP3File file)
        {
            _mP3Files.Add(file);
        }
    }
}
