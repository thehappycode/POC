#!/bin/sh

val=`expr 2 + 2`
echo "Total value: $val"


# ARITHMETIC OPERATORS

A=10
B=20

# ADDITION
ADD=`expr $A + $B`
echo "A + B = $ADD"

# SUBTRACTION
SUB=`expr $A - $B`
echo "A - B = $SUB"

# MULTIPLICATION
MUL=`expr $A \* $B`
echo "A * B = $MUL"

# DIVISION
DIV=`expr $A / $B`
echo "A / B = $DIV"

DIV=`expr $B / $A`
echo "B / A = $DIV"

# MODULUS
MOD=`expr $A % $B`
echo "A % B = $MOD"

MOD=`expr $B % $A`
echo "B % A = $MOD"

# ASSIGNMENT
ASS=$A
echo "ASS = A = $ASS"

# EQUALITY
# EQU=[ $A == $B ]
echo "A == B = $[$A == $B ]"

# NOT EQUALITY
echo "A != B = $[ $A != $B ]"



# RELATIONAL OPERATORS

# A="10"
# B="20"

#EQ=[ $A -eq $B ] # KHONG ASSIGN DUOC
#echo "$[ $A -eq $B ]"



# BOOLEAN OPERATORS
echo "!false = $[!false]"
echo "[ A -lt 20 -o B -gt 100 ] = $[ $A -lt 20 -o $B -gt 100 ]"
echo "[ $A -lt 20 -a $B -gt 100 ] = $[ $A -lt 20 -a $B -gt 100 ]"

