using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MongoDB.Bson;
using MongoDB.Driver;
using NoSqlWithoutEf.Models;

namespace NoSqlWithoutEf.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            //NoSqlCrudWithType();
            //NoSqlCrudWithOutType();
        }

        private void NoSqlCrudWithType()
        {
            MongoClient _client = new MongoClient("mongodb://localhost:27017");
            var db = _client.GetDatabase("NoSqlDb");
            var collection = db.GetCollection<Teacher>("TeacherCollection");


            Teacher t = new Teacher()
            {
                Id = Guid.NewGuid(),
                FirstName = "Saeid",
                LastName = "Kamyab",
                FatherName = "Es",
                NationalCode = "4900253936",
                Address = "NasirShahr.......",
                UserName = "s",
                Password = "s",
                PhoneNumbers = new List<PhoneNumber>
                {
                    new PhoneNumber()
                    {
                        Id = Guid.NewGuid(),
                        Number = "09029182652"
                    },
                    new PhoneNumber()
                    {
                    Id = Guid.NewGuid(),
                    Number = "09355473891"
                    }
                }

            };

            //Add.....................................
            collection.InsertOne(t);

            var myFilter = Builders<Teacher>.Filter.Eq(q => q.FirstName, "Saeid");
            var result = collection.Find(myFilter);
            var sk = result.ToList();

            //Update.....................................
            var updateOperator = Builders<Teacher>.Update.Set(q => q.LastName, "Toli");
            collection.FindOneAndUpdate<Teacher>(myFilter, updateOperator);


            //Delete.....................................
            collection.FindOneAndDelete(myFilter);
        }
        private void NoSqlCrudWithOutType()
        {
            MongoClient _client = new MongoClient("mongodb://localhost:27017");
            var db = _client.GetDatabase("NoSqlDb");


            var AnonymousObject = new
            {
                Address = "uiffhskhsdfhgkls",
                Tell = "0213265623",
                Age = 20
            };

            var collection = db.GetCollection<dynamic>("AnonyMous");

            //Add.....................................
            collection.InsertOne(AnonymousObject);

            var myFilter = Builders<dynamic>.Filter.Eq("Age", "20");
            var result = collection.Find(myFilter);
            var sk = result.ToList();

            //Update.....................................
            var updateOperator = Builders<dynamic>.Update.Set("Age", "20");
            collection.FindOneAndUpdate<dynamic>(myFilter, updateOperator);


            //Delete.....................................
            collection.FindOneAndDelete(myFilter);
        }
    }
}
