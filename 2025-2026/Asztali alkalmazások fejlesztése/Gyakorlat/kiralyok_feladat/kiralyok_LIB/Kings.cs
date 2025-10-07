using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kiralyok_LIB
{
    public class Kings
    {
        List<King> kings = new List<King>();

        public Kings(IEnumerable<string> fileLines)
        {
            foreach (var fileLine in fileLines.Skip(1))
            {
                string[] row = fileLine.Split(";");
                int id = int.Parse(row[0]);
                string name = row[1];
                string? nickName = StringNullable(row[2]);
                int birthDate = int.Parse(row[3]);
                int deathDate = int.Parse(row[4]);
                string house = row[5];
                int startOfRuling = int.Parse(row[6]);
                int endOfRuling = int.Parse(row[7]);
                int? crowningDate = ParseNullable(row[8]);

                string? StringNullable(string inputString) => string.IsNullOrEmpty(inputString) ? null : inputString;
                int? ParseNullable(string inputNum) => string.IsNullOrEmpty(inputNum) ? null : int.Parse(inputNum);

                kings.Add(new King(id, name, nickName, birthDate, deathDate, house, startOfRuling, endOfRuling, crowningDate));
            }
        }

        public IEnumerable<King> kingsWhoRuledInThisCentury(int century) => kings.Where(x => x.CrowningDate >= (century - 1) * 100 && x.CrowningDate < (century) * 100);
        public IEnumerable<King> kingsOrderedByBirthdate() => kings.OrderByDescending(x => x.BirthDate).DistinctBy(x => x.Name);
        public IEnumerable<King> kingsSeperatedByAge(int age) => kings.Where(x => x.StartOfRuling - x.BirthDate < age).OrderBy(x => x.StartOfRuling - x.BirthDate).DistinctBy(x => x.Name);
        public IEnumerable<King> kingsWhoRuledTheMostByYears(int numberOfKings) => kings.OrderByDescending(x => x.EndOfRuling - x.StartOfRuling).Take(numberOfKings);
        public Dictionary<string, int> housesOrderedByHouseMembersCount() => kings.DistinctBy(x => x.Name).GroupBy(x => x.House).OrderByDescending(x => x.Count()).ToDictionary(x => x.Key, x => x.Count());
        public List<string> kingsWhoRuledBeforeBeingCrowded() => kings.Where(x => x.StartOfRuling < x.CrowningDate || x.CrowningDate == null).Select(x => x.Name).ToList();
        public IEnumerable<King> kingsWithNickNamesOrderedByName() => kings.Where(x => x.NickName != null).OrderByDescending(x => x.BirthDate);

        public void FileWrite(string fileName)
        {
            StreamWriter fileWrite = new StreamWriter(fileName);

            foreach (var king in kingsWithNickNamesOrderedByName())
            {
                fileWrite.Write($"{king.Name} ({king.NickName}) ");

                if (king.CrowningDate != null)
                {
                    fileWrite.WriteLine($"{king.CrowningDate}");
                }
                else
                {
                    fileWrite.WriteLine($"-");
                }
            }
            fileWrite.Close();
        }
    }
}
