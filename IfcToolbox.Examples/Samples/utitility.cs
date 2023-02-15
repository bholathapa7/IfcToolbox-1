using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.IO;

namespace IfcToolbox.Examples.Utility
{
    class GetBuildingStoreyId
    {
        public List<string> Regex(string input)
        {
            var idList = new List<string> { };
            // string input = "| | | #125 = [IfcBuildingStorey] \"PIT\" _↑ 114 #126 = [IfcBuildingStorey] \"GROUND FLOOR\" _↑ 120";
            // Define the regular expression pattern
            string pattern = @"\#(\w+)";
            // Create a regular expression object
            Regex rgx = new Regex(pattern);
            // Get all matches of the pattern in the input string
            MatchCollection matches = rgx.Matches(input);
            // Print out the matched words
            foreach (Match match in matches)
            {
                Console.WriteLine(match.Value.Replace("#", ""));
                idList.Add(match.Value.Replace("#", ""));
            }
            return idList;
        }

        public List<string> GetAllFiles(string path)
        {
            var fileList = new List<string> { };
            DirectoryInfo di = new DirectoryInfo(path);

            foreach (var fi in di.GetFiles())
            {
                fileList.Add(path + fi.Name);
            }

            Console.WriteLine();
            return fileList;
        }
    }
};