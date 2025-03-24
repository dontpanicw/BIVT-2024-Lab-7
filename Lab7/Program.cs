using Lab_7;

namespace Lab7;

class Program
{
    public static void Main()
    {
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
        Console.WriteLine("Призы 5м соревнования: " + string.Join(", ", competition5m.Prize));
    }
}
