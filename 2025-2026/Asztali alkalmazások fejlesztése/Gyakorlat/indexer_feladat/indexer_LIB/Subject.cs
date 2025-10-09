using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace indexer_LIB
{
    public class Subject
    {
        public string Name { get; init; }
        public int ID { get; init; }

        public Subject(string name, int id)
        {
            this.Name = name;
            this.ID = id;
        }
    }
}