using PropertyChanger.Tests.Infrastructure.Mp3Files;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyChanger.Tests.Infrastructure
{
    public class A
    {
        public static ModelDataAnnotationCheckBuilder ModelDataAnnotationCheck => new ModelDataAnnotationCheckBuilder();
    }

    public class An
    {
        public static MP3FileBuilder MP3File => new MP3FileBuilder();
    }
}
