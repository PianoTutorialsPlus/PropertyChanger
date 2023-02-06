using NUnit.Framework;
using NUnit.Framework.Internal;
using PropertyChanger.Model;
using PropertyChanger.Services.CommonServices;
using PropertyChanger.Tests.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyChanger.Tests.ServiceLayer
{
    public class ModelDataAnnotationCheckTests
    {
        public class TheValidateModelDataAnnotationMethod
        {
            [TestCase("ab - Test.mp3")]
            [TestCase("0b - Test.mp3")]
            [TestCase("b0 - Test.mp3")]
            [TestCase("01- Test.mp3")]
            [TestCase("01 -Test.mp3")]
            [TestCase("01 Test.mp3")]
            public void Given_MP3File_When_Checked_Then(string name)
            {
                MP3File file = An.MP3File;
                file.Name = name;

                ModelDataAnnotationCheck annotationCheck = A.ModelDataAnnotationCheck;
                Assert.Throws<ArgumentException>(() => annotationCheck.ValidateModelDataAnnotations(file));

            }
            [TestCase("01 - TestäÖü.mp3")]
            [TestCase("01 - T e st.mp3")]
            [TestCase("01 - ... Test`s.mp3")]
            public void Given_MP3File_When_Checked_Then2(string name)
            {
                MP3File file = An.MP3File;
                file.Name = name;

                ModelDataAnnotationCheck annotationCheck = A.ModelDataAnnotationCheck;

                Assert.DoesNotThrow(() => annotationCheck.ValidateModelDataAnnotations(file));

            }
        }
    }
}
