# Shell Bacis Operators

Mỗi loại shell sẽ được hỗ trợ nhiều operators khác nhau. Trong bài học hôm nay chúng ta sẽ trình bày chi tiết về Bourne Shell.

Chúng ta sẽ chỉ trình bày các operators sau:

```md
- Arithmetic (số học) Operators
- Relational Operators
- Boolean Operators
- String Operators
- File Test Operators
```

Trước tiên (originally), Bourne shell không thể thực hiện arithmetic operatos đơn giản trên bất kỳ máy tính nào, nhưng chúng có thể sử dụng các extenal prográm, như `awk` or `expr`

```shell
#!/bin/sh

val=`expr 2 + 2`
echo "Total value: $val"
```

Ở đây chúng ta sẽ có một số điểm cần lưu ý

```md
- Bắt buộc phải có khoảng cách giữa 2 operators và expressions. Ví dụ, 2 + 2 là đúng, 2+2 là sai.
- Complete expression phải nằm giữa ``, gọi là backtick.
```

## Arithmetic Operators

Sau đây là danh sách các arithmetic operators được hỗ trợ bởi Bourne Shell.
Giả sử a = 10, b = 20.

| Operator | Description    | Example                   |
| -------- | -------------- | ------------------------- |
| `+`      | Addition       | `expr $a + $b` = 30       |
| `-`      | Subtraction    | `expr $a - $b` = -10      |
| `*`      | Multiplication | `expr $a \* $b` = 200     |
| `/`      | Division       | `expr $b / $a` = 2        |
| `%`      | Modulus        | `expr $b % $a` = 0        |
| `=`      | Assignment     | a = $b                    |
| `==`     | Equality       | [ $a == $b ] return false |
| `!=`     | Not Equality   | [ $a != $b ] return true  |

## Relational Operators

Bourne Shell supports các relational operators dành cho các giá trị là numberic.
Giả sử a = 10, b = 20.

| Operator | Description                | Example                    |
| -------- | -------------------------- | -------------------------- |
| `-eq`    | Kiểm tra bằng              | [ $a -eq $b ] return false |
| `-ne`    | Phủ định của `-eq`         | [ $a -ne $b ] return true  |
| `-gt`    | Kiểm tra lớn hơn           | [ $a -gt $b ] return false |
| `-lt`    | Phủ định của `-gt`         | [ $a -lt $b ] return true  |
| `-ge`    | Kiểm tra lớn hơn hoặc bằng | [ $a -ge $b ] return false |
| `-le`    | Phủ định của `-le`         | [ $a -le $b ] return true  |

## Boolean Operators

Bourne Shell supported các boolean operators sau:
Giả sử a = 10, b = 20.

| Operator | Description | Example |
| -------- | ----------- | ------- |

ç
| `-o` | Toán tử hoặc (**OR**) | [ $a -lt 20 -o $b -gt 100 ] return true |
| `!` | Toán tử phủ định | [ !false ] return true |

## String Operators

Bourne Shell supported các string operators sau:
Giả sử a = "abc", b = egf

| Operator | Description                      | Example                 |
| -------- | -------------------------------- | ----------------------- |
| `=`      | Kiểm tra 2 bằng                  | [ $a = $b] return false |
| `!=`     | Phủ định của `=`                 | [ $a != $b] return true |
| `-z`     | Kiểm tra nếu length = 0 trả true | [ -z $a] return false   |
| `-n`     | Phủ định của `-z`                | [ -z $a] return true    |
| `str`    | Kiểm tra empty string            | [ -z $a] return true    |

## File Test Operators

Chúng ta có nhiều operators có thể sử dụng để associated một Unix file.
Giả sử chúng ta có một biến file, và tồn tại 1 file có tên là "test" kích thước là 100 bytes, và file có quyền **read**, **write** và **execute**.

| Operator   | Description                                                                              | Example                   |
| ---------- | ---------------------------------------------------------------------------------------- | ------------------------- |
| `-b $file` | Kiểm tra nếu file là một _block special file_                                            | [ -b $file ] return false |
| `-c $file` | Kiểm tra nếu file là một _character special file_                                        | [ -c $file ] return false |
| `-d $file` | Kiểm tra nếu file là một _directory_                                                     | [ -d $file ] return false |
| `-f $file` | Kiểm tra nếu file là một file bình thường, không phải là _directory_ hoặc _special file_ | [ -f $file ] return true  |
| `-g $file` | Kiểm tra nếu file có Set Group ID (SGID) bit set                                         | [ -g $file ] return false |
| `-k $file` | Kiểm tra nếu file có sticky bit set                                                      | [ -k $file ] return false |
| `-p $file` | Kiểm tra nếu file có named pipe                                                          | [ -p $file ] return false |
| `-t $file` | Kiểm tra nếu file được open and associated with a terminal                               | [ -t $file ] return false |
| `-u $file` | Kiểm tra nếu file có Set User ID (SUID) bit set                                          | [ -u $file ] return false |
| `-r $file` | Kiểm tra nếu file được phép đọc (readable)                                               | [ -r $file ] return true  |
| `-w $file` | Kiểm tra nếu file được phép ghi (writable)                                               | [ -w $file ] return true  |
| `-x $file` | Kiểm tra nếu file được phép thực thi (executable)                                        | [ -x $file ] return true  |
| `-s $file` | Kiểm tra nếu file có size greater than 0                                                 | [ -x $file ] return true  |
| `-e $file` | Kiểm tra nếu file có tồn tại                                                             | [ -x $file ] return true  |
