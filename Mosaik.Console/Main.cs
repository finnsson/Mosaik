using System;
using Mosaik.Library;

namespace Mosaik.Console
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			//var photo = args[0];
			
			System.Console.WriteLine ("Hello World!");
			
			var factory = new Factory("data.db4o");
			
			var modelDB = factory.ModelDB();
			
			var res = modelDB.Read();
			
			System.Console.WriteLine(res.Length);
		}
	}
}