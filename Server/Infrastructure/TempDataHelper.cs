namespace Infrastructure
{
	public static class TempDataHelper
	{
		static TempDataHelper()
		{
		}

		public static void Put<T>
			(this Microsoft.AspNetCore.Mvc.ViewFeatures.ITempDataDictionary tempData, string key, T value) where T : class
		{
			//var options =
			//	new System.Text.Json.JsonSerializerOptions
			//	{
			//		IncludeFields = true,
			//		IgnoreReadOnlyFields = false,
			//		IgnoreReadOnlyProperties = false,
			//	};

			//tempData[key] =
			//	System.Text.Json.JsonSerializer.Serialize(value: value, options: options);

			tempData[key] =
				System.Text.Json.JsonSerializer.Serialize(value: value);

			//tempData[key: key] =
			//	Newtonsoft.Json.JsonConvert.SerializeObject(value: value);
		}

		public static T? Get<T>
			(this Microsoft.AspNetCore.Mvc.ViewFeatures.ITempDataDictionary tempData, string key) where T : class
		{
			object? obj =
				tempData[key: key] as T;

			//tempData.TryGetValue(key, out object? obj);

			if (obj == null)
			{
				return null;
			}

			var result =
				System.Text.Json.JsonSerializer.Deserialize<T>((string)obj);

			//var result =
			//	Newtonsoft.Json.JsonConvert.DeserializeObject<T>(value: (string)obj);

			return result;
		}
	}
}
