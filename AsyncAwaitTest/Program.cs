using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace HelloWorld
{
  public class Program
  {
    public static void Main(string[] args)
    {
			Console.WriteLine("Start main thread");
			RunSomething();
			Console.WriteLine("Back to main thread");
			Console.ReadLine();
		}

		public static async void RunSomething()
		{
			Console.WriteLine("Start running something method");
			await SomeBlockingCode();
			Console.WriteLine("Finish running something method");
		}

		public static async Task SomeBlockingCode()
		{
			Console.WriteLine("Start blocking method");
			await Task.Delay(2500).ContinueWith(e => Console.WriteLine("Finished some kind of CPU intensive activity. Need to wait so long....."));
			Console.WriteLine("Finish blocking method");
		}

		public static IHostBuilder CreateHostBuilder(string[] args) =>
      Host.CreateDefaultBuilder(args)
          .ConfigureWebHostDefaults(webBuilder =>
          {
            webBuilder.UseStartup<Startup>();
          });
	}
}

