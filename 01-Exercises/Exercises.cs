using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Exercises
{
    class Exercises
    {
        static void Main()
        {
            var inputLine = Console.ReadLine();

            var text = new List<string>();

            int count = 0;

            while (inputLine != "end")
            {
                var splitted = inputLine.Split('-', '>');
                var sentence = splitted[0];
                
                var values = splitted[2];
                var splittedValues = values.Split(new[] {' ', ','}, StringSplitOptions.RemoveEmptyEntries);

                count = 0;

                foreach (var item in splittedValues)
                {
                    sentence = sentence.Replace(string.Join("", "{", count, "}"), item);
                    count++;
                }

                text.Add(sentence);

                inputLine = Console.ReadLine();
            }

            foreach (var words in text)
            {
                Console.WriteLine(words);
            }

        }
    }
}
