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

Thật không may, khi `mock` thường được nói đến khi testing. Các following points định nghĩa hầu hết khi writing unit test là kiểu `faker`:

*Fake* - là một thuật ngữ chung dùng để trình bày a `stub` hoặc `mock` object. `stub` hay `mock` sẽ phụ thuộc vào context khi bạn sử dụng nó. Nói cách khác, `fake` có thể là `stub` hoặc `mock`.

*Mock* - Một `mock` object là một `fake` object được trong hệ thống, xác định một unit test có *passed* hoặc *failed*. Mock là khởi đầu (starts out) bằng một Fake cho đến khi nó asserted againts.

*Stub* - Một `stub` là controllable replacement của các dependency tồn tại trong hệ thống. Bởi vì sử dụng một `stub`, bạn có thể test code không cần phân tách với dependency directly. Bởi mặc định,  `stub` là khởi đầu (start out) của `fake`.

```dotnet
var mockOrder = new MockOrder();
var purchase = new Purchase(mockOrder);

purchase.ValidateOrders();

Assert.True(purchase.CanBeShipped);
```

Ví dụ bên trên một `stub` có thể được xem như một `mock`. Trong trường hợp này, nó là `stub`. Bạn có thể passing trong Order, có thể hiểu cho phép instantiate Purchase. Tên MockOrder rất dễ gây nhầm lẫn (misleading) vởi vì order không phải là `mock`.

Tốt hơn bạn nên viết:

```dotnet
var stubOrder = new FakeOrder();
var purchase = new Purchase(stubOrder);

purchase.ValidateOrders();

Assert.True(purchase.CanBeShipped);
```

Đổi tên class MockOrder thành FakeOrder, bạn có một class chung hơn (more generic). Class có thể sử dụng như `mock` hoặc `stub`, sẽ tốt hơn dành cho các test case. Trong ví dụ bên trên, FakeOrder được sử dụng là `stub`. Bạn không được sử dụng FakeOrder trong bất kỳ shape hoặc form trong suốt quá trình assert. FakeOrder được passed vào trong Purchase class là một yêu cầu an toàn cho contructor.

Muốn sử dụng `mock`, bạn có thể viết như sau:

```dotnet
var mockOrder = new FakeOrder();
var purchase = new Purchase(mockOrder);

purchase.ValidateOrders();

Assert.True(mockOrder.Validated);

```

Để nhớ về sự khác nhau giửa `mock` với `stub`, đó là `mock` giống như `stub`, nhưng bạn phải assert against the mock object, bạn không cần assert against một `stub`. 

## Best practices

Một số thứ gần như rất quan trọng cho best practices khi viết unit tests.

### Avoid infrastructure dependencies

