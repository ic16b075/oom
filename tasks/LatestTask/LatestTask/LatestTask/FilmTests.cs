using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace LatestTask
{
    [TestFixture]
    class FilmTests
    {
        [Test]
        public void CanCreateFilm()
        {
            var x = new Film("TestName", 42.24, 1992);

            Assert.IsTrue(x.Title == "TestName");
            Assert.IsTrue(x.GetPrice() == 42.24);
            Assert.IsTrue(x.Release_year == 1992);
        }

        [Test]
        public void CannotCreateFilmWithNullTitle1()
        {
            Assert.Catch(() =>
            {
                var x = new Film(null, 42.24, 1992);
            });
        }

        [Test]
        public void CannotCreateFilmWithNullTitle2()
        {
            Assert.Catch(() =>
            {
                var x = new Film("", 42.24, 1992);
            });
        }

        [Test]
        public void CannotCreateFilmWithWhiteSpaceTitle()
        {
            Assert.Catch(() =>
            {
                var x = new Film(" ", 42.24, 1992);
            });
        }
        
        [Test]
        public void CheckValidReleaseYear()
        {
            Assert.Catch(() =>
            {
                var x = new Film("TestName", 42.24, 1887);
            });
        }
        
        [Test]
        public void CheckValidPrice()
        {
            Assert.Catch(() =>
            {
                var x = new Film("TestName", -42.24, 1992);
            });
        }
    }
}
