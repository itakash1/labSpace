#include <iostream>
#include <locale>
#include "./calculate.h"

using namespace std;

int main(){
    setlocale(LC_ALL, "Russian");

    int a, b, c, d;

    do
    {
        std::cout << "Введите: a != 0: \n";
        std::cin >> a;
    } while (a == 0);

    std::cout << "Введите: b = \n";
    std::cin >> b;

    std::cout << "Введите: c = \n";
    std::cin >> c;

    do
    {
        std::cout << "Введите: d != 0: \n";
        std::cin >> d;
    } while (d == 0);

    int result = calculate(a, b, c, d);

    int result1 = (-a - 73 + (-6 * b)) / (( - 4 * c + 200) / (d * a));

    printf("Результат вычесления C++: %d\n", result1);
    printf("Результат вычесления языка Ассембер: %d\n", result);

    return 0;
}