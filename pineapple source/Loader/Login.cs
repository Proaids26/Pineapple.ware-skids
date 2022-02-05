using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Siticone.UI.AnimatorNS;
using Siticone.UI.WinForms;
using Siticone.UI.WinForms.Enums;

namespace KeyAuth
{
	// Token: 0x02000006 RID: 6
	public partial class Login : Form
	{
		// Token: 0x0600002C RID: 44 RVA: 0x00004E92 File Offset: 0x00003092
		public Login()
		{
			this.InitializeComponent();
		}

		// Token: 0x0600002D RID: 45 RVA: 0x00004EA0 File Offset: 0x000030A0
		private void siticoneControlBox1_Click(object sender, EventArgs e)
		{
			Environment.Exit(0);
		}

		// Token: 0x0600002E RID: 46 RVA: 0x00004EA8 File Offset: 0x000030A8
		private void Login_Load(object sender, EventArgs e)
		{
			Login.KeyAuthApp.init();
		}

		// Token: 0x0600002F RID: 47 RVA: 0x00004EB4 File Offset: 0x000030B4
		private void LoginBtn_Click(object sender, EventArgs e)
		{
			Login.KeyAuthApp.login(this.username.Text, this.password.Text);
			if (Login.KeyAuthApp.response.success)
			{
				new Main().Show();
				base.Hide();
				return;
			}
			this.status.Text = "Status: " + Login.KeyAuthApp.response.message;
		}

		// Token: 0x06000030 RID: 48 RVA: 0x00004F28 File Offset: 0x00003128
		private void RgstrBtn_Click(object sender, EventArgs e)
		{
			Login.KeyAuthApp.register(this.username.Text, this.password.Text, this.key.Text);
			if (Login.KeyAuthApp.response.success)
			{
				new Main().Show();
				base.Hide();
				return;
			}
			this.status.Text = "Status: " + Login.KeyAuthApp.response.message;
		}

		// Token: 0x06000031 RID: 49 RVA: 0x00004FA8 File Offset: 0x000031A8
		private void LicBtn_Click(object sender, EventArgs e)
		{
			Login.KeyAuthApp.license(this.key.Text);
			if (Login.KeyAuthApp.response.success)
			{
				new Main().Show();
				base.Hide();
				return;
			}
			this.status.Text = "Status: " + Login.KeyAuthApp.response.message;
		}

		// Token: 0x04000027 RID: 39
		private static string name = "pineapple spoofer";

		// Token: 0x04000028 RID: 40
		private static string ownerid = "GTIizF45qh";

		// Token: 0x04000029 RID: 41
		private static string secret = "7b6f9b8af69a4f0dfb073251ebb9df1db87a4f52419e7f906a8c6223bdd967a4";

		// Token: 0x0400002A RID: 42
		private static string version = "1.0";

		// Token: 0x0400002B RID: 43
		public static api KeyAuthApp = new api(Login.name, Login.ownerid, Login.secret, Login.version);
	}
}
