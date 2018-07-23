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
		public Guid Id { get; set; }
		[BsonElement("Name")]
		public string Name { get; set; }
		[BsonElement("Details")]
		public string Details;
		[BsonElement("Age")]
		public int Age { get; set; }
		[BsonElement("SuggestedDeit")]
		public List<Meal> SuggestedDeit { get; }
		[BsonElement("EatedDeit")]
		public List<Meal> EatedDiet { get; }

		public void AddMeal(string diet, Meal meal)
		{
			switch (diet)
			{
				case "Suggested":
					SuggestedDeit.Add(meal);
					break;
				case "Eated":
					EatedDiet.Add(meal);
					break;
			}
		}
	}
}
