
using System;
using System.Collections.Generic;
using GpaCalculatorApp;

bool checksPassed = Calculator.RunSelfChecks();
Console.WriteLine($"[VERIFICATION CHECK] Programmatic Self-Test Passed: {checksPassed}");

if (!checksPassed)
{
    Console.WriteLine("Calculation verification failed. Terminating execution.");
    return;
}

var semesterCourses = new List<Course>
{
    new() { Code = "CSC301", Units = 3, Score = 75.5 }, // A (5) -> 15 Q.P
    new() { Code = "MTH301", Units = 4, Score = 62.0 }, // B (4) -> 16 Q.P
    new() { Code = "GST111", Units = 2, Score = 81.0 }, // A (5) -> 10 Q.P
    new() { Code = "PHY101", Units = 3, Score = 48.0 }  // D (2) -> 6 Q.P
};

Console.WriteLine("\n==========================================================");
Console.WriteLine("| Course Code | Units | Score | Grade | Points | Total Q.P |");
Console.WriteLine("----------------------------------------------------------");

foreach (var c in semesterCourses)
{
    var (grade, point) = c.GetGradeAndPoint();
    int qp = c.Units * point;
    Console.WriteLine($"| {c.Code,-11} | {c.Units,5} | {c.Score,5:F1} | {grade,5} | {point,6} | {qp,9} |");
}

Console.WriteLine("==========================================================");

var (totalUnits, totalPoints, gpa) = Calculator.Compute(semesterCourses);
Console.WriteLine($"Total Units Registered: {totalUnits}");
Console.WriteLine($"Total Quality Points:   {totalPoints}");
Console.WriteLine($"Calculated Semester GPA:{gpa:F2} / 5.00");
Console.WriteLine("==========================================================\n");