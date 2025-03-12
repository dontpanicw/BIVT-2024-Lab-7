using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6{
    public class Blue_2{

        public struct Participant {
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
                if (_marks == null || _marks.GetLength(0) == 0 || _marks.GetLength(1) == 0 || result == null || result.Length == 0 || _ind > 1) return;            
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