using System;
using System.Text;
using Microsoft.Win32;

namespace HWIDSpoofer
{
	// Token: 0x02000003 RID: 3
	internal class Spoofer
	{
		// Token: 0x02000004 RID: 4
		public static class HWID
		{
			// Token: 0x06000005 RID: 5 RVA: 0x000022FB File Offset: 0x000004FB
			public static string GetValue()
			{
				return Spoofer.HWID.regeditOBJ.Read(Spoofer.HWID.Key);
			}

			// Token: 0x06000006 RID: 6 RVA: 0x0000230C File Offset: 0x0000050C
			public static bool SetValue(object value)
			{
				return Spoofer.HWID.regeditOBJ.Write(Spoofer.HWID.Key, value);
			}

			// Token: 0x06000007 RID: 7 RVA: 0x00002320 File Offset: 0x00000520
			public static bool Spoof()
			{
				Spoofer.HWID.Log.Clear();
				string value = Spoofer.HWID.GetValue();
				bool flag = Spoofer.HWID.SetValue("{" + Guid.NewGuid().ToString() + "}");
				if (flag)
				{
					Spoofer.HWID.Log.Append("  [MANGOSPOOFER] HWID spoofed sucessfully from " + value + " to " + Spoofer.HWID.GetValue());
					return flag;
				}
				Spoofer.HWID.Log.AppendLine("  [MANGOSPOOFER] ERROR - run the program as administrator");
				return flag;
			}

			// Token: 0x04000002 RID: 2
			public static Spoofer.Regedit regeditOBJ = new Spoofer.Regedit("SYSTEM\\CurrentControlSet\\Control\\IDConfigDB\\Hardware Profiles\\0001");

			// Token: 0x04000003 RID: 3
			public static readonly string Key = "HwProfileGuid";

			// Token: 0x04000004 RID: 4
			public static StringBuilder Log = new StringBuilder();
		}

		// Token: 0x02000005 RID: 5
		public static class PCGuid
		{
			// Token: 0x06000009 RID: 9 RVA: 0x000023BE File Offset: 0x000005BE
			public static string GetValue()
			{
				return Spoofer.PCGuid.regeditOBJ.Read(Spoofer.PCGuid.Key);
			}

			// Token: 0x0600000A RID: 10 RVA: 0x000023CF File Offset: 0x000005CF
			public static bool SetValue(object value)
			{
				return Spoofer.PCGuid.regeditOBJ.Write(Spoofer.PCGuid.Key, value);
			}

			// Token: 0x0600000B RID: 11 RVA: 0x000023E4 File Offset: 0x000005E4
			public static bool Spoof()
			{
				Spoofer.PCGuid.Log.Clear();
				string value = Spoofer.PCGuid.GetValue();
				bool flag = Spoofer.PCGuid.SetValue(Guid.NewGuid().ToString());
				if (flag)
				{
					Spoofer.PCGuid.Log.Append("  [MANGOSPOOFER] Guid succesfully spoofed from " + value + " to " + Spoofer.PCGuid.GetValue());
					return flag;
				}
				Spoofer.PCGuid.Log.AppendLine("  [MANGOSPOOFER] ERROR - run the program as administrator");
				return flag;
			}

			// Token: 0x04000005 RID: 5
			public static Spoofer.Regedit regeditOBJ = new Spoofer.Regedit("SOFTWARE\\Microsoft\\Cryptography");

			// Token: 0x04000006 RID: 6
			public static readonly string Key = "MachineGuid";

			// Token: 0x04000007 RID: 7
			public static StringBuilder Log = new StringBuilder();
		}

		// Token: 0x02000006 RID: 6
		public static class PCName
		{
			// Token: 0x0600000D RID: 13 RVA: 0x00002473 File Offset: 0x00000673
			public static string GetValue()
			{
				return Spoofer.PCName.regeditOBJ.Read(Spoofer.PCName.Key);
			}

			// Token: 0x0600000E RID: 14 RVA: 0x00002484 File Offset: 0x00000684
			public static bool SetValue(object value)
			{
				return Spoofer.PCName.regeditOBJ.Write(Spoofer.PCName.Key, value);
			}

			// Token: 0x0600000F RID: 15 RVA: 0x00002498 File Offset: 0x00000698
			public static bool Spoof()
			{
				Spoofer.PCName.Log.Clear();
				string value = Spoofer.PCName.GetValue();
				bool flag = Spoofer.PCName.SetValue("DESKTOP-" + Spoofer.Utilities.GenerateString(15));
				if (flag)
				{
					Spoofer.PCName.Log.Append("  [MANGOSPOOFER] Computer name spoofed from " + value + " to " + Spoofer.PCName.GetValue());
					return flag;
				}
				Spoofer.PCName.Log.AppendLine("  [MANGOSPOOFER] ERROR - run the program as administrator");
				return flag;
			}

