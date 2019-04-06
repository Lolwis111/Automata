using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.IO;

namespace Automata
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "";
            if (args.Length > 0 && File.Exists(args[0]))
            {
                path = args[0];
            }
            else
            {
                bool trigger = false;
                string p = string.Empty;
                Console.Write("Datei: ");
                while (!trigger)
                {
                    p = Console.ReadLine();

                    if (!File.Exists(p)) Console.Error.WriteLine("\nDatei nicht gefunden!\n");
                    else trigger = true;
                }
                path = p;
            }

            StreamReader reader = null;
            try
            {
                reader = new StreamReader(File.Open(path, FileMode.Open, FileAccess.Read));

                bool _hasStart = false, _hasEnd = false;
                List<State> states = new List<State>();
                while (!reader.EndOfStream)
                {
                    string l = reader.ReadLine();
                    string name = l.Substring(0, l.IndexOf('{'));
                    string[] conds = l.Substring(l.IndexOf('{') + 1, l.IndexOf('}') - l.IndexOf('{') - 1).Split( ';');
                    bool start = false, end = false;

                    end = start = l.EndsWith("ES") || l.EndsWith("SE");
                    end = l.EndsWith("E");
                    start = l.EndsWith("S");

                    if (end)
                        _hasEnd = true;
                    if (start)
                        _hasStart = true;

                    Dictionary<char, string> conditions = new Dictionary<char, string>();
                    foreach (string c in conds)
                    {
                        char character = c.Split(',')[0].Substring(1,1)[0];
                        string fName = c.Split(',')[1];
                        fName = fName.Substring(0, fName.Length - 1);

                        if (!conditions.ContainsKey(character))
                            conditions.Add(character, fName);
                        else
                            throw new Exception("Automat ist kein DFA und kann deshalb nicht simuliert werden!");
                    }

                    states.Add(new State() { Conditions = conditions, Name = name, IsEndState = end, IsStartState = start });
                }

                if (!(_hasEnd && _hasStart))
                {
                    throw new Exception("Automat ist kein DFA und kann deshalb nicht simuliert werden!");
                }

                foreach (State state in states)
                {
                    foreach (string name in state.Conditions.Values)
                    {
                        var a = from c in states where c.Name == name select c;
                        if (a.Count() <= 0)
                            throw new Exception("Automat ist Fehlerhaft!");
                    }
                }

                Console.WriteLine("OK.");

                while (true)
                {
                    Console.Write("Input: ");
                    string input = Console.ReadLine();

                    char[] word = input.ToArray();

                    State state = (from c in states where c.IsStartState select c).ElementAt(0);

                    for (int i = 0; i < word.Length; i++)
                    {
                        string f = state.Conditions[word[i]];
                        state = (from c in states where c.Name == f select c).ElementAt(0);
                    }

                    if (state.IsEndState)
                    {
                        Console.WriteLine("Das Wort wurde akzeptiert!");
                    }
                    else
                    {
                        Console.WriteLine("Das Wort wurde nicht akzeptiert!");
                    }
                }
            }
            catch(Exception ex)
            {
                Console.Error.WriteLine();
                Console.Error.WriteLine(ex.Message);
                Console.Error.WriteLine(ex.StackTrace);
                Console.Error.WriteLine();
            }
            finally
            {
                if (reader != null)
                {
                    reader.Dispose();
                    reader = null;
                }

                Console.ReadLine();
            }
        }
    }
}
