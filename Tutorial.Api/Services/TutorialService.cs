using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Tutorial.Api.Models;

namespace Tutorial.Api.Services
{
    public class TutorialService
    {
        private readonly IMongoCollection<Models.Tutorial> _tutorialCollection;

        public TutorialService(IOptions<TutorialDatabaseSettings> tutorialDatabaseSettings)
        {
            var mongoClient = new MongoClient(tutorialDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(tutorialDatabaseSettings.Value.DatabaseName);

            _tutorialCollection = mongoDatabase.GetCollection<Models.Tutorial>(tutorialDatabaseSettings.Value.TutorialCollectionName);
        }

        public async Task<List<Models.Tutorial>> GetAsync() =>
            await _tutorialCollection.Find(_ => true).ToListAsync();

        public async Task<Models.Tutorial?> GetAsync(string id) =>
            await _tutorialCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Models.Tutorial newBook) =>
            await _tutorialCollection.InsertOneAsync(newBook);

        public async Task UpdateAsync(string id, Models.Tutorial updatedBook) =>
            await _tutorialCollection.ReplaceOneAsync(x => x.Id == id, updatedBook);

        public async Task RemoveAsync(string id) =>
            await _tutorialCollection.DeleteOneAsync(x => x.Id == id);

        public async Task RemoveAsync() =>
           await _tutorialCollection.DeleteManyAsync(x => x.Id !=null);
    }


}
