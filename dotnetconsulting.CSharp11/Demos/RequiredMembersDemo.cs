// Disclaimer
// Dieser Quellcode ist als Vorlage oder als Ideengeber gedacht. Er kann frei und ohne 
// Auflagen oder Einschränkungen verwendet oder verändert werden.
// Jedoch wird keine Garantie übernommen, dass eine Funktionsfähigkeit mit aktuellen und 
// zukünftigen API-Versionen besteht. Der Autor übernimmt daher keine direkte oder indirekte 
// Verantwortung, wenn dieser Code gar nicht oder nur fehlerhaft ausgeführt wird.
// Für Anregungen und Fragen stehe ich jedoch gerne zur Verfügung.

// Thorsten Kansy, www.dotnetconsulting.eu

using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace dotnetconsulting.CSharp11.Demos;

#pragma warning disable IDE0059 // Unnecessary assignment of a value

internal class RequiredMembersDemo
{
    internal static void Run()
    {
        Debugger.Break();

        // Fehler
        // var instance1 = new ClassWithRequired();

        // Es müssen alle 'required' Felder gesetzt werden 
        var instance2 = new ClassWithRequired()
        {
            Firstname = "Thorsten",
            Name = "Kansy",
            Age = 18,
            LikesCSharp = true
        };

        var instance3 = new ClassWithRequired(name: "Kansy", firstname:"Thorsten", 
                                               age: 21, likesCSharp: true);

        var instance4 = new ClassWithRequired(name: "Kansy", firstname: "Thorsten");

        Debugger.Break();
    }
}

public class ClassWithRequired
{
    // Eigenschaften
    public required string Name { get; init; }

    public required string Firstname { get; set; }

    // Felder
    public required int Age;

    public required bool LikesCSharp = true;

    public ClassWithRequired()
    {  }

    [SetsRequiredMembers]
    public ClassWithRequired(string name, string firstname, int age, bool likesCSharp)
    {
        Name = name;
        Firstname = firstname;
        Age = age;
        LikesCSharp = likesCSharp;
    }

    [SetsRequiredMembers]
    public ClassWithRequired(string name, string firstname)
    {
        Name = name;
        Firstname = firstname;
        Age = 21;
    }
}