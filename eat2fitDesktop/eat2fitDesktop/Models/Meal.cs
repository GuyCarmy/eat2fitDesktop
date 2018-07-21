using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;

namespace eat2fitDesktop.Models
{
    class Meal
    {
		[BsonId(IdGenerator = typeof(CombGuidGenerator))]
		public Guid Id { get; set; }
		[BsonElement("Time")]
		public int Time; 
		// time is kept in minutes sense midnight. either TimeSpan or DateTime fits right for this usage, so I went for the simplest solution.

		public List<Food> Foods;

    }
}
