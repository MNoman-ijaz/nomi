#include <iostream>
#include<string>
using namespace std;
class Node 
{
public:
	int playerId;
	string playerName;
	int score;
	Node* left;
	Node* right;
	Node(int id, string name, int scr)
	{
		playerId = id;
		playerName = name;
		score = scr;
		left = nullptr;
		right = nullptr;
	}
};
class Leaderboard
{
private:
	Node* root;
public:
	Leaderboard() 
	{
		root = nullptr;
	}

	Node* insertNode(Node* root, int playerId, string playerName, int score) 
	{
		if (root == nullptr) {
			return new Node(playerId, playerName, score);
		}

		if (score > root->score || (score == root->score && playerId > root->playerId)) 
		{
			root->left = insertNode(root->left, playerId, playerName, score);
			root->left->right = root;
			root->left->left = nullptr; // Set left pointer of new node to nullptr
		}
		else {
			root->right = insertNode(root->right, playerId, playerName, score);
			root->right->left = root;
			root->right->right = nullptr; // Set right pointer of new node to nullptr
		}

		return root;
	}

	Node* findNode(Node* root, int playerId) 
	{
		if (root == nullptr || root->playerId == playerId) {
			return root;
		}

		Node* leftNode = findNode(root->left, playerId);
		if (leftNode != nullptr) {
			return leftNode;
		}

		return findNode(root->right, playerId);
	}

	void removeNode(Node* node) {
		if (node->left != nullptr) {
			node->left->right = node->right;
		}

		if (node->right != nullptr) {
			node->right->left = node->left;
		}

		delete node;
	}
	Node* updateScore(Node* root, int playerId, int score) {
		Node* node = findNode(root, playerId);
		if (node != nullptr) {
			removeNode(node);
			root = insertNode(root, playerId, node->playerName, score);
		}
		return root;
	}
	void getTopPlayers(Node* root, int n, Node** players) {
		if (root == nullptr || n == 0) {
			return;
		}

		getTopPlayers(root->left, n, players);

		*players = root;
		players++;

		getTopPlayers(root->right, n - 1, players);
	}
	void addPlayer(int playerId, string playerName, int score) {
		root = insertNode(root, playerId, playerName, score);
	}

	void removePlayer(int playerId) {
		Node* node = findNode(root, playerId);
		if (node != nullptr) {
			removeNode(node);
		}
		else {
			cout << "Player with ID " << playerId << " not found." << endl;
		}
	}

	void updateScore(int playerId, int score) {
		root = updateScore(root, playerId, score);
	}

	void getTopPlayers(int n, Node** players) {
		getTopPlayers(root, n, players);
	}
};

int main() {
	Leaderboard leaderboard;

	leaderboard.addPlayer(1, "John", 100);
	leaderboard.addPlayer(2, "Alice", 90);
	leaderboard.addPlayer(3, "Bob", 95);

	leaderboard.updateScore(2, 95);

	const int n = 2;
	Node* topPlayers[n];
	leaderboard.getTopPlayers(n, topPlayers);

	for (int i = 0; i < n; i++) {
		cout << "Player ID: " << topPlayers[i]->playerId << ", Score: " << topPlayers[i]->score << endl;
	}
	system("pause");
	return 0;
}
