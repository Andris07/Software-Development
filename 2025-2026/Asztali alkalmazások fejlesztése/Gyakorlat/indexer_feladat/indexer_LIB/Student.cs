namespace indexer_LIB
{
    public class Student
    {
        public string Name { get; init; }
        public int ID { get; init; }

        public Dictionary<Subject, List<int>> subjectsWithGrades = new();

        public Student(string name, int id, Dictionary<Subject, List<int>> grades)
        {
            this.Name = name;
            this.ID = id;
            this.subjectsWithGrades = grades;
        }

        public void addGradeToSubject(Subject subject, List<int> grades)
        {
            if (subjectsWithGrades.Any(x => x.Key == subject))
            {
                subjectsWithGrades[subject].AddRange(grades);
            }
            else
            {
                subjectsWithGrades.Add(subject, grades);
            }
        }

        public bool this[Subject subject] => subjectsWithGrades.TryAdd(subject, []) ? true : false;
    }
}