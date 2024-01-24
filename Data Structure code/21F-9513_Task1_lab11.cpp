#include <iostream>
using namespace std;
class MinHeap 
{
private:                         //attributes 
	int* heapArray;
	int capacity;
	int heapSize;

public:
	MinHeap(int capacity)//constructor
	{
		this->capacity = capacity;
		heapArray = new int[capacity];
		heapSize = 0;
	}

	void swap(int& a, int& b)
	{
		int temp = a;
		a = b;
		b = temp;
	}
	int parent(int i) 
	{
		return (i - 1) / 2;
	}
	int leftChild(int i)
	{
		return 2 * i + 1;
	}

	int rightChild(int i) {
		return 2 * i + 2;
	}
	int getMini() // it will return the root element
	{
		if (heapSize == 0) {
			cout << "Heap is empty!" << endl;
			return -1;
		}
		return heapArray[0];
	}

	// Function to extract the minimum element from the heap (root element)
	int extractMin()
	{
		if (heapSize == 0) 
		{
			cout << "Heap is empty!" << endl;
			return -1;
		}
		int root = heapArray[0];
		heapArray[0] = heapArray[heapSize - 1];
		heapSize--;
		minHeapify(0);
		return root;
	}
	// Helper function to maintain the Min Heap property
	void minHeapify(int i) {
		int smallest = i;
		int left = leftChild(i);
		int right = rightChild(i);
		if (left < heapSize && heapArray[left] < heapArray[smallest]) {
			smallest = left;
		}
		if (right < heapSize && heapArray[right] < heapArray[smallest]) {
			smallest = right;
		}
		if (smallest != i)
		{
			swap(heapArray[i], heapArray[smallest]);
			minHeapify(smallest);
		}
	}
	// Function to insert a new key into the heap
	void insert(int key) 
	{
		if (heapSize == capacity) {
			cout << "Heap is full!" << endl;
			return;
		}
		heapArray[heapSize] = key;
		int i = heapSize;
		heapSize++;
		while (i > 0 && heapArray[parent(i)] > heapArray[i]) {
			swap(heapArray[i], heapArray[parent(i)]);
			i = parent(i);
		}
	}
	// Function to print the elements of the heap
	void printHeap() {
		for (int i = 0; i < heapSize; i++) {
			cout << heapArray[i] << " ";
		}
		cout << endl;
	}
};

int main() 
{
	int size, value;
	cout << "enter size of heap = ";
	cin >> size;
	MinHeap heap(size);
	for (int i = 0; i < size; i++)
	{
		cout << "enter " << i + 1 << "th value in heap = ";
		cin >> value;
		heap.insert(value);
	}
	cout << "values in heap are = " << endl;
	heap.printHeap();
	cout << "minimum value is =  " << endl;
	cout << heap.getMini() << endl;
	system("pause");
	return 0;
}