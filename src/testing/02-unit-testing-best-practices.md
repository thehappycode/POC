# Unit testing best practices with .NET Core and .NET Standard

Viết unit test sẽ mang lại nhiều lợi ít, nó giúp quy hồi (regression), cung cấp documentation, và tạo điều kiện cho một thiết kế tốt. Tuy nhiên, viết khó đọc và brittle (dễ vỡ vụn) unit tests có thể tàn phá (wreak havoc) code base của bạn.

Trong bài hướng đẫn này, bạn sẽ học một số best practices khi writing unit tests và giữ cho test của bạn linh hoạt (resilient) và dễ hiểu

## Why uinit test?

Có nhiều lý do dể sử dụng unit tests.

### Less time performing function tests

Functional test là rất đắt giá (expensive). Chúng thường liên quan đén việc mở ứng dụng và thực hiện một loạt các bước dự kiến mà bạn (hoặc người khác) phải tuân thủ để đạt được kết quả mong muốn. Nhưng bước này không phải lúc nào tester cũng biết. Họ phải tìm kiếm một số người có kiến thức trong lĩnh vực này để thực hiện bài test. Bản thân Testing tự nó có thể mất vài giây cho thay đổi nhỏ hoặc nhiều phút với thay đổi lớn, Cuối cùng, quá trình này sẽ được lặp lại cho mỗi lần bạn có thay đổi trong thệ thống.

Unit test, mặc khác chỉ mất vài millisecond, có thể chạy bằng cách ấn một nút, và không cần yêu cầu bất kỳ kiến thức nào về hệ thống (kể cả hệ thống lớn). Việc chạy bài test, có passes hoặc fails là do người test, không phải do bất kỳ cá nhân.

### Protection against regression

Regression defects (Những lỗi quy hồi) là những lỗi được đưa vào khi có một thay đổi trong application. Thông thường, những tester không chỉ test new feature, mà còn test lại những features có liên đã tồn tại trước đó để xác nhận những hành động trược đó vẫn thực hiện đúng như mong đợi.

Với unit testing, nó chắc chắn sẽ được chạy lại toàn bộ bài tests sau mỗi lần build hoặc sau mỗi lần bạn thay đỏi một dòng code. Luôn giữ cho code bạn có độ đang tin cao, new code sẽ không làm hõng các chức năng đã tồn tại.

### Executable documentation

Không phải lúc nào một method cũng rõ ràng hoặc nó sẽ hoạt động cách nào với input. Bạn có thể tự hỏi chính mình: Method sẽ hành động thế nào nếu tôi pass cho nó một blank string? hoặc Null?

Khi bạn có một bộ (suite) unit test với cách đặt tên tốt, mỗi lần test sẽ giải thích cho bạn output mong muốn từ input. Hơn nữa, còn xác nhận nó thực sự hoạt động được.

### Less coupled code

Khi code được liên kết quá chặc chẻ, nó sẽ gây khó cho unit test. Nếu không tạo các unit test dành cho code của bạn writting, thì các liên kết sẽ ít rõ ràng.

Writting test dành cho code của bạn sẽ tự nhiên tách rời code của bạn, bởi vì nếu không, nó sẽ gây khó cho việc test

## Characteristics of a good unit test

- **Fast:** Một project có hàng ngìn unit tests là rất phổ biến. Unit tests có thể chạy với ít thời gian. Milliseconds.
- **Isolated:** Unit tests là standalone, có thể chạy riêng, mà không phụ thuộc vào bất kỳ yếu tố bên ngoài nào như file hoặc database.
- **Repeatable:** Running một unit test luôn trả về cùng một kết quả giống nhau, nếu bạn không thay đổi bấy kỳ thứ gì giữa những lần chạy.
- **Self-Checking:** Bài test có thể tự động xác định, nếu nó passed hoặc failed mà không cần có bất kỳ tác động nào từ con người.
- **Timely:** Viết một unit test có thể không tốn nhiều thời gian khi so sánh với code đã tested. Nếu bạn tốn nhiều thời gian cho testing khi so sánh với writing code, hãy thiết kế lại để test dễ dàng hơn

## Code coverage

## Let's speak the same language



## Reference

https://learn.microsoft.com/en-us/dotnet/core/testing/unit-testing-best-practices
