using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Driver;
using eat2fitDesktop.Models;
using System.Security.Authentication;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace eat2fitDesktop.Services
{
    class MongoService
    {
		string ConnectionString = "";
		string dbName = "eat2fit";
		string collectionName = "Customers";

		IMongoCollection<Customer> customersCollection;
		IMongoCollection<Customer> CustomersCollection
		{
			get
			{
				if (customersCollection == null)
				{
					MongoClientSettings settings = MongoClientSettings.FromUrl(
					  new MongoUrl(ConnectionString)
					);

					settings.SslSettings =
						new SslSettings() { EnabledSslProtocols = SslProtocols.Tls12 };

					// Initialize the client
					var mongoClient = new MongoClient(settings);

					// This will create or get the database
					var db = mongoClient.GetDatabase(dbName);

					// This will create or get the collection
					var collectionSettings = new MongoCollectionSettings { ReadPreference = ReadPreference.Nearest };
					customersCollection = db.GetCollection<Customer>(collectionName, collectionSettings);
				}
				return customersCollection;
			}
		}


		public async Task<List<Customer>> GetAllCustomers()
		{
			try
			{
				var allCustomers = await CustomersCollection
					.Find(new BsonDocument())
					.ToListAsync();

				return allCustomers;
			}
			catch (Exception ex)
			{
				System.Diagnostics.Debug.WriteLine(ex.Message);
			}
			return null;
		}
		/*
		public async Task<List<MyTask>> GetIncompleteTasks()
		{
			var incompleteTasks = await TasksCollection
				.Find(mt => mt.Complete == false)
				.ToListAsync();

			return incompleteTasks;
		}

		public async Task<MyTask> GetTaskById(Guid taskId)
		{
			var singleTask = await TasksCollection
				.Find(f => f.Id.Equals(taskId))
				.FirstOrDefaultAsync();

			return singleTask;
		}


		public async Task<List<MyTask>> GetIncompleteTasksDueBefore(DateTime date)
		{
			var tasks = await TasksCollection
							.AsQueryable()
							.Where(t => t.Complete == false)
							.Where(t => t.DueDate < date)
							.ToListAsync();

			return tasks;
		}
		*/
		public async Task CreateCustomer(Customer customer)
		{
			await CustomersCollection.InsertOneAsync(customer);
		}
		/*
		public async Task UpdateTask(MyTask task)
		{
			await TasksCollection.ReplaceOneAsync(t => t.Id.Equals(task.Id), task);
		}

		public async Task DeleteTask(MyTask task)
		{
			await TasksCollection.DeleteOneAsync(t => t.Id.Equals(task.Id));
		}
		*/

	}
}
