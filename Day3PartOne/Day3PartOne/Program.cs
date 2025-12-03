// See https://aka.ms/new-console-template for more information

Console.WriteLine("Hello, World!");

List<List<int>> rows = ReadDigitsFromFile("../../../../input3.txt");
long result = 0;
var dayOneVariable = 2;
var dayTwoVariable = 12;

foreach (List<int> row in rows)
{
    var stringResult = "";
    var startIndex = -1;
    for (int i = dayTwoVariable; i >= 1; i--)
    {
        var slicedList = row.Slice(startIndex + 1, (row.Count - (i + startIndex)));
        var value = slicedList.Max();
        var tryIndex = -2;
        while (tryIndex < startIndex)
        {
            tryIndex = row.FindIndex(x => x == value);
            row[tryIndex] = 0;
        }
        
        startIndex = tryIndex;
        stringResult += value.ToString();
    }
    result += long.Parse(stringResult);
}

Console.WriteLine("The result is: " + result);

static List<List<int>> ReadDigitsFromFile(string filePath)
{
    var rows = new List<List<int>>();
    
    string[] lines = File.ReadAllLines(filePath);
        
    foreach (string line in lines)
    {
        if (string.IsNullOrWhiteSpace(line))
            continue;
        
        var digits = line
            .Where(c => char.IsDigit(c)) 
            .Select(c => c - '0')
            .ToList();
            
        rows.Add(digits);
    }
        
    return rows;
}