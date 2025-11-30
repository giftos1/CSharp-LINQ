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
var digits = new[] { 10, 25, 4, 6, 56, 7, 9 };
bool isAnyLargerThan10 = digits.Any(digit => digit > 10);
Console.WriteLine("isAnyLargerThan10 " + isAnyLargerThan10);

var areAllLargerThan10 = digits.All(digit => digit > 10);
Console.WriteLine("areAllLargerThan10 " + areAllLargerThan10);

bool is7Present = digits.Contains(7);
Console.WriteLine("is7Present " + is7Present);


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

var isAnyDog = pets.Any(pet => pet.Type == PetType.Dog);
Console.WriteLine("isAnyDog " + isAnyDog);

var isThereAVerySpecificPet = pets.Any(pet => pet.Name.Length > 4 && pet.Id % 2 == 0);
Console.WriteLine("isThereAVerySpecificPet " + isThereAVerySpecificPet);

var isNotEmpty = pets.Any(); // returns true if there is at least one element and false if empty

var doAllHaveNonEmptynames = pets.All(pet => !string.IsNullOrEmpty(pet.Name));
Console.WriteLine("doAllHaveNonEmptynames " + doAllHaveNonEmptynames);

/*Count Functionality */
// Count returns long by default
var countOfDogs = pets.Count(pet => pet.Type == PetType.Dog);
Console.WriteLine("countOfDogs " + countOfDogs);

var countOfPetsNameMolly = pets.Count(pet => pet.Name == "Molly");
Console.WriteLine("countOfPetsNameMolly " + countOfPetsNameMolly);

var countDogsHeavierThan10 = pets.Count(pet => pet.Type == PetType.Dog && pet.Weight > 10);
Console.WriteLine("countDogsGreaterThan10 " + countDogsHeavierThan10);


var allPetsCount = pets.Count();
Console.WriteLine("allPetsCount " + allPetsCount);
/*End Count Functionality*/





/*Exercise
 
 Any & All
Using LINQ, implement the IsAnyWordWhiteSpace method, which checks if, in a given collection of strings, any word consists only of white space characters.

White space characters are all "empty" chars, like a space or a new line symbol. We can check if a character is a white space by using the char.IsWhiteSpace method.

For example:

for words {"hello", "There    "} the result shall be false because no word consists only of white space characters

for words {"hello", "      "}, the result shall be true because "      " consists only of white space characters

for empty collection, the result shall be false because no word consists only of whitespace characters (because there are no words at all)
 
 Answer:

public static bool IsAnyWordWhiteSpace(List<string> words) 
{
    
    return words.Any(word => word.All(letter => char.IsWhiteSpace(letter)));
}
 
Count & Contains
Implement the CountListsContainingZeroLongerThan method. It takes the following parameters:

length of type int

listsOfNumbers of type List of Lists of ints

This method should return the count of the lists that meet the following conditions:

Contain the number zero

Are longer than length

For example, for length 3 and the following lists contained in the listsOfNumbers:

{1, 2, 5, -1}

{0, 4, 4, 6}

{9, 0}

The result shall be 1 because there is only one list that contains zero, and has more than 3 items.

Answer:
public static int CountListsContainingZeroLongerThan(int length, List<List<int>> listsOfNumbers)
{
    //your code goes here
    return listsOfNumbers.Count(array => array.Contains(0) && array.Count() > length);
             
}
 */











public record Person(string Name, string Country);

public record Pet(int Id, string Name, PetType Type, float Weight);
public enum PetType
{
    Dog,
    Cat,
    Fish,
    Bird
}