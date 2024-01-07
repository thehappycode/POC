#!/bin/sh

# ARRAY

NAME[0]="tamnt0"
NAME[1]="tamnt1"
NAME[2]="tamnt2"
NAME[3]="tamnt3"
NAME[4]="tamnt4"

# TRUY CAP THEO INDEX
echo "First Index: ${NAME[0]}"
echo "Second Index: ${NAME[1]}"
echo "Third Index: ${NAME[2]}"

# TRUY CAP HET TAT CA CAC PHAN TU

echo "Accessing all index with [*]: ${NAME[*]}"
echo "Accessing all index with [@]: ${NAME[@]}"