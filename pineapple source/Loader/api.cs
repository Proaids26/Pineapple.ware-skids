using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;

namespace KeyAuth
{
	// Token: 0x02000002 RID: 2
	public class api
	{
		// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
		public api(string name, string ownerid, string secret, string version)
		{
			if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(ownerid) || string.IsNullOrWhiteSpace(secret) || string.IsNullOrWhiteSpace(version))
			{
				api.error("Application not setup correctly. Please watch video link found in Program.cs");
				Environment.Exit(0);
			}
			this.name = name;
			this.ownerid = ownerid;
			this.secret = secret;
			this.version = version;
		}

		// Token: 0x06000002 RID: 2 RVA: 0x000020E4 File Offset: 0x000002E4
		public void init()
		{
			this.enckey = encryption.sha256(encryption.iv_key());
			string init_iv = encryption.sha256(encryption.iv_key());
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("init"));
			nameValueCollection["ver"] = encryption.encrypt(this.version, this.secret, init_iv);
			nameValueCollection["hash"] = api.checksum(Process.GetCurrentProcess().MainModule.FileName);
			nameValueCollection["enckey"] = encryption.encrypt(this.enckey, this.secret, init_iv);
			nameValueCollection["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.name));
			nameValueCollection["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.ownerid));
			nameValueCollection["init_iv"] = init_iv;
			string response = api.req(nameValueCollection);
			if (response == "KeyAuth_Invalid")
			{
				api.error("Application not found");
				Environment.Exit(0);
			}
			response = encryption.decrypt(response, this.secret, init_iv);
			api.response_structure json = this.response_decoder.string_to_generic<api.response_structure>(response);
			this.load_response_struct(json);
			if (json.success)
			{
				this.load_app_data(json.appinfo);
				this.sessionid = json.sessionid;
				this.initzalized = true;
				return;
			}
			if (json.message == "invalidver")
			{
				Process.Start(json.download);
				Environment.Exit(0);
			}
		}

		// Token: 0x06000003 RID: 3 RVA: 0x00002268 File Offset: 0x00000468
		public void register(string username, string pass, string key)
		{
			if (!this.initzalized)
			{
				api.error("Please initzalize first");
				Environment.Exit(0);
			}
			string hwid = WindowsIdentity.GetCurrent().User.Value;
			string init_iv = encryption.sha256(encryption.iv_key());
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("register"));
			nameValueCollection["username"] = encryption.encrypt(username, this.enckey, init_iv);
			nameValueCollection["pass"] = encryption.encrypt(pass, this.enckey, init_iv);
			nameValueCollection["key"] = encryption.encrypt(key, this.enckey, init_iv);
			nameValueCollection["hwid"] = encryption.encrypt(hwid, this.enckey, init_iv);
			nameValueCollection["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.sessionid));
			nameValueCollection["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.name));
			nameValueCollection["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.ownerid));
			nameValueCollection["init_iv"] = init_iv;
			string response = api.req(nameValueCollection);
			response = encryption.decrypt(response, this.enckey, init_iv);
			api.response_structure json = this.response_decoder.string_to_generic<api.response_structure>(response);
			this.load_response_struct(json);
			if (json.success)
			{
				this.load_user_data(json.info);
			}
		}

		// Token: 0x06000004 RID: 4 RVA: 0x000023D4 File Offset: 0x000005D4
		public void login(string username, string pass)
		{
			if (!this.initzalized)
			{
				api.error("Please initzalize first");
				Environment.Exit(0);
			}
			string hwid = WindowsIdentity.GetCurrent().User.Value;
			string init_iv = encryption.sha256(encryption.iv_key());
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("login"));
			nameValueCollection["username"] = encryption.encrypt(username, this.enckey, init_iv);
			nameValueCollection["pass"] = encryption.encrypt(pass, this.enckey, init_iv);
			nameValueCollection["hwid"] = encryption.encrypt(hwid, this.enckey, init_iv);
			nameValueCollection["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.sessionid));
			nameValueCollection["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.name));
			nameValueCollection["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.ownerid));
			nameValueCollection["init_iv"] = init_iv;
			string response = api.req(nameValueCollection);
			response = encryption.decrypt(response, this.enckey, init_iv);
			api.response_structure json = this.response_decoder.string_to_generic<api.response_structure>(response);
			this.load_response_struct(json);
			if (json.success)
			{
				this.load_user_data(json.info);
			}
		}

		// Token: 0x06000005 RID: 5 RVA: 0x00002528 File Offset: 0x00000728
		public void upgrade(string username, string key)
		{
			if (!this.initzalized)
			{
				api.error("Please initzalize first");
				Environment.Exit(0);
			}
			string value = WindowsIdentity.GetCurrent().User.Value;
			string init_iv = encryption.sha256(encryption.iv_key());
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("upgrade"));
			nameValueCollection["username"] = encryption.encrypt(username, this.enckey, init_iv);
			nameValueCollection["key"] = encryption.encrypt(key, this.enckey, init_iv);
			nameValueCollection["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.sessionid));
			nameValueCollection["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.name));
			nameValueCollection["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.ownerid));
			nameValueCollection["init_iv"] = init_iv;
			string response = api.req(nameValueCollection);
			response = encryption.decrypt(response, this.enckey, init_iv);
			api.response_structure json = this.response_decoder.string_to_generic<api.response_structure>(response);
			json.success = false;
			this.load_response_struct(json);
		}

		// Token: 0x06000006 RID: 6 RVA: 0x00002658 File Offset: 0x00000858
		public void license(string key)
		{
			if (!this.initzalized)
			{
				api.error("Please initzalize first");
				Environment.Exit(0);
			}
			string hwid = WindowsIdentity.GetCurrent().User.Value;
			string init_iv = encryption.sha256(encryption.iv_key());
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("license"));
			nameValueCollection["key"] = encryption.encrypt(key, this.enckey, init_iv);
			nameValueCollection["hwid"] = encryption.encrypt(hwid, this.enckey, init_iv);
			nameValueCollection["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.sessionid));
			nameValueCollection["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.name));
			nameValueCollection["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.ownerid));
			nameValueCollection["init_iv"] = init_iv;
			string response = api.req(nameValueCollection);
			response = encryption.decrypt(response, this.enckey, init_iv);
			api.response_structure json = this.response_decoder.string_to_generic<api.response_structure>(response);
			this.load_response_struct(json);
			if (json.success)
			{
				this.load_user_data(json.info);
			}
		}

		// Token: 0x06000007 RID: 7 RVA: 0x00002794 File Offset: 0x00000994
		public void setvar(string var, string data)
		{
			if (!this.initzalized)
			{
				api.error("Please initzalize first");
				Environment.Exit(0);
			}
			string init_iv = encryption.sha256(encryption.iv_key());
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("setvar"));
			nameValueCollection["var"] = encryption.encrypt(var, this.enckey, init_iv);
			nameValueCollection["data"] = encryption.encrypt(data, this.enckey, init_iv);
			nameValueCollection["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.sessionid));
			nameValueCollection["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.name));
			nameValueCollection["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.ownerid));
			nameValueCollection["init_iv"] = init_iv;
			string response = api.req(nameValueCollection);
			response = encryption.decrypt(response, this.enckey, init_iv);
			api.response_structure json = this.response_decoder.string_to_generic<api.response_structure>(response);
			this.load_response_struct(json);
		}

		// Token: 0x06000008 RID: 8 RVA: 0x000028AC File Offset: 0x00000AAC
		public string getvar(string var)
		{
			if (!this.initzalized)
			{
				api.error("Please initzalize first");
				Environment.Exit(0);
			}
			string init_iv = encryption.sha256(encryption.iv_key());
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("getvar"));
			nameValueCollection["var"] = encryption.encrypt(var, this.enckey, init_iv);
			nameValueCollection["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.sessionid));
			nameValueCollection["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.name));
			nameValueCollection["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.ownerid));
			nameValueCollection["init_iv"] = init_iv;
			string response = api.req(nameValueCollection);
			response = encryption.decrypt(response, this.enckey, init_iv);
			api.response_structure json = this.response_decoder.string_to_generic<api.response_structure>(response);
			this.load_response_struct(json);
			if (json.success)
			{
				return json.response;
			}
			return null;
		}

		// Token: 0x06000009 RID: 9 RVA: 0x000029BC File Offset: 0x00000BBC
		public void ban()
		{
			if (!this.initzalized)
			{
				api.error("Please initzalize first");
				Environment.Exit(0);
			}
			string init_iv = encryption.sha256(encryption.iv_key());
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("ban"));
			nameValueCollection["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.sessionid));
			nameValueCollection["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.name));
			nameValueCollection["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.ownerid));
			nameValueCollection["init_iv"] = init_iv;
			string response = api.req(nameValueCollection);
			response = encryption.decrypt(response, this.enckey, init_iv);
			api.response_structure json = this.response_decoder.string_to_generic<api.response_structure>(response);
			this.load_response_struct(json);
		}

		// Token: 0x0600000A RID: 10 RVA: 0x00002AA4 File Offset: 0x00000CA4
		public string var(string varid)
		{
			if (!this.initzalized)
			{
				api.error("Please initzalize first");
				Environment.Exit(0);
			}
			string value = WindowsIdentity.GetCurrent().User.Value;
			string init_iv = encryption.sha256(encryption.iv_key());
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("var"));
			nameValueCollection["varid"] = encryption.encrypt(varid, this.enckey, init_iv);
			nameValueCollection["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.sessionid));
			nameValueCollection["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.name));
			nameValueCollection["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.ownerid));
			nameValueCollection["init_iv"] = init_iv;
			string response = api.req(nameValueCollection);
			response = encryption.decrypt(response, this.enckey, init_iv);
			api.response_structure json = this.response_decoder.string_to_generic<api.response_structure>(response);
			this.load_response_struct(json);
			if (json.success)
			{
				return json.message;
			}
			return null;
		}

		// Token: 0x0600000B RID: 11 RVA: 0x00002BC4 File Offset: 0x00000DC4
		public List<api.msg> chatget(string channelname)
		{
			if (!this.initzalized)
			{
				api.error("Please initzalize first");
				Environment.Exit(0);
			}
			string init_iv = encryption.sha256(encryption.iv_key());
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("chatget"));
			nameValueCollection["channel"] = encryption.encrypt(channelname, this.enckey, init_iv);
			nameValueCollection["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.sessionid));
			nameValueCollection["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.name));
			nameValueCollection["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.ownerid));
			nameValueCollection["init_iv"] = init_iv;
			string response = api.req(nameValueCollection);
			response = encryption.decrypt(response, this.enckey, init_iv);
			api.response_structure json = this.response_decoder.string_to_generic<api.response_structure>(response);
			this.load_response_struct(json);
			if (json.success)
			{
				return json.messages;
			}
			return null;
		}

		// Token: 0x0600000C RID: 12 RVA: 0x00002CD4 File Offset: 0x00000ED4
		public bool chatsend(string msg, string channelname)
		{
			if (!this.initzalized)
			{
				api.error("Please initzalize first");
				Environment.Exit(0);
			}
			string init_iv = encryption.sha256(encryption.iv_key());
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("chatsend"));
			nameValueCollection["message"] = encryption.encrypt(msg, this.enckey, init_iv);
			nameValueCollection["channel"] = encryption.encrypt(channelname, this.enckey, init_iv);
			nameValueCollection["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.sessionid));
			nameValueCollection["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.name));
			nameValueCollection["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.ownerid));
			nameValueCollection["init_iv"] = init_iv;
			string response = api.req(nameValueCollection);
			response = encryption.decrypt(response, this.enckey, init_iv);
			api.response_structure json = this.response_decoder.string_to_generic<api.response_structure>(response);
			this.load_response_struct(json);
			return json.success;
		}

		// Token: 0x0600000D RID: 13 RVA: 0x00002DF8 File Offset: 0x00000FF8
		public bool checkblack()
		{
			if (!this.initzalized)
			{
				api.error("Please initzalize first");
				Environment.Exit(0);
			}
			string hwid = WindowsIdentity.GetCurrent().User.Value;
			string init_iv = encryption.sha256(encryption.iv_key());
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("checkblacklist"));
			nameValueCollection["hwid"] = encryption.encrypt(hwid, this.enckey, init_iv);
			nameValueCollection["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.sessionid));
			nameValueCollection["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.name));
			nameValueCollection["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.ownerid));
			nameValueCollection["init_iv"] = init_iv;
			string response = api.req(nameValueCollection);
			response = encryption.decrypt(response, this.enckey, init_iv);
			api.response_structure json = this.response_decoder.string_to_generic<api.response_structure>(response);
			this.load_response_struct(json);
			return json.success;
		}

		// Token: 0x0600000E RID: 14 RVA: 0x00002F14 File Offset: 0x00001114
		public string webhook(string webid, string param, string body = "", string conttype = "")
		{
			if (!this.initzalized)
			{
				api.error("Please initzalize first");
				Environment.Exit(0);
				return null;
			}
			string init_iv = encryption.sha256(encryption.iv_key());
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("webhook"));
			nameValueCollection["webid"] = encryption.encrypt(webid, this.enckey, init_iv);
			nameValueCollection["params"] = encryption.encrypt(param, this.enckey, init_iv);
			nameValueCollection["body"] = encryption.encrypt(body, this.enckey, init_iv);
			nameValueCollection["conttype"] = encryption.encrypt(conttype, this.enckey, init_iv);
			nameValueCollection["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.sessionid));
			nameValueCollection["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.name));
			nameValueCollection["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.ownerid));
			nameValueCollection["init_iv"] = init_iv;
			string response = api.req(nameValueCollection);
			response = encryption.decrypt(response, this.enckey, init_iv);
			api.response_structure json = this.response_decoder.string_to_generic<api.response_structure>(response);
			this.load_response_struct(json);
			if (json.success)
			{
				return json.response;
			}
			return null;
		}

		// Token: 0x0600000F RID: 15 RVA: 0x00003070 File Offset: 0x00001270
		public byte[] download(string fileid)
		{
			if (!this.initzalized)
			{
				api.error("Please initzalize first. File is empty since no request could be made.");
				Environment.Exit(0);
			}
			string init_iv = encryption.sha256(encryption.iv_key());
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("file"));
			nameValueCollection["fileid"] = encryption.encrypt(fileid, this.enckey, init_iv);
			nameValueCollection["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.sessionid));
			nameValueCollection["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.name));
			nameValueCollection["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.ownerid));
			nameValueCollection["init_iv"] = init_iv;
			string response = api.req(nameValueCollection);
			response = encryption.decrypt(response, this.enckey, init_iv);
			api.response_structure json = this.response_decoder.string_to_generic<api.response_structure>(response);
			this.load_response_struct(json);
			if (json.success)
			{
				return encryption.str_to_byte_arr(json.contents);
			}
			return null;
		}

		// Token: 0x06000010 RID: 16 RVA: 0x00003188 File Offset: 0x00001388
		public void log(string message)
		{
			if (!this.initzalized)
			{
				api.error("Please initzalize first");
				Environment.Exit(0);
			}
			string init_iv = encryption.sha256(encryption.iv_key());
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("log"));
			nameValueCollection["pcuser"] = encryption.encrypt(Environment.UserName, this.enckey, init_iv);
			nameValueCollection["message"] = encryption.encrypt(message, this.enckey, init_iv);
			nameValueCollection["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.sessionid));
			nameValueCollection["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.name));
			nameValueCollection["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.ownerid));
			nameValueCollection["init_iv"] = init_iv;
			api.req(nameValueCollection);
		}

		// Token: 0x06000011 RID: 17 RVA: 0x00003284 File Offset: 0x00001484
		public static string checksum(string filename)
		{
			string result;
			using (MD5 md = MD5.Create())
			{
				using (FileStream fileStream = File.OpenRead(filename))
				{
					result = BitConverter.ToString(md.ComputeHash(fileStream)).Replace("-", "").ToLowerInvariant();
				}
			}
			return result;
		}

		// Token: 0x06000012 RID: 18 RVA: 0x000032F4 File Offset: 0x000014F4
		public static void error(string message)
		{
			Process.Start(new ProcessStartInfo("cmd.exe", "/c start cmd /C \"color b && title Error && echo " + message + " && timeout /t 5\"")
			{
				CreateNoWindow = true,
				RedirectStandardOutput = true,
				RedirectStandardError = true,
				UseShellExecute = false
			});
			Environment.Exit(0);
		}

		// Token: 0x06000013 RID: 19 RVA: 0x00003344 File Offset: 0x00001544
		private static string req(NameValueCollection post_data)
		{
			string result;
			try
			{
				using (WebClient client = new WebClient())
				{
					byte[] raw_response = client.UploadValues("https://keyauth.win/api/1.0/", post_data);
					result = Encoding.Default.GetString(raw_response);
				}
			}
			catch (WebException ex)
			{
				if (((HttpWebResponse)ex.Response).StatusCode == (HttpStatusCode)429)
				{
					api.error("You're connecting too fast to loader, slow down.");
					Environment.Exit(0);
					result = "";
				}
				else
				{
					api.error("Connection failure. Please try again, or contact us for help.");
					Environment.Exit(0);
					result = "";
				}
			}
			return result;
		}

		// Token: 0x06000014 RID: 20 RVA: 0x000033E0 File Offset: 0x000015E0
		private void load_app_data(api.app_data_structure data)
		{
			this.app_data.numUsers = data.numUsers;
			this.app_data.numOnlineUsers = data.numOnlineUsers;
			this.app_data.numKeys = data.numKeys;
			this.app_data.version = data.version;
			this.app_data.customerPanelLink = data.customerPanelLink;
		}

		// Token: 0x06000015 RID: 21 RVA: 0x00003444 File Offset: 0x00001644
		private void load_user_data(api.user_data_structure data)
		{
			this.user_data.username = data.username;
			this.user_data.ip = data.ip;
			this.user_data.hwid = data.hwid;
			this.user_data.createdate = data.createdate;
			this.user_data.lastlogin = data.lastlogin;
			this.user_data.subscriptions = data.subscriptions;
		}

		// Token: 0x06000016 RID: 22 RVA: 0x000034B7 File Offset: 0x000016B7
		private void load_response_struct(api.response_structure data)
		{
			this.response.success = data.success;
			this.response.message = data.message;
		}

		// Token: 0x04000001 RID: 1
		public string name;

		// Token: 0x04000002 RID: 2
		public string ownerid;

		// Token: 0x04000003 RID: 3
		public string secret;

		// Token: 0x04000004 RID: 4
		public string version;

		// Token: 0x04000005 RID: 5
		private string sessionid;

		// Token: 0x04000006 RID: 6
		private string enckey;

		// Token: 0x04000007 RID: 7
		private bool initzalized;

		// Token: 0x04000008 RID: 8
		public api.app_data_class app_data = new api.app_data_class();

		// Token: 0x04000009 RID: 9
		public api.user_data_class user_data = new api.user_data_class();

		// Token: 0x0400000A RID: 10
		public api.response_class response = new api.response_class();

		// Token: 0x0400000B RID: 11
		private json_wrapper response_decoder = new json_wrapper(new api.response_structure());

		// Token: 0x0200000A RID: 10
		[DataContract]
		private class response_structure
		{
			// Token: 0x17000004 RID: 4
			// (get) Token: 0x0600003D RID: 61 RVA: 0x00005FDA File Offset: 0x000041DA
			// (set) Token: 0x0600003E RID: 62 RVA: 0x00005FE2 File Offset: 0x000041E2
			[DataMember]
			public bool success { get; set; }

			// Token: 0x17000005 RID: 5
			// (get) Token: 0x0600003F RID: 63 RVA: 0x00005FEB File Offset: 0x000041EB
			// (set) Token: 0x06000040 RID: 64 RVA: 0x00005FF3 File Offset: 0x000041F3
			[DataMember]
			public string sessionid { get; set; }

			// Token: 0x17000006 RID: 6
			// (get) Token: 0x06000041 RID: 65 RVA: 0x00005FFC File Offset: 0x000041FC
			// (set) Token: 0x06000042 RID: 66 RVA: 0x00006004 File Offset: 0x00004204
			[DataMember]
			public string contents { get; set; }

			// Token: 0x17000007 RID: 7
			// (get) Token: 0x06000043 RID: 67 RVA: 0x0000600D File Offset: 0x0000420D
			// (set) Token: 0x06000044 RID: 68 RVA: 0x00006015 File Offset: 0x00004215
			[DataMember]
			public string response { get; set; }

			// Token: 0x17000008 RID: 8
			// (get) Token: 0x06000045 RID: 69 RVA: 0x0000601E File Offset: 0x0000421E
			// (set) Token: 0x06000046 RID: 70 RVA: 0x00006026 File Offset: 0x00004226
			[DataMember]
			public string message { get; set; }

			// Token: 0x17000009 RID: 9
			// (get) Token: 0x06000047 RID: 71 RVA: 0x0000602F File Offset: 0x0000422F
			// (set) Token: 0x06000048 RID: 72 RVA: 0x00006037 File Offset: 0x00004237
			[DataMember]
			public string download { get; set; }

			// Token: 0x1700000A RID: 10
			// (get) Token: 0x06000049 RID: 73 RVA: 0x00006040 File Offset: 0x00004240
			// (set) Token: 0x0600004A RID: 74 RVA: 0x00006048 File Offset: 0x00004248
			[DataMember(IsRequired = false, EmitDefaultValue = false)]
			public api.user_data_structure info { get; set; }

			// Token: 0x1700000B RID: 11
			// (get) Token: 0x0600004B RID: 75 RVA: 0x00006051 File Offset: 0x00004251
			// (set) Token: 0x0600004C RID: 76 RVA: 0x00006059 File Offset: 0x00004259
			[DataMember(IsRequired = false, EmitDefaultValue = false)]
			public api.app_data_structure appinfo { get; set; }

			// Token: 0x1700000C RID: 12
			// (get) Token: 0x0600004D RID: 77 RVA: 0x00006062 File Offset: 0x00004262
			// (set) Token: 0x0600004E RID: 78 RVA: 0x0000606A File Offset: 0x0000426A
			[DataMember]
			public List<api.msg> messages { get; set; }
		}

		// Token: 0x0200000B RID: 11
		public class msg
		{
			// Token: 0x1700000D RID: 13
			// (get) Token: 0x06000050 RID: 80 RVA: 0x0000607B File Offset: 0x0000427B
			// (set) Token: 0x06000051 RID: 81 RVA: 0x00006083 File Offset: 0x00004283
			public string message { get; set; }

			// Token: 0x1700000E RID: 14
			// (get) Token: 0x06000052 RID: 82 RVA: 0x0000608C File Offset: 0x0000428C
			// (set) Token: 0x06000053 RID: 83 RVA: 0x00006094 File Offset: 0x00004294
			public string author { get; set; }

			// Token: 0x1700000F RID: 15
			// (get) Token: 0x06000054 RID: 84 RVA: 0x0000609D File Offset: 0x0000429D
			// (set) Token: 0x06000055 RID: 85 RVA: 0x000060A5 File Offset: 0x000042A5
			public string timestamp { get; set; }
		}

		// Token: 0x0200000C RID: 12
		[DataContract]
		private class user_data_structure
		{
			// Token: 0x17000010 RID: 16
			// (get) Token: 0x06000057 RID: 87 RVA: 0x000060B6 File Offset: 0x000042B6
			// (set) Token: 0x06000058 RID: 88 RVA: 0x000060BE File Offset: 0x000042BE
			[DataMember]
			public string username { get; set; }

			// Token: 0x17000011 RID: 17
			// (get) Token: 0x06000059 RID: 89 RVA: 0x000060C7 File Offset: 0x000042C7
			// (set) Token: 0x0600005A RID: 90 RVA: 0x000060CF File Offset: 0x000042CF
			[DataMember]
			public string ip { get; set; }

			// Token: 0x17000012 RID: 18
			// (get) Token: 0x0600005B RID: 91 RVA: 0x000060D8 File Offset: 0x000042D8
			// (set) Token: 0x0600005C RID: 92 RVA: 0x000060E0 File Offset: 0x000042E0
			[DataMember]
			public string hwid { get; set; }

			// Token: 0x17000013 RID: 19
			// (get) Token: 0x0600005D RID: 93 RVA: 0x000060E9 File Offset: 0x000042E9
			// (set) Token: 0x0600005E RID: 94 RVA: 0x000060F1 File Offset: 0x000042F1
			[DataMember]
			public string createdate { get; set; }

			// Token: 0x17000014 RID: 20
			// (get) Token: 0x0600005F RID: 95 RVA: 0x000060FA File Offset: 0x000042FA
			// (set) Token: 0x06000060 RID: 96 RVA: 0x00006102 File Offset: 0x00004302
			[DataMember]
			public string lastlogin { get; set; }

			// Token: 0x17000015 RID: 21
			// (get) Token: 0x06000061 RID: 97 RVA: 0x0000610B File Offset: 0x0000430B
			// (set) Token: 0x06000062 RID: 98 RVA: 0x00006113 File Offset: 0x00004313
			[DataMember]
			public List<api.Data> subscriptions { get; set; }
		}

		// Token: 0x0200000D RID: 13
		[DataContract]
		private class app_data_structure
		{
			// Token: 0x17000016 RID: 22
			// (get) Token: 0x06000064 RID: 100 RVA: 0x00006124 File Offset: 0x00004324
			// (set) Token: 0x06000065 RID: 101 RVA: 0x0000612C File Offset: 0x0000432C
			[DataMember]
			public string numUsers { get; set; }

			// Token: 0x17000017 RID: 23
			// (get) Token: 0x06000066 RID: 102 RVA: 0x00006135 File Offset: 0x00004335
			// (set) Token: 0x06000067 RID: 103 RVA: 0x0000613D File Offset: 0x0000433D
			[DataMember]
			public string numOnlineUsers { get; set; }

			// Token: 0x17000018 RID: 24
			// (get) Token: 0x06000068 RID: 104 RVA: 0x00006146 File Offset: 0x00004346
			// (set) Token: 0x06000069 RID: 105 RVA: 0x0000614E File Offset: 0x0000434E
			[DataMember]
			public string numKeys { get; set; }

			// Token: 0x17000019 RID: 25
			// (get) Token: 0x0600006A RID: 106 RVA: 0x00006157 File Offset: 0x00004357
			// (set) Token: 0x0600006B RID: 107 RVA: 0x0000615F File Offset: 0x0000435F
			[DataMember]
			public string version { get; set; }

			// Token: 0x1700001A RID: 26
			// (get) Token: 0x0600006C RID: 108 RVA: 0x00006168 File Offset: 0x00004368
			// (set) Token: 0x0600006D RID: 109 RVA: 0x00006170 File Offset: 0x00004370
			[DataMember]
			public string customerPanelLink { get; set; }
		}

		// Token: 0x0200000E RID: 14
		public class app_data_class
		{
			// Token: 0x1700001B RID: 27
			// (get) Token: 0x0600006F RID: 111 RVA: 0x00006181 File Offset: 0x00004381
			// (set) Token: 0x06000070 RID: 112 RVA: 0x00006189 File Offset: 0x00004389
			public string numUsers { get; set; }

			// Token: 0x1700001C RID: 28
			// (get) Token: 0x06000071 RID: 113 RVA: 0x00006192 File Offset: 0x00004392
			// (set) Token: 0x06000072 RID: 114 RVA: 0x0000619A File Offset: 0x0000439A
			public string numOnlineUsers { get; set; }

			// Token: 0x1700001D RID: 29
			// (get) Token: 0x06000073 RID: 115 RVA: 0x000061A3 File Offset: 0x000043A3
			// (set) Token: 0x06000074 RID: 116 RVA: 0x000061AB File Offset: 0x000043AB
			public string numKeys { get; set; }

			// Token: 0x1700001E RID: 30
			// (get) Token: 0x06000075 RID: 117 RVA: 0x000061B4 File Offset: 0x000043B4
			// (set) Token: 0x06000076 RID: 118 RVA: 0x000061BC File Offset: 0x000043BC
			public string version { get; set; }

			// Token: 0x1700001F RID: 31
			// (get) Token: 0x06000077 RID: 119 RVA: 0x000061C5 File Offset: 0x000043C5
			// (set) Token: 0x06000078 RID: 120 RVA: 0x000061CD File Offset: 0x000043CD
			public string customerPanelLink { get; set; }
		}

		// Token: 0x0200000F RID: 15
		public class user_data_class
		{
			// Token: 0x17000020 RID: 32
			// (get) Token: 0x0600007A RID: 122 RVA: 0x000061DE File Offset: 0x000043DE
			// (set) Token: 0x0600007B RID: 123 RVA: 0x000061E6 File Offset: 0x000043E6
			public string username { get; set; }

			// Token: 0x17000021 RID: 33
			// (get) Token: 0x0600007C RID: 124 RVA: 0x000061EF File Offset: 0x000043EF
			// (set) Token: 0x0600007D RID: 125 RVA: 0x000061F7 File Offset: 0x000043F7
			public string ip { get; set; }

			// Token: 0x17000022 RID: 34
			// (get) Token: 0x0600007E RID: 126 RVA: 0x00006200 File Offset: 0x00004400
			// (set) Token: 0x0600007F RID: 127 RVA: 0x00006208 File Offset: 0x00004408
			public string hwid { get; set; }

			// Token: 0x17000023 RID: 35
			// (get) Token: 0x06000080 RID: 128 RVA: 0x00006211 File Offset: 0x00004411
			// (set) Token: 0x06000081 RID: 129 RVA: 0x00006219 File Offset: 0x00004419
			public string createdate { get; set; }

			// Token: 0x17000024 RID: 36
			// (get) Token: 0x06000082 RID: 130 RVA: 0x00006222 File Offset: 0x00004422
			// (set) Token: 0x06000083 RID: 131 RVA: 0x0000622A File Offset: 0x0000442A
			public string lastlogin { get; set; }

			// Token: 0x17000025 RID: 37
			// (get) Token: 0x06000084 RID: 132 RVA: 0x00006233 File Offset: 0x00004433
			// (set) Token: 0x06000085 RID: 133 RVA: 0x0000623B File Offset: 0x0000443B
			public List<api.Data> subscriptions { get; set; }
		}

		// Token: 0x02000010 RID: 16
		public class Data
		{
			// Token: 0x17000026 RID: 38
			// (get) Token: 0x06000087 RID: 135 RVA: 0x0000624C File Offset: 0x0000444C
			// (set) Token: 0x06000088 RID: 136 RVA: 0x00006254 File Offset: 0x00004454
			public string subscription { get; set; }

			// Token: 0x17000027 RID: 39
			// (get) Token: 0x06000089 RID: 137 RVA: 0x0000625D File Offset: 0x0000445D
			// (set) Token: 0x0600008A RID: 138 RVA: 0x00006265 File Offset: 0x00004465
			public string expiry { get; set; }

			// Token: 0x17000028 RID: 40
			// (get) Token: 0x0600008B RID: 139 RVA: 0x0000626E File Offset: 0x0000446E
			// (set) Token: 0x0600008C RID: 140 RVA: 0x00006276 File Offset: 0x00004476
			public string timeleft { get; set; }
		}

		// Token: 0x02000011 RID: 17
		public class response_class
		{
			// Token: 0x17000029 RID: 41
			// (get) Token: 0x0600008E RID: 142 RVA: 0x00006287 File Offset: 0x00004487
			// (set) Token: 0x0600008F RID: 143 RVA: 0x0000628F File Offset: 0x0000448F
			public bool success { get; set; }

			// Token: 0x1700002A RID: 42
			// (get) Token: 0x06000090 RID: 144 RVA: 0x00006298 File Offset: 0x00004498
			// (set) Token: 0x06000091 RID: 145 RVA: 0x000062A0 File Offset: 0x000044A0
			public string message { get; set; }
		}
	}
}
