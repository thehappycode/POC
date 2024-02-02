#!/bin/sh

echo ""
echo ""
echo "The while loop"

A=0

while [ $A -lt 10 ]
do
   echo $A
   A=`expr $A + 1`
done

echo ""
echo ""
echo "The for loop"


for B in 0 1 2 3 4 5 6 7 8 9
do
   echo $B
done

echo ""
echo ""
echo "The until loop"

C=0

until [ ! $C -lt 10 ]
do
   echo $C
   C=`expr $C + 1`
done

echo ""
echo ""
D=0
until [ $D -eq 1 ]
do
   echo "0 equal 1"
   D=`expr $D + 1`
done

echo ""
echo ""
echo "The select loop"

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

echo ""
echo ""
echo "Nesting loops"

a=0
while [ "$a" -lt 10 ]    # this is loop1
do
   b="$a"
   while [ "$b" -ge 0 ]  # this is loop2
   do
      echo -n "$b "
      b=`expr $b - 1`
   done
   echo
   a=`expr $a + 1`
done
