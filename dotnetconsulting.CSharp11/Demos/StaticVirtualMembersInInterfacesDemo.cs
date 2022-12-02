// Disclaimer
// Dieser Quellcode ist als Vorlage oder als Ideengeber gedacht. Er kann frei und ohne 
// Auflagen oder Einschränkungen verwendet oder verändert werden.
// Jedoch wird keine Garantie übernommen, dass eine Funktionsfähigkeit mit aktuellen und 
// zukünftigen API-Versionen besteht. Der Autor übernimmt daher keine direkte oder indirekte 
// Verantwortung, wenn dieser Code gar nicht oder nur fehlerhaft ausgeführt wird.
// Für Anregungen und Fragen stehe ich jedoch gerne zur Verfügung.

// Thorsten Kansy, www.dotnetconsulting.eu

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using System.Diagnostics;
using static System.Console;

#pragma warning disable IDE0059 // Unnecessary assignment of a value

namespace dotnetconsulting.CSharp11.Demos;

internal class StaticVirtualMembersInInterfacesDemo
{
    internal static void Run()
    {
        Debugger.Break();

        // Instanzen passend zum Interface erzeugen.
        // Die Erstellung erfolgt via statischer Methode.
        IObject<MyObject> x1 = MyObject.CreateNew();
        MyObject x2 = MyObject.CreateNew();

        // Demo-Aufruf mit Typenparamter
        IObjectDemo<MyObject>();

        // Demo mit Struct und Operator
        var str = new RepeatSequence();
        for (int i = 0; i < 10; i++)
            WriteLine(str++);

        // Web Demo
        RunWebDemo();

        Debugger.Break();
    }

    internal static void IObjectDemo<T>() where T : IObject<T>
    {
        T x1 = T.CreateNew();
        T x2 = T.CreateNew();

        WriteLine($"x1=x2: {T.IsEqual(x1, x2)}");
    }

    internal static void RunWebDemo()
    {
        // Demo WebApp
        var builder = WebApplication.CreateBuilder();
        var app = builder.Build();

        // Wozu genau wird die Instanz gebraucht? Sie ist unnötig
        // http://localhost:5000/HelloWorldOld
        app.MapEndPointOld(new HelloWorldOld());

        // Eleganter ab C#11
        // http://localhost:5000/HelloWorld
        app.MapEndPoint<HelloWorld>();
        
        app.Run();
    }
}

#region ObjectKey Demo
internal interface IHasKey
{
    public string? Key { get; set; }
}

internal interface IObject<T> : IHasKey where T : IHasKey
{
    static abstract T CreateNew();

    static virtual bool IsEqual(T A, T B) => string.Compare(A.Key, B.Key, true) == 0;
}

internal class MyObject : IObject<MyObject>
{
    public string? Key { get; set; }

    public static MyObject CreateNew() => new() { Key = DateTime.Now.ToString() };
}
#endregion

#region Struct Demo
internal interface IGetNext<T> where T : IGetNext<T>
{
    static abstract T operator ++(T other);
}

internal struct RepeatSequence : IGetNext<RepeatSequence>
{
    private const char Ch = 'A';
    public string Text = new(Ch, 1);

    public RepeatSequence() { }

    public static RepeatSequence operator ++(RepeatSequence other) => other with { Text = other.Text + Ch };

    public override string ToString() => Text;
}
#endregion

#region Web Demo
#region Pre C#11
internal interface IEndpointOld
{
    public string Pattern { get; }

    HttpMethod Method { get; }

    Delegate Handler { get; }
}

public class HelloWorldOld : IEndpointOld
{
    public string Pattern => "HelloWorldOld";

    public HttpMethod Method => HttpMethod.Get;

    public Delegate Handler => () => "Hello World Old";
}

public static class EndpointExtentionsOld
{
    internal static IEndpointRouteBuilder MapEndPointOld(this IEndpointRouteBuilder app, IEndpointOld endpoint)
    {
        app.MapMethods(endpoint.Pattern,
                       new string[] { endpoint.Method.ToString() },
                       endpoint.Handler);

        return app;
    }
}
#endregion

#region C#11
internal interface IEndpoint
{
    static abstract string Pattern { get; }

    static virtual HttpMethod Method { get; } = HttpMethod.Get;

    static abstract Delegate Handler { get; }
}

public class HelloWorld : IEndpoint
{
    public static string Pattern => "HelloWorld";

    // Überschreiben nur optional
    // public static HttpMethod Method => HttpMethod.Post;

    public static Delegate Handler => () => "Hello World, C#11";
}
public static class EndpointExtentions
{
    internal static IEndpointRouteBuilder MapEndPoint<T>(this IEndpointRouteBuilder app)
        where T : IEndpoint
    {
        app.MapMethods(T.Pattern,
                       new string[] { T.Method.ToString() },
                       T.Handler);

        return app;
    }
}
#endregion
#endregion