#include <iostream>
using namespace std;
struct TreeNode
{
	int val;
	TreeNode* left;
	TreeNode* right;
	TreeNode(int v) : val(v), left(nullptr), right(nullptr) {}
};
TreeNode* removeLeafNodes(TreeNode* root) 
{
	if (root == nullptr)
	{
		return nullptr;
	}
	// Check if the node is a leaf node
	if (root->left == nullptr && root->right == nullptr)
	{
		delete root;
		return nullptr;
	}
	// Recursively remove leaf nodes from the left and right subtrees
	root->left = removeLeafNodes(root->left);
	root->right = removeLeafNodes(root->right);
	// If the current node has become a leaf node after removing its children, delete it
	if (root->left == nullptr && root->right == nullptr) 
	{
		delete root;
		return nullptr;
	}
	return root;
}
void inorderTraversal(TreeNode* root) {
	if (root == nullptr) return;
	inorderTraversal(root->left);
	cout << root->val << " ";
	inorderTraversal(root->right);
}

int main() {
	// Create a sample binary tree
	TreeNode* root = new TreeNode(1);
	root->left = new TreeNode(2);
	root->right = new TreeNode(3);
	root->left->left = new TreeNode(4);
	root->left->right = new TreeNode(5);
	root->right->left = new TreeNode(6);
	root->right->right = new TreeNode(7);

	cout << "Original tree: ";
	inorderTraversal(root);
	cout << endl;

	// Remove leaf nodes
	root = removeLeafNodes(root);

	cout << "Tree after removing leaf nodes: ";
	inorderTraversal(root);
	cout << endl;
	system("pause");
	return 0;
}
