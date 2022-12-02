// Disclaimer
// Dieser Quellcode ist als Vorlage oder als Ideengeber gedacht. Er kann frei und ohne 
// Auflagen oder Einschränkungen verwendet oder verändert werden.
// Jedoch wird keine Garantie übernommen, dass eine Funktionsfähigkeit mit aktuellen und 
// zukünftigen API-Versionen besteht. Der Autor übernimmt daher keine direkte oder indirekte 
// Verantwortung, wenn dieser Code gar nicht oder nur fehlerhaft ausgeführt wird.
// Für Anregungen und Fragen stehe ich jedoch gerne zur Verfügung.

// Thorsten Kansy, www.dotnetconsulting.eu

using System.Collections;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.Numerics;
using System.Reflection;
using static System.Console;


#pragma warning disable IDE0060 // Remove unused parameter
#pragma warning disable CA1822 // Mark members as static

namespace dotnetconsulting.CSharp11.Demos;

internal class GenericAttributesDemo
{
    internal static void Run()
    {
        Debugger.Break();

        var x = new GenericType<string>();
        x.Method1();

        Debugger.Break();
    }

    [AttributeUsage(AttributeTargets.Method)]
    internal class NonGenericAttribute : Attribute
    {
        public NonGenericAttribute(Type t)
        { }
    }

    [AttributeUsage(AttributeTargets.Method)]
    internal class GenericAttribute<T> : Attribute // where T : IEnumerable
    { }

    // [GenericAttribute<string>()]
    internal class GenericType<T>
    {
        [GenericAttribute<string>()]
        // [NonGenericAttribute(typeof(string))]
        internal void Method1()
        {
            MethodBase method = MethodBase.GetCurrentMethod()!;

            // Generisches Attribut
            GenericAttribute<T> genAttr = (GenericAttribute<T>)method.GetCustomAttributes(typeof(GenericAttribute<T>), true)[0];
            // Bei Typeneinschränkung im Attribute
            // GenericAttribute<IEnumerable<T>> genAttr = (GenericAttribute<IEnumerable<T>>)method.GetCustomAttributes(typeof(GenericAttribute<IEnumerable<T>>), true)[0];
            WriteLine($"type={genAttr.GetType()}");
            WriteLine($"genAttr.GetType().IsGenericType= {genAttr.GetType().IsGenericType}");

            // Zum Vergleich, ein nicht generisches Attribut
            NonGenericAttribute nonGenAttr = (NonGenericAttribute)method.GetCustomAttributes(typeof(NonGenericAttribute), true)[0];
            WriteLine($"type={nonGenAttr.GetType()}");
            WriteLine($"nonGenAttr.GetType().IsGenericType= {nonGenAttr.GetType().IsGenericType}");
        }

        //[GenericAttribute<T>()] // Not allowed! generic attributes must be fully constructed types.
        //public T Method2() => default(T);

        public Type GetGenericType => typeof(T);
    }
}