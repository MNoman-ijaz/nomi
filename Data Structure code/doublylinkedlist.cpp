#include<iostream>
using namespace std;
class Node
{
public:
	Node* next;
	Node* prev;
	int data;
	Node(int d)
	{
		next = NULL;
		prev = NULL;
		data = d;
	}
};
class linkedlist
{
private:
	Node* head;
	Node* tail;
public:
	linkedlist()
	{
		head = NULL;
		tail = NULL;
	}
	void inserathead(int d)
	{
		if (head==NULL)
		{
			Node* newnode = new Node(d);
			head = newnode;
		}
		else
		{
		Node* newnode = new Node(d);
		newnode->next = head;
		head->prev = newnode;
		head = newnode;
		}
	}
	void inserattail(int d)
	{
		if (tail==NULL)
		{
			Node* newnode = new Node(d);
			tail = newnode;

		}
		else
		{
			Node* newnode = new Node(d);
			tail->next = newnode;
			newnode->prev = tail;
			tail = newnode;
		}
	}
	void inseratanypos(int pos,int d)
	{
		if (pos==1)
		{
			inserathead(d);
			return;
		}
		Node* temp = head;
		int cnt = 1;
		while (cnt<pos-1)
		{
			temp = temp->next;
			cnt++;
		}
		if (temp->next==NULL)
		{
			inserattail(d);
			return;
		}
		Node* nodetoinsert = new Node(d);
		nodetoinsert->next = temp->next;
		nodetoinsert->next->prev = nodetoinsert;
		temp->next = nodetoinsert;
		nodetoinsert->prev = temp;
	}
	void deletion(int pos)
	{
		if (pos==1)
		{
			Node* temp = head;
			head = head->next;
			temp->next->prev = NULL;
			temp->next = NULL;
			delete temp;
		}
		else
		{
			int cnt = 1;
			Node* curr = head;
			Node* prev = NULL;
			while (cnt<pos)
			{
				prev = curr;
				curr = curr->next;
				
				cnt++;
			}
			curr->prev = NULL;
			prev->next = curr->next;
			curr->next = NULL;
			delete curr;
		}
	}
	void dsiplay()
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
	obj.inserathead(10);
	obj.inserathead(20);
	obj.inserathead(30);
	obj.inserathead(40);
	obj.inserathead(50);
	obj.dsiplay();
	obj.inserattail(8);
	obj.dsiplay();
	obj.inseratanypos(3, 8);
	obj.dsiplay();
	obj.deletion(3);
	obj.dsiplay();
	system("pause");
}