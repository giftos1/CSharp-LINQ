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

var numbers = new List<int> { 50, 21, 33, 75, 5, 1, 20, 9, 10 };
var wordsLongerThan3Letters = words.Where(word => word.Length > 3);
var oddNumbers = numbers.Where(number => number % 2 == 1);

Console.WriteLine(string.Join(", ", wordsLongerThan3Letters));
Console.WriteLine(string.Join(", ", oddNumbers));

/* Method chaining */

// Get odd numbers and order them
var orderedNumbers = numbers
    .Where(number => number % 2 == 1)
    .OrderBy(number => number);

Console.WriteLine(string.Join(", ", orderedNumbers));

Console.WriteLine("Second Iteration");

// It only executes when called not declared (deffered execution)
foreach (var number in orderedNumbers)
{
    Console.Write(number + " ");
}
numbers.Add(77);
Console.WriteLine();
Console.WriteLine();

Console.WriteLine("Second Iteration");
foreach (var number in numbers)
{
    Console.Write(number + " ");
}

Console.WriteLine();
Console.WriteLine();
Console.WriteLine("List Query");
// transform query to list 
var listOrderedNumbers = numbers
    .Where(number => number % 2 == 1)
    .OrderBy(number => number).ToList();

listOrderedNumbers.Add(24); // This will not affect the original numbers list

Console.WriteLine(string.Join(", ", listOrderedNumbers));
Console.WriteLine();
Console.WriteLine("Original numbers list");
Console.WriteLine(string.Join(", ", numbers));

Console.WriteLine("----------");
var people = new List<Person>
{
    new Person("Steve Irwin", "UK"),
    new Person("Hugh Jackman", "Australia"),
    new Person("Nicole Kidman", "Ethiopia"),
    new Person("Chris Hemsworth", "Canada"),
    new Person("Margot Robbie", "Australia"),
    new Person("Heath Ledger", "Australia"),
    new Person("Russell Crowe", "New Zealand"),
    new Person("Cate Blanchett", "Australia"),
    new Person("Liam Hemsworth", "USA"),
};

var aussies = people.Where(person => person.Country == "Australia");

// modify the amount of records returned using Take
var notAllAussies = aussies.Take(2);

Console.WriteLine();
Console.WriteLine("All Aussies");
Console.WriteLine(string.Join(", ", aussies));

Console.WriteLine();
Console.WriteLine("Modified Number of Aussies using Take");
Console.WriteLine(string.Join(", ", notAllAussies));

Console.WriteLine();
var shoes = new List<string>
{
    "Nike Air Max",
    "Adidas Ultraboost",
    "Puma Suede",
    "Reebok Classic",
    "New Balance 990",
    "Asics Gel-Kayano",
    "Converse Chuck Taylor",
    "Vans Old Skool"
};

// Demonstate deferred execution with side effects
// return keyword should be used when there are multiple lines in the lambda expression
var shoesStartingWithN = shoes.Where(shoe =>
{
    Console.WriteLine("Checking shoe: " + shoe); // Side effect to demonstrate deferred execution
    return shoe.StartsWith("N");
});

// Query is excuted at the same time as it is being iterated
foreach (var shoe in shoesStartingWithN)
{
    Console.WriteLine(shoe + " ");
}


/* End Method chaining */
Console.WriteLine();
Console.WriteLine();
var digits = new [] { 10, 25, 4, 6, 56, 7, 9 };
bool isAnyLargerThan10 = digits.Any(digit => digit > 10);
Console.WriteLine("isAnyLargerThan10 " + isAnyLargerThan10);


Console.WriteLine();
Console.WriteLine();

var pets = new[]
{
    new Pet(1, "Max", PetType.Fish, 1.1f),
    new Pet(2, "Bella", PetType.Dog, 12.5f),
    new Pet(3, "Charlie", PetType.Cat, 8.3f),
    new Pet(4, "Lucy", PetType.Dog, 10.0f),
    new Pet(5, "Daisy", PetType.Bird, 0.5f),
    new Pet(6, "Molly", PetType.Cat, 9.0f),
    new Pet(7, "Buddy", PetType.Dog, 15.2f),
};

var isAnyPetNamedLucy = pets.Any(pet => pet.Name == "Lucy");
Console.WriteLine("isAnyPetNamedLucy " + isAnyPetNamedLucy);

var isAnyDog = pets.Any(pet => pet.Type == PetType.Dog );
Console.WriteLine("isAnyDog " + isAnyDog);

var isThereAVerySpecificPet = pets.Any(pet => pet.Name.Length > 4 && pet.Id % 2 == 0);
Console.WriteLine("isThereAVerySpecificPet " + isThereAVerySpecificPet);

var isNotEmpty = pets.Any(); // returns true if there is at least one element and false if empty


public record Person(string Name, string Country);

public record Pet(int Id, string Name, PetType Type, float Weight);
public enum PetType
{
    Dog,
    Cat,
    Fish,
    Bird
}