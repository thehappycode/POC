# .NET cryptography model

.NET cung cấp thực thi nhiều giải thuật mã hoá học chuẩn (standard cryptography algorithms).

## Object inheritance

Hệ thống .NET cryptography thực thi việc mở rộng pattern từ derived class inheritance. Thứ tự sẽ như sau:

- Algorithm type class như `SymmetricAlgorith`, `AsymmetricAlgorithm`, hoặc `HashAlgorithm`. Đây là ở mức độ trừ tượng (abstract).
- Algorithm class được kế thừa từ Algorithm type class; ví dụ như, `Aes`, `RSA` hoặc `ECDiffieHellman`. Đây là ở mức độ trừ tượng (abstract).
- Thực thi các algorithm class được kế thừa từ algorithm class; ví dụ, `AesManaged`, `RC2CryptoServiceProvider`, hoặc `ECDiffieHellmanCng`. Đây hoàn toàn là mức độ thực thi 

Pattern của derived class cho bạn thêm mới một algorithm hoặc thực thi mới một algorithm đã tồn tại trước đó. Ví dụ, tạo new public-key algorithm, bạn cũng có thể inherit từ `AsymmetricAlgorithm` class. Tạo mới một thực thi cho một algorithm, bạn có thể tạo một non-abstract derived class của algorithm đó.

Model inheritance không được sử dụng cho `AesGcm` hoặc `Shake128`. Do các alogrithms là `sealed`. Nếu bạn cần mở rộng pattern hoặc over kiểu abstraction, thì việc thực thi abstraction là trách nhiệm của developer.

## One-shots

Trong .NET 5, one-shot API đã được giới thiệu dành cho hashing và HMAC. One-shorts đơn giản là sử dụng, giảm chỉ định sử dụng hoặc chỉ định sử dụng tự do, với những luồng an toàn, và sử dụng sẽ thực thi tốt dành cho platform. Hashing và HMAC export một static method `HashData` trên kiểu là `SHA256.HashData`. Static API đề nghị không built-in extensibility mechanism. Nếu bạn thực hiện một algorithm của mình, offer recommended static APIs cho algorithm.

`RandomNumberGenerator` class là một offers static method dành cho tạo hoặc filling buffers với cryptographic random data. Nó sẽ luôn sữ dụng system là CSPRNG (cryptographically secure pseudorandom number generator).

## How to alogrithms are implemented in .NET

Một ví dụ khác về thực thi algorithm, xét những symmetric algorithms. Base của tất cả symmetric algorithms là `SymmetricAlgorithm`, được inherited từ `Aes`, `TripleDES` và một số khác không được giới thiệu.

`Aes` là inherited từ `AesCryptoServiceProvider`, `AesCng`, và `AesManaged`.

Trong .NET framework trên Windows:

- `*CryptoServiceProvider` algorithm classes, như `AesCryptoServiceProvider`, thực thi đóng gói algorith xung quanh (around) Windows Cryptography API (CAPI).
- `*Cng` algorithm classes, như `ECDiffieHellmanCng`, thực thi đóng gói algorithm xung quanh Windows C¬ryptography Next Generation (CNG).
- `*Managed` classes, như `AesManaged`, được viết hoàn toàn trong managed code. Thực thi `*Managed` không cần chứng chỉ (certified) của Federal Information Processing Standards (FIPS), và sẽ đóng gói classes rất chậm khi so với với `*CryptoServiceProvider` và `*Cng`

Trong .NET Core và .NET 5 và các phiên bản sau, tất cả implementation classes (`*CryptoServiceProvider`, `*Managed`, `*Cng`) sẽ được đóng gói theo OS algorithms. Nếu OS algorithms là FIPS-certified, khi đó .NET sẽ sử dụng FIPS-certified algorithms.

Trong hầu hết các trường hợp, bạn không cần directly reference đến algorithm implementation class, như `AesCryptoServiceProvider`. Các methods và properties bạn cần đều ở bass algorithm class, như `Aes`. Tạo một instance của implementation class mặc định sẽ sử dụng factory method trên base algorithm class, và refer đến base algorithm class.


## Choose an algorithm

Bạn có thể lựa chọn algorithm vì nhiều lý do khác nhau, ví dụ: Như data integrity (toàn vẹn dữ liệu), data private, hoặc generate môt key. Symmetric và hash algorithms dành cho việc protecting data. Hash algorithms chủ yếu được sử dụng cho data integrity.

Sau đây là danh sách algorithms đề cử cho application của bạn

- Data privacy:
    - Aes

- Data integrity:
    - HMACSHA256
    - HMACSHA512

- Digital signature:
    - ECDsa
    - RSA

- Key exchange:
    - ECDiffieHellman
    - RSA

- Random number generation:
    - RandomNumberGenerator.GetBytes
    - RandomNumberGenerator.Fill

- Generating a key from a password:
    - Rfc2898DeriveBytes.Pbkdf2


## Reference link

https://learn.microsoft.com/en-us/dotnet/standard/security/cryptography-model