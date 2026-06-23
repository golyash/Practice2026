namespace task02;

public class Student
{
    public string Name { get; set; }
    public string Faculty { get; set; } 
    public List<int> Grades { get; set; }

    public Student()
    {
        Name = "";
        Faculty = "";
        Grades = new List<int>();
    }
}
