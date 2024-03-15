using EmployeeTaskManager.Domain.Enum;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTaskManager.API.Repositories.Models.TaskModels
{
    public class EmployeeTaskModel
    {
        [BsonId]

        [BsonRepresentation(BsonType.ObjectId)]

        public string? Name { get; set; }

        public string? Description { get; set; }

        public TaskState TaskState { get; set; }

        public string? EmployeeId { get; set; }
        public ObjectId Id { get; set; }



    }
}
