using GradeBook.Enums;
using System;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = GradeBookType.Ranked;
        }

        // TODO - GetLetterGrade algo is confusing. Simplify
        public override char GetLetterGrade(double averageGrade)
        {
            var numStudents = Students.Count;
            if (numStudents < 5)
            {
                throw new InvalidOperationException("Ranked-grading requires a minimum of 5 students to work");
            }

            int numStudentsHigherGrade = 0;
            foreach (var student in Students)
            {
                if (student.AverageGrade > averageGrade)
                {
                    numStudentsHigherGrade++;
                }
            }

            var dropAGrade = (numStudents / 5);
            var placement = numStudentsHigherGrade / dropAGrade;
            switch (placement)
            {
                case 0:
                    return 'A';

                case 1:
                    return 'B';

                case 2:
                    return 'C';

                case 3:
                    return 'D';

                default:
                    return 'F';
            }
        }
    }
}