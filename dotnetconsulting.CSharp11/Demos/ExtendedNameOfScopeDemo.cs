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

#pragma warning disable IDE0060 // Remove unused parameter

namespace dotnetconsulting.CSharp11.Demos;

internal class ExtendedNameOfScopeDemo
{
    internal static void Run()
    {
        Debugger.Break();


        Debugger.Break();
    }

    [MyDemo(nameof(msg))]
    [return: NotNullIfNotNull(nameof(msg))]
    internal static void DemoCall(string msg)
    {

    }
}

[AttributeUsage(AttributeTargets.Method)]
internal class MyDemoAttribute: Attribute
{
    public MyDemoAttribute(string ParameterName) => 
        Debug.Print(ParameterName);
}