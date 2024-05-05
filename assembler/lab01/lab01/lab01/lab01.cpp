//(-a-73-6*b)/(-4*c+200/d*a); var:118

#include <iostream>
#include <stdio.h>

int calc(int a, int b, int c, int d) {

    int result = 0;

    __asm {
        mov	eax, a      // <--
        mov	ebx, b      // <--
        mov	ecx, c      // <--
        mov edi, d      // <--

        imul ecx, -4    // c*-4
        add ecx, 200    // c*-4+200
        mov eax, ecx    // c*-4+200 --> eax
        cdq             // eax = edx:eax
        mov ecx, a      // ecx --> a   !
        imul edi, ecx   // d*a
        idiv edi        // -4*c+200/d*a
        push eax        // --> стек (1)

        mov eax, a      // a --> eax
        imul ebx, -6    // b*-6
        add ebx, -73    // b*-6-73
        neg eax         // Смена знака с - на + и наоборот
        add eax, ebx    // b*-6-73-a
        mov ebx, eax    // eax --> ebx

        pop ebx         // ebx <-- стек(1)
        cdq             // eax = -4*c+200/d*a
        idiv ebx        // (-a-73-6*b)/(-4*c+200/d*a)

        mov result, eax
    }

    return result;
}




int main() {
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

    int result = calc(a, b, c, d);

    int result1 = (-a - 73 + (-6 * b)) / ((-4 * c + 200) / (d * a));

    printf("Результат вычесления C++: %d\n", result1);
    printf("Результат вычесления языка Ассембер: %d\n", result);

    return 0;
}