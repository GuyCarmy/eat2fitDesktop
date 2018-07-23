using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;

namespace eat2fitDesktop.Models
{
    class Food
    {
		[BsonId(IdGenerator = typeof(CombGuidGenerator))]
		public Guid Id { get; set; }
		[BsonElement("Name")]
		public string Name { get; set; }
		[BsonElement("Calories")]
		public int Calories { get; set; }
		public override string ToString()
		{
			return Name;
		}
	}
}
