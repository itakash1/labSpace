#include <iostream>

int* array_work_asm(int* arr, int _size) {
	if (_size == 0 || _size == 1) return arr;

	int* result = new int[_size - 1];
	__asm
	{
		xor esi, esi; // i = 0
		mov ebx, arr; // кладёт адрес начала массива в ebx
		mov ecx, _size; // ecx = _size
		dec ecx; // ecx = _size - 1
		mov edi, result; // кладёт адрес начала результата в edi

	loop_start:
		mov eax, [ebx + esi * 4]; // eax = arr[i]
		add eax, [ebx + esi * 4 + 4]; // eax = arr[i] + arr[i + 1]
		mov [edi + esi * 4], eax; // result[i] = eax
		inc esi; // i++
		dec ecx; // ecx = ecx - 1
		jnz loop_start; // если ecx != 0, то переход в loop_start
	end:
		mov result, edi;
	}
	return result;
}

int* array_work(int* arr, int size) {
	if (size == 0 || size == 1) return arr;

	int* result = new int[size - 1];
	for (int i = 0; i < size - 1; ++i) {
		result[i] = arr[i] + arr[i + 1];
	}
	return result;
}

int main()
{
	setlocale(LC_ALL, "Russian");
	std::cout << "Лабораторная работа 3. Выполнил студент группы 6104-020302D Маликов Николай.\n";
	std::cout << "Вариант 118. В одномерном массиве A={a[i]} целых чисел вычислить сумму между соседними элементам {a[i]=a[i]+a[i+1]}.\n\n";

	int size;
	std::cout << "Введите размер массива: ";
	std::cin >> size;
	int* arr = new int[size];
	int* arrCopy = new int[size];

	for (int i = 0; i < size; ++i) {
		std::cout << "Введите элемент массива [" << i << "]: ";
		std::cin >> arr[i];
		arrCopy[i] = arr[i];
	}

	arr = array_work_asm(arr, size);
	arrCopy = array_work(arrCopy, size);

	if (size > 1)
		size -= 1;

	std::cout << "Результат в Ассемблере: {";
	for (int i = 0; i < size; ++i) {
		std::cout << " " << arr[i];
	}
	std::cout << " }" << std::endl;

	std::cout << "Результат в C++: {";
	for (int i = 0; i < size; ++i) {
		std::cout << " " << arrCopy[i];
	}
	std::cout << " }" << std::endl;

	delete[] arr;
	delete[] arrCopy;

	system("pause");
}