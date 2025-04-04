using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Formatters;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;

namespace Lab_7{
    public class Blue_5{
        public class Sportsman{
            private string _name;
            private string _surname;
            private int _place;
            private bool _status;

            public string Name => _name;

            public string Surname => _surname;

            public int Place => _place;

            public Sportsman(string name, string surname){
                _name = name;
                _surname = surname;
                _place = 0;
                _status = false;
                
            }

            public void SetPlace(int place){
                if (_place != 0) return;

                _place = place;
                _status = true;
            }
            public void Print()
            {
                Console.WriteLine($"Спортсмен: {_name} {_surname}, Место: {_place}");
            }
        }

        public abstract class Team {
            private string _name;
            private Sportsman[] _sportsmen;
            private int _count;

            public string Name => _name;

            public Sportsman[] Sportsmen => _sportsmen;

            public int SummaryScore
            {
                get
                {
                    if (_sportsmen == null || _sportsmen.Length == 0) return 0;

                    int totalScore = 0;
                    for (int i = 0; i < _sportsmen.Length; i++)
                    {
                        if (_sportsmen[i] == null) continue;

                        switch (_sportsmen[i].Place)
                        {
                            case 1: totalScore += 5; break;
                            case 2: totalScore += 4; break;
                            case 3: totalScore += 3; break;
                            case 4: totalScore += 2; break;
                            case 5: totalScore += 1; break;
                            default: break;
                        }
                    }
                    return totalScore;
                }
            }

            public int TopPlace{
                get
                {
                    if (Sportsmen == null || Sportsmen.Length == 0) return 0;
                    int top = 18;
                    for (int i = 0; i < _sportsmen.Length; i++){
                        if (_sportsmen[i] == null) continue;
                        if (_sportsmen[i].Place < top && _sportsmen[i].Place != 0){
                            top = _sportsmen[i].Place;
                            }
                    }
                    return top;
                }
            }

            public Team(string name)
            {
                _name = name;
                _sportsmen = new Sportsman[6]; 
                _count = 0;
            }

            public void Add(Sportsman sportsman) {
                if (_sportsmen == null){
                    _sportsmen = new Sportsman[6];
                }
                if (_count < 6){
                    _sportsmen[_count] = sportsman;
                    _count++;
                }
            }
            public void Add(Sportsman[] sportsmen){
                foreach(var sportsman in sportsmen){
                    Add(sportsman);
                }
            }
            public static void Sort(Team[] teams){
                if (teams == null || teams.Length == 0) return;
                for (int i = 0; i < teams.Length - 1; i++){
                    for (int j = 0; j < teams.Length - i - 1; j++){
                        if (teams[j] == null || teams[j + 1] == null) continue;
                        if (teams[j].SummaryScore < teams[j + 1].SummaryScore)
                        {
                            Team temp = teams[j];
                            teams[j] = teams[j + 1];
                            teams[j + 1] = temp;
                        }
                        else if (teams[j].SummaryScore == teams[j + 1].SummaryScore)
                        {
                            if (teams[j].TopPlace > teams[j + 1].TopPlace)
                            {
                                Team temp = teams[j];
                                teams[j] = teams[j + 1];
                                teams[j + 1] = temp;
                    }
                }
            }
                }
            }

            protected abstract double GetTeamStrength();
                
            public static Team GetChampion(Team[] teams){
                if(teams == null) return null;
                Team champion = teams[0];
                double maxChampStrenght = champion.GetTeamStrength();
                for (int i = 0; i < teams.Length; i++){
                    double currentStr = teams[i].GetTeamStrength();
                    if (currentStr > maxChampStrenght)
                    {
                        maxChampStrenght = currentStr;
                        champion = teams[i];
                    }
                    
                }
                return champion;

            }
            public void Print()
            {
                Console.WriteLine($"Команда: {_name}");
                Console.WriteLine($"Суммарный балл: {SummaryScore}");
                Console.WriteLine($"Наивысшее место: {TopPlace}");
                Console.WriteLine("Спортсмены:");

                if (_sportsmen != null && _sportsmen.Length > 0)
                {
                    for (int i = 0; i < _sportsmen.Length; i++)
                    {
                        _sportsmen[i].Print();
                    }
                }
                else
                {
                    Console.WriteLine("Нет данных о спортсменах.");
                }
            }


        }

        public class ManTeam : Team{
            public ManTeam(string name) : base(name) {}

            protected override double GetTeamStrength()
            {
                if (Sportsmen == null ) return 0;
                double sumPlaces = 0;
                int counter = 0;
                foreach (var sportsman in Sportsmen)
                {
                    if (sportsman != null && sportsman.Place != 0)
                    {
                        sumPlaces += sportsman.Place;
                        counter++;
                    }
                }
                if (counter == 0) return 0;
                return 100 / (sumPlaces / counter);
            }
        }

        public class WomanTeam : Team{
            public WomanTeam(string name) : base(name) {}

            protected override double GetTeamStrength()
            {
                if (Sportsmen == null) return 0;
                double productPlaces = 1;
                double sumPlaces = 0;
                int counter = 0;
                foreach (var sportsman in Sportsmen)
                {
                    if (sportsman != null && sportsman.Place != 0)
                    {
                        productPlaces *= sportsman.Place;
                        sumPlaces += sportsman.Place;
                        counter++;
                    }
                }
                if (counter == 0) return 0;

                return 100 * sumPlaces * counter / productPlaces;
            }

        }



    }
}

