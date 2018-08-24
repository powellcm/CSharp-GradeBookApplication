using GradeBook.Enums;
using System;
using System.Linq;

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

            var gradeBoundry = (int)Math.Ceiling(Students.Count * 0.2);

            var grades = Students.OrderByDescending(e => e.AverageGrade).Select(e => e.AverageGrade).ToList();

            if (averageGrade >= grades[gradeBoundry - 1])
                return 'A';
            if (averageGrade >= grades[(gradeBoundry * 2) - 1])
                return 'B';
            if (averageGrade >= grades[(gradeBoundry * 3) - 1])
                return 'C';
            if (averageGrade >= grades[(gradeBoundry * 4) - 1])
                return 'D';

            return 'F';

        }
    }
}
