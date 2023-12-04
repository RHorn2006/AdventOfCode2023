using System.Text.RegularExpressions;
using System.IO;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

class Program
{
    static void Main()
    {
        List<string> inputStrings = ReadStringsFromFile("InputStrings.txt");

        int totalValue = TotalValueCalc(inputStrings);

        Console.WriteLine($"Total Value: {totalValue}");
    }

    static List<string> ReadStringsFromFile(string fileName)
    {
        List<string> inputStrings = new List<string>();

        try
        {
            string[] lines = File.ReadAllLines(fileName);

            inputStrings.AddRange(lines);
        }
        catch (IOException e)
        {
            Console.WriteLine($"Error reading file: {e.Message}");
        }

        return inputStrings;
    }

    static int TotalValueCalc(List<string> inputStrings)
    {
        int totalValue = 0;

        Regex regex = new Regex(@"\d");

        foreach (string inputString in inputStrings)
        {
            MatchCollection matches = regex.Matches(inputString);

            if (matches.Count > 0)
            {
                string convertedString = ConvertAlphabetNumbers(inputString);

                int firstNumber = int.Parse(matches[0].Value);
                int lastNumber = int.Parse(matches[matches.Count - 1].Value);

                int mergedNumber = int.Parse($"{firstNumber}{lastNumber}");

                Console.WriteLine(mergedNumber);

                totalValue += mergedNumber;
            }
        }
        
        return totalValue;
    }

    static string ConvertAlphabetNumbers(string input)
    {
        Dictionary<string, char> alphabetNumberMap = new Dictionary<string, char>
        {
            {"one", '1'},
            {"two", '2'},
            {"three", '3'},
            {"four", '4'},
            {"five", '5'},
            {"six", '6'},
            {"seven", '7'},
            {"eight", '8'},
            {"nine", '9'}
        };

        string convertedString = input;
        foreach (var entry in alphabetNumberMap)
        {
            string word = entry.Key;
            char replacementWord = entry.Value;

            int index = 0;

            while ((index = convertedString.IndexOf(word, index, StringComparison.OrdinalIgnoreCase)) != -1)
            {
                convertedString = convertedString.Substring(0, index) + replacementWord + convertedString.Substring(index + word.Length);
                index += 1;
            }
        }

        return input;
    }
}
