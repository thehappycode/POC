# Shell Quoing Mechanisms

Trong phần này, chúng ta sẽ thảo luận chi tiết về Shell quoting mechainsms. Chúng ta sẽ bắt đầu thảo luận về metacharacters.

## The Metacharacters

Unix Shell cung cấp nhiều metacharacters, chúng ta sẽ hiểu khi cần sử dụng chúng trong bất kỳ shell script và chú ý termination của một từ không dùng quoted.

Ví dụ, `?` matches với single character trong danh sách files thư mục, và `*` matches nhiều hơn one character. Ở đây chúng ta sẽ có một danh sách hầu hết các ký tự đặc biệt (được gọi là metacharacters)

```shell
* ? [ ] ' " \ $ ; & ( ) | ^ < > new-line space tab
```

|Sr.No|Quoting & Description|
|-|-|
|1|**Single quote** <br> Tất cả các ký tự đặt biệt ở giữa quotes sẽ mất ý nghĩa|
|2|**Double quote** <br> Hầu hết các ký tự đặt biệt sẽ mất hết ý nghĩa của chúng ngoại từ <ul><li>$<li>`</li><li>\\\$</li><li>\\'</li><li>\\"</li><li>\\\\</li> </ul>|
|3|**Backslash** <br> Bất kỳ ký tứ tự nào phiếu sau backslash sẽ lập tức mất đi ý nghĩa|
|4|**Back quote** <br> Bất kỳ ký tự nào nằm giữa back quotes đều được xem là một command và sẽ được thực hiện|

## The Single Quotes

Một lệnh echo có thể chứa nhiều ký tự đặc biết

```shell
echo <-$1500.**>; (update?) [y|n]
```

Thêm một backslash `\` trước mỗi ký tử đặc biệt là rất chán và làm cho dòng càng khó đọc

```shell
echo \<-\$1500.\*\*\>\; \(update\?\) \[y\|n\]
```

Có một cách dễ dàng hơn là dùng một backslash cho một nhóm các từ đặt biết

```shell
echo '<-$1500.**>; (update?) [y|n]'
```

Nếu muốn hiển thị một single quote trong chuổi khi output, bạn có thể không cần thêm chuổi trong  single quotes, thay vì thế bạn có thể sử dụng một backslash (`\`) như sau:

```shell
echo 'It\'s Shell Programming
```

## Double Quotes

Hãy thực hiện lệnh shell script sử dụng một single quote

```shell
VAR=ZARA
echo '$VAR owes <-$1500.**>; [ as of (`date +%m/%d`) ]'
```

Nó sẽ không hiển thị kết quả. Một single quotes đã chặn variable substitution. Nếu bạn muốn substitution variable values làm việc như mong dợi, khi đó bạn cần thêm vào double quotes vào trong lệnh như sau:

```shell
VAR=ZARA
echo "$VAR owes <-\$1500.**>; [ as of (`date +%m/%d`) ]"
```

Double qoutes sẽ hiểu ý nghĩa của các ký tự đặc biệt sau:

|Sr.No|Description|
|-|-|
|1|**$** dành cho parameter substitution|
|2|**Backquotes** dành cho command substitution|
|3|**\\$** cho phép sử dụng ký hiệu dollar|
|4|**\\`** cho phép dùng ký tự backqoutes|
|5|**\\"** cho phép nhúng double quotes|
|6|**\\\\** cho phép nhúng backslashes|
|7|Tất cả các ký tự **\\** đều không được thực hiện|


## The Backquotes

Thêm bất kỳ shell command ở giữa **backquotes** đều được thực thị lênh.

### Syntax

```shell
var=`command`
```

### Example

```shell
DATE=`date`
echo "Current Date: ${DATE}"
```

## Reference

https://www.tutorialspoint.com/unix/unix-quoting-mechanisms.htm

