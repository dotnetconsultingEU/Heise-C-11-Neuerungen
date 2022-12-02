// Disclaimer
// Dieser Quellcode ist als Vorlage oder als Ideengeber gedacht. Er kann frei und ohne 
// Auflagen oder Einschränkungen verwendet oder verändert werden.
// Jedoch wird keine Garantie übernommen, dass eine Funktionsfähigkeit mit aktuellen und 
// zukünftigen API-Versionen besteht. Der Autor übernimmt daher keine direkte oder indirekte 
// Verantwortung, wenn dieser Code gar nicht oder nur fehlerhaft ausgeführt wird.
// Für Anregungen und Fragen stehe ich jedoch gerne zur Verfügung.

// Thorsten Kansy, www.dotnetconsulting.eu

using System.Diagnostics;
using System.Numerics;
using static System.Console;

namespace dotnetconsulting.CSharp11.Demos;

internal class GenericMathDemo
{
    internal static void Run()
    {
        Debugger.Break();

        // Demo mit generischer Addition
        int i = AddNumber(1, 1);
        _ = AddNumber(1.0m, 1.0m);
        _ = AddNumber(1.0f, 1.0f);
        WriteLine($"Nun ist es raus: {i}");

        // Demo mit generischer Methode und unterschiedlichen numerischen Datentypen
        DumpSequence(10);
        DumpSequence(5.0m);
        DumpSequence(7.0f);

        Debugger.Break();
    }

    static T AddNumber<T>(T left, T right) where T : INumber<T>, IAdditionOperators<T, T, T> => left + right;

    static void DumpSequence<T>(T number) where T : INumber<T>
    {
        for (T i = default!; i < number; i++)
            WriteLine($"{i}");
    }
}