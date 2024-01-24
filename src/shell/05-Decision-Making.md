# Decision Making

Trong chapter này, chúng ta sẽ hiểu shell decision-making (quyết định) trong Unix. Khi bạn writting a shell script, có thể trong một tình huống bạn sẽ quyết định đi một trong 2 con đường. Khi đó bạn cần sử dụng câu lệnh điều kiện (conditional statements) cho phép chương trình của bạn quyết định thực hiện hành động đúng.

Unix shell hỗ trợ các câu lệnh điều kiện khi bạn thực hiện những hành động khác nhau trên những điều kiện khác nhau. Chúng ta sẽ hiểu 2 decision-making statements sau:

- The `if` ... `else` statement
- The `case` ... `esac` statement

## The `if` ... `else` statement

If else statement được sử dụng decision-making statements bất cứ lúc nào bạn chọn một option từ một tập hợp options.

Unix shell hỗ trợ các lệnh **if ... else** sau:

```shell
if ... fi
if ... else ... fi
if ... elif ... else ... fi
```

Hầu hết lệnh if được sử dụng để check các relational operators đã được trình bày ở chapter trước.

## The `case` ... `esac` statement

Bạn có thể sử dụng **if ... else** để thực hiện multiway branch. Tuy nhiên, đó không phải là hướng giải quyết tốt nhất, đặc biệt khi tất cả branchs đều phụ thuộc vào một single variable.

Unix shell hỗ trợ **case ... esac** statement, bạn có thể sử dụng trong tình huống bên trên, và nó sẽ mang nhiều hiểu quả hơn là việc lặp lại **if ... else** statements

```shell
case ... esac
```

**case ... esac** statement trong Unix shell rất giống với **switch ... case** statement chúng ta thường sử dụng trong các ngôn ngữ lập trình khác như **C**, **C++** và **PERL**, ...