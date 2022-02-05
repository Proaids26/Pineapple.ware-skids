namespace KeyAuth
{
	// Token: 0x02000006 RID: 6
	public partial class Login : global::System.Windows.Forms.Form
	{
		// Token: 0x06000032 RID: 50 RVA: 0x00005010 File Offset: 0x00003210
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000033 RID: 51 RVA: 0x00005038 File Offset: 0x00003238
		private void InitializeComponent()
		{
			this.components = new global::System.ComponentModel.Container();
			global::Siticone.UI.AnimatorNS.Animation animation = new global::Siticone.UI.AnimatorNS.Animation();
			global::System.ComponentModel.ComponentResourceManager resources = new global::System.ComponentModel.ComponentResourceManager(typeof(global::KeyAuth.Login));
			this.siticoneDragControl1 = new global::Siticone.UI.WinForms.SiticoneDragControl(this.components);
			this.siticoneControlBox1 = new global::Siticone.UI.WinForms.SiticoneControlBox();
			this.siticoneControlBox2 = new global::Siticone.UI.WinForms.SiticoneControlBox();
			this.siticoneTransition1 = new global::Siticone.UI.WinForms.SiticoneTransition();
			this.label1 = new global::System.Windows.Forms.Label();
			this.label2 = new global::System.Windows.Forms.Label();
			this.LoginBtn = new global::Siticone.UI.WinForms.SiticoneRoundedButton();
			this.key = new global::Siticone.UI.WinForms.SiticoneRoundedTextBox();
			this.username = new global::Siticone.UI.WinForms.SiticoneRoundedTextBox();
			this.password = new global::Siticone.UI.WinForms.SiticoneRoundedTextBox();
			this.RgstrBtn = new global::Siticone.UI.WinForms.SiticoneRoundedButton();
			this.LicBtn = new global::Siticone.UI.WinForms.SiticoneRoundedButton();
			this.status = new global::Siticone.UI.WinForms.SiticoneLabel();
			this.siticoneShadowForm = new global::Siticone.UI.WinForms.SiticoneShadowForm(this.components);
			this.pictureBox1 = new global::System.Windows.Forms.PictureBox();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox1).BeginInit();
			base.SuspendLayout();
			this.siticoneDragControl1.TargetControl = this;
			resources.ApplyResources(this.siticoneControlBox1, "siticoneControlBox1");
			this.siticoneControlBox1.BorderRadius = 10;
			this.siticoneTransition1.SetDecoration(this.siticoneControlBox1, global::Siticone.UI.AnimatorNS.DecorationType.None);
			this.siticoneControlBox1.FillColor = global::System.Drawing.Color.FromArgb(35, 39, 42);
			this.siticoneControlBox1.HoveredState.FillColor = global::System.Drawing.Color.FromArgb(232, 17, 35);
			this.siticoneControlBox1.HoveredState.IconColor = global::System.Drawing.Color.White;
			this.siticoneControlBox1.HoveredState.Parent = this.siticoneControlBox1;
			this.siticoneControlBox1.IconColor = global::System.Drawing.Color.White;
			this.siticoneControlBox1.Name = "siticoneControlBox1";
			this.siticoneControlBox1.ShadowDecoration.Parent = this.siticoneControlBox1;
			this.siticoneControlBox1.Click += new global::System.EventHandler(this.siticoneControlBox1_Click);
			resources.ApplyResources(this.siticoneControlBox2, "siticoneControlBox2");
			this.siticoneControlBox2.BorderRadius = 10;
			this.siticoneControlBox2.ControlBoxType = global::Siticone.UI.WinForms.Enums.ControlBoxType.MinimizeBox;
			this.siticoneTransition1.SetDecoration(this.siticoneControlBox2, global::Siticone.UI.AnimatorNS.DecorationType.None);
			this.siticoneControlBox2.FillColor = global::System.Drawing.Color.FromArgb(35, 39, 42);
			this.siticoneControlBox2.HoveredState.Parent = this.siticoneControlBox2;
			this.siticoneControlBox2.IconColor = global::System.Drawing.Color.White;
			this.siticoneControlBox2.Name = "siticoneControlBox2";
			this.siticoneControlBox2.ShadowDecoration.Parent = this.siticoneControlBox2;
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
			resources.ApplyResources(this.label1, "label1");
			this.siticoneTransition1.SetDecoration(this.label1, global::Siticone.UI.AnimatorNS.DecorationType.None);
			this.label1.ForeColor = global::System.Drawing.Color.White;
			this.label1.Name = "label1";
			resources.ApplyResources(this.label2, "label2");
			this.siticoneTransition1.SetDecoration(this.label2, global::Siticone.UI.AnimatorNS.DecorationType.None);
			this.label2.ForeColor = global::System.Drawing.SystemColors.ButtonFace;
			this.label2.Name = "label2";
			this.LoginBtn.BorderColor = global::System.Drawing.Color.FromArgb(64, 64, 0);
			this.LoginBtn.BorderThickness = 1;
			this.LoginBtn.CheckedState.Parent = this.LoginBtn;
			this.LoginBtn.CustomImages.Parent = this.LoginBtn;
			this.siticoneTransition1.SetDecoration(this.LoginBtn, global::Siticone.UI.AnimatorNS.DecorationType.None);
			this.LoginBtn.FillColor = global::System.Drawing.Color.FromArgb(64, 64, 0);
			resources.ApplyResources(this.LoginBtn, "LoginBtn");
			this.LoginBtn.ForeColor = global::System.Drawing.Color.White;
			this.LoginBtn.HoveredState.BorderColor = global::System.Drawing.Color.FromArgb(213, 218, 223);
			this.LoginBtn.HoveredState.Parent = this.LoginBtn;
			this.LoginBtn.Name = "LoginBtn";
			this.LoginBtn.ShadowDecoration.Parent = this.LoginBtn;
			this.LoginBtn.Click += new global::System.EventHandler(this.LoginBtn_Click);
			this.key.AllowDrop = true;
			this.key.BorderColor = global::System.Drawing.Color.FromArgb(64, 64, 0);
			this.key.Cursor = global::System.Windows.Forms.Cursors.IBeam;
			this.siticoneTransition1.SetDecoration(this.key, global::Siticone.UI.AnimatorNS.DecorationType.None);
			this.key.DefaultText = "Key";
			this.key.DisabledState.BorderColor = global::System.Drawing.Color.FromArgb(208, 208, 208);
			this.key.DisabledState.FillColor = global::System.Drawing.Color.FromArgb(226, 226, 226);
			this.key.DisabledState.ForeColor = global::System.Drawing.Color.FromArgb(138, 138, 138);
			this.key.DisabledState.Parent = this.key;
			this.key.DisabledState.PlaceholderForeColor = global::System.Drawing.Color.FromArgb(138, 138, 138);
			this.key.FillColor = global::System.Drawing.Color.FromArgb(35, 39, 42);
			this.key.FocusedState.BorderColor = global::System.Drawing.Color.FromArgb(94, 148, 255);
			this.key.FocusedState.Parent = this.key;
			this.key.HoveredState.BorderColor = global::System.Drawing.Color.FromArgb(94, 148, 255);
			this.key.HoveredState.Parent = this.key;
			resources.ApplyResources(this.key, "key");
			this.key.Name = "key";
			this.key.PasswordChar = '\0';
			this.key.PlaceholderText = "";
			this.key.SelectedText = "";
			this.key.ShadowDecoration.Parent = this.key;
			this.key.TextAlign = global::System.Windows.Forms.HorizontalAlignment.Center;
			this.username.AllowDrop = true;
			this.username.BorderColor = global::System.Drawing.Color.FromArgb(64, 64, 0);
			this.username.Cursor = global::System.Windows.Forms.Cursors.IBeam;
			this.siticoneTransition1.SetDecoration(this.username, global::Siticone.UI.AnimatorNS.DecorationType.None);
			this.username.DefaultText = "Username";
			this.username.DisabledState.BorderColor = global::System.Drawing.Color.FromArgb(208, 208, 208);
			this.username.DisabledState.FillColor = global::System.Drawing.Color.FromArgb(226, 226, 226);
			this.username.DisabledState.ForeColor = global::System.Drawing.Color.FromArgb(138, 138, 138);
			this.username.DisabledState.Parent = this.username;
			this.username.DisabledState.PlaceholderForeColor = global::System.Drawing.Color.FromArgb(138, 138, 138);
			this.username.FillColor = global::System.Drawing.Color.FromArgb(35, 39, 42);
			this.username.FocusedState.BorderColor = global::System.Drawing.Color.FromArgb(94, 148, 255);
			this.username.FocusedState.Parent = this.username;
			this.username.HoveredState.BorderColor = global::System.Drawing.Color.FromArgb(94, 148, 255);
			this.username.HoveredState.Parent = this.username;
			resources.ApplyResources(this.username, "username");
			this.username.Name = "username";
			this.username.PasswordChar = '\0';
			this.username.PlaceholderText = "";
			this.username.SelectedText = "";
			this.username.ShadowDecoration.Parent = this.username;
			this.username.TextAlign = global::System.Windows.Forms.HorizontalAlignment.Center;
			this.password.AllowDrop = true;
			this.password.BorderColor = global::System.Drawing.Color.FromArgb(64, 64, 0);
			this.password.Cursor = global::System.Windows.Forms.Cursors.IBeam;
			this.siticoneTransition1.SetDecoration(this.password, global::Siticone.UI.AnimatorNS.DecorationType.None);
			this.password.DefaultText = "Password";
			this.password.DisabledState.BorderColor = global::System.Drawing.Color.FromArgb(208, 208, 208);
			this.password.DisabledState.FillColor = global::System.Drawing.Color.FromArgb(226, 226, 226);
			this.password.DisabledState.ForeColor = global::System.Drawing.Color.FromArgb(138, 138, 138);
			this.password.DisabledState.Parent = this.password;
			this.password.DisabledState.PlaceholderForeColor = global::System.Drawing.Color.FromArgb(138, 138, 138);
			this.password.FillColor = global::System.Drawing.Color.FromArgb(35, 39, 42);
			this.password.FocusedState.BorderColor = global::System.Drawing.Color.FromArgb(94, 148, 255);
			this.password.FocusedState.Parent = this.password;
			this.password.HoveredState.BorderColor = global::System.Drawing.Color.FromArgb(94, 148, 255);
			this.password.HoveredState.Parent = this.password;
			resources.ApplyResources(this.password, "password");
			this.password.Name = "password";
			this.password.PasswordChar = '\0';
			this.password.PlaceholderText = "";
			this.password.SelectedText = "";
			this.password.ShadowDecoration.Parent = this.password;
			this.password.TextAlign = global::System.Windows.Forms.HorizontalAlignment.Center;
			this.RgstrBtn.BorderColor = global::System.Drawing.Color.FromArgb(64, 64, 0);
			this.RgstrBtn.BorderThickness = 1;
			this.RgstrBtn.CheckedState.Parent = this.RgstrBtn;
			this.RgstrBtn.CustomImages.Parent = this.RgstrBtn;
			this.siticoneTransition1.SetDecoration(this.RgstrBtn, global::Siticone.UI.AnimatorNS.DecorationType.None);
			this.RgstrBtn.FillColor = global::System.Drawing.Color.FromArgb(64, 64, 0);
			resources.ApplyResources(this.RgstrBtn, "RgstrBtn");
			this.RgstrBtn.ForeColor = global::System.Drawing.Color.White;
			this.RgstrBtn.HoveredState.BorderColor = global::System.Drawing.Color.FromArgb(213, 218, 223);
			this.RgstrBtn.HoveredState.Parent = this.RgstrBtn;
			this.RgstrBtn.Name = "RgstrBtn";
			this.RgstrBtn.ShadowDecoration.Parent = this.RgstrBtn;
			this.RgstrBtn.Click += new global::System.EventHandler(this.RgstrBtn_Click);
			this.LicBtn.BorderColor = global::System.Drawing.Color.FromArgb(64, 64, 0);
			this.LicBtn.BorderThickness = 1;
			this.LicBtn.CheckedState.Parent = this.LicBtn;
			this.LicBtn.CustomImages.Parent = this.LicBtn;
			this.siticoneTransition1.SetDecoration(this.LicBtn, global::Siticone.UI.AnimatorNS.DecorationType.None);
			this.LicBtn.FillColor = global::System.Drawing.Color.FromArgb(64, 64, 0);
			resources.ApplyResources(this.LicBtn, "LicBtn");
			this.LicBtn.ForeColor = global::System.Drawing.Color.White;
			this.LicBtn.HoveredState.BorderColor = global::System.Drawing.Color.FromArgb(213, 218, 223);
			this.LicBtn.HoveredState.Parent = this.LicBtn;
			this.LicBtn.Name = "LicBtn";
			this.LicBtn.ShadowDecoration.Parent = this.LicBtn;
			this.LicBtn.Click += new global::System.EventHandler(this.LicBtn_Click);
			resources.ApplyResources(this.status, "status");
			this.status.BackColor = global::System.Drawing.Color.Transparent;
			this.siticoneTransition1.SetDecoration(this.status, global::Siticone.UI.AnimatorNS.DecorationType.None);
			this.status.ForeColor = global::System.Drawing.Color.FromArgb(64, 64, 0);
			this.status.Name = "status";
			this.status.TextAlignment = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.siticoneTransition1.SetDecoration(this.pictureBox1, global::Siticone.UI.AnimatorNS.DecorationType.None);
			resources.ApplyResources(this.pictureBox1, "pictureBox1");
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.TabStop = false;
			resources.ApplyResources(this, "$this");
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.AutoValidate = global::System.Windows.Forms.AutoValidate.Disable;
			this.BackColor = global::System.Drawing.Color.FromArgb(35, 39, 42);
			base.Controls.Add(this.pictureBox1);
			base.Controls.Add(this.status);
			base.Controls.Add(this.LicBtn);
			base.Controls.Add(this.RgstrBtn);
			base.Controls.Add(this.password);
			base.Controls.Add(this.username);
			base.Controls.Add(this.key);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.LoginBtn);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.siticoneControlBox2);
			base.Controls.Add(this.siticoneControlBox1);
			this.siticoneTransition1.SetDecoration(this, global::Siticone.UI.AnimatorNS.DecorationType.BottomMirror);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Name = "Login";
			base.TransparencyKey = global::System.Drawing.Color.Maroon;
			base.Load += new global::System.EventHandler(this.Login_Load);
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox1).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x0400002C RID: 44
		private global::System.ComponentModel.IContainer components;

		// Token: 0x0400002D RID: 45
		private global::Siticone.UI.WinForms.SiticoneDragControl siticoneDragControl1;

		// Token: 0x0400002E RID: 46
		private global::Siticone.UI.WinForms.SiticoneControlBox siticoneControlBox1;

		// Token: 0x0400002F RID: 47
		private global::Siticone.UI.WinForms.SiticoneControlBox siticoneControlBox2;

		// Token: 0x04000030 RID: 48
		private global::Siticone.UI.WinForms.SiticoneTransition siticoneTransition1;

		// Token: 0x04000031 RID: 49
		private global::System.Windows.Forms.Label label1;

		// Token: 0x04000032 RID: 50
		private global::System.Windows.Forms.Label label2;

		// Token: 0x04000033 RID: 51
		private global::Siticone.UI.WinForms.SiticoneRoundedButton LoginBtn;

		// Token: 0x04000034 RID: 52
		private global::Siticone.UI.WinForms.SiticoneShadowForm siticoneShadowForm;

		// Token: 0x04000035 RID: 53
		private global::Siticone.UI.WinForms.SiticoneRoundedTextBox key;

		// Token: 0x04000036 RID: 54
		private global::Siticone.UI.WinForms.SiticoneRoundedTextBox password;

		// Token: 0x04000037 RID: 55
		private global::Siticone.UI.WinForms.SiticoneRoundedTextBox username;

		// Token: 0x04000038 RID: 56
		private global::Siticone.UI.WinForms.SiticoneRoundedButton LicBtn;

		// Token: 0x04000039 RID: 57
		private global::Siticone.UI.WinForms.SiticoneRoundedButton RgstrBtn;

		// Token: 0x0400003A RID: 58
		private global::Siticone.UI.WinForms.SiticoneLabel status;

		// Token: 0x0400003B RID: 59
		private global::System.Windows.Forms.PictureBox pictureBox1;
	}
}
