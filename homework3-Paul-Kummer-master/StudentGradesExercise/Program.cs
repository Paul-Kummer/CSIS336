using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace StudentGradesExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            // cur proj director
            string projDir = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;

            // location of the csv file with student info
            string filePath = projDir + "\\AllStudents.csv";

            // location to ouput the new text files
            string outputPath = projDir + @"\Output\";

            // decompose the csv file into student objects and add them into a list
            var stuObjs = CreateStuList(filePath);

            // create text file of all students using student classes to string method for writing output
            CreateTxtOutOne(outputPath, stuObjs);

            // create text file and sort through students using linq to create output
            CreateTxtOutTwo(outputPath, stuObjs);  
        }

        static List<Student> CreateStuList(string csvPath)
        {
            var stuObjs = new List<Student>();

            string[] allStudentInfo = File.ReadAllLines(csvPath);

            foreach (string student in allStudentInfo)
            {
                string[] studentInfo = student.Split(',');

                var grades =
                    from grade in studentInfo.Skip(3)
                    where decimal.TryParse(grade, out decimal x) // returns bool, checking if it is parsable
                    select decimal.Parse(grade);

                string fName = studentInfo[0];
                string lName = studentInfo[1];
                int yearInSchool = int.TryParse(studentInfo[2], out int y) ? int.Parse(studentInfo[2]) : 0;

                stuObjs.Add(new Student(fName, lName, yearInSchool, grades));  
            }

            return stuObjs;
        }

        static void CreateTxtOutOne(string directoryToUse, IEnumerable<Student> stuArr)
        {
            var outputOne = File.CreateText(directoryToUse + "StudentLastNames.txt");

            var sortedStudent =
                from tmpStu in stuArr
                orderby tmpStu.LName ascending
                select tmpStu;

            foreach (Student stu in sortedStudent)
            {
                outputOne.WriteLine(stu);
            }

            outputOne.Close();
        }

        static void CreateTxtOutTwo(string directoryToUse, IEnumerable<Student> stuArr)
        {
            var outputTwo = File.CreateText(directoryToUse + "PassingStudentsByYearByGrade.txt");

            var sortedArr =
                from stu in stuArr
                where (int)stu.AvgLetterGrade() != 0
                orderby stu.SchoolProg descending, stu.AvgGradePercent() descending
                select stu;

            foreach (Student stu in sortedArr)
            {
                outputTwo.WriteLine(stu.AltString());
            }

            outputTwo.Close();
        }
    }
}
