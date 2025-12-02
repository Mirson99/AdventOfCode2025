// See https://aka.ms/new-console-template for more information

using System.Text.RegularExpressions;

Console.WriteLine("Hello, World!");

string pattern = @"^([1-9]\d*)\1$";
string pattern2 = @"^([1-9]\d*)\1+$";
long result = 0;

string content = File.ReadAllText("../../../../input2.txt");

List<IdRange> idRanges = content
    .Split(',')
    .Select(item => item.Trim())
    .Where(item => !string.IsNullOrEmpty(item))
    .Select(item =>
    {
        var parts = item.Split('-');
        return new IdRange
        {
            Start = long.Parse(parts[0]),
            End = long.Parse(parts[1])
        };
    })
    .ToList();

foreach (var range in idRanges)
{
    for (long i = range.Start; i < range.End; i++)
    {
        bool match = Regex.IsMatch(i.ToString(), pattern2);
        if (match)
            result += i;
    }
}

Console.WriteLine(result);



public class IdRange
{
    public long Start { get; set; }
    public long End { get; set; }
}

