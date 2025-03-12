using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Formatters;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;

namespace Lab_6{
    public class Blue_4{
        public struct Team{
            private string _name;
            private int[] _scores;

            public string Name => _name;

            public int[] Scores{
                get
                {
                    if (_scores == null) return null;
                    int[] copy = new int[_scores.Length];
                    Array.Copy(_scores, copy, _scores.Length);
                    return copy;
                }
            }
            public int TotalScore
            {
                get
                {
                    if (_scores == null) return 0;
                    int total = 0;
                    for (int i = 0; i < _scores.Length; i++){
                        total += _scores[i];
                    }
                    return total;
                }
                
            }
            public Team(string name){
                _name = name;
                _scores = new int[0];
            }
            public void PlayMatch(int result){
                if (_scores == null) return;

                int[] newScores = new int[_scores.Length + 1];
                Array.Copy(_scores, newScores, _scores.Length);
                newScores[newScores.Length - 1] = result;
                _scores = newScores;
            }
            public void Print()
            {
                Console.WriteLine($"{Name}: {TotalScore}");
            }
        }
        public struct Group{
            private string _name;
            private Team[] _teams;
            private int _teamCount;

            public string Name => _name;

            public Team[] Teams => _teams;


            public Group(string name){
                _name = name;
                _teams = new Team[12];
                _teamCount = 0;


            }
            public void Add(Team team){
                if (_teams == null) return;
                if (_teamCount < _teams.Length){
                    _teams[_teamCount] = team;
                    _teamCount ++;
                }
            }
            // создать метод Remove(int count) который сокращает массив команд экземпляра на count с конца
            
            public void Remove(int count){
                if (_teams == null || _teams.Length == 0 || count <= _teams.Length) return;
                Team[] new_array = new Team[_teams.Length - count];
                for (int i = 0; i < _teams.Length; i++){
                    new_array[i] = _teams[i];
                }
                _teams = new_array;

            }
            public void Add(Team[] teams){
                if (_teams == null || _teams.Length == 0) return;
                for (int i = 0; i < teams.Length; i++){
                    Add(teams[i]);
                }
            }
            public void Sort()
            {
                if (_teams == null || _teams.Length == 0) return;

                for (int i = 0; i < _teams.Length - 1; i++)
                {
                    for (int j = 0; j < _teams.Length - 1 - i; j++)
                    {
                        if (_teams[j].TotalScore < _teams[j + 1].TotalScore)
                        {
                            Team temp = _teams[j];
                            _teams[j] = _teams[j + 1];
                            _teams[j + 1] = temp;
                        }
                    }
                }
            }
            public static Group Merge(Group group1, Group group2, int size){
                Group result = new Group("Финалисты");
                int i = 0; int j = 0;
                while(i < size / 2 && j < size / 2)
                {
                    if (group1.Teams[i].TotalScore >= group2.Teams[j].TotalScore)
                    {
                        result.Add(group1.Teams[i++]);
                    }
                    else
                    {
                        result.Add(group2.Teams[j++]);
                    }
                }
                while(i < size / 2)
                {
                    result.Add(group1.Teams[i++]);
                }
                while (j < size / 2)
                {
                    result.Add(group2.Teams[j++]);
                }

                return result;
            }

            public void Print()
            {
                Console.WriteLine($"Группа: {_name}");
                Console.WriteLine("Команды:");

                if (_teams != null && _teams.Length > 0)
                {
                    for (int i = 0; i < _teams.Length; i++)
                    {
                        Console.WriteLine($"Команда {i + 1}");
                        _teams[i].Print();
                    }
                }
                else
                {
                    Console.WriteLine("Нет данных о командах.");

        }
    }
}
    }
}