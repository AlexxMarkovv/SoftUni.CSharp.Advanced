namespace _02._Average_Student_Grades
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    internal class Program
    {
        static void Main(string[] args)
        {
            int students = int.Parse(Console.ReadLine());

            Dictionary<string, List<decimal>> studentGrades
                = new Dictionary<string, List<decimal>>();

            for (int i = 0; i < students; i++)
            {
                string[] studentData = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string name = studentData[0];
                decimal grade = decimal.Parse(studentData[1]);

                if (!studentGrades.ContainsKey(name))
                {
                    studentGrades.Add(name, new List<decimal>());
                }

                studentGrades[name].Add(grade);
            }

            foreach (var studentGrade in studentGrades)
            {
                Console.Write($"{studentGrade.Key} -> ");
                foreach (var item in studentGrade.Value)
                {
                    Console.Write($"{item:f2} ");
                }
                Console.WriteLine($"(avg: {studentGrade.Value.Average():f2})");
            }
        }
    }
}