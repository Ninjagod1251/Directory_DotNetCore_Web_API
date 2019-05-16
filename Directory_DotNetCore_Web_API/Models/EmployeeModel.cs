using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Directory_DotNetCore_Web_API.Models
{
    public class EmployeeModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }


        [BsonElement("firstName")]
        public string firstName { get; set; }

        [BsonElement("lastName")]
        public string lastName { get; set; }

        [BsonElement("address")]
        public string address { get; set; }

        [BsonElement("phoneNumbers")]
        public List<int> phoneNumbers { get; set; }

        [BsonElement("ActiveStatus")]
        public bool activeStatus { get; set; } = false;

        [BsonDateTimeOptions]
        public DateTime? startDate { get; set; }

        [BsonDateTimeOptions]
        public DateTime? endDate { get; set; }

    }
}
