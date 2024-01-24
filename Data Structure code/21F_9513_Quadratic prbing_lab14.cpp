#include <iostream>
using namespace std;
class HashTable 
{
private:
	int tableSize;
	int* hashTable;
	bool* var;
public:
	HashTable(int size) : tableSize(size) 
	{
		hashTable = new int[tableSize];
		var = new bool[tableSize];
		for (int i = 0; i < tableSize; i++) {
			hashTable[i] = -1;
			var[i] = false;
		}
	}
	// Hash function to convert a key into an index
	int hashFunction(int key) {
		return key % tableSize;
	}
	// Quadratic probing function
	int quadraticProbing(int index, int i) {
		return (index + i * i) % tableSize;
	}
	// Insert an element into the hash table using quadratic probing
	void insert(int key) {
		int index = hashFunction(key);
		int i = 0;

		while (var[index]) {
			i++;
			index = quadraticProbing(index, i);
			if (i == tableSize) {
				cout << "Hash table is full. Cannot insert more elements.\n";
				return;
			}
		}

		hashTable[index] = key;
		var[index] = true;
	}

	// Delete an element from the hash table
	bool remove(int key) {
		int index = hashFunction(key);
		int i = 0;

		while (var[index]) {
			if (hashTable[index] == key) {
				hashTable[index] = -1;
				var[index] = false;
				return true;
			}
			i++;
			index = quadraticProbing(index, i);
		}

		return false;
	}

	// Search for an element in the hash table
	bool search(int key) {
		int index = hashFunction(key);
		int i = 0;

		while (var[index]) {
			if (hashTable[index] == key) {
				return true;
			}
			i++;
			index = quadraticProbing(index, i);
		}

		return false;
	}

	~HashTable() {
		delete[] hashTable;
		delete[] var;
	}
};

int main() {
	int tableSize;
	cout << "Enter the size of the hash table: ";
	cin >> tableSize;

	HashTable hashTable(tableSize);

	int choice, key;
	while (true) {
		cout << "\n1. Insert\n2. Delete\n3. Search\n4. Exit\n";
		cout << "Enter your choice: ";
		cin >> choice;

		switch (choice) {
		case 1:
			cout << "Enter the key to insert: ";
			cin >> key;
			hashTable.insert(key);
			break;
		case 2:
			cout << "Enter the key to delete: ";
			cin >> key;
			if (hashTable.remove(key)) {
				cout << "Element " << key << " deleted successfully.\n";
			}
			else {
				cout << "Element " << key << " not found in the hash table.\n";
			}
			break;
		case 3:
			cout << "Enter the key to search: ";
			cin >> key;
			if (hashTable.search(key)) {
				cout << "Element " << key << " found in the hash table.\n";
			}
			else {
				cout << "Element " << key << " not found in the hash table.\n";
			}
			break;
		case 4:
			cout << "Exiting...\n";
			return 0;
		default:
			cout << "Invalid choice. Try again.\n";
		}
	}
	system("pause");
	return 0;
}
