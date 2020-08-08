using System;
using System.Collections.Generic;

namespace SyntacticSugar
{
    class Program
    {
        static void Main(string[] args)
        {
            var predators = new List<string>();
            predators.Add("AntEater");
            predators.Add("Termites");

            var prey = new List<string>();
            prey.Add("Carrion");
            prey.Add("Sugar");

            var bug = new Bug("ant","ant",predators,prey);

            Console.WriteLine(bug.FormalName);

            bug.Name = "steve";

            Console.WriteLine(bug.FormalName);

            Console.WriteLine($"{bug.FormalName} likes to prey on {bug.PreyList()}");
            Console.WriteLine($"{bug.FormalName} hates {bug.PredatorList()}");

            Console.WriteLine(bug.Eat("Sugar"));
            Console.WriteLine(bug.Eat("plastic"));
    
        }
    }

    public class Bug
    {
        public string Name { get; set; }
        public string Species { get; }
        public List<string> Predators { get; }
        public List<string> Prey { get; }


        public string FormalName => $"{Name} the {Species}";
        
        public Bug(string name, string species, List<string> predators, List<string> prey)
        {
            Name = name;
            Species = species;
            Predators = predators;
            Prey = prey;
        }

        public string PreyList() => string.Join(",", Prey);
        
        public string PredatorList() => string.Join(",", Predators);

        public string Eat(string food) => Prey.Contains(food)
                                            ? $"{Name} ate the {food}."
                                            : $"{Name} is still hungry.";
    }
}
