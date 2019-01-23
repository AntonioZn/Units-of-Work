using System;
using System.Collections.Generic;

namespace ConsoleApp6
{
    public class Program
    {
        public static void Main()
        {

            SortedSet<Unit> sortedSet = new SortedSet<Unit>(new UnitComparer());

            while (true)
            {
                string command = Console.ReadLine();

                var split = command.Split();

                

                if (split[0] == "add")
                {
                    var hero = new Unit(split[1], split[2], int.Parse(split[3]));

                    if (sortedSet.Contains(hero))
                    {
                        Console.WriteLine($"FAIL: {hero.Name} already exists!");
                    }
                    else
                    {
                        sortedSet.Add(hero);
                        Console.WriteLine($"SUCCESS: {hero.Name} added!");
                    }
                    
                    if (hero.Attack < 100 || hero.Attack > 1000)
                    {
                        throw new ArgumentOutOfRangeException("Attack must be from 100 to 1000");
                    }

                }

                else if (split[0] == "power")
                {

                    var numbers = int.Parse(split[1]);

                    var counter = 0;

                    var list = new List<Unit>();

                    foreach (Unit unit in sortedSet.Reverse())
                    {
                        list.Add(unit);
                        counter++;
                        if (counter == numbers)
                        {
                            break;
                        }

                    }
                    Console.WriteLine($"RESULT: {string.Join(", ", list)}");
                }

                else if (split[0] == "remove")
                {
                    var unitName = split[1];

                    
                        foreach (Unit unit in sortedSet)
                        {
                            if (unit.Name != unitName)
                            {
                              Console.WriteLine($"FAIL: {unit.Name} could not be found!");                        
                            }
                            else
                            {
                              sortedSet.Remove(unit);  
                            }
                        }

                        Console.WriteLine($"SUCCESS: {unitName} removed!");
                    
                }

                else if (split[0] == "find")
                {
                    var unitType = split[1];
                    var list = new List<Unit>();
                    foreach (Unit unit in sortedSet.Reverse())
                    {
                        if (unitType == unit.Type)
                        {
                            list.Add(unit);
                        }
                        
                    }
                    Console.WriteLine($"RESULT: {string.Join(", ", list)}");
                }

                else if (split[0] == "end")
                {
                    break;
                }
            }
        }
    }

    public class Unit
    {

        public Unit(string name, string type, int attack)
        {
            this.Name = name;

            this.Attack = attack;

            this.Type = type;
        }

        public string Name { get; set; }

        public string Type { get; set; }

        public int Attack { get; set; }

        public override string ToString()
        {
            return $"{Name}[{Type}]({Attack})";
        }
    }

    public class UnitComparer : IComparer<Unit>
    {
        public int Compare(Unit x, Unit y)
        {

            int result = x.Attack.CompareTo(y.Attack);

            return result;
        }
    }
}





  

    
    
