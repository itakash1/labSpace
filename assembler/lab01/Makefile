run: build
	./main

build: ./main.cpp ./calculate.asm ./calculate.h
	nasm -felf64 ./calculate.asm -o calculate.o
	g++ -c ./main.cpp -o main.o
	g++ ./main.o ./calculate.o -o main