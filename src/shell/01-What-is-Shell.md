# Shell

Origin Unix shell được viết vào giữa thập niên 1970 bởi Stephen R.Bourne tại phòng thí nghiệm AT&T Bell Labs - New Jersey.

Bourne shell thường được cài đặt ở /bin/sh trên hầu hết các phiên bản của Unix.

Shell cung cấp một interface trên hệ thống Unix. Bạn nhận input và chương trình sẽ thực thi trên input đó. Khi chương trình thực thi xong, nó sẽ hiển thị kết quả output.

## Shell Prompt

Prompt, `$` được gọi là **command prompt**, được tạo (issued) từ shell.
Shell đọc (read) input sau khi press **Enter**

```shell
$date
Sat Dec 30 17:54:40 +07 2023
```

## Shell Types

Trong Unix, có 2 chuyên ngành (major types) của shell
- **Bourne shell**: Ký hiệu mặc định prompt của Bourne-type shell là `$`. Gồm có:
    - Bourne shell (sh)
    - Korn shell (ksh)
    - Bourne Again shell (bash)
    - POSIX shell (sh)

- **C shell**: Ký hiệu mặc định prompt của C-type shell là `%`. Gồm có:
    - C shell (csh)
    - TENEX/TOPS C shell (tcsh)

## Shell Scripts

Shell scripts cơ bản là một danh sách các commands và được thực thi lần lượt. Trong shell script chúng ta có thể comments bằng `#`.
