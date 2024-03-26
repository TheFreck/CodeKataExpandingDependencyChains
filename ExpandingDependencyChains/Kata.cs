using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpandingDependencyChains
{
    public class Kata
    {
        public static Dictionary<string, string[]> ExpandDependencies(Dictionary<string, string[]> input)
        {
            var hashSet = new Dictionary<string,HashSet<string>>();
            foreach(var entry in input)
            {
                hashSet.Add(entry.Key, entry.Value.ToHashSet());
            }
            var keys = input.Keys;
            var values = input.Values;
            var keepGoing = true;
            do
            {
                var updated = false;
                foreach(var inBranch in input)
                {
                    foreach (var outPair in hashSet)
                    {
                        if (outPair.Value.Contains(inBranch.Key))
                        {
                            foreach(var leaf in inBranch.Value)
                            {
                                if(!outPair.Value.Contains(leaf))
                                {
                                    outPair.Value.Add(leaf);
                                    updated = true;
                                }
                            }
                        }
                    }
                }
                if (updated) keepGoing = true;
                else keepGoing = false;
            } while (keepGoing);
            var outSet = new Dictionary<string, string[]>();
            foreach(var hash in hashSet)
            {
                if (hash.Value.Contains(hash.Key))
                    throw new InvalidOperationException();
                    //return new Dictionary<string, string[]> { { "ERROR", new string[] { "Circular Reference" } } };
                outSet.Add(hash.Key,hash.Value.OrderBy(d => d).ToArray());
            }
            return outSet;
        }

        
        //foreach (var dependency in input)
        //{
        //  Console.WriteLine(dependency.Key + ": ");
        //  foreach (var dep in dependency.Value)
        //  {
        //      Console.Write(dep + ", ");
        //  }
        //}
    }
}
