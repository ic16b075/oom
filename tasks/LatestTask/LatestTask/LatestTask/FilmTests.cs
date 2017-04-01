using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace LatestTask
{
    [TestFixture]
    class FilmTests
    {
        [Test]
        public void CanCreateFilm()
        {
            var x = new Film("TestName", 42.24, 1992, true);

            Assert.IsTrue(x.Title == "TestName");
            Assert.IsTrue(x.Price == 42.24);
            Assert.IsTrue(x.Release_year == 1992);
            Assert.IsTrue(x.GetStatus() == true); 

        }

        [Test]
        public void CannotCreateFilmWithNullTitle1()
        {
            Assert.Catch(() =>
            {
                var x = new Film(null, 42.24, 1992, true);
            });
        }

        [Test]
        public void CannotCreateFilmWithNullTitle2()
        {
            Assert.Catch(() =>
            {
                var x = new Film("", 42.24, 1992, true);
            });
        }

        [Test]
        public void CannotCreateFilmWithWhiteSpaceTitle()
        {
            Assert.Catch(() =>
            {
                var x = new Film(" ", 42.24, 1992, true);
            });
        }
        
        [Test]
        public void CheckValidReleaseYear()
        {
            Assert.Catch(() =>
            {
                var x = new Film("TestName", 42.24, 1887, true);
            });
        }
        
        [Test]
        public void CheckValidPrice()
        {
            Assert.Catch(() =>
            {
                var x = new Film("TestName", -42.24, 1992, true);
            });
        }
    }
}
