using GradeBook.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
            {
                throw new InvalidOperationException("Ranked-grading requires a minimum of 5 students to work");
            }

            int studentsPerGrade = Students.Count/5;
            var rankedStudents = Students.OrderByDescending(x => x.AverageGrade).ToList();

            if (averageGrade >= rankedStudents[(studentsPerGrade*1)-1].AverageGrade)
            {
                Console.WriteLine("A");
                return 'A';
            }
            else if (averageGrade >= rankedStudents[(studentsPerGrade*2)-1].AverageGrade)
            {
                Console.WriteLine("B");
                return 'B';
            }
            else if (averageGrade >= rankedStudents[(studentsPerGrade*3)-1].AverageGrade)
            {
                Console.WriteLine("C");
                return 'C';
            }
            else if (averageGrade >= rankedStudents[(studentsPerGrade*4)-1].AverageGrade)
            {
                Console.WriteLine("D");
                return 'D';
            }
            else
            {
                Console.WriteLine("F");
                return 'F';
            }
        }
    }
}
