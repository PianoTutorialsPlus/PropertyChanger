using PropertyChanger.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyChanger.Tests.Infrastructure.Mp3Files
{
    public class MP3FileBuilder : TestDataBuilder<MP3File>
    {
        private string _name;
        private string _title;
        private int _titleNumber;

        public MP3FileBuilder() : this("01 - Test.mp3","Test",01)
        {
        }

        public MP3FileBuilder(
            string name, 
            string title, 
            int titleNumber)
        {
            _name = name;
            _title = title;
            _titleNumber = titleNumber;
        }

        public override MP3File Build()
        {
            return new MP3File
            {
                Name = _name,
                Title = _title,
                TitleNumber = _titleNumber
            };
        }
    }
}
