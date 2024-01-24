#include <iostream>
using namespace std;
class UndirectedGraph 
{
private:
	int N; // Number of vertices
	int** adjacencyList; // 2D array for the adjacency list

public:

	UndirectedGraph(int n) : N(n) 
	{
		adjacencyList = new int*[N + 1]; // Adding 1 to N to make it 1-indexed
		for (int i = 1; i <= N; i++) 
		{
			adjacencyList[i] = nullptr;
		}
	}
	void addEdge(int x, int y) {
		if (x >= 1 && x <= N && y >= 1 && y <= N) {
			// Add y to the adjacency list of x
			adjacencyList[x] = addNode(adjacencyList[x], y);

			// Add x to the adjacency list of y
			adjacencyList[y] = addNode(adjacencyList[y], x);
		}
	}
	// Function to add a node to the adjacency list
	int* addNode(int* head, int data) 
	{
		int* newNode = new int[2];
		newNode[0] = data;
		newNode[1] = 0;

		if (head == nullptr) 
		{
			head = newNode;
		}
		else {
			int* current = head;
			while (current[1] != 0) {
				current = current + 2;
			}
			current[1] = (int)newNode;
		}

		return head;
	}
	// Function to print the adjacency list
	void printAdjacencyList() {
		for (int i = 1; i <= N; i++) {
			std::cout << "Vertex " << i << ": ";
			int* current = adjacencyList[i];
			while (current != nullptr) {
				std::cout << current[0] << " ";
				current = (int*)current[1];
			}
			cout <<endl;
		}
	}
};
int main() 
{
	int N = 5; // Number of vertices
	UndirectedGraph graph(N);
	// Adding edges to the graph
	graph.addEdge(1, 2);
	graph.addEdge(2, 3);
	graph.addEdge(3, 4);
	graph.addEdge(4, 5);
	graph.addEdge(5, 1);
	cout << "Adjacency List:" << endl;
	graph.printAdjacencyList();
	system("pause");
	return 0;
}
