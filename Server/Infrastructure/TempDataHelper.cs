using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.Text.Json;

namespace Infrastructure;

public static class TempDataHelper : object
{
	public static void Put<T>
		(this ITempDataDictionary tempData, string key, T value) where T : class
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

		tempData[key] = JsonSerializer.Serialize(value: value);

		//tempData[key: key] =
		//	Newtonsoft.Json.JsonConvert.SerializeObject(value: value);
	}

	public static T? Get<T>
		(this ITempDataDictionary tempData, string key) where T : class
	{
		object? obj = tempData[key: key] as T;

		//tempData.TryGetValue(key, out object? obj);

		if (obj == null)
		{
			return null;
		}

		var result = JsonSerializer.Deserialize<T>((string)obj);

		//var result =
		//	Newtonsoft.Json.JsonConvert.DeserializeObject<T>(value: (string)obj);

		return result;
	}
}
