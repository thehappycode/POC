# Shell Loop

Trong phần này, chúng ta sẽ thảo luận về shell loops trong Unix. Một loop và một tool đầy sức mạnh trong ngôn ngữ lập trình, nó cho phép bạn execute các lệnh được lặp lại trong một set. Trong phần này, chúng ta sẽ có các loại loops dành cho các shell programmers

## The while loop

### Syntax

```shell
while condition
do
    // TODO
done
```
### Example

```shell
#!/bin/sh

A=0
while [ $A -lt 10 ]
do
    echo $A
    A=`expr $A + 1`
done
```

## The for loop

### Syntax

```shell
for var in word1 word2 ... wordN
do
    // TODO
done
```

### Example

```shell
#!/bin/sh

for I in 0 1 2 3 4 5 6 7 8 9
do
    echo $I
done
```

## The until loop

`until` loop có syntax rất giống với `while`, nhưng điều kiện để thực hiện vòng lặp của `until` thì phủ định với điều kiện lặp của `while`. Hay hiểu cách khác `until` sẽ thực hiện vòng lặp với điều kiện `false`

### Syntax

```shell
until condition
do
    // TODO
done
```

### Example

```shell
#!/bin/sh

A=0
until [ ! $A -lt 10 ]
do
    echo $A
    A=`expr $A + 1`
done
```

## The select loop

`select` loop cung cấp đến người dùng lựa chon theo chỉ số trong danh sách. Nó rất tiện dụng cho việc bạn hỏi người dùng cần lựa chon 1 hoặc nhiều item từ dánh sách lựa chọn.

`select` được giới thiệu trong `ksh` có thể được adapted vào trong `bash`. Nhưng nó không có trong `sh`.

### Syntax

```shell
select var in word1 word2 ... wordN
do
    // TODO
done
```

### Example

```shell
#!/bin/ksh

select DRINK in tea cofee water juice appe all none
do
   case $DRINK in
      tea|cofee|water|all) 
         echo "Go to canteen"
         ;;
      juice|appe)
         echo "Available at home"
      ;;
      none) 
         break 
      ;;
      *) echo "ERROR: Invalid selection" 
      ;;
   esac
done
```

## Reference
https://www.tutorialspoint.com/unix/unix-shell-loops.htm