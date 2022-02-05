namespace KeyAuth
{
	// Token: 0x02000005 RID: 5
	public partial class Main : global::System.Windows.Forms.Form
	{
		// Token: 0x0600002A RID: 42 RVA: 0x00003C4A File Offset: 0x00001E4A
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600002B RID: 43 RVA: 0x00003C70 File Offset: 0x00001E70
		private void InitializeComponent()
		{
			this.components = new global::System.ComponentModel.Container();
			global::Siticone.UI.AnimatorNS.Animation animation = new global::Siticone.UI.AnimatorNS.Animation();
			global::System.ComponentModel.ComponentResourceManager resources = new global::System.ComponentModel.ComponentResourceManager(typeof(global::KeyAuth.Main));
			this.siticoneDragControl1 = new global::Siticone.UI.WinForms.SiticoneDragControl(this.components);
			this.siticoneControlBox1 = new global::Siticone.UI.WinForms.SiticoneControlBox();
			this.siticoneControlBox2 = new global::Siticone.UI.WinForms.SiticoneControlBox();
			this.siticoneTransition1 = new global::Siticone.UI.WinForms.SiticoneTransition();
			this.label1 = new global::System.Windows.Forms.Label();
			this.label2 = new global::System.Windows.Forms.Label();
			this.key = new global::Siticone.UI.WinForms.SiticoneLabel();
			this.expiry = new global::Siticone.UI.WinForms.SiticoneLabel();
			this.subscription = new global::Siticone.UI.WinForms.SiticoneLabel();
			this.dataGridView1 = new global::System.Windows.Forms.DataGridView();
			this.Sender = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Message = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Time = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.sendmsg = new global::Siticone.UI.WinForms.SiticoneRoundedButton();
			this.chatmsg = new global::Siticone.UI.WinForms.SiticoneRoundedTextBox();
			this.hwid = new global::Siticone.UI.WinForms.SiticoneLabel();
			this.createDate = new global::Siticone.UI.WinForms.SiticoneLabel();
			this.lastLogin = new global::Siticone.UI.WinForms.SiticoneLabel();
			this.label3 = new global::System.Windows.Forms.Label();
			this.pictureBox1 = new global::System.Windows.Forms.PictureBox();
			this.label4 = new global::System.Windows.Forms.Label();
			this.siticoneShadowForm = new global::Siticone.UI.WinForms.SiticoneShadowForm(this.components);
			this.timer1 = new global::System.Windows.Forms.Timer(this.components);
			((global::System.ComponentModel.ISupportInitialize)this.dataGridView1).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox1).BeginInit();
			base.SuspendLayout();
			this.siticoneDragControl1.TargetControl = this;
			this.siticoneControlBox1.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right);
			this.siticoneControlBox1.BorderRadius = 10;
			this.siticoneTransition1.SetDecoration(this.siticoneControlBox1, global::Siticone.UI.AnimatorNS.DecorationType.None);
			this.siticoneControlBox1.FillColor = global::System.Drawing.Color.FromArgb(35, 39, 42);
			this.siticoneControlBox1.HoveredState.FillColor = global::System.Drawing.Color.FromArgb(232, 17, 35);
			this.siticoneControlBox1.HoveredState.IconColor = global::System.Drawing.Color.White;
			this.siticoneControlBox1.HoveredState.Parent = this.siticoneControlBox1;
			this.siticoneControlBox1.IconColor = global::System.Drawing.Color.White;
			this.siticoneControlBox1.Location = new global::System.Drawing.Point(299, 1);
			this.siticoneControlBox1.Name = "siticoneControlBox1";
			this.siticoneControlBox1.ShadowDecoration.Parent = this.siticoneControlBox1;
			this.siticoneControlBox1.Size = new global::System.Drawing.Size(45, 29);
			this.siticoneControlBox1.TabIndex = 1;
			this.siticoneControlBox1.Click += new global::System.EventHandler(this.siticoneControlBox1_Click);
			this.siticoneControlBox2.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right);
			this.siticoneControlBox2.BorderRadius = 10;
			this.siticoneControlBox2.ControlBoxType = global::Siticone.UI.WinForms.Enums.ControlBoxType.MinimizeBox;
			this.siticoneTransition1.SetDecoration(this.siticoneControlBox2, global::Siticone.UI.AnimatorNS.DecorationType.None);
			this.siticoneControlBox2.FillColor = global::System.Drawing.Color.FromArgb(35, 39, 42);
			this.siticoneControlBox2.HoveredState.Parent = this.siticoneControlBox2;
			this.siticoneControlBox2.IconColor = global::System.Drawing.Color.White;
			this.siticoneControlBox2.Location = new global::System.Drawing.Point(248, 1);
			this.siticoneControlBox2.Name = "siticoneControlBox2";
			this.siticoneControlBox2.ShadowDecoration.Parent = this.siticoneControlBox2;
			this.siticoneControlBox2.Size = new global::System.Drawing.Size(45, 29);
			this.siticoneControlBox2.TabIndex = 2;
			this.siticoneTransition1.AnimationType = global::Siticone.UI.AnimatorNS.AnimationType.Rotate;
			this.siticoneTransition1.Cursor = null;
			animation.AnimateOnlyDifferences = true;
			animation.BlindCoeff = (global::System.Drawing.PointF)resources.GetObject("animation1.BlindCoeff");
			animation.LeafCoeff = 0f;
			animation.MaxTime = 1f;
			animation.MinTime = 0f;
			animation.MosaicCoeff = (global::System.Drawing.PointF)resources.GetObject("animation1.MosaicCoeff");
			animation.MosaicShift = (global::System.Drawing.PointF)resources.GetObject("animation1.MosaicShift");
			animation.MosaicSize = 0;
			animation.Padding = new global::System.Windows.Forms.Padding(50);
			animation.RotateCoeff = 1f;
			animation.RotateLimit = 0f;
			animation.ScaleCoeff = (global::System.Drawing.PointF)resources.GetObject("animation1.ScaleCoeff");
			animation.SlideCoeff = (global::System.Drawing.PointF)resources.GetObject("animation1.SlideCoeff");
			animation.TimeCoeff = 0f;
			animation.TransparencyCoeff = 1f;
			this.siticoneTransition1.DefaultAnimation = animation;
			this.label1.AutoSize = true;
			this.siticoneTransition1.SetDecoration(this.label1, global::Siticone.UI.AnimatorNS.DecorationType.None);
			this.label1.Font = new global::System.Drawing.Font("Segoe UI Light", 10f);
			this.label1.ForeColor = global::System.Drawing.Color.White;
			this.label1.Location = new global::System.Drawing.Point(-1, 136);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(0, 19);
			this.label1.TabIndex = 22;
			this.label2.AutoSize = true;
			this.siticoneTransition1.SetDecoration(this.label2, global::Siticone.UI.AnimatorNS.DecorationType.None);
			this.label2.Font = new global::System.Drawing.Font("Segoe UI Semibold", 10.2f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label2.ForeColor = global::System.Drawing.SystemColors.ButtonFace;
			this.label2.Location = new global::System.Drawing.Point(50, 11);
			this.label2.Margin = new global::System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(87, 19);
			this.label2.TabIndex = 27;
			this.label2.Text = "Loader Main";
			this.key.BackColor = global::System.Drawing.Color.Transparent;
			this.siticoneTransition1.SetDecoration(this.key, global::Siticone.UI.AnimatorNS.DecorationType.None);
			this.key.Font = new global::System.Drawing.Font("Segoe UI", 7.8f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.key.ForeColor = global::System.Drawing.SystemColors.ButtonHighlight;
			this.key.Location = new global::System.Drawing.Point(20, 80);
			this.key.Margin = new global::System.Windows.Forms.Padding(2);
			this.key.Name = "key";
			this.key.Size = new global::System.Drawing.Size(71, 14);
			this.key.TabIndex = 37;
			this.key.Text = "usernameLabel";
			this.expiry.BackColor = global::System.Drawing.Color.Transparent;
			this.siticoneTransition1.SetDecoration(this.expiry, global::Siticone.UI.AnimatorNS.DecorationType.None);
			this.expiry.Font = new global::System.Drawing.Font("Segoe UI", 7.8f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.expiry.ForeColor = global::System.Drawing.SystemColors.ButtonHighlight;
			this.expiry.Location = new global::System.Drawing.Point(20, 101);
			this.expiry.Margin = new global::System.Windows.Forms.Padding(2);
			this.expiry.Name = "expiry";
			this.expiry.Size = new global::System.Drawing.Size(56, 14);
			this.expiry.TabIndex = 38;
			this.expiry.Text = "expiryLabel";
			this.subscription.BackColor = global::System.Drawing.Color.Transparent;
			this.siticoneTransition1.SetDecoration(this.subscription, global::Siticone.UI.AnimatorNS.DecorationType.None);
			this.subscription.Font = new global::System.Drawing.Font("Segoe UI", 7.8f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.subscription.ForeColor = global::System.Drawing.SystemColors.ButtonHighlight;
			this.subscription.Location = new global::System.Drawing.Point(20, 125);
			this.subscription.Margin = new global::System.Windows.Forms.Padding(2);
			this.subscription.Name = "subscription";
			this.subscription.Size = new global::System.Drawing.Size(84, 14);
			this.subscription.TabIndex = 39;
			this.subscription.Text = "subscriptionLabel";
			this.dataGridView1.ColumnHeadersHeightSizeMode = global::System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Columns.AddRange(new global::System.Windows.Forms.DataGridViewColumn[]
			{
				this.Sender,
				this.Message,
				this.Time
			});
			this.siticoneTransition1.SetDecoration(this.dataGridView1, global::Siticone.UI.AnimatorNS.DecorationType.None);
			this.dataGridView1.Location = new global::System.Drawing.Point(54, 1);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.Size = new global::System.Drawing.Size(10, 10);
			this.dataGridView1.TabIndex = 41;
			this.dataGridView1.CellContentClick += new global::System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
			this.Sender.HeaderText = "Sender";
			this.Sender.Name = "Sender";
			this.Sender.Width = 75;
			this.Message.HeaderText = "Message";
			this.Message.Name = "Message";
			this.Message.Width = 200;
			this.Time.HeaderText = "Time";
			this.Time.MaxInputLength = 50000;
			this.Time.Name = "Time";
			this.Time.Width = 175;
			this.sendmsg.BorderColor = global::System.Drawing.Color.DodgerBlue;
			this.sendmsg.BorderThickness = 1;
			this.sendmsg.CheckedState.Parent = this.sendmsg;
			this.sendmsg.CustomImages.Parent = this.sendmsg;
			this.siticoneTransition1.SetDecoration(this.sendmsg, global::Siticone.UI.AnimatorNS.DecorationType.None);
			this.sendmsg.FillColor = global::System.Drawing.Color.Red;
			this.sendmsg.Font = new global::System.Drawing.Font("Segoe UI", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.sendmsg.ForeColor = global::System.Drawing.Color.White;
			this.sendmsg.HoveredState.BorderColor = global::System.Drawing.Color.FromArgb(213, 218, 223);
			this.sendmsg.HoveredState.Parent = this.sendmsg;
			this.sendmsg.Location = new global::System.Drawing.Point(54, 1);
			this.sendmsg.Name = "sendmsg";
			this.sendmsg.ShadowDecoration.Parent = this.sendmsg;
			this.sendmsg.Size = new global::System.Drawing.Size(10, 10);
			this.sendmsg.TabIndex = 42;
			this.sendmsg.Text = "Send";
			this.sendmsg.Click += new global::System.EventHandler(this.sendmsg_Click);
			this.chatmsg.AllowDrop = true;
			this.chatmsg.BorderColor = global::System.Drawing.Color.FromArgb(64, 64, 0);
			this.chatmsg.Cursor = global::System.Windows.Forms.Cursors.IBeam;
			this.siticoneTransition1.SetDecoration(this.chatmsg, global::Siticone.UI.AnimatorNS.DecorationType.None);
			this.chatmsg.DefaultText = "Updating...";
			this.chatmsg.DisabledState.BorderColor = global::System.Drawing.Color.FromArgb(208, 208, 208);
			this.chatmsg.DisabledState.FillColor = global::System.Drawing.Color.FromArgb(226, 226, 226);
			this.chatmsg.DisabledState.ForeColor = global::System.Drawing.Color.FromArgb(138, 138, 138);
			this.chatmsg.DisabledState.Parent = this.chatmsg;
			this.chatmsg.DisabledState.PlaceholderForeColor = global::System.Drawing.Color.FromArgb(138, 138, 138);
			this.chatmsg.FillColor = global::System.Drawing.Color.FromArgb(35, 39, 42);
			this.chatmsg.FocusedState.BorderColor = global::System.Drawing.Color.FromArgb(94, 148, 255);
			this.chatmsg.FocusedState.Parent = this.chatmsg;
			this.chatmsg.HoveredState.BorderColor = global::System.Drawing.Color.FromArgb(94, 148, 255);
			this.chatmsg.HoveredState.Parent = this.chatmsg;
			this.chatmsg.Location = new global::System.Drawing.Point(13, 216);
			this.chatmsg.Margin = new global::System.Windows.Forms.Padding(4);
			this.chatmsg.Name = "chatmsg";
			this.chatmsg.PasswordChar = '\0';
			this.chatmsg.PlaceholderText = "";
			this.chatmsg.SelectedText = "";
			this.chatmsg.ShadowDecoration.Parent = this.chatmsg;
			this.chatmsg.Size = new global::System.Drawing.Size(335, 30);
			this.chatmsg.TabIndex = 43;
			this.chatmsg.TextAlign = global::System.Windows.Forms.HorizontalAlignment.Center;
			this.hwid.BackColor = global::System.Drawing.Color.Transparent;
			this.siticoneTransition1.SetDecoration(this.hwid, global::Siticone.UI.AnimatorNS.DecorationType.None);
			this.hwid.Font = new global::System.Drawing.Font("Segoe UI", 7.8f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.hwid.ForeColor = global::System.Drawing.SystemColors.ButtonHighlight;
			this.hwid.Location = new global::System.Drawing.Point(202, 83);
			this.hwid.Margin = new global::System.Windows.Forms.Padding(2);
			this.hwid.Name = "hwid";
			this.hwid.Size = new global::System.Drawing.Size(50, 14);
			this.hwid.TabIndex = 45;
			this.hwid.Text = "hwidLabel";
			this.createDate.BackColor = global::System.Drawing.Color.Transparent;
			this.siticoneTransition1.SetDecoration(this.createDate, global::Siticone.UI.AnimatorNS.DecorationType.None);
			this.createDate.Font = new global::System.Drawing.Font("Segoe UI", 7.8f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.createDate.ForeColor = global::System.Drawing.SystemColors.ButtonHighlight;
			this.createDate.Location = new global::System.Drawing.Point(202, 101);
			this.createDate.Margin = new global::System.Windows.Forms.Padding(2);
			this.createDate.Name = "createDate";
			this.createDate.Size = new global::System.Drawing.Size(76, 14);
			this.createDate.TabIndex = 46;
			this.createDate.Text = "createDateLabel";
			this.lastLogin.BackColor = global::System.Drawing.Color.Transparent;
			this.siticoneTransition1.SetDecoration(this.lastLogin, global::Siticone.UI.AnimatorNS.DecorationType.None);
			this.lastLogin.Font = new global::System.Drawing.Font("Segoe UI", 7.8f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.lastLogin.ForeColor = global::System.Drawing.SystemColors.ButtonHighlight;
			this.lastLogin.Location = new global::System.Drawing.Point(202, 125);
			this.lastLogin.Margin = new global::System.Windows.Forms.Padding(2);
			this.lastLogin.Name = "lastLogin";
			this.lastLogin.Size = new global::System.Drawing.Size(69, 14);
			this.lastLogin.TabIndex = 47;
			this.lastLogin.Text = "lastLoginLabel";
			this.label3.AutoSize = true;
			this.siticoneTransition1.SetDecoration(this.label3, global::Siticone.UI.AnimatorNS.DecorationType.None);
			this.label3.Font = new global::System.Drawing.Font("Segoe UI", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label3.ForeColor = global::System.Drawing.SystemColors.ButtonFace;
			this.label3.Location = new global::System.Drawing.Point(66, 180);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(90, 13);
			this.label3.TabIndex = 48;
			this.label3.Text = "Status:updating";
			this.siticoneTransition1.SetDecoration(this.pictureBox1, global::Siticone.UI.AnimatorNS.DecorationType.None);
			this.pictureBox1.Image = (global::System.Drawing.Image)resources.GetObject("pictureBox1.Image");
			this.pictureBox1.Location = new global::System.Drawing.Point(4, 1);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new global::System.Drawing.Size(41, 45);
			this.pictureBox1.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox1.TabIndex = 49;
			this.pictureBox1.TabStop = false;
			this.label4.AutoSize = true;
			this.siticoneTransition1.SetDecoration(this.label4, global::Siticone.UI.AnimatorNS.DecorationType.None);
			this.label4.ForeColor = global::System.Drawing.SystemColors.ButtonFace;
			this.label4.Location = new global::System.Drawing.Point(199, 180);
			this.label4.Name = "label4";
			this.label4.Size = new global::System.Drawing.Size(0, 13);
			this.label4.TabIndex = 50;
			this.timer1.Enabled = true;
			this.timer1.Interval = 1;
			this.timer1.Tick += new global::System.EventHandler(this.timer1_Tick);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.AutoValidate = global::System.Windows.Forms.AutoValidate.Disable;
			this.BackColor = global::System.Drawing.Color.FromArgb(35, 39, 42);
			base.ClientSize = new global::System.Drawing.Size(362, 259);
			base.Controls.Add(this.label4);
			base.Controls.Add(this.pictureBox1);
			base.Controls.Add(this.label3);
			base.Controls.Add(this.lastLogin);
			base.Controls.Add(this.createDate);
			base.Controls.Add(this.hwid);
			base.Controls.Add(this.chatmsg);
			base.Controls.Add(this.sendmsg);
			base.Controls.Add(this.dataGridView1);
			base.Controls.Add(this.subscription);
			base.Controls.Add(this.expiry);
			base.Controls.Add(this.key);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.siticoneControlBox2);
			base.Controls.Add(this.siticoneControlBox1);
			this.siticoneTransition1.SetDecoration(this, global::Siticone.UI.AnimatorNS.DecorationType.BottomMirror);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Name = "Main";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Loader";
			base.TransparencyKey = global::System.Drawing.Color.Maroon;
			base.Load += new global::System.EventHandler(this.Main_Load);
			((global::System.ComponentModel.ISupportInitialize)this.dataGridView1).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox1).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x0400000F RID: 15
		private global::System.ComponentModel.IContainer components;

		// Token: 0x04000010 RID: 16
		private global::Siticone.UI.WinForms.SiticoneDragControl siticoneDragControl1;

		// Token: 0x04000011 RID: 17
		private global::Siticone.UI.WinForms.SiticoneControlBox siticoneControlBox1;

		// Token: 0x04000012 RID: 18
		private global::Siticone.UI.WinForms.SiticoneControlBox siticoneControlBox2;

		// Token: 0x04000013 RID: 19
		private global::Siticone.UI.WinForms.SiticoneTransition siticoneTransition1;

		// Token: 0x04000014 RID: 20
		private global::System.Windows.Forms.Label label1;

		// Token: 0x04000015 RID: 21
		private global::System.Windows.Forms.Label label2;

		// Token: 0x04000016 RID: 22
		private global::Siticone.UI.WinForms.SiticoneShadowForm siticoneShadowForm;

		// Token: 0x04000017 RID: 23
		private global::Siticone.UI.WinForms.SiticoneLabel subscription;

		// Token: 0x04000018 RID: 24
		private global::Siticone.UI.WinForms.SiticoneLabel expiry;

		// Token: 0x04000019 RID: 25
		private global::Siticone.UI.WinForms.SiticoneLabel key;

		// Token: 0x0400001A RID: 26
		private global::System.Windows.Forms.DataGridView dataGridView1;

		// Token: 0x0400001B RID: 27
		private global::System.Windows.Forms.DataGridViewTextBoxColumn Sender;

		// Token: 0x0400001C RID: 28
		private global::System.Windows.Forms.DataGridViewTextBoxColumn Message;

		// Token: 0x0400001D RID: 29
		private global::System.Windows.Forms.DataGridViewTextBoxColumn Time;

		// Token: 0x0400001E RID: 30
		private global::Siticone.UI.WinForms.SiticoneRoundedButton sendmsg;

		// Token: 0x0400001F RID: 31
		private global::Siticone.UI.WinForms.SiticoneRoundedTextBox chatmsg;

		// Token: 0x04000020 RID: 32
		private global::System.Windows.Forms.Timer timer1;

		// Token: 0x04000021 RID: 33
		private global::Siticone.UI.WinForms.SiticoneLabel hwid;

		// Token: 0x04000022 RID: 34
		private global::Siticone.UI.WinForms.SiticoneLabel createDate;

		// Token: 0x04000023 RID: 35
		private global::Siticone.UI.WinForms.SiticoneLabel lastLogin;

		// Token: 0x04000024 RID: 36
		private global::System.Windows.Forms.PictureBox pictureBox1;

		// Token: 0x04000025 RID: 37
		private global::System.Windows.Forms.Label label3;

		// Token: 0x04000026 RID: 38
		private global::System.Windows.Forms.Label label4;
	}
}
