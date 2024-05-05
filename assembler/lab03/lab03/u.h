#pragma once

int sum_adjacent(std::vector<int> vec, int size, int indexArray)
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
