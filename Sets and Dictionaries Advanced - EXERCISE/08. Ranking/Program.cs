namespace _08._Ranking
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    internal class Program
    {
        static void Main(string[] args)
        {
            var contestsAndPass = new Dictionary<string, string>();
            var candidatesInfo = new Dictionary<string, Candidate>();

            string contests;
            while ((contests = Console.ReadLine()) != "end of contests")
            {
                string[] contestData = contests.Split(":", StringSplitOptions.RemoveEmptyEntries);
                string contestName = contestData[0];
                string password = contestData[1];

                contestsAndPass.Add(contestName, password);
            }

            string submissions;
            while ((submissions = Console.ReadLine()) != "end of submissions")
            {
                string[] cmndArrgs = submissions
                    .Split("=>", StringSplitOptions.RemoveEmptyEntries);

                string contest = cmndArrgs[0];
                string password = cmndArrgs[1];
                string username = cmndArrgs[2];
                int points = int.Parse(cmndArrgs[3]);

                if (contestsAndPass.ContainsKey(contest)
                    && contestsAndPass[contest].Contains(password)
                    && !candidatesInfo.ContainsKey(username))
                {
                    candidatesInfo.Add(username, new Candidate(password, new Dictionary<string, int>()));
                    candidatesInfo[username].ContestsAndPoints.Add(contest, points);
                }
                else if (contestsAndPass.ContainsKey(contest)
                        && contestsAndPass[contest].Contains(password)
                        && candidatesInfo.ContainsKey(username)
                        && candidatesInfo[username].ContestsAndPoints.ContainsKey(contest)
                        && candidatesInfo[username].Password == password
                        && candidatesInfo[username].ContestsAndPoints[contest] < points)
                {
                    candidatesInfo[username].ContestsAndPoints[contest] = points;
                }
                else if (contestsAndPass.ContainsKey(contest)
                    && contestsAndPass[contest].Contains(password)
                    && candidatesInfo.ContainsKey(username)
                    && !candidatesInfo[username].ContestsAndPoints.ContainsKey(contest))
                {
                    candidatesInfo[username].ContestsAndPoints.Add(contest, points);
                }
            }

            candidatesInfo = candidatesInfo
                .OrderByDescending(x => x.Value.ContestsAndPoints.Values.Sum())
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var candidate in candidatesInfo)
            {
                Console.WriteLine($"Best candidate is {candidatesInfo.Keys.First()} with total " +
                    $"{candidate.Value.ContestsAndPoints.Values.Sum()} points.");
                break;
            }
           
            candidatesInfo = candidatesInfo
                .OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);

            Console.WriteLine("Ranking:");
            foreach (var student in candidatesInfo)
            {
                Console.WriteLine(student.Key);

                foreach (var item in student.Value.ContestsAndPoints
                    .OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {item.Key} -> {item.Value}");
                }
            }
        }

        class Candidate
        {
            public string Password { get; set; }

            public Dictionary<string, int> ContestsAndPoints { get; set; }

            public Candidate(string password, Dictionary<string,int> contestsAndPoints) 
            {
                ContestsAndPoints = contestsAndPoints;
                Password = password;
            }
        }
    }
}