			// Token: 0x04000008 RID: 8
			public static Spoofer.Regedit regeditOBJ = new Spoofer.Regedit("SYSTEM\\CurrentControlSet\\Control\\ComputerName\\ActiveComputerName");

			// Token: 0x04000009 RID: 9
			public static readonly string Key = "ComputerName";

			// Token: 0x0400000A RID: 10
			public static StringBuilder Log = new StringBuilder();
		}

		// Token: 0x02000007 RID: 7
		public static class ProductId
		{
			// Token: 0x06000011 RID: 17 RVA: 0x00002525 File Offset: 0x00000725
			public static string GetValue()
			{
				return Spoofer.ProductId.regeditOBJ.Read(Spoofer.ProductId.Key);
			}

			// Token: 0x06000012 RID: 18 RVA: 0x00002536 File Offset: 0x00000736
			public static bool SetValue(object value)
			{
				return Spoofer.ProductId.regeditOBJ.Write(Spoofer.ProductId.Key, value);
			}

			// Token: 0x06000013 RID: 19 RVA: 0x00002548 File Offset: 0x00000748
			public static bool Spoof()
			{
				Spoofer.ProductId.Log.Clear();
				string value = Spoofer.ProductId.GetValue();
				bool flag = Spoofer.ProductId.SetValue(string.Concat(new string[]
				{
					Spoofer.Utilities.GenerateString(5),
					"-",
					Spoofer.Utilities.GenerateString(5),
					"-",
					Spoofer.Utilities.GenerateString(5),
					"-",
					Spoofer.Utilities.GenerateString(5)
				}));
				if (flag)
				{
					Spoofer.ProductId.Log.AppendLine("  [MANGOSPOOFER] Sucessfully Spoofer Computer Product ID from " + value + " to " + Spoofer.ProductId.GetValue());
					return flag;
				}
				Spoofer.ProductId.Log.AppendLine("  [MANGOSPOOFER] ERROR - run the program as administrator");
				return flag;
			}

			// Token: 0x0400000B RID: 11
			public static Spoofer.Regedit regeditOBJ = new Spoofer.Regedit("SOFTWARE\\\\Microsoft\\\\Windows NT\\\\CurrentVersion");

			// Token: 0x0400000C RID: 12
			public static readonly string Key = "ProductID";

			// Token: 0x0400000D RID: 13
			public static StringBuilder Log = new StringBuilder();
		}

		// Token: 0x02000008 RID: 8
		public class Regedit
		{
			// Token: 0x06000015 RID: 21 RVA: 0x0000260B File Offset: 0x0000080B
			public Regedit(string regeditPath)
			{
				this.regeditPath = regeditPath;
			}

			// Token: 0x06000016 RID: 22 RVA: 0x00002628 File Offset: 0x00000828
			public string Read(string keyName)
			{
				string result;
				try
				{
					using (RegistryKey registryKey = Registry.LocalMachine.OpenSubKey(this.regeditPath, true))
					{
						if (registryKey != null)
						{
							result = registryKey.GetValue(keyName).ToString();
						}
						else
						{
							result = "ERR";
						}
					}
				}
				catch (Exception)
				{
					result = "ERR";
				}
				return result;
			}

			// Token: 0x06000017 RID: 23 RVA: 0x00002694 File Offset: 0x00000894
			public bool Write(string keyName, object value)
			{
				bool result;
				try
				{
					using (RegistryKey registryKey = Registry.LocalMachine.OpenSubKey(this.regeditPath, true))
					{
						if (registryKey != null)
						{
							registryKey.SetValue(keyName, value);
							result = true;
						}
						else
						{
							result = false;
						}
					}
				}
				catch (Exception)
				{
					result = false;
				}
				return result;
			}

			// Token: 0x0400000E RID: 14
			private string regeditPath = string.Empty;
		}

		// Token: 0x02000009 RID: 9
		public static class Utilities
		{
			// Token: 0x06000018 RID: 24 RVA: 0x000026F4 File Offset: 0x000008F4
			public static string GenerateString(int size)
			{
				char[] array = new char[size];
				for (int i = 0; i < size; i++)
				{
					array[i] = "ABCDEF0123456789"[Spoofer.Utilities.rand.Next("ABCDEF0123456789".Length)];
				}
				return new string(array);
			}

			// Token: 0x0400000F RID: 15
			private static Random rand = new Random();

			// Token: 0x04000010 RID: 16
			public const string Alphabet = "ABCDEF0123456789";

			// Token: 0x04000011 RID: 17
			private static Random random = new Random();

			// Token: 0x04000012 RID: 18
			public const string Alphabet1 = "abcdef0123456789";
		}
	}
}
