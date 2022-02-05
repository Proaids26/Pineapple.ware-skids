using System;

namespace HWIDSpoofer
{
	// Token: 0x02000002 RID: 2
	internal class Program
	{
		// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
		private static void Main(string[] args)
		{
			for (;;)
			{
				Console.Title = "MangoSpoofer";
				Console.ResetColor();
				Console.Clear();
				Console.WriteLine(Program.textLogo);
				Console.WriteLine("  ┌───────────────── FUNCS ─────────────────┐");
				Console.WriteLine("  │   [1] Spoof HWID                        │");
				Console.WriteLine("  │   [2] Spoof Guid                        │");
				Console.WriteLine("  │   [3] Spoof your Computer Name          │");
				Console.WriteLine("  │   [4] Spoof ProductId                   │");
				Console.WriteLine("  └─────────────────────────────────────────┘");
				string a = Console.ReadLine();
				if (a == "1")
				{
					Console.Clear();
					Console.WriteLine(Program.textLogo);
					if (Spoofer.HWID.Spoof())
					{
						Console.ForegroundColor = ConsoleColor.Green;
						Console.WriteLine(Spoofer.HWID.Log.ToString());
						Console.WriteLine("\n\nPress ENTER to use another commands...");
					}
					else
					{
						Console.ForegroundColor = ConsoleColor.Red;
						Console.WriteLine(Spoofer.HWID.Log.ToString());
					}
					Console.ReadLine();
				}
				else if (a == "2")
				{
					Console.Clear();
					Console.WriteLine(Program.textLogo);
					if (Spoofer.PCGuid.Spoof())
					{
						Console.ForegroundColor = ConsoleColor.Green;
						Console.WriteLine(Spoofer.PCGuid.Log.ToString());
						Console.WriteLine("\n\nPress ENTER to use another commands...");
					}
					else
					{
						Console.ForegroundColor = ConsoleColor.Red;
						Console.WriteLine(Spoofer.PCGuid.Log.ToString());
					}
					Console.ReadLine();
				}
				else if (a == "3")
				{
					Console.Clear();
					Console.WriteLine(Program.textLogo);
					if (Spoofer.PCName.Spoof())
					{
						Console.ForegroundColor = ConsoleColor.Green;
						Console.WriteLine(Spoofer.PCName.Log.ToString());
						Console.WriteLine("\n\nPress ENTER to use another commands...");
					}
					else
					{
						Console.ForegroundColor = ConsoleColor.Red;
						Console.WriteLine(Spoofer.PCName.Log.ToString());
					}
					Console.ReadLine();
				}
				else if (a == "4")
				{
					Console.Clear();
					Console.WriteLine(Program.textLogo);
					if (Spoofer.ProductId.Spoof())
					{
						Console.ForegroundColor = ConsoleColor.Green;
						Console.WriteLine(Spoofer.ProductId.Log.ToString());
						Console.WriteLine("\n\nPress ENTER to use another commands...");
					}
					else
					{
						Console.ForegroundColor = ConsoleColor.Red;
						Console.WriteLine(Spoofer.ProductId.Log.ToString());
					}
					Console.ReadLine();
				}
			}
		}

		// Token: 0x04000001 RID: 1
		public static string textLogo = string.Concat(new string[]
		{
			" ___ ___   ____  ____    ____   ___   _____ ____   ___    ___   _____  ___  ____  ",
			Environment.NewLine,
			"|   |   | /    ||    \\  /    | /   \\ / ___/|    \\ /   \\  /   \\ |     |/  _]|    \\ ",
			Environment.NewLine,
			"| _   _ ||  o  ||  _  ||   __||     (   \\_ |  o  )     ||     ||   __/  [_ |  D  )",
			Environment.NewLine,
			"|  \\_/  ||     ||  |  ||  |  ||  O  |\\__  ||   _/|  O  ||  O  ||  |_|    _]|    / ",
			Environment.NewLine,
			"|   |   ||  _  ||  |  ||  |_ ||     |/  \\ ||  |  |     ||     ||   _]   [_ |    \\ ",
			Environment.NewLine,
			"|   |   ||  |  ||  |  ||     ||     |\\    ||  |  |     ||     ||  | |     ||  .  \\",
			Environment.NewLine,
			"|___|___||__|__||__|__||___,_| \\___/  \\___||__|   \\___/  \\___/ |__| |_____||__|\\_| ",
			Environment.NewLine
		});
	}
}
