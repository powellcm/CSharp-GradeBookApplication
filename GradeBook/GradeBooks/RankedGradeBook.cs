using GradeBook.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace GradeBook.GradeBooks
{
    class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            double gradeBoundry;

            if (Students.Count < 5)
            {
                throw new InvalidOperationException("Ranked-grading requires a minimum of 5 students to work");
            }

            gradeBoundry = Students.Count * 0.2;

            if (averageGrade >= gradeBoundry * 4)
            {
                return 'A';
            }
            else if (averageGrade >= gradeBoundry * 3)
            {
                return 'B';
            }
            else if (averageGrade >= gradeBoundry * 2)
            {
                return 'C';
            }
            else if (averageGrade >= gradeBoundry * 1)
            {
                return 'D';
            }
            else
            {
                return 'F';
            }
        }
    }
}
