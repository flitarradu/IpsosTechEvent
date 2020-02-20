using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using Ipsos.TechEvent;
using Ipsos.TechEvent.Exceptions;

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
			/*
			var parent = new ExampleClass();
			var child = new ChildExampleClass();
			// parent._age = 255;
			parent.Age = 50;
			parent.ShouldNotBeImplemented();

			object o = parent;
			object t = new {t = 1};
			System.Console.WriteLine(o.ToString()); 
			System.Console.WriteLine(parent.ToString());
			System.Console.WriteLine(t.ToString());

			// A child can be a parent
			ExampleClass p = child;

			// A parent cannot be a child
			// ChildExampleClass c = parent;
			
			// An abstract class cannot be istantiated
			//var x = new ExampleAbstractClass();

			ExampleAbstractClass.StaticRandom();

			var p1 = new ExampleClass();
			var p2 = new ChildExampleClass();

			p1.SecondVariable = 15;
			p2.SecondVariable = 20;

			ExampleClass.RandomVariable = 25;

			p1.ChildAccessModifiers();
			p2.ChildAccessModifiers();



			//*/

			/*
			AccessModifiers(parent, child);
			//*/

			/*
			Inheritance(parent, child);
			//*/

			/*
			Polymorphism(parent, child);
			Polymorphism(parent as IExampleAbstractClass, child as IExampleChildClass);
			//*/

			/*
			BoxingUnboxing();
			//*/

			/*
			try
			{
				ExceptionHandlingCorrect(1);
			}
			catch (Exception ex)
			{
				System.Console.WriteLine(ex);
				System.Console.WriteLine(ex.InnerException);
			}

			Delimiter();

			try
			{
				ExceptionHandlingCorrect(2);
			}
			catch (Exception ex)
			{
				System.Console.WriteLine(ex);
				System.Console.WriteLine(ex.InnerException);
			}

			Delimiter();

			try
			{
				ExceptionHandlingCorrect(3);
			}
			catch (Exception ex)
			{
				System.Console.WriteLine(ex);
				System.Console.WriteLine(ex.InnerException);
			}
			//*/

			/*/
			Generics<string, Func<string, int>>(
				GenerateFeed,
				k => k.Length,
				kvp => kvp.Key.Length.ToString() + " -> " + kvp.Value.Invoke(kvp.Key).ToString());
			//*/
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

			// child does not expose methods
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

		static void ExceptionHandlingCorrect(int ex)
		{
			try
			{
				switch (ex)
				{
					case 1:
						throw new ExceptionChild();
					case 2:
						throw new ExceptionParent();
					default:
						throw new ExceptionGrandParent();
				}
			}
			catch (ExceptionChild exc)
			{
				System.Console.WriteLine(exc);
				throw;
			}
			catch (ExceptionParent exp)
			{
				System.Console.WriteLine(exp);
				throw exp;
			}
			catch (ExceptionGrandParent exgp)
			{
				System.Console.WriteLine(exgp);
			}
			finally
			{
				System.Console.WriteLine("Finally!");
			}
		}

		/*
		static void ExceptionHandlingIncorrect(int ex)
		{
			try
			{
				switch (ex)
				{
					case 1:
						throw new ExceptionChild();
					case 2:
						throw new ExceptionParent();
					default:
						throw new ExceptionGrandParent();
				}
			}
			catch (ExceptionGrandParent exgp)
			{
				System.Console.WriteLine(exgp);
			}
			catch (ExceptionParent exp)
			{
				System.Console.WriteLine(exp);
			}
			catch (ExceptionChild exc)
			{
				System.Console.WriteLine(exc);
			}
			finally
			{
				System.Console.WriteLine("Finally!");
			}
		}
		*/

		private static IEnumerable<KeyValuePair<string, Func<string, int>>> GenerateFeed()
		{
			var rnd = new Random((int)(DateTime.Now.Ticks % int.MaxValue));
			var n = rnd.Next(5, 10);
			for (var i = 0; i < n; i++)
			{
				yield return new KeyValuePair<string, Func<string, int>>
				(
					GenerateString(10 + (GenerateRandomInt() % 10)),
					s => s.Length * 2
				);
			}
		}

		private static void Generics<TKey, TValue>(
			Func<IEnumerable<KeyValuePair<TKey, TValue>>> feed,
			Func<TKey, int> order,
			Func<KeyValuePair<TKey, TValue>, string> display)
		{
			var dic = new Dictionary<TKey, TValue>(feed.Invoke());
			var orderedDic = dic.OrderBy(e => order(e.Key));
			foreach (var item in dic)
			{
				System.Console.WriteLine($"{item.Key}: {display(item)}");
			}
			Delimiter();
			foreach (var item in orderedDic)
			{
				System.Console.WriteLine($"{item.Key} = {display(item)}");
			}
		}

		private static string GenerateString(int len)
		{
			const string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
			var result = "";
			for (var i = 0; i < len; i++)
			{
				var intVal = GenerateRandomInt();
				result += letters[intVal % letters.Length];
			}
			return result;
		}

		private static int GenerateRandomInt()
		{
			var data = GenerateRandomBytes();
			return Math.Abs(BitConverter.ToInt32(data, 0));
		}

		private static byte[] GenerateRandomBytes(int restrict = 4)
		{
			byte[] data = new byte[restrict];
			using (var crypto = new RNGCryptoServiceProvider())
			{
				crypto.GetNonZeroBytes(data);
			}
			return data;
		}


		private static void Delimiter(int nr = 50)
		{
			System.Console.WriteLine();
			System.Console.WriteLine(new String('=', nr));
			System.Console.WriteLine();
		}
	}
}
