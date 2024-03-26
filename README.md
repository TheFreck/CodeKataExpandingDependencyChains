# Code Wars
## CodeKataExpandingDependencyChains
https://www.codewars.com/kata/56293ae77e20756fc500002e/train/csharp

### Explanation:

When building a program a file only needs to be compiled if it or one of its dependencies has changed since the last build. However, these changes can propogate upwards through dependencies. For example, if A is dependent on B, and B is dependent on C, then a change to C will require that all three files be recompiled.

For this kata you will be provided with a list of files along with their immediate dependencies. Your task is to determine all dependencies for every file in the list, and return those values.

Specification:
Your code needs to accept as its input a Dictionary<string,string[]> The keys in the dictionary contain the names of the files you need to consider as strings. Each key (file) is mapped to an array of strings, each element of which represents a single direct dependency. A file with no dependencies is mapped to an empty array.

The return from your method needs to follow the same format, a Dictionary<string,string[]> mapping file names to dependencies, but needs to include all the dependencies, not just the direct dependencies.

You will also need to check for circular dependencies. For example, if you have three files, A, B, and C, with A dependent on B, B dependent on C, and C dependent on A, there is a circular dependency. In such cases you should throw an InvalidOperationException.

Example:
As input for our example I have provided a dictionary detailing 4 files, A, B, C, and D. A is dependent on B and D. B is dependent on C, and C and dependent on D.

"A" => ["B", "D"]
"B" => ["C"]
"C" => ["D"]
"D" => [ ]
When we expand these out we come up with a new set up dependencies:

"A" => ["B", "C", "D"]
"B" => ["C", "D"]
"C" => ["D"]
"D" => [ ]
Because B is dependent on C and, indirectly, D, those are added to A as well. The order isn't important in your results, but even files with no dependencies still need to remain in the list.

