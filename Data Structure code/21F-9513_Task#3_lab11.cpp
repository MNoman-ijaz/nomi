#include<iostream>
using namespace std;
void Heap(int Arr[], int n, int data)
{
	int smallest = data;
	int Left = 2 * data + 1;
	int Right = 2 * data + 2;
	if (Left < n && Arr[Left] < Arr[smallest])
	{
		smallest = Left;
	}
	if (Right < n && Arr[Right] < Arr[smallest])
	{
		smallest = Right;
	}
	if (smallest != data)
	{
		swap(Arr[data], Arr[smallest]);
		Heap(Arr, n, smallest);
	}
}
int minheap(int arr[], int n, int k) // This function will sort the element in the minimum order 
{
	for (int i = n / 2 - 1; i >= 0; i--)
	{
		Heap(arr, n, i);
	}
	for (int i = n - 1; i >= n - k; i--)
	{
		swap(arr[0], arr[i]);
		Heap(arr, i, 0);
	}
	return arr[n - k];
}
int main()
{
	int size = 7;
	int arr[] = { 4, 2, 6, 1, 3, 5, 7 };
	cout<< "The  MIN ElEMENTS IN THE HEAP = ";
	for (int i = 0; i < size; i++)
	{
		cout << minheap(arr, size, i + 1) << " ";
	}
	system("pause");
	return 0;
}

