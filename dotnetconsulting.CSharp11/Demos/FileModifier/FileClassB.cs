// Disclaimer
// Dieser Quellcode ist als Vorlage oder als Ideengeber gedacht. Er kann frei und ohne 
// Auflagen oder Einschränkungen verwendet oder verändert werden.
// Jedoch wird keine Garantie übernommen, dass eine Funktionsfähigkeit mit aktuellen und 
// zukünftigen API-Versionen besteht. Der Autor übernimmt daher keine direkte oder indirekte 
// Verantwortung, wenn dieser Code gar nicht oder nur fehlerhaft ausgeführt wird.
// Für Anregungen und Fragen stehe ich jedoch gerne zur Verfügung.

// Thorsten Kansy, www.dotnetconsulting.eu

using static System.Console;

namespace dotnetconsulting.CSharp11.Demos;

file interface IFile
{
    DateOnly GetDate();
}

file class FileClass : IFile
{
    public DateOnly GetDate() => DateOnly.FromDateTime(DateTime.Today);
}

internal static class FileRunB
{
    internal static void Run()
    {
        IFile fileClass = new FileClass();
        WriteLine(fileClass.GetDate().ToString());
    }
}