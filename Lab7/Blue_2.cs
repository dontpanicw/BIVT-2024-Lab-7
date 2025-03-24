using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Lab_7{
    public class Blue_2{
        public abstract class WaterJump
        {
            private string _name;
            private int _bank;
            protected Participant[] _participants;
            protected int _counter;

            public string Name => _name;

            public int Bank => _bank;

            public Participant[] Participants => _participants;
            public abstract double[] Prize {get ; }

            public WaterJump(string name, int bank) {
                this._name = name;
                this._bank = bank;
                this._participants = new Participant[0];
                this._counter = 0;
            }

            public void Add(Participant participant){
                if (_participants == null) return;
                if (_counter < _participants.Length){
                    _participants[_counter] = participant;
                    _counter++;
                }
            }
            public void Add(Participant[] participants){
                if (_participants == null || participants.Length == 0 || participants == null) return;
                for (int i = 0; i < participants.Length; i++){
                    Add(participants[i]);
                }
                }
            }
            public class WaterJump3m : WaterJump
            {
            public WaterJump3m(string name, int bank) : base(name, bank){ }

            public override double[] Prize
            {
                get
                {
                    if (_participants == null || _participants.Length < 3 ){
                        return new double[0];
                    }
                    return new double[]
                    {
                    0.5 * Bank, 
                    0.3 * Bank, 
                    0.2 * Bank 
                    };
                }
            }
        }

        public class WaterJump5m : WaterJump
        {
            public WaterJump5m(string name, int bank) : base(name, bank){ }

            public override double[] Prize{
                get
                {
                    if (_participants == null || _participants.Length < 3 ){
                        return new double[0];
                    }
                    int countAboveMiddle = _counter / 2;
                    if (countAboveMiddle < 3) countAboveMiddle = 3;
                    if (countAboveMiddle > 10) countAboveMiddle = 10; 

                    double[] prizes = new double[_counter];
                    double n = 0.2 / countAboveMiddle; 

                    prizes[0] = 0.4 * Bank; 
                    prizes[1] = 0.25 * Bank; 
                    prizes[2] = 0.15 * Bank; 

                    for (int i = 3; i < countAboveMiddle; i++)
                    {
                        prizes[i] = n * Bank;
                    }
                    return prizes;
                }
                
            } 
        }

        public struct Participant 
        {
            private string _name;

            private string _surname;

            private int[,] _marks;
            private int _ind;

            public string Name => _name;

            public string Surname => _surname;

            public int[,] Marks
            {
                get
                {
                    if (_marks == null || _marks.GetLength(0) == 0 || _marks.GetLength(1) == 0) return null;
                    int[,] copy = new int[_marks.GetLength(0), _marks.GetLength(1)];
                    for (int i = 0; i < _marks.GetLength(0); i++){
                        for (int j = 0; j < _marks.GetLength(1); j++){
                            copy[i,j] = _marks[i,j];
                        }
                    }
                return copy;
                }
            }

            public int TotalScore 
            {
                get
                {   
                    if (_marks == null || _marks.GetLength(0) == 0 || _marks.GetLength(1) == 0) return 0;
                    int sum = 0;
                    for (int i = 0; i < _marks.GetLength(0); i++){
                        for (int j = 0; j < _marks.GetLength(1); j++){
                            sum += _marks[i,j];
                        }
                    }
                    return sum;
                }
            }

            public Participant(string name, string surname) {
                this._name = name;
                this._surname = surname;
                this._marks = new int[2,5];
                this._ind = 0;
                }

            public void Jump(int[] result)
            {
                if (result == null || result.Length == 0 || _ind > 1) return;            
                if (_ind == 0)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        _marks[0, i] = result[i];
                    }
                    _ind++;
                }
                else if (_ind == 1)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        _marks[1, i] = result[i];
                    }
                    _ind++;
                }
            }
    
            
            public static void Sort(Participant[] array)
            {
                if (array == null || array.Length == 0) return;

                for (int i = 0; i < array.Length - 1; i++)
                {
                    for (int j = 0; j < array.Length - i - 1; j++)
                    {
                        if (array[j + 1].TotalScore > array[j].TotalScore)
                        {
                            (array[j + 1], array[j]) = (array[j], array[j + 1]);
                        }
                    }
                }
            }

            public void Print()
            {
                Console.WriteLine($"{Name} {Surname}: {TotalScore} очков");
            }


        }
    }

}
    