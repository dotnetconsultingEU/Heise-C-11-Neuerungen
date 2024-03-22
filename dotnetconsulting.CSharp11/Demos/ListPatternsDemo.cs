// Disclaimer
// Dieser Quellcode ist als Vorlage oder als Ideengeber gedacht. Er kann frei und ohne 
// Auflagen oder Einschränkungen verwendet oder verändert werden.
// Jedoch wird keine Garantie übernommen, dass eine Funktionsfähigkeit mit aktuellen und 
// zukünftigen API-Versionen besteht. Der Autor übernimmt daher keine direkte oder indirekte 
// Verantwortung, wenn dieser Code gar nicht oder nur fehlerhaft ausgeführt wird.
// Für Anregungen und Fragen stehe ich jedoch gerne zur Verfügung.

// Thorsten Kansy, www.dotnetconsulting.eu

using System.Diagnostics;
using static System.Console;

namespace dotnetconsulting.CSharp11.Demos;

internal class ListPatternsDemo
{
    internal static void Run()
    {
        Debugger.Break();

        var numbers = new int[] { 1, 3, 5, 7, 9 };

        WriteLine($"1) {numbers is [1, 3, 5, 7, 9]}");
        WriteLine($"2) {numbers is [1, .., 7]}"); // .. => Range Pattern, 0..n Elemente
        WriteLine($"3) {numbers is [1, 3, _, 7, 9]}"); // _ => Discard Pattern, 1 Element
        WriteLine($"4) {numbers is [1, _, 3, 7, >= 9]}"); 

        if (numbers is [1, 3, 5, var x, 9]) // var => Var Pattern, liest Werte aus "Treffern"
            WriteLine($"5) True x={x}");
        else
            WriteLine($"5) False");
        
        WriteLine($"6) {numbers is [1, _, 3, 5, 7, >= 9]}");
        WriteLine($"7) {numbers is [1, .., 3, 5, 7, >= 9]}");
        WriteLine($"8) {numbers is [1, 3, .. int[] restOfArray]}"); // .. => Rest of array

        // Nicht erlaubt sind Type object oder dynamic
        var transactions = new string[][]
        {
            new string [] {"2022-08-16", "DEPOSIT", "Initial deposit", "2250" },
            new string [] {"2022-08-16", "DEPOSIT", "Refund","125" },
            new string [] {"2022-08-17", "DEPOSIT", "Paycheck","825" },
            new string [] {"2022-08-17", "WITHDRAWAL", "Debit", "Groceries", "255" },
            new string [] {"2022-08-17", "WITHDRAWAL" , "#1812", "Rent", "2100" },
            new string [] {"2022-08-18", "INTEREST", "0" },
            new string [] {"2022-08-19", "WITHDRAWAL", "Debit", "Movies", "12" },
            new string [] {"2022-08-20", "FEE", "6" },
        };

        decimal balance = 0.0m;
        foreach (var transaction in transactions)
        {
            balance += transaction switch
            {
                [_, "DEPOSIT", .., string amount] => decimal.Parse(amount),
                [_, "WITHDRAWAL", .., string amount] => -decimal.Parse(amount),
                [_, "INTEREST", .., string amount] => decimal.Parse(amount),
                [_, "FEE", .., string amount] => -decimal.Parse(amount),
                _ => throw new InvalidOperationException()
            };
        }

        WriteLine($"balance: {balance:N2}");

        Debugger.Break();
    }
}