using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorisk_opgave
{
    public class Trophy
    {
        public int Id { get; set; }
        public string Competition { get; set; }
        public int Year { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}, Competition: {Competition}, Year: {Year}";
        }

        public void ValidateCompetition()
        {
            if (Competition == null)
            {
                throw new ArgumentException("Competition name must be filled out");
            }
            if (Competition.Length < 3)
            {
                throw new ArgumentException("Competition name must be at least 3 characters long");
            }

        }

        public void ValidateYear()
        {
            if (Year < 1970 || Year > DateTime.Now.Year)
            {
                throw new ArgumentException("Year must be between 1970 and the current year");
            }
        }

        public void Validate()
        {
            ValidateCompetition();
            ValidateYear();
        }
    }

}
