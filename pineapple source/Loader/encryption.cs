using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading;

namespace KeyAuth
{
	// Token: 0x02000003 RID: 3
	public static class encryption
	{
		// Token: 0x06000017 RID: 23 RVA: 0x000034DC File Offset: 0x000016DC
		public static string byte_arr_to_str(byte[] ba)
		{
			StringBuilder hex = new StringBuilder(ba.Length * 2);
			foreach (byte b in ba)
			{
				hex.AppendFormat("{0:x2}", b);
			}
			return hex.ToString();
		}

		// Token: 0x06000018 RID: 24 RVA: 0x00003520 File Offset: 0x00001720
		public static byte[] str_to_byte_arr(string hex)
		{
			byte[] result;
			try
			{
				int NumberChars = hex.Length;
				byte[] bytes = new byte[NumberChars / 2];
				for (int i = 0; i < NumberChars; i += 2)
				{
					bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
				}
				result = bytes;
			}
			catch
			{
				Console.WriteLine("\n\n  The session has ended, open program again.");
				Thread.Sleep(3500);
				Environment.Exit(0);
				result = null;
			}
			return result;
		}

		// Token: 0x06000019 RID: 25 RVA: 0x00003594 File Offset: 0x00001794
		public static string encrypt_string(string plain_text, byte[] key, byte[] iv)
		{
			Aes encryptor = Aes.Create();
			encryptor.Mode = CipherMode.CBC;
			encryptor.Key = key;
			encryptor.IV = iv;
			string result;
			using (MemoryStream mem_stream = new MemoryStream())
			{
				using (ICryptoTransform aes_encryptor = encryptor.CreateEncryptor())
				{
					using (CryptoStream crypt_stream = new CryptoStream(mem_stream, aes_encryptor, CryptoStreamMode.Write))
					{
						byte[] p_bytes = Encoding.Default.GetBytes(plain_text);
						crypt_stream.Write(p_bytes, 0, p_bytes.Length);
						crypt_stream.FlushFinalBlock();
						result = encryption.byte_arr_to_str(mem_stream.ToArray());
					}
				}
			}
			return result;
		}

		// Token: 0x0600001A RID: 26 RVA: 0x0000364C File Offset: 0x0000184C
		public static string decrypt_string(string cipher_text, byte[] key, byte[] iv)
		{
			Aes encryptor = Aes.Create();
			encryptor.Mode = CipherMode.CBC;
			encryptor.Key = key;
			encryptor.IV = iv;
			string @string;
			using (MemoryStream mem_stream = new MemoryStream())
			{
				using (ICryptoTransform aes_decryptor = encryptor.CreateDecryptor())
				{
					using (CryptoStream crypt_stream = new CryptoStream(mem_stream, aes_decryptor, CryptoStreamMode.Write))
					{
						byte[] c_bytes = encryption.str_to_byte_arr(cipher_text);
						crypt_stream.Write(c_bytes, 0, c_bytes.Length);
						crypt_stream.FlushFinalBlock();
						byte[] p_bytes = mem_stream.ToArray();
						@string = Encoding.Default.GetString(p_bytes, 0, p_bytes.Length);
					}
				}
			}
			return @string;
		}

		// Token: 0x0600001B RID: 27 RVA: 0x0000370C File Offset: 0x0000190C
		public static string iv_key()
		{
			return Guid.NewGuid().ToString().Substring(0, Guid.NewGuid().ToString().IndexOf("-", StringComparison.Ordinal));
		}

		// Token: 0x0600001C RID: 28 RVA: 0x00003750 File Offset: 0x00001950
		public static string sha256(string r)
		{
			return encryption.byte_arr_to_str(new SHA256Managed().ComputeHash(Encoding.Default.GetBytes(r)));
		}

		// Token: 0x0600001D RID: 29 RVA: 0x0000376C File Offset: 0x0000196C
		public static string encrypt(string message, string enc_key, string iv)
		{
			byte[] _key = Encoding.Default.GetBytes(encryption.sha256(enc_key).Substring(0, 32));
			byte[] _iv = Encoding.Default.GetBytes(encryption.sha256(iv).Substring(0, 16));
			return encryption.encrypt_string(message, _key, _iv);
		}

		// Token: 0x0600001E RID: 30 RVA: 0x000037B4 File Offset: 0x000019B4
		public static string decrypt(string message, string enc_key, string iv)
		{
			byte[] _key = Encoding.Default.GetBytes(encryption.sha256(enc_key).Substring(0, 32));
			byte[] _iv = Encoding.Default.GetBytes(encryption.sha256(iv).Substring(0, 16));
			return encryption.decrypt_string(message, _key, _iv);
		}
	}
}
