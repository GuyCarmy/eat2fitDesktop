using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;

namespace eat2fitDesktop.Models
{
    public class Meal
    {
		[BsonElement("Details")]
		public string Details;
	
		[BsonElement("Foods")]
		public List<Food> Foods { get; set; }

		public Meal()
		{
			Foods = new List<Food>();
		}

		private int time;
		[BsonElement("Time")]
		public int Time
		{
			get { return time; }
			set
			{
				time = value;
				// time is kept in minutes sense midnight. either TimeSpan or DateTime fits right for this usage, so I went for the simplest solution.
				int mealMin = value % 60;
				int mealHr = value / 60;
				int cal = 0;
				foreach (Food f in Foods)
					cal += f.Calories*f.Amount;
				cal /= 100;
				Details = "Meal Time: " + mealHr + ":" + mealMin + ", Meal Calories: " + cal;
			}
		}
	}
}
