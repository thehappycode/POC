using System.Text;
using RabbitMQ.Client;

var factory = new ConnectionFactory { HostName = "localhost" };
using var connection = factory.CreateConnection();
using var channel = connection.CreateModel();

// declare a direct exchange
channel.ExchangeDeclare(exchange: "direct_logs", type: ExchangeType.Direct);

var message = GetMessage(args);
var body = Encoding.UTF8.GetBytes(message);


var color = (args.Length > 0) ? args[0] : "black";

channel.BasicPublish(exchange: "direct_logs",
                     routingKey: color,
                     basicProperties: null,
                     body: body);
Console.WriteLine($" [x] Sent '{color}':'{message}'");

Console.WriteLine(" Press [enter] to exit.");
Console.ReadLine();

static string GetMessage(string[] args) =>
    ((args.Length > 0) ? string.Join(" ", args) : "info: Hello World!");