Đừng thử đưa dependencies vào infrastructure khi writting unit tests. Dependencies làm test chậm và dễ vở, và có thể dành riêng (reserved) nó cho phần integration test. Bạn phải tránh dependenceies trong ứng dụng của bạn bằng cách tìm hiểu [Explicit Dependencies Principle](https://deviq.com/explicit-dependencies-principle) hoặc sử dụng [Dependency Injection](https://learn.microsoft.com/en-us/dotnet/core/extensions/dependency-injection). Bạn có thể giữ unit test trong một project riêng biệt. Với cách tiếp cận này, đảm bảo project unit test của bạn sẽ không references đến dependencies trên infrastructure packages.

### Name your tests

Tên unit test của bạn phải chứa three parts:

- Tên của phương thức tested
- Kịch bản mà nó tested
- Hành động mong muốn (expected behavior) khi kịch bản được gọi

#### Why?

Đặt tên theo một tiêu chuẩn là rất quan trọng bởi vì chúng ta sẽ dẽ chú ý hơn khi test. Test nhiều hơn thì sẽ làm cho code của bạn bạn việc chắn chắn hơn, và các bài test cũng là một nguồn cung cấp documentation. Khi nhìn vào toàn bộ unit test, bạn có thể suy ra (infer) nội dung code của bạn, mà không cần phải đọc từng dòng code. Thêm nữa, khi test chạy lỗi, bạn có thể thấy chính xác kịch bản không thể lường trước được khi viết code.

#### Bad

```dotnet
[Fact]
public void Test_Single()
{
    var stringCalculator = new StringCalculator();

    var actual = stringCalculator.Add("0");

    Assert.Equal(0, actual);
}
```

#### Better

```dotnet
[Fact]
public void Add_SingleNumber_ReturnsSameNumber()
{
    var stringCalculator = new StringCalculator();

    var actual = stringCalculator.Add("0");

    Assert.Equal(0, actual);
}
```

### Arranging your test

`Arrange`, `Act`, `Assert` là một pattern khi viết unit testing. Đúng như tên gọi, nó bao gồm 3 hành động chính:

- `Arrange` là sắp xếp objects của bạn, create and set cần đưa chúng lên cùng nó rất cần thiết.
- `Act` là hành động một object
- `Assert` là kết quả bạn mong muốn

#### Why?

- Chia thành từng phần rõ ràng sẽ giúp việc test từng bước từ *arrange* đến *assert*
- Code sẽ ít lẫn lộn nhất, hoặc gộp giữa *act* và *assert*.

Khả năng đọc được là rất quan trọng khi bạn viết một bài test. Việc chia tách theo mỗi hành động (actions) bên trong bài test sẽ làm code rõ ràng nổi bật hơn (clearly hightlight) và nó phụ thuộc vào yêu cầu từ code của bạn, và diều bạn khẳng định (assert). Chắc chắc kết hợp một số bước sẽ làm giảm kích thước bài test của bạn, nhưng mục đích cơ bản nhất của bài test là khả năng chắc chắn phải đọc được.

### Bad

```dotnet
[Fact]
public void Add_EmptyString_ReturnsZero()
{
    // Arrange
    var stringCalculator = new StringCalculator();

    // Assert
    Assert.Equal(0, stringCalculator.Add(""));
}
```

```dotnet
[Fact]
public void Add_EmptyString_ReturnsZero()
{
    // Arrange
    var stringCalculator = new StringCalculator();

    // Act
    var actual = stringCalculator.Add("");

    // Assert
    Assert.Equal(0, actual);
}
```

### Write minimally passing tests

Input được sử dụng trong unit test phải đơn giản nhất trong việc xác nhận (verify) hành động hiện tại bạn đang testing.

#### Why?

- Những bài test này sẽ được tái sử dụng nhiều lần trong tương lại trong trường hợp bạn thay đổi codebase
- Gần nhất với thực hiện hành động testing.

Những bài test gồm nhiều thông tin yêu cầu hơn để pass, bài test sẽ có rủi ro về lỗi khi test và có thể làm cho ý định test của bạn ít rõ ràng hơn. Khi viết bài tests, bạn có thể muốn tập trung vào hành vi (behavior). Setting extra properties trên models hoặc sử dụng giá trị none-zero khi không yêu cầu, chỉ làm mất tập trung khi bạn thử chứng minh bài test.

#### Bad

```dotnet
[Fact]
public void Add_SingleNumber_ReturnsSameNumber()
{
    var stringCalculator = new StringCalculator();

    var actual = stringCalculator.Add("42");

    Assert.Equal(42, actual);
}
```

#### Better

```dotnet
[Fact]
public void Add_SingleNumber_ReturnsSameNumber()
{
    var stringCalculator = new StringCalculator();

    var actual = stringCalculator.Add("0");

    Assert.Equal(0, actual);
}
```

### Avoid magic strings

Tên biến trong unit test là rất quan trọng, không có gì quan trọng hơn tên biến trong production code. Unit test không chứa **magic strings**

#### Why?



### Avoid logic in tests

### Prefer helper methods to setup and teardown

### Avoid multiple acts

### Validate private method by unit testing public method

### Stub statuc references

## Reference

https://learn.microsoft.com/en-us/dotnet/core/testing/unit-testing-best-practices
