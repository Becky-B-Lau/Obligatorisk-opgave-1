using Obligatorisk_opgave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace OOTest
{
    [TestClass]
    public class TrophiesRepositoryTest
    {
        private TrophiesRepository _list;

        private Trophy _trophy = new() { Id = 1, Competition = "Test", Year = 2021 };
        private Trophy _badTrophy = new() { Competition="null", Year = 1969 };


        [TestInitialize]
        public void Init()
        {
            _list = new TrophiesRepository();

            _list.Add(new Trophy() { Year= 2022, Competition = "Swimming"});
            _list.Add(new Trophy() { Year = 2021, Competition = "Running" });
            _list.Add(new Trophy() { Year = 2020, Competition = "Cycling" });
            _list.Add(new Trophy() { Year = 2015, Competition = "Basketball" });
            _list.Add(new Trophy() { Year = 2013, Competition = "Volleyball" });
            _list.Add(new Trophy() { Year = 2003, Competition = "Fencing" });
            _list.Add(new Trophy() { Year = 2002, Competition = "Archery" });
            _list.Add(new Trophy() { Year = 1999, Competition = "Shooting" });
            _list.Add(new Trophy() { Year = 1998, Competition = "Boxing" });
        }

        [TestMethod]
        public void GetTest()
        {
            Assert.AreEqual(9, _list.GetAll().Count);
        }

        [TestMethod]
        public void TestAdd()
        {
            Assert.AreEqual(9, _list.GetAll().Count);
            _list.Add(_trophy);
            Assert.AreEqual(10, _list.GetAll().Count);
        }

        [TestMethod]
        public void TestAddBadTrophy()
        {
            Assert.ThrowsException<ArgumentException>(() => _list.Add(_badTrophy));
        }

        [TestMethod]
        public void TestGetAll()
        {
            Assert.AreEqual(9, _list.GetAll().Count);
        }

        [TestMethod]
        public void TestGetById()
        {
            Assert.AreEqual("Swimming", _list.GetById(1).Competition);
            Assert.AreEqual("Running", _list.GetById(2).Competition);
            Assert.AreEqual("Cycling", _list.GetById(3).Competition);
            Assert.AreEqual("Basketball", _list.GetById(4).Competition);
            Assert.AreEqual("Volleyball", _list.GetById(5).Competition);
            Assert.AreEqual("Fencing", _list.GetById(6).Competition);
            Assert.AreEqual("Archery", _list.GetById(7).Competition);
            Assert.AreEqual("Shooting", _list.GetById(8).Competition);
            Assert.AreEqual("Boxing", _list.GetById(9).Competition);
        }

        [TestMethod]
        public void TestDelete()
        {
            Assert.AreEqual(9, _list.GetAll().Count);
            _list.Delete(1);
            Assert.AreEqual(8, _list.GetAll().Count);
        }

        [TestMethod]
        public void TestUpdate()
        {
            Trophy trophy = new Trophy() { Competition = "Unknown", Year = 2000 };
            _list.Update(1, trophy);
            Assert.AreEqual("Unknown", _list.GetById(1).Competition);
        }

    }
}
