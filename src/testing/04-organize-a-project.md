# Organizing and testing projects with the .NET CLI

## Using folders to organize code

Nếu bạn muốn tạo một new types trong một console app, bạn có thể thêm files types trong app. Ví dụ, nếu bạn thêm files có nội dung `AccountInformation` và `MonthlyReportRecords` types trong project, cấu trúc files trong prject là phẳng (flat) sẽ như sau:

```C#
/MyProject
|__AccountInformation.cs
|__MonthlyReportRecords.cs
|__MyProject.csproj
|__Program.cs
```

Tuy nhiên, flat structure chỉ làm việc tốt khi size project của bạn thật sự nhỏ. Bạn có thể tưởng tượng, đều gì sẽ xảy ra nếu bạn add thêm 20 types vào trong project? Project sẽ có rất khó tìm kiếm (natigate) và maintain với nhiều file cùng root directory.

Tổ chức project, với tạo một new folder và đặt tên là _Models_ để chứa type files.

```C#
/MyProject
|__/Models
   |__AccountInformation.cs
   |__MonthlyReportRecords.cs
|__MyProject.csproj
|__Program.cs
```

Nhóm các files theo logic trong cùng một folders để dễ dàng tìm kiếm (navigate) và maintain.

## Testing the sample

Project `NewTypes` là một nơi, bạn đã tổ chức và giữ các pets-related types trong cùng một folder. Tiếp theo, bạn tạo một test project và bắt đầu writting bài test với `xUnit` test framework. Unit testing cho phép bạn tự động check các hành vi (behavior) của pet types của bạn và confirm với operating property.

Bạn tạo thêm một project và đặt tên là `NewTypesTests` trong cùng folder, khi đó folder sẽ có cấu trúc thư mục như sau:

```C#
/NewTypes
|__/src
   |__/NewTypes
      |__/Pets
         |__Dog.cs
         |__Cat.cs
         |__IPet.cs
      |__Program.cs
      |__NewTypes.csproj
|__/test
   |__NewTypesTests
      |__PetTests.cs
      |__NewTypesTests.csproj
```

## Organizing and testing using the NewTypes PetsSample

## Reference

https://learn.microsoft.com/en-us/dotnet/core/tutorials/testing-with-cli
