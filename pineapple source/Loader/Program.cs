using System;
using System.Windows.Forms;

namespace KeyAuth
{
	// Token: 0x02000007 RID: 7
	internal static class Program
	{
		// Token: 0x06000035 RID: 53 RVA: 0x00005F5B File Offset: 0x0000415B
		[STAThread]
		private static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new Login());
		}
	}
}
