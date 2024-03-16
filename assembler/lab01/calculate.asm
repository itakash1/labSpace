section .text
global calculate

calculate:
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

	ret