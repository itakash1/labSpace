#include <iostream>
#include <cmath>

double cot(double x) {
	return 1 / tan(x);
}

double count(double a, double b) {
	bool error = false;
	double result;
	const double c = 118.0;
	int intPart;
	__asm
	{
		fld b; // put b in st(0)
		fisttp intPart; // put int(b) in intPart
		fld b; // put b in st(0)
		fild intPart; // put intPart in st(0)
		fsub; // st(0) = b - int(b) (проверка на целость числа)
		fldz; // put 0 in st(0)
		fucomip st(0), st(1); // compare st(0) and st(1) with EFLAGS changing
		je _error; // if st(0) == st(1) goto _error (если b - целое число)
		
		fstp st(0); // remove trash from st(0) after compare


		fld c; // put 118.0 in st(0)
		fldpi; // put pi in st(0)
		fmul; // st(0) = 118.0 * pi
		fld b; // put b in st(0)
		fsin; // st(0) = sin(b)
		fmul; // st(0) = 118.0 * pi * sin(b)

		fld a; // put a in st(0)
		fcos; // st(0) = cos(a)
		fsub; // st(0) = 118.0 * pi * sin(b) - cos(a)

		fld b; // put b in st(0)
		fptan; // st(0) = 1 | st(1) = tan(b)
		fstp st(0); // remove trash 1 from st(0)
		fsub; // st(0) = 118.0 * pi * sin(b) - cos(a) - tan(b)

		fldpi; // put pi in st(0)
		fld b; // put b in st(0)
		fmul; // st(0) = pi * b
		fptan; // st(0) = 1 | st(1) = tan(pi * b)
		fdivr; // st(0) = 1 / tan(pi * b) = cot(pi * b)
		fadd; // st(0) = (118.0 * pi * sin(b) - cos(a) - tan(b) + cot(pi * b)) = [1]

		fld c; // put 118.0 in st(0)
		fld b; // put b in st(0)
		fmul; // st(0) = 118.0 * b
		fld a; // put a in st(0)
		fadd; // st(0) = 118.0 * b + a
		fldpi; // put pi in st(0)
		fmul; // st(0) = pi * (118.0 * b + a)

		fld c; // put 118.0 in st(0)
		fld a; // put a in st(0)
		fmul; // st(0) = 118.0 * a
		fld b; // put b in st(0)
		fsub; // st(0) = 118.0 * a - b

		fldz; // put 0 in st(0)
		fucomip st(0), st(1); // compare st(0) and st(1)
		je _error; // if st(0) == 0 goto _error

		fdiv; // st(0) = pi * (118.0 * b + a) / (118.0 * a - b)
		fsub; // st(0) = [1] - pi * (118.0 * b + a) / (118.0 * a - b)

		fst result; // result = 118.0 * pi * sin(b) - cos(a) - tan(b) + cot(pi * b) - pi * (118.0 * b + a) / (118.0 * a - b)
		jmp end;

	_error:
		mov error, 1;

	end:
	}

	if (error) {
		std::cout << "Ошибка, введено недопустимое значение!" << std::endl;
		system("pause");
		exit(0);
	}

	return result;
}

double count_no_asm(double a, double b) {
	double pi = atan(1) * 4;
	return 118 * pi * sin(b) - cos(-a) - tan(b) + cot(pi * b) - pi * (118 * b + a) / (118 * a - b);
}

int main()
{
	setlocale(LC_ALL, "Russian");
	std::cout << "Лабораторная работа 4. Выполнил студент группы 6104-020302D Маликов Николай" << std::endl;
	std::cout << "Вариант 118. Вычислить результат выражения:\nX = 118*pi*sin(b) - cos(-a) - tg(b) + ctg(pi*b) - pi*(118*b+a)/(118*a-b)." << std::endl;

	double a, b;
	std::cout << "Введите a и b: ";
	std::cin >> a >> b;
	double r = count(a, b);
	std::cout << "Ассемблер: " << r << std::endl;
	double r2 = count_no_asm(a, b);
	std::cout << "С++: " << r2 << std::endl;

	system("pause");

	return 0;
}