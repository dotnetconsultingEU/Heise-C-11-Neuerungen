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

internal class NewLineInStringInterpolationDemo
{
    internal static void Run()
    {
        Debugger.Break();

        // Nicht neu, nur mehrere String Interpolations
        string i1 = $"Heute ist " +
                    $"der {DateTime.Today:d}";
        WriteLine($"i1={i1}");

        // Das geht erst ab C#11
        string i2 = $@"Heute ist {DateTime.Today.DayOfWeek switch
                                    {
                                        DayOfWeek.Sunday => 7,
                                        DayOfWeek.Monday => 1,
                                        DayOfWeek.Tuesday => 2,
                                        DayOfWeek.Wednesday => 3,
                                        DayOfWeek.Thursday => 4,
                                        DayOfWeek.Friday => 5,
                                        DayOfWeek.Saturday => 6,
                                        // Code-Analyse hält das für wichtig ;-)
                                        _ => throw new NotImplementedException(), 
                                    }}. Tag der Woche";
        WriteLine($"i1={i2}");

        Debugger.Break();
    }
}