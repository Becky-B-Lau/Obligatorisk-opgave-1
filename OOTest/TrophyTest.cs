using Obligatorisk_opgave;

namespace OOTest
{
    [TestClass]
    public class TrophyTest
    {
        public Trophy _trophy = new() { Id = 1, Competition = "Test", Year = 2021 };
        public Trophy _nullCompetitionTrophy = new() { Id = 2, Competition= null, Year = 1969 };
        public Trophy _shortCompetitionTrophy = new() { Id = 3, Competition = "Te", Year = 1970 };
        public Trophy _tooLowYearTrophy = new() { Id = 4, Competition = "Test2", Year = 1969 };
        public Trophy _tooHighYearTrophy = new() { Id = 5, Competition = "Test3", Year = 2130 };

            
        [TestMethod]
        public void ToStringTest()
        {
            Assert.AreEqual("Id: 1, Competition: Test, Year: 2021", _trophy.ToString());
        }

        [TestMethod]
        public void ValidateCompetitionTest()
        {
            _trophy.ValidateCompetition();
            Assert.ThrowsException<ArgumentException>(() => _nullCompetitionTrophy.ValidateCompetition());
            Assert.ThrowsException<ArgumentException>(() => _shortCompetitionTrophy.ValidateCompetition());
        }

        [TestMethod]
        public void ValidateYearTest()
        {
            _trophy.ValidateYear();
            Assert.ThrowsException<ArgumentException>(() => _tooLowYearTrophy.ValidateYear());
            Assert.ThrowsException<ArgumentException>(() => _tooHighYearTrophy.ValidateYear());
        }

        [TestMethod]
        public void ValidateTest()
        {
            _trophy.Validate();
        }

    }
}