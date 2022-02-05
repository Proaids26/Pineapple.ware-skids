using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Siticone.UI.AnimatorNS;
using Siticone.UI.WinForms;
using Siticone.UI.WinForms.Enums;

namespace KeyAuth
{
	// Token: 0x02000005 RID: 5
	public partial class Main : Form
	{
		// Token: 0x06000023 RID: 35 RVA: 0x000038BE File Offset: 0x00001ABE
		public Main()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000024 RID: 36 RVA: 0x000038D7 File Offset: 0x00001AD7
		private void siticoneControlBox1_Click(object sender, EventArgs e)
		{
			Environment.Exit(0);
		}

		// Token: 0x06000025 RID: 37 RVA: 0x000038E0 File Offset: 0x00001AE0
		private void Main_Load(object sender, EventArgs e)
		{
			this.key.Text = "Username: " + Login.KeyAuthApp.user_data.username;
			this.expiry.Text = "Expiry: " + this.UnixTimeToDateTime(long.Parse(Login.KeyAuthApp.user_data.subscriptions[0].expiry)).ToString();
			this.subscription.Text = "Subscription: " + Login.KeyAuthApp.user_data.subscriptions[0].subscription;
			this.hwid.Text = "HWID: " + Login.KeyAuthApp.user_data.hwid;
			this.createDate.Text = "Creation date: " + this.UnixTimeToDateTime(long.Parse(Login.KeyAuthApp.user_data.createdate)).ToString();
			this.lastLogin.Text = "Last login: " + this.UnixTimeToDateTime(long.Parse(Login.KeyAuthApp.user_data.lastlogin)).ToString();
		}

		// Token: 0x06000026 RID: 38 RVA: 0x00003A14 File Offset: 0x00001C14
		public DateTime UnixTimeToDateTime(long unixtime)
		{
			DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Local);
			dtDateTime = dtDateTime.AddSeconds((double)unixtime).ToLocalTime();
			return dtDateTime;
		}

		// Token: 0x06000027 RID: 39 RVA: 0x00003A48 File Offset: 0x00001C48
		private void sendmsg_Click(object sender, EventArgs e)
		{
			if (Login.KeyAuthApp.chatsend(this.chatmsg.Text, this.chatchannel))
			{
				this.dataGridView1.Rows.Insert(0, new object[]
				{
					Login.KeyAuthApp.user_data.username,
					this.chatmsg.Text,
					this.UnixTimeToDateTime(DateTimeOffset.Now.ToUnixTimeSeconds())
				});
				return;
			}
			this.chatmsg.Text = "Status: " + Login.KeyAuthApp.response.message;
		}

		// Token: 0x06000028 RID: 40 RVA: 0x00003AEC File Offset: 0x00001CEC
		private void timer1_Tick(object sender, EventArgs e)
		{
			this.dataGridView1.Rows.Clear();
			this.timer1.Interval = 15000;
			if (!string.IsNullOrEmpty(this.chatchannel))
			{
				List<api.msg> messages = Login.KeyAuthApp.chatget(this.chatchannel);
				if (messages == null || !messages.Any<api.msg>())
				{
					this.dataGridView1.Rows.Insert(0, new object[]
					{
						"KeyAuth",
						"No Chat Messages",
						this.UnixTimeToDateTime(DateTimeOffset.Now.ToUnixTimeSeconds())
					});
					return;
				}
				using (List<api.msg>.Enumerator enumerator = messages.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						api.msg message = enumerator.Current;
						this.dataGridView1.Rows.Insert(0, new object[]
						{
							message.author,
							message.message,
							this.UnixTimeToDateTime(long.Parse(message.timestamp))
						});
					}
					return;
				}
			}
			this.dataGridView1.Rows.Insert(0, new object[]
			{
				"KeyAuth",
				"No Chat Messages",
				this.UnixTimeToDateTime(DateTimeOffset.Now.ToUnixTimeSeconds())
			});
		}

		// Token: 0x06000029 RID: 41 RVA: 0x00003C48 File Offset: 0x00001E48
		private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
		}

		// Token: 0x0400000E RID: 14
		private string chatchannel = "testing";
	}
}
