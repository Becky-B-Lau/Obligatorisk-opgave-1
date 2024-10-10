using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorisk_opgave
{
    public class TrophiesRepository
    {
        private int nextId = 1;
        private List<Trophy> trophies = new();

        public IEnumerable<Trophy> Get(int? YearAfter = null, string? competitionIncludes = null, string? sortBy = null)
        {
            IEnumerable<Trophy> result = new List<Trophy>(trophies);
            // Filtering
            if (YearAfter != null)
            {
                result = result.Where(a => a.Year > YearAfter);
            }
            if (competitionIncludes != null)
            {
                result = result.Where(a => a.Competition.Contains(competitionIncludes));
            }

            // Ordering aka. sorting
            if (sortBy != null)
            {
                sortBy = sortBy.ToLower();
                switch (sortBy)
                {
                    case "competition": // fall through to next case
                    case "competition_asc":
                        result = result.OrderBy(t => t.Competition);
                        break;
                    case "competition_desc":
                        result = result.OrderByDescending(t => t.Competition);
                        break;
                    case "year":
                    case "year_asc":
                        result = result.OrderBy(t => t.Year);
                        break;
                    case "year_desc":
                        result = result.OrderByDescending(t => t.Year);
                        break;
                    default:
                        break; // do nothing
                        //throw new ArgumentException("Unknown sort order: " + orderBy);
                }
            }
            return result;
        }

        public Trophy Add(Trophy trophy)
        {
            trophy.Id = nextId++;
            trophy.Validate();
            trophies.Add(trophy);
            return trophy;
        }

        public List<Trophy> GetAll()
        {
            return trophies;
        }

        public Trophy? GetById(int id)
        {
            return trophies.Find(trophy => trophy.Id == id);
        }

        public Trophy? Delete(int id)
        {
            Trophy? trophy = GetById(id);
            if (trophy == null)
            {
                return null;
            }
            trophies.Remove(trophy);
            return trophy;
        }

        public Trophy? Update(int id, Trophy trophy)
        {
            trophy.Validate();
            Trophy? existingTrophy = GetById(id);
            if (existingTrophy == null)
            {
                return null;
            }
            existingTrophy.Competition = trophy.Competition;
            existingTrophy.Year = trophy.Year;
            return existingTrophy;
        }
    }
}
