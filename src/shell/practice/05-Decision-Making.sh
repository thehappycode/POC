#!/bin/sh

# The if ... else statement

echo "if ... else statement"
POINT10=2

if [ $POINT10 -ge 8 ]
then
    echo "Loại giỏi"

elif [ $POINT10 -lt 8 -a $POINT10 -ge 6 ]
then
    echo "Loại khá"

elif [ $POINT10 -lt 6 -a $POINT10 -ge 5 ]
then
    echo "Loại trung bình"

elif [ $POINT10 -lt 5 -a $POINT10 -ge 3 ]
then
    echo "Loại yếu"

else
    echo "Loại kém"
fi

# The case ... esac statement

echo "case ... esac statement"
POINT4="B"

case $POINT4 in
    "A")
        echo "A tương ứng 4"
        ;;
    "B+")
        echo "B+ tương ứng với 3.5"
        ;;
    "B")
        echo "B tương ứng với 3.2"
        ;;
    "C+")
        echo "C+ tương ứng với 2.5"
        ;;
    "C")
        echo "C tương ứng với 2"
        ;;
    "D+")
        echo "D+ tương ứng với 1.5"
        ;;
    "D")
        echo "D tương ứng với 1"
        ;;
    "F")
        echo "tương ứng với 0"
esac