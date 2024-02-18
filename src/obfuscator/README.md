# Overview

Làm cách nào để các công ty công nghệ muốn bảo vệ các dữ liệu nhạy cảm, các thuật toán quan trọng, bảo vệ bản quyền hay bảo vệ quyền sở hữu trí tuệ cửa một sản phẩm trước công ty đối thủ?

Đó là chủ đề trong buổi tech talk ngày hôm nay, trong chủ dề này chúng ta sẽ tìm hiểu một số cách để che giấu mã nguồn gốc, làm cho người xem mã nguồn khó đọc, khó hiểu, phát hiện việc định nghĩa lại hoặc custom logic từ mã nguồn gốc.

Để tất cả anh em có thể dễ hiểu và nắm bắt tốt hơn, chúng ta sẽ đi tìm hiểu trước một số thuật ngữ chuyên ngành sau:

## Thuật ngữ

### Assembly (Hợp ngữ) là gì?

Các anh em là dự án .NET đã từng nghe hoặc đã từng biết về Assembly. Các Assembly thường thấy nhất được thể hiện dưới hai dạng sau:

- Các loại assembly:
    - File có `*.exe`: Thường nó project, có chứa một điểm khởi đầu khi hoạt động chương trình (entry point) là hàm **static void Main()**
    - File có đuôi là `*.dll`: được sử dụng cho nhiều project khác nhau, **không** chứa hàm ***static void Main()**. Sử dụng trong các `classlib` hoặc `nuget`.

#### Định nghĩa

Thế thì assembly ở đây là gì? Nó là kết quả biên dịch code của project sử dụng CIL (Common Intermediate Language - Mã ngôn ngữ trung gian). Một dự án thường sẽ được ghép nối nhiều assembly với nhau. Vấn đề là chúng ta hoàn toàn có thể đảo ngược Assembly về mã nguồn gốc

#### Minh hoạ hình ảnh

Mã nguồn -compiler-> Assembly -ILSpy-> Mã nguồn  

### Reverse-engineering là gì?

Nhìn ảnh bên trên, quá trình dịch ngược từ Assembly sử dụng công cụ ILSpy để được về mã nguồn gốc được gọi là `Reverse-engineering`.

#### Định nghĩa

Là quá trình phân tích, tìm ra các nguyên lý hoạt động hoặc công nghệ của một sản phẩm phần mền đã có từ trước đó.

#### Tools

- ILSpy
- dotPeek
- JustDecompile

#### Minh hoạ hình ảnh?

### Obfuscator là gì?

#### Định nghĩa

#### Minh hoạ hình ảnh?

## Tại sao lại cần Obfuscator

Obfuscator giúp chúng ta bảo vệ an toàn bản quyền sở hữu trí tuệ (intellectual property) bỏi vì gây khó khăn cho việc reverse-engineering. Bởi vì kẻ tấn công (attackers) không thể hiểu và ăn cắp mã nguồn. Do đó sẽ bảo vệ được logic, giải thuật và cấu trúc ứng dụng đặc biết là không thể khai thác các thông tin nhạy cảm được sử dụng trong mã nguồn.

## Nhược điểm là gì?

## Tools

### Open source

### Freemium

## PreEmptive Protection

### Features

- `Renaming`: Thay đổi tên biến, tên hàm thành một tên ngẫu nhiên, làm cho `reverse-enginneering` mã trở nên khó hiểu với người đọc.
- `Anti-tamper` (Chống giả mạo): Xác định và phản hồi với các hành vi định nghĩa lại, hoặc custom logic khi giả mạo mã nguồn ứng dụng.
- `Anti-debug` (Chống debug): Xác định và phản hòi với các hành vi định nghĩa lại, hoặc custom logic khi debugger trên ứng dụng đang chạy.
- `Anti-rooted device`: Xác định và phản hồi với các hành vi định nghĩa lại, hoặc custom logic nếu ứng dụng đang chạy trên thiết bị rooted Android
- `Application expiration behaviors`: Mã hóa `end-of-line` date, xác định và phản hồi các hành vi định nghĩa lại, hoặc custom logic sau khi ứng dụng đã hết hạn.

## Demo

## Test performance

### Tổng kết

###

## Reference

https://learn.microsoft.com/en-us/visualstudio/ide/dotfuscator/?view=vs-2022
https://www.preemptive.com/dotfuscator/ce/docs/help/index.html
https://github.com/NotPrab/.NET-Obfuscator
https://www.armdot.com/blog/2023/11/13/obfuscator-for-net-8/
https://tuhocict.com/assembly-trong-c-su-dung-thu-vien-ham-nuget/