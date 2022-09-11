#!/bin/bash

if [[ $1 = -h ]]
then
echo Эта утилита удлиняет файлы с указанным суфиксом до заданной длины, путем добавления к нему другого файла
echo Ключи:
echo -h - выводит мануал по данной утилите
echo -i - выводит название изменяемого файла, его начальный размер, его конечный размер и количество итераций
echo -v - выводит версию утилиты
echo -y - ключ используется в конце, запрашивает разренешие на изменение файла
elif [[ $1 = -v ]]
then
echo версия: 1.1
elif [[ $1 = -i ]]
then
a0=$2 
ls *$a0* | unexpand >| ch.odt
p=`ls *$a0* | wc -w`
k=0
for ((i = 1; i<= $p; i++))
do
a0=`cat ch.odt| head -$i | tail -1`
a=`du -b $a0`
a=`echo $a | sed 's/\([^ ]\) .*/\1/'`
echo $a0
echo было - $a
b=$3
c=$4
if [[ $a -lt $b ]]
then
while [ $a -lt $b ] 
    do
    a1=`cat $c >> $a0`
    a2=`du -b $a0`
    a=`echo $a2 | sed 's/\([^ ]\) .*/\1/'`
    let k=$k+1
    done
    a0=`du -b $a0`
    d=`echo $a0 | sed 's/\([^ ]\) .*/\1/'`
    echo стало - $d
    echo количество итераций - $k
    k=0
    fi
    done 
 else
    a0=$1
    ls *$a0* | unexpand >| ch.odt
    p=`ls *$a0* | wc -w`
    for ((i = 1; i<= $p; i++))
    do
    a0=`cat ch.odt| head -$i | tail -1`
    a=`du -b $a0`
    a=`echo $a | sed 's/\([^ ]\) .*/\1/'`
    b=$2
    c=$3
    if [[ $4 = -y ]]
    then
    echo "Разрешить изменить этот файл $a0 [Да(y),Нет(n)]"
    read l
    fi
    if [[ $l = y ]]
    then 
    if [[ $a -lt $b ]]
    then
    while [ $a -lt $b ]
    do
    a1=`cat $c >> $a0`
    a2=`du -b $a0`
    a=`echo $a2 | sed 's/\([^ ]\) .*/\1/'`
    done
    fi
    fi
    done
    fi   
