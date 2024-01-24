#include<iostream>
using namespace std;
class Node 
{
public:
	int key;
	Node* next;
	Node(int key) : key(key), next(nullptr) {}
};
class HashTable 
{
private:
	int tableSize;
	Node** hashTable;
	// Hash function to convert a key into an index
	int hashFunction(int key) {
		return key % tableSize;
	}
public:
	HashTable(int size) : tableSize(size) {
		hashTable = new Node*[tableSize];
		for (int i = 0; i < tableSize; i++) {
			hashTable[i] = nullptr;
		}
	}

	// Insert an element into the hash table using the Bucket method
	void insert(int key) {
		int index = hashFunction(key);
		Node* newNode = new Node(key);

		if (hashTable[index] == nullptr) {
			hashTable[index] = newNode;
		}
		else {
			Node* curr = hashTable[index];
			while (curr->next != nullptr) {
				curr = curr->next;
			}
			curr->next = newNode;
		}
	}

	// Delete an element from the hash table
	bool remove(int key) {
		int index = hashFunction(key);
		Node* curr = hashTable[index];
		Node* prev = nullptr;

		while (curr != nullptr) {
			if (curr->key == key) {
				if (prev == nullptr) {
					hashTable[index] = curr->next;
				}
				else {
					prev->next = curr->next;
				}
				delete curr;
				return true;
			}
			prev = curr;
			curr = curr->next;
		}

		return false;
	}

	// Search for an element in the hash table
	bool search(int key) {
		int index = hashFunction(key);
		Node* curr = hashTable[index];

		while (curr != nullptr) {
			if (curr->key == key) {
				return true;
			}
			curr = curr->next;
		}

		return false;
	}

	// Destructor to deallocate memory
	~HashTable() {
		for (int i = 0; i < tableSize; i++) {
			Node* curr = hashTable[i];
			while (curr != nullptr) {
				Node* next = curr->next;
				delete curr;
				curr = next;
			}
		}
		delete[] hashTable;
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
