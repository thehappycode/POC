using System.Security.Cryptography;
using System.Text.Json;

// Symmetric encryption
Aes aes = Aes.Create();

Console.WriteLine($"Key: {JsonSerializer.Serialize(aes.Key)}");
Console.WriteLine($"IV: {JsonSerializer.Serialize(aes.IV)}");

aes.GenerateKey();
aes.GenerateIV();
Console.WriteLine($"Key1: {JsonSerializer.Serialize(aes.Key)}");
Console.WriteLine($"IV1: {JsonSerializer.Serialize(aes.IV)}");

aes.GenerateKey();
aes.GenerateIV();
Console.WriteLine($"Key: {JsonSerializer.Serialize(aes.Key)}");
Console.WriteLine($"IV: {JsonSerializer.Serialize(aes.IV)}");

// Asymmetric encryption

// Generate a public-key, private-key pair
RSA rsa = RSA.Create();

var publicKey = rsa.ExportRSAPublicKey();
var privateKey = rsa.ExportRSAPrivateKey();
Console.WriteLine($"Public-Key: {JsonSerializer.Serialize(publicKey)}");
Console.WriteLine($"Private-Key: {JsonSerializer.Serialize(privateKey)}");

// Save the public-key information to an RSAParameters structure
RSAParameters rsaParameters = rsa.ExportParameters(false);