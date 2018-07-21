using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;

namespace eat2fitDesktop.Models
{
    class Customer
    {
		[BsonId(IdGenerator = typeof(CombGuidGenerator))]
		public Guid id { get; set; }
		[BsonElement("name")]
		public string name { get; set; }
		[BsonElement("age")]
		public int age { get; set; }

    }
}
