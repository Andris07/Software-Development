using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace indexer_LIB
{
    public class School
    {
        private List<Student> students = new List<Student>();
        private List<Subject> subjects = new List<Subject>();

        public void addStudent(string name, int id, Dictionary<Subject, List<int>> subjectsWithGrades)
        {
            students.Add(new Student(name, id, subjectsWithGrades));
        }

        public void addSubject(string name, int id)
        {
            subjects.Add(new Subject(name, id));
        }

        public Student this[int id] => students.First(x => x.ID == id);
        public Subject this[string name] => subjects.First(x => x.Name == name);
    }
}