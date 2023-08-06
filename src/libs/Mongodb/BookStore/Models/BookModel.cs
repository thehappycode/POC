using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Mongodb.BookStore.Models;

public class BookModel
{
    [BsonId]
    public Guid Id { get; set; } =  Guid.NewGuid();
    [JsonPropertyName("Name")]
    [BsonElement("Name")]
    public string BookName { get; set; } = null!;
    public decimal Price { get; set; }
    public string Category { get; set; } = null!;
    public string Author { get; set; } = null!;
}