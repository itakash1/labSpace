#include <iostream>
#include<cstdio>
#include <vector>
#include "u.h"


using namespace std;


//var:118 |
//В одномерном массиве A = { a[i] } целых чисел вычислить сумму между соседними элементам{ a[i] += a[i] + a[i + 1] }.


int sum_adjaсent(vector<int> vect, int len, int indexArray) {
	int result = 0;
	__asm {
		mov  ebx, vect  // указывает на начало массива
		mov ecx, len    // размер массива
		mov edi, indexArray // выбранный индекс

		mov  eax, [ebx + (edi + 0) * 4]

		cmp edi, 0
		je case_1

		cmp edi, ecx - 1
		je case_2

		add eax, [ebx + (edi - 1) * 4]
		add eax, [ebx + (edi + 1) * 4]
		jmp go_out

		case_1 :
		add eax, [ebx + (edi + 1) * 4]
			jmp go_out

			case_2 :
		add eax, [ebx + (edi - 1) * 4]
			jmp go_out

			go_out :
		mov result, eax
	}
	return result;
}


int calculate_cpp(vector<int> vec, int size, int indexArray)
{
	int result = 0;
	if (indexArray == 0) {
		result = vec[indexArray] + vec[indexArray + 1];
	}
	else if (indexArray == vec.size() - 1) {
		result = vec[indexArray] + vec[indexArray - 1];
	}
	else {
		result = vec[indexArray] + vec[indexArray + 1] + vec[indexArray - 1];
	}
	return result;
}

int main() {
	setlocale(LC_ALL, "Russian");
	int n, d;
	do {
		cout << "Введите размер массива x>0: ";
		cin >> n;
	} while (n <= 0);

	vector<int> vec(n);

	cout << "Введите " << n << " элементов: ";
	for (int i = 0; i < n; ++i) {
		cin >> vec[i];
	}
	cout << "Ваш массив:" << endl;
	for (int i = 0; i < vec.size(); i++)
	{
		cout << vec[i] << " ";
	}
	cout << ' ' << endl;

	do {
		cout << "Введите индекс элемента массива, рядом с которым хотите посчитать значения: ";
		cin >> d;
	} while (d < 0);
	int indexArray = d - 1;

	cout << "[c++] В массиве A={a[i]} целых чисел сумма между соседними элементами: " << calculate_cpp(vec, vec.size(), indexArray) << endl;
	cout << "[ass] В массиве A={a[i]} целых чисел сумма между соседними элементами: " << sum_adjacent(vec, vec.size(), indexArray) << endl;
}