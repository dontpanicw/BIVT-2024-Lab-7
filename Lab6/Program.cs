using Lab_6;

namespace Lab6;

class Program
{
    static void Main(string[] args)
    {
        
        //TASK 1
        
        Blue_1.Response[] responses =
        {
            new Blue_1.Response("Иван", "Иванов"),
            new Blue_1.Response("Петр", "Петров"),
            new Blue_1.Response("Иван", "Иванов"),
            new Blue_1.Response("Анна", "Смирнова"),
            new Blue_1.Response("Иван", "Иванов"),
            new Blue_1.Response("Анна", "Смирнова")
        };
        var distinctCandidates = responses.Distinct().ToArray();
        foreach (var candidate in distinctCandidates)
        {
            Blue_1.Response countedCandidate = candidate;
            countedCandidate.CountVotes(responses);
            countedCandidate.Print();
        }

        //TASK 2

        Blue_2.Participant[] participants =
        {
            new Blue_2.Participant("Иван", "Иванов"),
            new Blue_2.Participant("Петр", "Петров"),
            new Blue_2.Participant("Анна", "Смирнова")
        };

        participants[0].Jump(new int[] { 8, 9, 7, 8, 9 });
        participants[0].Jump(new int[] { 9, 9, 8, 9, 10 });
        
        participants[1].Jump(new int[] { 7, 8, 7, 7, 8 });
        participants[1].Jump(new int[] { 8, 8, 8, 8, 9 });
        
        participants[2].Jump(new int[] { 9, 9, 9, 8, 9 });
        participants[2].Jump(new int[] { 10, 10, 9, 9, 10 });
        
        Blue_2.Participant.Sort(participants);
        
        foreach (var participant in participants)
        {
            participant.Print();
        }

        //TASK 3

        // Blue_3.Participant[] participants =
        // {
        //     new Blue_3.Participant("Иван", "Иванов"),
        //     new Blue_3.Participant("Петр", "Петров"),
        //     new Blue_3.Participant("Анна", "Смирнова"),
        //     new Blue_3.Participant("Сергей", "Кузнецов")
        // };

        // participants[0].PlayMatch(2);
        // participants[0].PlayMatch(5);
        
        // participants[1].PlayMatch(0);
        // participants[1].PlayMatch(2);
        
        // participants[2].PlayMatch(10);
        
        // participants[3].PlayMatch(5);
        // participants[3].PlayMatch(5);
        
        // Blue_3.Participant.Sort(participants);
        
        // foreach (var participant in participants)
        // {
        //     if (!participant.IsExpelled)
        //         participant.Print();
        // }

        ///TASK 4

        Blue_4.Group groupA = new Blue_4.Group("Группа A");
        Blue_4.Group groupB = new Blue_4.Group("Группа B");

        for (int i = 1; i <= 12; i++)
        {
            Blue_4.Team team = new Blue_4.Team($"Команда A{i}");
            team.PlayMatch(10);
            team.PlayMatch(new Random().Next(0, 10));
            groupA.Add(team);
        }
        
        for (int i = 1; i <= 12; i++)
        {
            Blue_4.Team team = new Blue_4.Team($"Команда B{i}");
            team.PlayMatch(new Random().Next(0, 10));
            team.PlayMatch(new Random().Next(0, 10));
            groupB.Add(team);
        }
        
        groupA.Sort();
        groupB.Sort();
        
        Blue_4.Group finalists = Blue_4.Group.Merge(groupA, groupB, 12);
        finalists.Print();

        ///TASK 5


        Blue_5.Team team1 = new Blue_5.Team("Команда 1");
        Blue_5.Team team2 = new Blue_5.Team("Команда 2");
        Blue_5.Team team3 = new Blue_5.Team("Команда 3");
        
        team3.Print();

        Random rnd = new Random();
        int[] places = Enumerable.Range(1, 18).OrderBy(_ => rnd.Next()).ToArray();
        int index = 0;

        for (int i = 0; i < 6; i++)
        {
            Blue_5.Sportsman s1 = new Blue_5.Sportsman($"Игрок{i+1}", "A");
            s1.SetPlace(places[index++]);
            team1.Add(s1);

            Blue_5.Sportsman s2 = new Blue_5.Sportsman($"Игрок{i+1}", "B");
            s2.SetPlace(places[index++]);
            team2.Add(s2);

            Blue_5.Sportsman s3 = new Blue_5.Sportsman($"Игрок{i+1}", "C");
            s3.SetPlace(places[index++]);
            team3.Add(s3);
        }

        Blue_5.Team[] teams = { team1, team2, team3 };
        Blue_5.Team.Sort(teams);

        Console.WriteLine("Результаты:");
        foreach (var team in teams)
        {
            team.Print();
        }

    }
}
