// See https://aka.ms/new-console-template for more information
using Console_Translator;

Console.WriteLine("Welcome to Deni's 4th-IR Translator!!!!");
Console.WriteLine("What do you wanna translate?");
var input = Console.ReadLine();
ApiTest api = new ApiTest(input);

string result = await api.ChangeText();

Console.WriteLine(result);
