# Variables

Variable (Biến) là một chuổi ký tự (character string) được gán (assign) một giá trị. Giá trị được assign có thể là number, text, filename, hoặc bất cứ kiểu dữ liệu nào khác (type of data).

Variable không gì hơn là một điểm (point) trỏ đến dữ dữ liệu thật. Shell cho phép bạn create, assign, delete variable.

## Variable Names

Tên biến có thể chứa bất kỳ ký tự nào a-z, A-Z, 0-9 và underscore (_).
Quy ước (by convention) trong shell khi đặt tên biến là **UPPERCASE**

```shell
VAR_1
VAR_2
```

## Defining Variables

```shell
variable_name = variable_value 
```

## Accessing Values

Sử dụng tiền tố `$` để try cập giá trị biến dược lưu trữ.

## Read-only Variables (constant)

Shell sẽ đánh dấu biến chỉ được phép đọc (mark read-only). Sau khi biến được mark read-only thì giá trị sẽ không thể thay đổi.
Sử dụng bằng cách thêm tiền tố `readonly`trước biến cần mark read only.

```shell
variable_name = variable_value
readonly variable_name
```

## Unsetting Variables

Unsetting hoặc delete một biến, shell sẽ xóa biến từ danh sách biến được đánh dấu (track). Sau khi unset biến, bạn sẽ không thể truy cập giá trị được lưu trữ in biến đó nữa.

```shell
variable_name = variable_value
unset variable_name
```

Bản không thể `unset` biến được đánh dấu `readonly`.

## Variable Types

Khi shell chạy sẽ có các kiểu biến sau:

- **Local Variables**: là biến được sử dụng trong current instance của shell. Nó không có khi chương trình khởi động shell.
- **Environment Variables**: là biến có trong bất kỳ quá trình xử lý (child process) của shell.
- **Shell Variables**: là biến đặc biệt được set trong shell và được yêu cầu bởi shell trong thực thi các chức năng. Một số là environment variables và một số khác là local variables.