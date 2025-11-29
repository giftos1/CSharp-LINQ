// See https://aka.ms/new-console-template for more information
using LinqIntroApp;

Console.WriteLine("Hello, World!");


var words = new string[]
{
    "hello",
    "WORLD",
    "Test",
    "LINQ"
};

var wordsNoUpper = new string[]
{
    "hello",
    "world",
    "test",
    "linq"
};

//var checkerNoUpper = new CheckUpperCase(wordsNoUpper).IsAnyWordUpperCase();

Console.WriteLine(CheckUpperCase.IsAnyWordUpperCase(words));
Console.WriteLine(CheckUpperCase.IsAnyWordUpperCaseLinq(words));
Console.WriteLine(CheckUpperCase.IsAnyWordUpperCase(wordsNoUpper));
Console.WriteLine(CheckUpperCase.IsAnyWordUpperCaseLinq(wordsNoUpper));


// LINQ and extension methods

var numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
var wordsLongerThan3Letters = words.Where(word => word.Length > 3);
var oddNumbers = numbers.Where(number => number % 2 == 1);

Console.WriteLine(string.Join(", ", wordsLongerThan3Letters));
Console.WriteLine(string.Join(", ", oddNumbers));