// See https://aka.ms/new-console-template for more information
string[] words = { "operation", "video", "coach", "program", "books", "pencil" };
Random rnd = new();
string word = words[rnd.Next(words.Length)];

string hidden = new string('_', word.Length);
int triesLeft = 6;

Console.WriteLine("Congratulations! Try to guess the encrypted word!");
Console.WriteLine($"Number of letters in a word: {word.Length}");
Console.WriteLine($"Number of possible incorrect attempts: {triesLeft}");
Console.WriteLine();

while (triesLeft > 0 && hidden != word)
{
    Console.Write("Enter your letter: ");
    string input = Console.ReadLine();

    if (string.IsNullOrWhiteSpace(input) || input.Length != 1)
    {
        Console.WriteLine("Enter one letter!");
        continue;
    }

    char letter = input[0];
    bool found = false;
    string newHidden = "";

    for (int i = 0; i < word.Length; i++)
    {
        if (word[i] == letter)
        {
            newHidden += letter;
            found = true;
        }
        else
        {
            newHidden += hidden[i];
        }
    }

    if (found)
    {
        Console.WriteLine("This letter is in the word!");
    }
    else
    {
        triesLeft--;
        Console.WriteLine($"There is no such letter! More attempts left: {triesLeft}");
    }

    hidden = newHidden;
    Console.WriteLine("Word: " + hidden);
    Console.WriteLine();
}

if (hidden == word)
{
    Console.WriteLine($"Congratulations, you guessed the word! That was: {word}");
}
else
{
    Console.WriteLine($"You lost. The guessed word was: {word}");
}

Console.WriteLine("Thanks for playing..");
