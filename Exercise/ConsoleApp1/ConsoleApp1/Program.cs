using System;
using System.Collections.Generic;
using System.Xml.Linq;

class Student
{
    public string Name { get; set; }
    public int ID { get; set; }
    public double GPA { get; set; }

    public Student(string name, int id, double gpa)
    {
        Name = name;
        ID = id;
        GPA = gpa;
    }


    public override string ToString()
    {
        return $"Name: {Name}, ID: {ID}, GPA: {GPA:F2}";
    }
}
class StudentManager
{
    private List<Student> students;

    public StudentManager()
    {
        students = new List<Student>();
    }

    public void AddStudent(Student student)
    {
        students.Add(student);
    }
    public void Remove(int id)
    {
        students.RemoveAll(x => x.ID == id);
    }
    public bool Update(int id, string name, double gpa)
    {
        Student student = students.Find(x => x.ID == id);
        if (student != null)
        {
            student.Name = name;
            student.GPA = gpa;
            return true;
        }
        return false;
    }
    public Student SearchStudent(int id)
    {
        return students.Find(x => x.ID == id);
    }

    public void PrintStudents()
    {
        foreach (Student student in students)
        {
            Console.WriteLine(student);
        }
    }
    class Test
    {
        static void Main()
        {
            StudentManager manager = new StudentManager();
            Console.WriteLine("Print all Student ");
            manager.AddStudent(new Student("Gia Phu", 1, 8.56));
            manager.AddStudent(new Student("Gia Bao", 2, 7.0));
            manager.AddStudent(new Student("Gia Minh", 3, 6.5));
            manager.PrintStudents();
            

            manager.Remove(2);

            Console.WriteLine("Removing student ");
            Console.WriteLine("List student after remove ");
            manager.PrintStudents();

            if (manager.Update(1, "Le Gia Phu", 9.9))
            {
                Console.WriteLine("Student updated successfully.");
            }
            else
            {
                Console.WriteLine("Student not found.");
            }
            manager.PrintStudents();

            var student = manager.SearchStudent(2);
            if (student != null)
            {
                Console.WriteLine(student);
            }
            else
            {
                Console.WriteLine("Student not found.");
            }
            var student1 = manager.SearchStudent(3);
            if (student1 != null)
            {
                Console.WriteLine(student1);
            }
            else
            {
                Console.WriteLine("Student not found.");
            }
        }
    }

}