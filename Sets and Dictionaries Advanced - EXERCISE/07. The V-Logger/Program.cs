namespace _07._The_V_Vlogger
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    internal class Program
    {
        static void Main(string[] args)
        {
            var vloggers = new Dictionary<string, Followers>();

            string command;
            while ((command = Console.ReadLine()) != "Statistics")
            {
                string[] cmndArrgs = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string vloggerName = cmndArrgs[0];
                string cmndType = cmndArrgs[1];

                if (cmndType == "joined" && !vloggers.ContainsKey(vloggerName))
                {
                    vloggers.Add(vloggerName, new Followers(new List<string>(), 0));
                }
                else if (cmndType == "followed")
                {
                    string secondVlogger = cmndArrgs[2];

                    if (vloggers.ContainsKey(vloggerName)
                        && vloggers.ContainsKey(secondVlogger)
                        && vloggerName != secondVlogger
                        && !vloggers[secondVlogger].Follower.Contains(vloggerName))
                    {
                        vloggers[secondVlogger].Follower.Add(vloggerName);
                        vloggers[vloggerName].Following++;
                    }
                }
            }

            vloggers = vloggers.OrderByDescending(x => x.Value.Follower.Count)
                .ThenBy(x => x.Value.Following).ToDictionary(x => x.Key, x => x.Value);

            Console.WriteLine($"The V-Logger has a total of {vloggers.Count} vloggers in its logs.");

            int count = 2;
            foreach (var name in vloggers.Values)
            {
                Console.WriteLine($"1. {vloggers.Keys.First()} : {name.Follower.Count} followers, " +
               $"{name.Following} following");

                foreach (var follower in name.Follower.OrderBy(x => x))
                {
                    Console.WriteLine($"*  {follower}");
                }

                foreach (var vlogger in vloggers.Skip(1))
                {
                    Console.WriteLine($"{count++}. {vlogger.Key} : " +
                        $"{vlogger.Value.Follower.Count} followers, {vlogger.Value.Following} following");
                }
                break;
            }
        }

        class Followers
        {
            public List<string> Follower { get; set; }

            public int Following { get; set; }
            public Followers(List<string> follower, int following)
            {
                Follower = follower;
                Following = following;
            }
        }
    }
}