// See https://aka.ms/new-console-template for more information

Console.WriteLine("Hello, World!");


// Part One
// List<string> instructions = File.ReadAllLines("../../../../input.txt").ToList();
//
// var currentValue = 50;
// var resultCount = 0;
//
// foreach (var instruction in instructions)
// {
//     var direction = instruction[0];
//     var value = int.Parse(instruction.Substring(1));
//     value = value % 100;
//     if (direction == 'R')
//     {
//         currentValue += value;
//         if (currentValue > 99)
//         {
//             currentValue -=100;
//         }
//     }
//
//     if (direction == 'L')
//     {
//         currentValue -= value;
//         if(currentValue < 0) 
//         {
//             currentValue += 100;
//         }
//     }
//     
//     if (currentValue == 0)
//         resultCount++;
// }
//
// Console.WriteLine(resultCount);


// Part Two

List<string> instructions = File.ReadAllLines("../../../../input.txt").ToList();

var currentValue = 50;
var resultCount = 0;

foreach (var instruction in instructions)
{
    var direction = instruction[0];
    var value = int.Parse(instruction.Substring(1));
    resultCount += (value / 100);
    value = value % 100;
    if (direction == 'R')
    {
        currentValue += value;
        if (currentValue > 99)
        {
            resultCount++;
            currentValue -= 100;
        }
    }

    if (direction == 'L')
    {
        var initialValue = currentValue;
        currentValue -= value;
        if(currentValue < 0)
        {
            currentValue += 100;

            if (initialValue != 0)
                resultCount++;
        }
        else if (currentValue == 0)
            resultCount++;
    }
}

Console.WriteLine(resultCount);



