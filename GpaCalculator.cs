using System;
using System.Collections.Generic;
using System.Linq;

namespace GpaCalculatorApp;

public class Calculator
{
    public static (int TotalUnits, int TotalPoints, double GPA) Compute(List<Course> courses)
    {
        if (courses == null || !courses.Any())
            return (0, 0, 0.0);

        int totalUnits = courses.Sum(c => c.Units);
        int totalPoints = courses.Sum(c => c.Units * c.GetGradeAndPoint().Point);
        double gpa = totalUnits > 0 ? (double)totalPoints / totalUnits : 0.0;

        return (totalUnits, totalPoints, Math.Round(gpa, 2));
    }

    // Embedded programmatic self-check suite
    public static bool RunSelfChecks()
    {
        var testCourses = new List<Course>
        {
            new() { Code = "TEST101", Units = 3, Score = 75.0 }, // 3 * 5 = 15
            new() { Code = "TEST102", Units = 3, Score = 42.0 }  // 3 * 1 = 3
        }; // Total Units = 6, Total Points = 18, Expected GPA = 3.00

        var (units, points, gpa) = Compute(testCourses);
        return (units == 6) && (points == 18) && (Math.Abs(gpa - 3.00) < 0.001);
    }
}