# Unit testing C# in .NET Core using dotnet test and xUnit

Trong bài học này sẽ hướng dẫn cách để buid một solution chứa unit test trong project và souce code project. Bạn có thể [download sample code tại đây](https://github.com/dotnet/samples/tree/main/core/getting-started/unit-testing-using-dotnet-test/)

## Create the solution

Trong mục này, sẽ tạo một solution chứa source và test projects. Sau khi hoàn thành solution của bạn sẽ có cấu trúc thư mục như sau:

```dotnet
/unit-testing-using-dotnet-test
    unit-testing-using-dotnet-test.sln
    /PrimeService
        PrimeService.cs
        PrimeService.csproj
    /PrimeService.Tests
        PrimeService_IsPrimeShould.cs
        PrimeServiceTests.csproj
```

### Step 1: Create a new solution

```.NET CLI
$ dotnet new sln -o unit-testing-using-dotnet-test
```

### Step 2: Create a new classlib and add into Solution

```.NET CLI
$ dotnet new classlib -o PrimeService

$ dotnet sln add ./PrimeService/PrimeService.csproj
```

### Step 3: Create a new xunit and add into Solution

```.NET CLI
$ dotnet new xunit -o PrimeService.Tests

$ dotnet sln add ./PrimeService.Tests/PrimeService.Tests.csproj
```

### Step 4: Add PrimeService into PrimeService.Tests

```.NET CLI
$ dotnet add ./PrimeService.Tests/PrimeService.Test.csproj reference ./PrimeService/PrimeService.csproj
```

## Create a test

Chúng ta sẽ tiếp cận theo hướng **test driven development** (TDD) là viết failling test trước khi thực hiện target code. Bài hướng dẫn này cũng sẽ sử dụng TTD. `IsPrime` method được phép gọi nhưng nó không thể thực hiện. Bài test `IsPrime` fails. Với TDD, một bài test luôn tiếp cận theo hướng viết fail trước. Target code sẽ update đến khi nào test pass. Và bạn lặp lại, viết một test fail trước và update đến khi nào target code to pass.

Tiếp cận theo hướng TDD, thêm nhiều failing tests, sau đó update target code.

## Reference

https://learn.microsoft.com/en-us/dotnet/core/testing/unit-testing-with-dotnet-test