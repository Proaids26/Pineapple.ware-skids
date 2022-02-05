using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;

namespace KeyAuth
{
	// Token: 0x02000004 RID: 4
	public class json_wrapper
	{
		// Token: 0x0600001F RID: 31 RVA: 0x000037FB File Offset: 0x000019FB
		public static bool is_serializable(Type to_check)
		{
			return to_check.IsSerializable || to_check.IsDefined(typeof(DataContractAttribute), true);
		}

		// Token: 0x06000020 RID: 32 RVA: 0x00003818 File Offset: 0x00001A18
		public json_wrapper(object obj_to_work_with)
		{
			this.current_object = obj_to_work_with;
			Type object_type = this.current_object.GetType();
			this.serializer = new DataContractJsonSerializer(object_type);
			if (!json_wrapper.is_serializable(object_type))
			{
				throw new Exception(string.Format("the object {0} isn't a serializable", this.current_object));
			}
		}

		// Token: 0x06000021 RID: 33 RVA: 0x00003868 File Offset: 0x00001A68
		public object string_to_object(string json)
		{
			object result;
			using (MemoryStream mem_stream = new MemoryStream(Encoding.Default.GetBytes(json)))
			{
				result = this.serializer.ReadObject(mem_stream);
			}
			return result;
		}

		// Token: 0x06000022 RID: 34 RVA: 0x000038B0 File Offset: 0x00001AB0
		public T string_to_generic<T>(string json)
		{
			return (T)((object)this.string_to_object(json));
		}

		// Token: 0x0400000C RID: 12
		private DataContractJsonSerializer serializer;

		// Token: 0x0400000D RID: 13
		private object current_object;
	}
}
