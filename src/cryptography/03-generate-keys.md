# Generate keys for encryption and decryption

Tạo và quản lý keys là một phần rất quan trọng trong cryptographic.

- **Symmetric algorithms** yêu cầu tạo một `key` và một `IV` (initialization vector). Bạn bắt buộc phải giữ bí mật `key`, do bất kỳ ai cũng có thể decrypt dữ liệu của bạn. `IV` thì không cần giữ bí mật vì sẽ được thay đổi sau mỗi session.
- **Asymmetric algorithms** yêu cầu tạo ra một `public-key` và một `private-key`. `public-key` được công khai với mọi người, nhưng `private-key` phải được giữ bí mật, và chỉ được sử dụng trong giai đoạn decrypting.

Trong mục này chúng ta sẽ thảo luận cách tạo (generate) và quản lý (manage) keys của cả symmetric algorithms và asymmetric algorithms.

## Symmetric keys

**Symmetric encryption class** được cung cấp bởi .NET yêu cầu một `key` và một `IV` để encrypt và decrypt dữ liệu. Một new `key` và `IV` được tạo tự động khi bạn khởi tạo một _new instance_ từ một _managed sysmetric cryptographic class_ khi không sử dụng tham số (parammeterless) `Create()` method. Bất kỳ ai được phép decrypt dữ liệu của bạn, đều bắt buộc phải sử dụng cùng `key`, `IV` và **algorithm** trong quá trình giả mã.
Nói chung, một new `key` và `IV` sẽ được tạo trong mỗi session, và cả `key` và `IV` đều không được lưu trữ lại để dùng cho session sau.

Giao tiếp từ xa với một symmetric `key` và `IV`, bạn thường phải encrypt symmetric key bằng cách sử dụng asymmetric encrytion. Sending một `key` không được mã hoá trên một mạng không được bảo vệ (insecure network) là không an toàn bởi vì bất kỳ ai cũng có thể chặn (intercepts) `key` và `IV` và có thể decrypt dữ liệu của bạn.

Sau đây là ví dụ để tạo một new instance mặc định từ `Aes` algorithm.

```C#
Aes aes = Aes.Create();
```

Khi thực thi code bên trên sẽ tạo ra một new `key` và `IV` và được set giá trị vào 2 thuộc tính (properties) là `Key` và `IV`.

Đôi khi bạn có thể cần khởi tạo **multiple keys**. Trong tình hướng này, bạn có thể tạo một new instance. Sau đó bạn có thể call `GenerateKey` và `GenerateIV` method để tạo mới `key` và `IV`. Như ví dụ sau:

```C#
Aes aes = Aes.Create();
aes.GenerateKey();
aes.GenerateIV();
```

## Asymmetric keys

.NET cung cấp `RSA` class của asymmetric encryption. Khi bạn sử dụng `Create()` method mà không truyền tham số (parameterless) sẽ tạo ra một **new instance**, `RSA` class sẽ tạo ra một cặp `public-key` và `private-key`. Asymmetric keys sẽ được lưu trữ để sử dụng cho `multiple session` hoặc được tạo chỉ dùng cho một session.

Một cặp `public-key` và `private-key` sẽ được khởi tạo khi bạn tạo một **new instance**. Sau khi tạo một new instance, bạn có thể biết chính xác thông tin keys bằng cách sử dugnj `ExportParameters` method. Phương thức này sẽ trả ra một `RSAParameters` structure đang nắm giữ thông tin của keys. Phương thức có thể trả về thông tin chỉ `public-key` hoặc `private-key` hoặc cả hai thông tin trên.

Các phương thức lấy thông tin của `key` bao gồm:

- `RSA.ExportRSAPublicKey`
- `RSA.ExportRSAPrivateKey`
- `AsymmetricAlgorithm.ExportSubjectPublicKeyInfo`
- `AsymmetricAlgorithm.ExportPkcs8PrivateKey`
- `AsymmetricAlgorithm.ExportEncryptedPkcs8PrivateKey`

Bạn có thể sử dụng `ImportParameters` method để khởi tạo một `RSA` instance với giá trị của một `RSAParameters` structure. Hoặc bạn có thể sử dụng `RSA.Create(RSAParameters)` method để tạo một new instance.

Đừng bao giờ lưu trữ `private-key` dưới dạng văn bản trên local computer. Nếu bạn cần lưu trữ một `private-key`, bắt buộc bạn phải sử dụng **key container**.

Ví dụ phía dưới sẽ hướng dẫn bạn tạo một new instance `RSA`, và tạo một cặp `public-key`, `private-key`, và lưu thông tin của `public-key` vào trong `RSAParameters` structure.

```C#
// Generate a public-key, private-key pair
RSA rsa = RSA.Create();

// Save the public-key information to an RSAParameters structure
RSAParameters rsaParameters = rsa.ExportParameters(false);
```

## Reference

https://learn.microsoft.com/en-us/dotnet/standard/security/generating-keys-for-encryption-and-decryption
