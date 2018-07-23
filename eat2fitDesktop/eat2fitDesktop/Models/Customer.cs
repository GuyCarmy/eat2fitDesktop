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
		[BsonElement("Age")]
		public int Age { get; set; }
		[BsonElement("SuggestedDeit")]
		public List<Meal> SuggestedDeit { get; }
		[BsonElement("EatedDeit")]
		public List<Meal> EatedDiet { get; }
		public string aa = "aaa";
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
		public override string ToString()
		{
			return Name;
		}
		[BsonElement("Details")]
		public string Details { get; set; }
		public Customer()
		{
			Details = "Age: " + Age + " ID: ";
		}
		
	}
}
