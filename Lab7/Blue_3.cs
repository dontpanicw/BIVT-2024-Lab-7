using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Net;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;

namespace Lab_7{
    public class Blue_3{
        public class Participant {
           private string _name;
           private string _surname;
           protected int [] _penaltyTimes;

           public string Name => _name;

           public string Surname => _surname;

           public int[] Penalties{
            get 
            {
                if (_penaltyTimes == null) return null;
                int[] copy = new int[_penaltyTimes.Length];
                Array.Copy(_penaltyTimes, copy, _penaltyTimes.Length);
                return copy;
            }
           }
           public int Total
           {
            get 
            {
                if (_penaltyTimes == null) return 0;
                int total = 0;
                for (int i = 0; i < _penaltyTimes.Length; i++){
                    total += _penaltyTimes[i];
                }
                return total;
            }
           }
           public virtual bool IsExpelled
           {
            get
            {
                if (_penaltyTimes == null) return false;
                bool status = false;
                for (int i = 0; i < _penaltyTimes.Length; i++){
                    if (_penaltyTimes[i] >= 10){
                        status = true;
                        return status;
                    }

                }
                return status;
            }
           }
           public Participant(string name, string surname){
            _name = name;
            _surname = surname;
            _penaltyTimes = new int[0];
           }

           public virtual void PlayMatch(int time){
            if (_penaltyTimes == null) return;
            int[] result = new int[_penaltyTimes.Length + 1];
            Array.Copy(_penaltyTimes, result, _penaltyTimes.Length);
            _penaltyTimes = result;
            _penaltyTimes[_penaltyTimes.Length - 1] = time;
           }

           public static void Sort(Participant[] array){
            if (array.Length == 0 || array == null) return;
            for (int i = 0; i < array.Length; i++)
                {
                    for (int j = 0; j < array.Length - i - 1; j++)
                    {
                        if (array[j].Total > array[j + 1].Total)
                            (array[j], array[j + 1]) = (array[j + 1], array[j]);
                    }
                }
           }

           public void Print(){
                Console.WriteLine(_name, _surname);
                if (_penaltyTimes != null)
                {
                    for (int i = 0; i < _penaltyTimes.Length; i++)
                    {
                        Console.WriteLine(_penaltyTimes[i]);
                    }
                    Console.WriteLine();
                }
                Console.WriteLine($"Общее штрафное время: {Total}");

           }
           }

           public class BasketballPlayer : Participant {
            public BasketballPlayer(string name, string surname) : base(name, surname){
                 _penaltyTimes = new int[0]; 
            }
            public override bool IsExpelled {
                get
                {
                    if (_penaltyTimes == null || _penaltyTimes.Length == 0) return false;
                    bool status = false;
                    int counterMatches = 0;

                    foreach (var fouls in _penaltyTimes){
                        if (fouls == 5){
                            counterMatches++;
                        }
                    }
                    if (counterMatches > _penaltyTimes.Length * 0.1){
                        status = true;
                    }
                    if (Total > _penaltyTimes.Length * 2){
                        status = true;
                    }
                    return status;

                }
                
            }
             public override void PlayMatch(int fouls)
            {

                if (_penaltyTimes == null || fouls < 0 || fouls > 5) return;
                int[] result = new int[_penaltyTimes.Length + 1];
                Array.Copy(_penaltyTimes, result, _penaltyTimes.Length);
                _penaltyTimes = result;
                _penaltyTimes[_penaltyTimes.Length - 1] = fouls;
        }
        }
        public class HockeyPlayer : Participant {
            private Participant[] _hockeyPlayers;
            public Participant[] HockeyPlayers => _hockeyPlayers;
            public HockeyPlayer(string name, string surname) : base(name, surname){
                _hockeyPlayers = new Participant[0];
                _penaltyTimes = new int[0];

            }

            public override bool IsExpelled{
                get
                {
                    if (_hockeyPlayers == null) return false;
                    bool status = false;
                    foreach (int penalty in _penaltyTimes)
                    {
                        if (penalty >= 10){
                            status = true;
                            break;
                        }
                    }
                    if (_hockeyPlayers.Length > 0)
                    {
                        int sumPlayersTotal = 0;
                        foreach (var player in _hockeyPlayers) {
                            sumPlayersTotal += player.Total;
                        }
                        int totalHockeys = sumPlayersTotal / _hockeyPlayers.Length;
                        if (totalHockeys != 0 && (Total / (double)totalHockeys) > 0.1)
                        {
                            status = true;
                        }
                    }
                return status;
                }
            }
        }


    }
}
