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