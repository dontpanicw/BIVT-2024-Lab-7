using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6{
    public class Blue_1{
        public struct Response{
            private string _name;
            private string _surname;
            private int _votes;

            public string Name => _name;
            public string Surname => _surname;
            public int Votes => _votes;

            public Response(string name, string surname){
                this._name = name;
                this._surname = surname;
                this._votes = 0;
            }

            public int CountVotes(Response[] responses){
                
                foreach (var candidate in responses)
                {
                    
                    if (candidate.Name == _name && candidate.Surname == _surname)
                    {
                        _votes++;
                    }
                }
                return _votes;  
            }

            public void Print()
            {
                Console.WriteLine($"{_name} {_surname}: {_votes}");
            }


        }
    }
}