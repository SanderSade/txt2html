using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace text2html.test
{
	internal sealed class InternalFieldResolver : DefaultContractResolver
	{
		protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
		{
			var props = type.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
				.Select(p => CreateProperty(p, memberSerialization))
				.ToList();

			props.ForEach(p =>
			{
				p.Writable = true;
				p.Readable = true;
			});

			return props;
		}
	}
}
