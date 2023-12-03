using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        List<string> inputStrings = new List<string>
        {
            "abcdef6ghi9",
            "xyz767pqr4mno1",
            "textNoN6umbers",
            "multiple2numbers57inBetween"
        };

        int totalValue = TotalValueCalc(inputStrings);
        Console.WriteLine($"this is the {totalValue}");
    }

    static int TotalValueCalc(List<string> inputStrings)
    {
        int totalValue = 0;

        Regex regex = new Regex(@"^\D*(\d).*?(\d)\D*$"); //sort out tomorrow

        foreach (string inputString in inputStrings)
        {
            MatchCollection matches = regex.Matches(inputString);

            if (matches.Count > 0)
            {
                int firstNumber = int.Parse(matches[0].Value);
                int lastNumber = int.Parse(matches[matches.Count - 1].Value);

                int mergedNumber = int.Parse($"{firstNumber}{lastNumber}");

                Console.WriteLine(mergedNumber);

                totalValue += mergedNumber;
            }
        }
        
        return totalValue;
    }
}
