// Disclaimer
// Dieser Quellcode ist als Vorlage oder als Ideengeber gedacht. Er kann frei und ohne 
// Auflagen oder Einschränkungen verwendet oder verändert werden.
// Jedoch wird keine Garantie übernommen, dass eine Funktionsfähigkeit mit aktuellen und 
// zukünftigen API-Versionen besteht. Der Autor übernimmt daher keine direkte oder indirekte 
// Verantwortung, wenn dieser Code gar nicht oder nur fehlerhaft ausgeführt wird.
// Für Anregungen und Fragen stehe ich jedoch gerne zur Verfügung.

// Thorsten Kansy, www.dotnetconsulting.eu

using System.Diagnostics;
using System.Text;
using static System.Console;

#pragma warning disable IDE0059 // Unnecessary assignment of a value

namespace dotnetconsulting.CSharp11.Demos;

internal class UTF8StringDemo
{
    internal static void Run()
    {
        Debugger.Break();

        // Alte Ansatz
        byte[] utfBytes = Encoding.UTF8.GetBytes("Hallo Welt");
        var utf8String = Encoding.UTF8.GetString(utfBytes, 0, utfBytes.Length);


        ReadOnlySpan<byte> utf8string1 = "hello"u8;
        byte[] array = "hello"u8.ToArray();

        // Span<byte> span = "dog"u8;                // new byte[] { 0x64, 0x6f, 0x67 }

        dumpSpan(utf8string1);

        Debugger.Break();

        static void dumpSpan(ReadOnlySpan<byte> span)
        {
            StringBuilder sb = new();
            foreach (byte b in span)
                sb.Append($"0x{b:x},");
            WriteLine(sb.ToString().TrimEnd(','));
        }
    }

    //static void Write(ReadOnlySpan<byte> message = "missing"u8)
    //{
    //    // Konstanten können nicht vom Typ ReadOnlySpan<byte> sein,
    //    // sodass Standardwerte für Parameter, Variablen, etc. nicht möglich sind
    //    const ReadOnlySpan<byte> utf8string1 = "hello"u8;
    //}
}