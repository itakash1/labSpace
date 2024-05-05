//var:118

#include <iostream>
#include<cstdio>

using namespace std;

int systemOfEquations(int a, int b) {
	int result = 0;

	__asm {
		mov ecx, a		// eсx <-- a
		mov ebx, b		// ebx <-- b

		cmp ecx, ebx	// a ?= b
		je grp_a		// переход если a равно b * переход если равно JE
		jg grp_b		// переход если a больше b * переход если больше JG
		jl grp_c		// переход если a меньше b * переход если меньше JL

		grp_a :				// a = b
			imul ebx, 5		// b * 5
			mov eax, ebx	// eax <-- b * 5
			jmp go_out		// переместиться к выводу

		grp_b :				// a > b
			mov eax, ebx	// eax <-- b
			cdq				// eax = edx:eax
			sub ecx, 9		// a - 9
			cmp ecx, 9		// a ?= 9
			je error_zero	// if a = 9 --> error_zero
			idiv ecx		// b / a - 9
			jmp go_out		// переместиться к выводу

		grp_c :				// a < b
			imul ecx, ebx	// a * b
			imul ecx, 7		// a * b * 7
			sub ecx, 5		// a * b * 7 - 5
			mov eax, ecx	// eax <-- a * b * 7 - 5
			cdq				// eax = edx:eax
			mov ecx, a		//	ecx <-- a
			add ecx, ebx	// a + b
			cmp ecx, 0
			je error_zero
			idiv ecx		// (a * b * 7 - 5)/(a + b)
			jmp go_out		// переместиться к выводу

			error_zero :

	go_out:
		mov result, eax	// result <-- eax
	}
	return result;
}

int main() {
	setlocale(LC_ALL, "Russian");

	int a, b;

	do
	{
		cout << "Введите a != 0: ";
		cin >> a;
	} while (a == 0);

	do
	{
		cout << "Введите b != 0: ";
		cin >> b;
	} while (b == 0);


	printf("X = %d\n", systemOfEquations(a, b));

	return 0;
}
