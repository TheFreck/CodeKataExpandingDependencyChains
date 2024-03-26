using Machine.Specifications;
using System.Xml.Linq;

namespace ExpandingDependencyChains.Specs
{
    public class When_Expanding_Dependencies
    {
        Establish context = () =>
        {
            inputs = new Dictionary<string, string[]>[]
            {
                new Dictionary<string, string[]>
                {
                    {"A",new string[]{ "B","C" }},
                    {"B",new string[]{ "D","E" }},
                    {"C",new string[]{ "D","G","H" }},
                    {"D",new string[]{ }},
                    {"E",new string[]{ "C","F" }},
                    {"F",new string[]{ "D","I" }},
                    {"G",new string[]{ }},
                    {"H",new string[]{ }},
                    {"I",new string[]{ }},
                },
            };
            expect = new Dictionary<string, string[]>[]
            {
                new Dictionary<string, string[]>
                {
                    {"A",new string[]{ "B","C","D","E","F","G","H","I" } },
                    {"B",new string[]{ "C","D","E","F","G","H","I" } },
                    {"C",new string[]{ "D","G","H" } },
                    {"D",new string[]{  } },
                    {"E",new string[]{ "C","D","F","G","H","I" } },
                    {"F",new string[]{ "D","I" } },
                    {"G",new string[]{ } },
                    {"H",new string[]{ } },
                    {"I",new string[]{ } },
                },
            };
            answers = new Dictionary<string, string[]>[expect.Length];
        };

        Because of = () =>
        {
            for (var i = 0; i < inputs.Length; i++)
            {
                answers[i] = Kata.ExpandDependencies(inputs[i]);
            }
        };

        It Should_Return_A_Dictionary_With_All_Dependencies = () =>
        {
            for(var i=0; i<answers.Length; i++)
            {
                foreach(var branch in answers[i])
                {
                    for(var k=0; k < branch.Value.Length; k++)
                    {
                        if (branch.Value[k] != expect[i][branch.Key][k])
                        {
                            var ans = branch.Value[k];
                            var exp = expect[i][branch.Key][k];
                        }
                        branch.Value[k].ShouldEqual(expect[i][branch.Key][k]);
                    }
                }
            }
        };

        private static Dictionary<string, string[]>[] inputs;
        private static Dictionary<string, string[]>[] expect;
        private static Dictionary<string, string[]>[] answers;
    }
}