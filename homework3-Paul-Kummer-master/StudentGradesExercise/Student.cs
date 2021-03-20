using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentGradesExercise
{
    class Student
    {
        public enum StudentLevel { New_Enroll, Freshman, Softmore, Junior, Senior}
        public enum LetterGrade { F , D , C , B , A }

        public Student(string fName, string lName, int stuYear, IEnumerable<decimal> grades)
        {
            FName = fName;
            LName = lName;
            SchoolProg = stuYear >= 0 && stuYear <= 4 ? (StudentLevel)stuYear : StudentLevel.New_Enroll;
            Grades = grades;
        }

        public string FName { get; set; }
        public string LName { get; set; }
        public StudentLevel SchoolProg { get; set; }
        public IEnumerable<decimal> Grades { get; private set; }

        public void NewGrade (decimal grade)
        {
            decimal[] tmpGrade = new decimal[] { grade };
            Grades = tmpGrade.Concat(Grades).ToArray();
        }

        public decimal AvgGradePercent() => Grades.Average();

        public LetterGrade AvgLetterGrade()
        {
            LetterGrade stuLetterGrade;

            switch ( (int)(AvgGradePercent()/10) ) // divide by 10 to truncate and give whole number
            {
                case 10:
                case 9:
                    stuLetterGrade = LetterGrade.A;
                    break;

                case 8:
                    stuLetterGrade = LetterGrade.B;
                    break;

                case 7:
                    stuLetterGrade = LetterGrade.C;
                    break;

                case 6:
                    stuLetterGrade = LetterGrade.D;
                    break;

                default:
                    stuLetterGrade = LetterGrade.F;
                    break;
            }

            return stuLetterGrade;
        }

        public string AltString()
        {
            return $"{SchoolProg} {AvgLetterGrade()} {AvgGradePercent() / 100:P2} {LName} {FName}";
        }

        public override string ToString()
        {
            return $"{LName} {FName} {SchoolProg} {AvgLetterGrade()}";
        }
    }
}
