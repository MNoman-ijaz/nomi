#include <iostream>
using namespace std;
void swap(int& a, int& b) 
{
	int temp = a;
	a = b;
	b = temp;
}
void heapify(int* arr, int n, int i) // This function will heapify the element 
{
	int largest = i;
	int l = 2 * i + 1;
	int r = 2 * i + 2;
	if (l < n && arr[l] > arr[largest])
		largest = l;
	if (r < n && arr[r] > arr[largest])
		largest = r;
	if (largest != i) {
		swap(arr[i], arr[largest]);
		heapify(arr, n, largest);
	}
}
void buildMaxHeap(int* arr, int n) //This will return max element first then so on decreasing..
{
	for (int i = n / 2 - 1; i >= 0; i--)
		heapify(arr, n, i);
}

void printHeap(int* arr, int n) //Displaying heap element 
{
	for (int i = 0; i < n; i++) {
		cout << arr[i] << " ";
	}
	cout << endl;
}
int main() 
{
	int size;
	cout << "Enter size of heap = ";
	cin >> size;
	int* arr = new int[size];
	for (int i = 0; i < size; i++) 
	{
		cout << "Enter " << i + 1 << "th value in heap: " << endl;
		cin >> arr[i];
	}
	int n = size;
	buildMaxHeap(arr, n);
	cout << "Max Heap: ";
	printHeap(arr, n);
	system("pause");
	return 0;
}