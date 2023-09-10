using System.Text;
using RabbitMQ.Client;

var factory = new ConnectionFactory { HostName = "localhost" };

using var connection = factory.CreateConnection();
using var channel = connection.CreateModel();

// declare a topic exchange
channel.ExchangeDeclare(exchange: "topic_logs", type: ExchangeType.Topic);

var message = GetMessage(args);
var body = Encoding.UTF8.GetBytes(message);

var routingKey = (args.Length > 0) ? args[0] : "anonymous";

channel.BasicPublish(exchange: "topic_logs",
                     routingKey: routingKey,
                     basicProperties: null,
                     body: body);

Console.WriteLine($" [x] Sent '{routingKey}':'{message}'");
Console.WriteLine(" Press [enter] to exit.");
Console.ReadLine();

static string GetMessage(string[] args) =>
    ((args.Length > 0) ? string.Join(" ", args) : "anonymous: Hello World!");