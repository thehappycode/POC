# Overview

## Test types

Automated tests là cách tuyệt vời nhất cho ứng dụng. Chúng ta có các loại test

- unit tests
- integration tests
- load tests

### Unit tests

Unit test là test một các riêng lẽ các thành phần hoặc phương thức của phần mềm, nó còn được biết với tên "unit of work". Unit test có thể chỉ là test code trong phạm vi của các developers. Unit test không test cùng với infrastruce. Infrastructure bao gồm việc tương tác với database, file systems, và network.

### Integration tests

Integration test khác với unit test là test từ hai hoặc nhiều hơn các thành phần có cùng chức năng của phần mền, nên được gọi là "integration". Thường integration tests có liên quan đến infrastructure.

### Load tests

Load test là xác định chính xác khả năng chịu tải của hệ thống. Ví dụ,  xác định số concurrent users đang sử dụng ứng dụng và có khả năng phản hồi các response.

## Test considerations

Luôn nghĩ về best practices khi viết tests. Ví dụ, **Test Driven Development (TDD)** là viết unit test trước khi code. TTD giống như tạo ra bản phát thảo trước khi viết. Unit test giúp các developers viết code đơn giản hơn, dễ đọc hơn và hiểu quả hơn.

## Testing tools

.NET là môi trường phát triển của nhiều ngôn ngữ, và bạn có thể viết các test types của C#, F#, và Visual Bacis. Mỗi ngôn ngữ, bạn sẽ có nhiều lựa chọn theo frameworks.

### xUnit

xUnit là mã nguồn mỡ, cộng đồng tập trung vào unit testing dàng cho .NET. xUnit.net là dự án của .NET Foundation

### NUnit

NUnit là một unit testing framework dành cho tất cả ngôn ngữ .NET. Khởi đầu, NUnit được chuyển từ JUnit, và bản product release hiện tại được viết lại với nhiều tính năng mới, hỗ trợ phạm vi rộng lớn của nên tảng .NET. Nó là dự án của .NET Foundation.

### MSTest

MSTest là Microsoft test framework dàn cho tất cả ngôn ngữ .NET. Nó có thể mở rộng làm việc với cả .NET CLI và Visual Studio.

### MSTest runner

MSTest runner là một lightweight and portable thay cho VSTest dành cho chạy trong continuous integration (CI), và Visual Studio Test Explore.

### .NET CLI

Bạn có thể chạy solutions unit test from .NET CLI với dotnet test command. .NET CLI exposes hầu hết các chức năng của Integrated Development Environments (IDEs). .NET CLI có thể sử dụng trên nhiều nên tảng và được sử dụng một phần trong continuous integration and delivery pipeline. .NET CLI được sử dụng với scripted processes và tự động common task.

### IDE

Bạn có thể sử dụng Visual Studio hoặc Visual Studio Code, nó có hình ảnh giao diện người dùng cho các chức năng testing. IDE có nhiều tính năng hơn CLI, ví dụ, Live Unit Testing.