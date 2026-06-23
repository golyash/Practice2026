namespace task02;

public class StudentService
{
    private readonly List<Student> _students;

    public StudentService(List<Student> students) => _students = students;

    public IEnumerable<Student> GetStudentsByFaculty(string faculty)
    {
        var result = from student in _students
                  where student.Faculty == faculty
                  select student;
        return result;
    }

    public IEnumerable<Student> GetStudentsWithMinAverageGrade(double minAverageGrade)
    {
        var result = from student in _students
                  where student.Grades.Average() >= minAverageGrade
                  select student;
        return result;
    }

    public IEnumerable<Student> GetStudentsOrderedByName()
    {
        var result = from student in _students
                  orderby student.Name
                  select student;
        return result;
    }

    public ILookup<string, Student> GroupStudentsByFaculty()
    {
        var result = from student in _students
                  group student by student.Faculty into facultyGroup
                  from student in facultyGroup
                  select student;
        return result.ToLookup(student => student.Faculty);
    }

    public string GetFacultyWithHighestAverageGrade()
    {
        var result = from student in _students
                  group student by student.Faculty into facultyGroup
                  orderby facultyGroup.Average(student => student.Grades.Average()) descending
                  select facultyGroup.Key;
        return result.First();
    }
}
