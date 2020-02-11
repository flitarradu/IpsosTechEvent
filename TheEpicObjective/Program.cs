using System;
using Ipsos.TechEvent;

namespace Ipsos.TheEpicObjective
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Starting...");

			Run();

			Console.WriteLine("End");
		}

		static void Run()
		{
			var parent = new ExampleClass();
			var child = new ChildExampleClass();

			AccessModifiers(parent, child);
			Inheritance(parent, child);
			Polymorphism(parent, child);
			Polymorphism(parent as IExampleAbstractClass, child as IExampleChildClass);
			BoxingUnboxing();
			ExceptionHandling();
		}

		static void AccessModifiers(ExampleClass parent, IExampleChildClass child)
		{
			//same assembly
			System.Console.WriteLine(parent._protectedInternal);
			System.Console.WriteLine(parent.InternalProperty);
			System.Console.WriteLine(parent.PublicProperty);
			parent.PublicMethod();
			child.ChildAccessModifiers();
		}

		static void Polymorphism(ExampleClass parent, ChildExampleClass child)
		{
			System.Console.WriteLine($"ExampleClass - ShouldNotBeImplemented: {parent.ShouldNotBeImplemented()}");
			System.Console.WriteLine($"ExampleClass - ShouldBeImplemented: {parent.ShouldBeImplemented()}");

			System.Console.WriteLine($"ChildExampleClass - ShouldNotBeImplemented: {child.ShouldNotBeImplemented()}");
			System.Console.WriteLine($"ChildExampleClass - ShouldBeImplemented: {child.ShouldBeImplemented()}");

			var parentNew = (ExampleClass)child;
			var childNew = (ChildExampleClass)parent;
		}

		static void Polymorphism(IExampleAbstractClass parent, IExampleChildClass child)
		{
			System.Console.WriteLine($"ExampleClass - ShouldNotBeImplemented: {parent.ShouldNotBeImplemented()}");
			System.Console.WriteLine($"ExampleClass - ShouldBeImplemented: {parent.ShouldBeImplemented()}");

			//System.Console.WriteLine($"ChildExampleClass - ShouldNotBeImplemented: {child.ShouldNotBeImplemented()}");
			//System.Console.WriteLine($"ChildExampleClass - ShouldBeImplemented: {child.ShouldBeImplemented()}");
		}

		static void Inheritance(ExampleClass parent, ChildExampleClass child)
		{
			child.PublicMethod();
			child.Inheritance();
		}

		static void BoxingUnboxing()
		{
			int i = 10;

			// This is boxing
			object o = i;

			// This is unboxing
			Console.WriteLine((int)o);
		}

		static void ExceptionHandling()
		{

		}
	}
}
