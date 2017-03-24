using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LatestTask
{
    [TestFixture]

    class SeasonTest
    {
        [Test]
        public void CanCreateSeason()
        {
            var x = new Season("TestName", 1, 13.37, 2020, true);

            Assert.IsTrue(x.Title == "TestName");
            Assert.IsTrue(x.GetStatus() == true);
            Assert.IsTrue(x.Release_year == 2020);
            Assert.IsTrue(x.Season_number == 1);
        }

        [Test]
        public void CheckValidSeasonNumber()
        {
            Assert.Catch(() =>
            {
                var x = new Season("TestName", 0, 13.37, 2020, true);
            });
        }
    }
}
