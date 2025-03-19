using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_7{
    public class Blue_1{
        public class Response{
            private string _name;
            protected int _votes;

            public string Name => _name;
            public int Votes => _votes;

            public Response(string name){
                this._name = name;
                this._votes = 0;
            }

            public virtual int CountVotes(Response[] responses){
                
                foreach (var response in responses)
                {
                    
                    if (response.Name == _name)
                    {
                        _votes++;
                    }
                }
                return _votes;  
            }

            public virtual void Print()
            {
                Console.WriteLine($"{_name}: {_votes}");
            }


        }
        public class HumanResponse : Response {
            private string _surname;
            public string Surname => _surname;
            public HumanResponse(string name, string surname) : base(name){
                this._surname = surname;
            }
            public override int CountVotes(Response[] responses){
                
                foreach (var response in responses)
                {
                    
                    if (response is HumanResponse humanResponse && humanResponse.Name == Name && humanResponse.Surname == Surname)
                    {
                        _votes++;
                    }
                }
                return _votes;
            }

                public override void Print()
            {
                Console.WriteLine($"{Name} {Surname}: {_votes}");
            }
            }
        }
}
