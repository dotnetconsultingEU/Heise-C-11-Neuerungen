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

namespace dotnetconsulting.CSharp11.Demos
{
    internal class NumericIntPtrandUIntPtrDemo
    {
        internal static void Run()
        {
            Debugger.Break();

            nint n1 = default;
            nuint n2 = default;

            if (n1.GetType() == typeof(System.IntPtr))
                WriteLine("nint Alias für System.IntPtr");

            if (n2.GetType() == typeof(System.UIntPtr))
                WriteLine("nuint Alias für System.UIntPtr");

            Debugger.Break();
        }
    }
}