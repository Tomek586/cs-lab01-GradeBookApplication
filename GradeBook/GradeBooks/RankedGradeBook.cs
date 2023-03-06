using GradeBook.Enums;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            if (Students.Count <5)
            {
                throw new InvalidOperationException("InvalidOperationException");
            }


            var top20percent = Students.Count / 5;

           
            List<double> Grades = new List<double>();
            foreach (var student in Students.OrderByDescending(student => student.AverageGrade))
            {
                Grades.Add(student.AverageGrade);
            }

            if (averageGrade > (Grades[top20percent]))
                return 'A';
            else if (averageGrade > (Grades[top20percent * 2]))
                return 'B';
            else if (averageGrade > (Grades[top20percent * 3]))
                return 'C';
            else if (averageGrade > (Grades[top20percent * 4]))
                return 'D';
            else
                return 'F';




        }


    }
}

