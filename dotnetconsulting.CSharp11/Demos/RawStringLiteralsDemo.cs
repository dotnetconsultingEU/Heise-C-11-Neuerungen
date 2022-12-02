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

internal class RawStringLiteralsDemo
{
    internal static void Run()
    {
        Debugger.Break();

        //  Text über mehrere Zeilen
        string longMessage = """
            This is a long message.
            It has several lines.
                Some are indented
                        more than others.
            Some should start at the first column.
            Some have "quoted text" in them.
            """;
        WriteLine(longMessage);

        // Text mit String Interpolation
        var todayMessage = $$"""
            Today is the {{DateTime.Today:d}}

            A few curly braces for the day {{{1}}}
            """;
        WriteLine(todayMessage);

        // Json
        var jsonString = """
            {
              "employees": [
                {
                  "firstName": "John",
                  "lastName": "Doe"
                },
                {
                  "firstName": "Anna",
                  "lastName": "Smith"
                },
                {
                  "firstName": "Peter",
                  "lastName": "Jones"
                }
              ]
            }
            """;
        WriteLine(jsonString);

        // Json
        string firstName = "Thorsten";
        string lastName = "Kansy";
        var jsonString2 = $$"""
            {
                "employees": [
                {
                    "firstName": "{{firstName}}",
                    "lastName": "{{lastName}}"
                },
                {
                    "firstName": "Anna",
                    "lastName": "Smith"
                },
                {
                    "firstName": "Peter",
                    "lastName": "Jones"
                }
                ]
            }
            """;
        WriteLine(jsonString2);

        Debugger.Break();
    }
}