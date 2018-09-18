using System;
using Gravity.Test.Helpers;
using Relativity.API;
using Relativity.Test.Helpers;

namespace GravityDemo
{
    public partial class Program
    {
	    private static TestHelper helper;

        static void Main()
        {
	        Init();

            Console.WriteLine("Create new instance of object");
	        var newArtifactId = Create();
            
	        
	        // Keep the console window open in debug mode.
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

	    private static void Init()
	    {
			helper = new TestHelper();
		}
    }
}
