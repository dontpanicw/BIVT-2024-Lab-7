using Lab_7;

namespace Lab7;

class Program
{
    public static void Main()
    {
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

        Console.WriteLine("Участники до сортировки:");
        foreach (var participant in participants)
        {
            participant.Print();
        }

        Blue_2.Participant.Sort(participants);

        Console.WriteLine("Участники после сортировки:");
        foreach (var participant in participants)
        {
            participant.Print();
        }

        var competition3m = new Blue_2.WaterJump3m("Jump 3m", 1000);
        competition3m.Add(participants);
        Console.WriteLine("Призы 3м соревнования: " + string.Join(", ", competition3m.Prize));

        var competition5m = new Blue_2.WaterJump5m("Jump 5m", 1000);
        competition5m.Add(participants);
        // Console.WriteLine("Призы 5м соревнования: " + string.Join(", ", competition5m.Prize));

        //TASK 3

        Blue_3.Participant[] participants3 =
        {
            new Blue_3.Participant("Иван", "Сидоров"),
            new Blue_3.BasketballPlayer("Петр", "Петров"),
            new Blue_3.HockeyPlayer("Анна", "Смирнова")
        };

        participants3[0].PlayMatch(3);
        participants3[0].PlayMatch(7);

        participants3[1].PlayMatch(0);
        participants3[1].PlayMatch(5);
        participants3[1].PlayMatch(3);

        participants3[2].PlayMatch(10);
        participants3[2].PlayMatch(2);
        participants3[2].PlayMatch(8);

        Console.WriteLine("Участники до сортировки:");
        foreach (var participant in participants3)
        {
            participant.Print();
            Console.WriteLine("Отстранен: " + participant.IsExpelled);
        }

        Blue_3.Participant.Sort(participants3);

        Console.WriteLine("Участники после сортировки:");
        foreach (var participant in participants3)
        {
            participant.Print();
            Console.WriteLine("Отстранен: " + participant.IsExpelled);
        }
        Console.WriteLine("\nПроверка Upcast и Downcast:");
        Blue_3.Participant genericParticipant = new Blue_3.BasketballPlayer("Алексей", "Сидоров");
        genericParticipant.PlayMatch(4);
        genericParticipant.PlayMatch(5);
        
        if (genericParticipant is Blue_3.BasketballPlayer basketballPlayer)
        {
            Console.WriteLine("Downcast успешен!");
            basketballPlayer.PlayMatch(3);
            basketballPlayer.Print();
        }
        else
        {
            Console.WriteLine("Ошибка Downcast!");
        }
    }
}
