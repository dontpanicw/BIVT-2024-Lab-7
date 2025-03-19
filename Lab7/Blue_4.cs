using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Formatters;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;

namespace Lab_7{
    public class Blue_4{
        public abstract class Team{
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

        public class ManTeam : Team{
            public ManTeam(string name) : base(name) {}
        }

        public class WomanTeam : Team{
            public WomanTeam(string name) : base(name) {}
        }

        public class Group{
            private string _name;
            private ManTeam[] _manTeams;
            private int _manTeamCount;
             private WomanTeam[] _womanTeams;
            private int _womanTeamCount;


            public string Name => _name;

            public ManTeam[] ManTeams => _manTeams;

            public WomanTeam[] WomanTeams => _womanTeams;


            public Group(string name){
                _name = name;
                _womanTeams = new WomanTeam[12];
                _manTeams = new ManTeam[12];
                _womanTeamCount = 0;
                _manTeamCount = 0;

            }
            public void Add(Team team){
                if (_womanTeams == null || _manTeams == null) return;

                if (team is WomanTeam womanTeam && _womanTeamCount < _womanTeams.Length){
                    _womanTeams[_womanTeamCount] = womanTeam;
                    _womanTeamCount ++;
                }
                else if (team is ManTeam manTeam && _manTeamCount < _manTeams.Length){
                    _manTeams[_manTeamCount] = manTeam;
                    _manTeamCount ++;
                }
            }
            // создать метод Remove(int count) который сокращает массив команд экземпляра на count с конца
            
            // public void Remove(int count){
            //     if (_teams == null || _teams.Length == 0 || count <= _teams.Length) return;
            //     Team[] new_array = new Team[_teams.Length - count];
            //     for (int i = 0; i < _teams.Length; i++){
            //         new_array[i] = _teams[i];
            //     }
            //     _teams = new_array;

            
            public void Add(Team[] teams){
                if (_manTeams == null || _manTeams.Length == 0 || _womanTeams == null || _womanTeams.Length == 0) return;
                for (int i = 0; i < teams.Length; i++){
                    Add(teams[i]);
                }
            }
            // public void Sort()
            // {
            //     if (_teams == null || _teams.Length == 0) return;

            //     for (int i = 0; i < _teams.Length - 1; i++)
            //     {
            //         for (int j = 0; j < _teams.Length - 1 - i; j++)
            //         {
            //             if (_teams[j].TotalScore < _teams[j + 1].TotalScore)
            //             {
            //                 Team temp = _teams[j];
            //                 _teams[j] = _teams[j + 1];
            //                 _teams[j + 1] = temp;
            //             }
            //         }
            //     }
            // }

            public void Sort()
            {
                SortTeam(WomanTeams);
                SortTeam(ManTeams);
            }
            public void SortTeam(Team[] team) {

                if (team == null) return;
                for (int i = 0; i < team.Length - 1; i++)
                {
                    for (int j = 0; j < team.Length - i - 1; j++)
                    {
                        if (team[j + 1].TotalScore > team[j].TotalScore)
                        {
                            (team[j + 1], team[j]) = (team[j], team[j + 1]);
                        }
                    }
                }
             
            }
            
             public static Group Merge(Group group1, Group group2, int size)
            {
                Group result = new Group("Финалисты");
                MergeTeams(group1.ManTeams, group2.ManTeams, result.ManTeams, size / 2);
                MergeTeams(group1.WomanTeams, group2.WomanTeams, result.WomanTeams, size / 2);
                return result;
            }

            private static void MergeTeams(Team[] team1, Team[] team2, Team[] resultTeam, int size)
            {
                int i = 0, j = 0, k = 0;
                while (i < size && j < size)
                {
                    if (team1[i].TotalScore >= team2[j].TotalScore)
                    {
                        resultTeam[k++] = team1[i++];
                    }
                    else
                    {
                        resultTeam[k++] = team2[j++];
                    }
                }
                while (i < size)
                {
                    resultTeam[k++] = team1[i++];
                }
                while (j < size)
                {
                    resultTeam[k++] = team2[j++];
                }
            }
            // public void Print()
            // {
            //     Console.WriteLine($"Группа: {_name}");
            //     Console.WriteLine("Команды:");

            //     if (_teams != null && _teams.Length > 0)
            //     {
            //         for (int i = 0; i < _teams.Length; i++)
            //         {
            //             Console.WriteLine($"Команда {i + 1}");
            //             _teams[i].Print();
            //         }
            //     }
            //     else
            //     {
            //         Console.WriteLine("Нет данных о командах.");

        }
    }
}
    
