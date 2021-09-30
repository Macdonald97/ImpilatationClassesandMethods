using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edith
{
    class Program
    {
        public class Student

        {


            public string FirstName { get; set; }

        public string LastName { get; set; }



        public Student(string firstName, string lastName)

        {

            this.FirstName = firstName;

            this.LastName = lastName;

        }



        public string Name

        {

            get

            {

                return this.FirstName + " " + this.LastName;

            }

        }



        public override string ToString()

        {

            return "Student: " + this.Name;

        }

    }





    public class Group

    {

        public string Name { get; set; }

        public List<Student> Students { get; set; }

        public Teacher Teacher { get; set; }



        public Group(string name)

        {

            this.Name = name;

            this.Students = new List<Student>();

        }



        public override string ToString()

        {

            StringBuilder groupAsString = new StringBuilder();

            groupAsString.AppendLine("Group name: " + this.Name);

            groupAsString.Append("Students in the group: " +

                string.Join(", ", this.Students.Select(s => s.Name)));

            if (this.Teacher != null)

            {

                groupAsString.Append("\nGroup : " +

                    this.Teacher.Name);

            }

            return groupAsString.ToString();

        }

    }



    public class Teacher

    {

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public List<Group> Groups { get; set; }



        public Teacher(string firstName, string lastName)

        {

            this.FirstName = firstName;

            this.LastName = lastName;

            this.Groups = new List<Group>();

        }



        public string Name

        {

            get

            {

                return this.FirstName + " " + this.LastName;

            }

        }



        public override string ToString()

        {

            StringBuilder teacherAsString = new StringBuilder();

            teacherAsString.AppendLine("Teacher name: " + this.Name);

            teacherAsString.Append("Groups of this teacher: " +

                string.Join(", ", this.Groups.Select(s => s.Name)));

            return teacherAsString.ToString();

        }

    }
        public class School

        {

            public string Name { get; set; }

            public List<Teacher> Teachers { get; set; }

            public List<Group> Groups { get; set; }

            public List<Student> Students { get; set; }



            public School(string name)

            {

                this.Name = name;

                this.Teachers = new List<Teacher>();

                this.Groups = new List<Group>();

                this.Students = new List<Student>();

            }



            public override string ToString()

            {

                StringBuilder schoolAsString = new StringBuilder();

                schoolAsString.AppendLine("School name: " + this.Name);

                schoolAsString.AppendLine("Lectures: " +

                    string.Join(", ", this.Teachers.Select(s => s.Name)));

                schoolAsString.AppendLine("Students: " +

                    string.Join(", ", this.Students.Select(s => s.Name)));

                schoolAsString.Append("Groups: " +

                    string.Join(", ", this.Groups.Select(s => s.Name)));

                foreach (var teacher in this.Teachers)

                {

                    schoolAsString.Append("\n---------------------------------------------\n");

                    schoolAsString.Append(teacher);

                }

                foreach (var group in this.Groups)

                {

                    schoolAsString.Append("\n-----------------------------------------------\n");

                    schoolAsString.Append(group);

                }

                foreach (var student in this.Students)

                {

                    schoolAsString.Append("\n---\n");

                    schoolAsString.Append(student);

                }

                return schoolAsString.ToString();

            }

        }

        static void Main(string[] args)
        {


            // Create a few students

            Student studentMzotho = new Student("Mzotho", "Shamba");

            Student studentNgcobo = new Student("Ngcobo", "Mandy");

            Student studentKhumalo = new Student("Khumalo", "Itumeleng");

            Student studentTambo = new Student("Tambo", "David");



            // Create a group and add a few students to it

            Group groupJAvaProgramming = new Group("Java Programming");

            groupJAvaProgramming.Students.Add(studentMzotho);

            groupJAvaProgramming.Students.Add(studentTambo);

            groupJAvaProgramming.Students.Add(studentKhumalo);

            groupJAvaProgramming.Students.Add(studentNgcobo);



            // Create a group and add a few students to it

            Group groupAdvanceDataStructure = new Group("Advance Data Structure");

            groupAdvanceDataStructure.Students.Add(studentKhumalo);

            groupAdvanceDataStructure.Students.Add(studentMzotho);



            // Create a teacher and assign it to few groups

            Teacher teacherRaymond = new Teacher("Raymond", "Walters");

            teacherRaymond.Groups.Add(groupJAvaProgramming);

            teacherRaymond.Groups.Add(groupAdvanceDataStructure);

            groupJAvaProgramming.Teacher = teacherRaymond;

            groupAdvanceDataStructure.Teacher = teacherRaymond;



            // Create another teacher and a group he teaches

            Teacher teacherProminent = new Teacher("Prominent", "Mugariri");

            Group groupPython = new Group("Python");

            groupPython.Students.Add(studentTambo);

            groupPython.Students.Add(studentKhumalo);

            groupPython.Teacher = teacherProminent;

            teacherProminent.Groups.Add(groupPython);



            // Create a school with few students, groups and teachers

            School school = new School("Richield Intitution of Technology ");

            school.Students.Add(studentMzotho);

            school.Students.Add(studentNgcobo);

            school.Students.Add(studentKhumalo);

            school.Students.Add(studentTambo);

            school.Groups.Add(groupJAvaProgramming);

            school.Groups.Add(groupAdvanceDataStructure);

            school.Groups.Add(groupPython);

            school.Teachers.Add(teacherRaymond);

            school.Teachers.Add(teacherProminent);



            // Modify some of the groups, student and teachers

            groupJAvaProgramming.Name = "JAva Programming";

            groupJAvaProgramming.Students.RemoveAt(0);

            studentMzotho.LastName = "White";

            teacherRaymond.LastName = "Shamba";



            // Print the school

            Console.WriteLine(school);
            Console.ReadKey();
        }
    }
}
