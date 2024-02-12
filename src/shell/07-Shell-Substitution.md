# Shell Substitution

## What is Substitution?

Shell sẽ thực hiện việc thay đổi mã code `substitution` khi biểu thức bắt gặp một hoặc nhiều ký tự đặc biệt.

| Sr.No | Escap & Description              |
| ----- | -------------------------------- |
| 1     | `\\` (backslash)                 |
| 2     | `\a` (alert)                     |
| 3     | `\b` (backspace)                 |
| 4     | `\c` (suppress trailing newline) |
| 5     | `\f` (form feed)                 |
| 6     | `\n` (new line)                  |
| 7     | `\r` (carriage return)           |
| 8     | `\t` (horizontal tab)            |
| 9     | `\v` (vertical tab)              |

Bạn có thể thêm `-E` options để disable trình phiên dịch (interpretation) của **backslash escapes (default)**.

Bạn có thể thêm `-n` options để disable thêm mới một dòng.

## Command Substitution

## Syntax

`command`

## Example

```shell
#!/bin/sh

DATE=`date`
echo "Date is $DATE"

USERS=`who | wc -l`
echo "Logged in user are $USERS"

UP=`date ; uptime`
echo "Uptime is $UP"
```

## Variable Substitution

Variable substitution cho phép shell programmer thao tác với giá trị của biến.

| Sr.No | Form & Description                                                                                                          |
| ----- | --------------------------------------------------------------------------------------------------------------------------- |
| 1     | `${var}` Thay thế cho giá trị của **var**                                                                                   |
| 2     | `${var:-word}` Nếu **var** là null hoặc unset, **word** sẽ thay thế cho **var**. Giá trị của **var** sẽ không thay đổi      |
| 3     | `${var:=word}` Nếu **var** là null hoặc unset, **var** sẽ được set giá trị từ **word**                                      |
| 4     | `${var:?message}` Nếu **var** là null hoặc unset, message khi print là _standard erorr_. Biến này sẽ check có set correctly |
| 5     | `${var:+word}` Nếu **var** được set, **word** sẽ thay thế cho **var**. Giá trị của **var** không thay đổi                   |

## Example

```shell
#!/bin/sh

echo ${var:-"Variable is not set"}
echo "1 - Value of var is ${var}"

echo ${var:="Variable is not set"}
echo "2 - Value of var is ${var}"

unset var
echo ${var:+"This is default value"}
echo "3 - Value of var is $var"

var="Prefix"
echo ${var:+"This is default value"}
echo "4 - Value of var is $var"

echo ${var:?"Print this message"}
echo "5 - Value of var is ${var}"
```

## Reference

https://www.tutorialspoint.com/unix/unix-shell-substitutions.htm
