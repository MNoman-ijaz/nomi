#include <iostream>
using namespace std;
class HashTable {
private:
	int tableSize;
	int* hashTable;
	bool* isOccupied;
	int numElements;
	const double loadFactorThreshold = 0.7;

public:
	HashTable(int size) : tableSize(size), numElements(0) {
		hashTable = new int[tableSize];
		isOccupied = new bool[tableSize];
		for (int i = 0; i < tableSize; i++) {
			hashTable[i] = -1;
			isOccupied[i] = false;
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

	// Insert an element into the hash table using quadratic probing and rehashing
	void insert(int key) {
		if (numElements >= loadFactorThreshold * tableSize) {
			rehash();
		}

		int index = hashFunction(key);
		int i = 0;

		while (isOccupied[index]) {
			i++;
			index = quadraticProbing(index, i);
		}

		hashTable[index] = key;
		isOccupied[index] = true;
		numElements++;
	}

	// Delete an element from the hash table
	bool remove(int key) {
		int index = hashFunction(key);
		int i = 0;

		while (isOccupied[index]) {
			if (hashTable[index] == key) {
				hashTable[index] = -1;
				isOccupied[index] = false;
				numElements--;
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

		while (isOccupied[index]) {
			if (hashTable[index] == key) {
				return true;
			}
			i++;
			index = quadraticProbing(index, i);
		}

		return false;
	}

	// Rehashing function to resize the hash table
	void rehash() {
		int newSize = tableSize * 2;
		int* newHashTable = new int[newSize];
		bool* newIsOccupied = new bool[newSize];
		for (int i = 0; i < newSize; i++) {
			newHashTable[i] = -1;
			newIsOccupied[i] = false;
		}

		for (int i = 0; i < tableSize; i++) {
			if (isOccupied[i]) {
				int key = hashTable[i];
				int newIndex = key % newSize;
				int j = 0;
				while (newIsOccupied[newIndex]) {
					j++;
					newIndex = quadraticProbing(newIndex, j);
				}
				newHashTable[newIndex] = key;
				newIsOccupied[newIndex] = true;
			}
		}

		delete[] hashTable;
		delete[] isOccupied;
		tableSize = newSize;
		hashTable = newHashTable;
		isOccupied = newIsOccupied;
	}
	~HashTable() {
		delete[] hashTable;
		delete[] isOccupied;
	}
};
int main() {
	int tableSize;
	cout << "Enter the size of the hash table: ";
	cin >> tableSize;

	HashTable obj(tableSize);

	int choice, key;
	while (true) {
		cout << "\n1. Insert\n2. Delete\n3. Search\n4. Exit\n";
		cout << "Enter your choice: ";
		cin >> choice;

		switch (choice) {
		case 1:
			cout << "Enter the key to insert: ";
			cin >> key;
			obj.insert(key);
			break;
		case 2:
			cout << "Enter the key to delete: ";
			cin >> key;
			if (obj.remove(key)) {
				cout << "Element " << key << " deleted successfully.\n";
			}
			else {
				cout << "Element " << key << " not found in the hash table.\n";
			}
			break;
		case 3:
			cout << "Enter the key to search: ";
			cin >> key;
			if (obj.search(key)) {
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
