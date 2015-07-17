using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            string folderLocation = args[0];
            string dllName = args[1].Replace(".", "\\.");
            string dllVersion = args[2];

            string[] csproj = Directory.GetFiles(folderLocation, "*.csproj", SearchOption.AllDirectories);

            foreach (string filePath in csproj)
            {
                string csProj = File.ReadAllText(filePath);
                Regex regExp = new Regex(string.Format(@"packages\\{0}[^\\]*\\", dllName));

                foreach (Match match in regExp.Matches(csProj))
                {
                    Console.Out.WriteLine(match.Value);
                }

            }
        }
    }
}
