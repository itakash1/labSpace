#include <iostream>
#include <locale>
#include "./calculate.h"

using namespace std;

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


	printf("X = %d\n", calculate(a, b));

	return 0;
}