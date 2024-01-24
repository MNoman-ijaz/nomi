#include<iostream>
using namespace std;
class Node
{
public:
	int data;
	Node* next;
	Node(int d)
	{
		data = d;
		this->next = NULL;
	}
};
class linkedlist
{
private:
	Node* head;
public:
	linkedlist()
	{
		head = NULL;
	}
	void insertathead(int d)
	{
		Node* temp = new Node(d);
		temp->next = head;
		head = temp;
	}
	void insertattail(int d)
	{
		Node* tail = new Node(d);
		head->next = tail;
		tail = tail->next;
	}
	void insertatanypos(int pos,int d)
	{
		if (pos==1)
		{
			insertathead(d);
			return;
		}
		Node* temp = head;
		int count = 1;
		while (count<pos-1)
		{
			temp = temp->next;
			count++;
		}
		if (temp->next==NULL)
		{
			insertattail(d);
			return;
		}
		Node* nodetoinsert = new Node(d);
		nodetoinsert->next = temp->next;
		temp->next = nodetoinsert;
	}
	void deleteion(int pos)
	{
		if (pos==1)
		{
			Node* temp = head;
			head = head->next; 
			temp->next = NULL;
			delete temp;
		}
		// deleting middle or last node
		else
		{
			Node* curr = head;
			Node* prev = NULL;
			int cnt = 1;
			while (cnt < pos)
			{
				prev = curr;
				curr = curr->next;
				cnt++;
			}
			//last node
			prev->next = curr->next;
			prev->next = NULL;
			delete curr;
		}
	}
	void display()
	{
		Node* temp = head;
		while (temp!=NULL)
		{
			cout << temp->data << " ";
			temp = temp->next;
		}
		cout << endl;
	}
};
int main()
{
	linkedlist obj;
	obj.insertathead(20);
	obj.insertathead(10);
	obj.display();
	obj.insertathead(30);
	obj.display();
	obj.insertattail(9);
	obj.display();
	obj.insertattail(8);
	obj.display();
	obj.insertatanypos(1, 7);
	obj.display();
	obj.deleteion(2);
	obj.display();
	system("pause");
	return 0;
}