#include<iostream>
using namespace std;
struct Node
{
	int data;
	Node* next;
};
class stack
{
private:
	Node* top;
public:
	stack()
	{
		top == NULL;
	}
	bool isempty()
	{
		if (top==NULL)
		{
			cout << "Stack is empty" << endl;
			return true;
		}
	}
	void push(int x)
	{
		if (isempty())
		{
			cout << "No element in the stack " << endl;
			return;
		}
		Node* temp = new Node;
		temp->next = top;
		x = top->data;
		top = temp;
	}
	void pop(int x)
	{
		if (isempty())
		{
			cout << "No element in the stack " << endl;
			return;
		}
		Node* temp = top;
		x = top->data;
		top = top->next;
		delete temp;
	}

};
int main()
{
	stack obj;
	obj.push(10);
	obj.push(20);
	obj.push(30);
	obj.pop(30);
	system("pause");

}