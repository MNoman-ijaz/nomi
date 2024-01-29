#include<iostream>
using namespace std;
void TotalNoRelation(int noe)	// Print total number of relations
{
	cout << "\nTotal number of relations are " << pow(2, noe * noe) << endl;
}
void Reflexive(int noe)		// Print total number of Reflexive Relations
{
	cout << "\nTotal number of Reflexive Relations are " << pow(2, (noe * noe) - noe) << endl;
}
void Symmetric(int noe)		// Print total number of Symmetric Relations
{
	cout << "\nTotal number of Symmetric Relations are " << pow(2, ((noe * noe) - noe) / 2) * pow(2, noe) << endl;
}
void Anti_Sym(int noe)		// Print total number of Anti-Symmetric Relations
{
	cout << "\nTotal number of Anti-Symmetric Relations are " << pow(3, ((noe * noe) - noe) / 2) * pow(2, noe) << endl;
}
void Ref_Sym(int noe)		// Print total number of Reflexive and Symmetric Relations
{
	cout << "\nTotal number of Reflexive and Symmetric Relations are " << pow(2, ((noe * noe) - noe) / 2) << endl;
}
void Sym_AntiSym(int noe)		// Print total number of Symmetric and Anti-Symmetric Relations
{
	cout << "\nTotal number of Symmetric and Anti-Symmetric Relations are " << pow(2, noe) << endl;
}
int main()
{
	int* set1, * set2, n, noe;
	cout << "\n					 ***********" << endl;
	cout << "					|           |" << endl;
	cout << "					| Relations |" << endl;
	cout << "					|           |" << endl;
	cout << "					 ***********\n" << endl;
	system("color E4");		// Changes color of text and background
label1:
	cout << "Enter the number of elements of set1 and set2(at least 3): ";
	cin >> noe;
	if (noe < 3)
		goto label1;
	set1 = new int[noe];	// Making dynamic array of set1
	set2 = new int[noe];	// Making dynamic array of set1
	cout << endl;
	for (int i = 0; i < noe; i++)
	{
		cout << "Enter a number in set1: ";		// Taking input in set1
		cin >> set1[i];
	}
	cout << endl;
	for (int i = 0; i < noe; i++)
	{
		cout << "Enter a number in set2: ";		// Taking input in set2
		cin >> set2[i];
	}
	cout << "\nSet1 = ";
	for (int i = 0; i < noe; i++)
	{
		cout << set1[i] << "  ";		// Printing elements of set1
	}
	cout << "\nSet2 = ";
	for (int i = 0; i < noe; i++)
	{
		cout << set2[i] << "  ";		// Printing elements of set2
	}
	cout << "\n\nCartesion Product of Set1 and Set2 is" << endl;
	cout << "Set1 x Set2 = ";
	for (int i = 0; i < noe; i++)
	{
		for (int j = 0; j < noe; j++)
		{
			cout << set1[i] << "," << set2[j] << "  ";		// Printing cartesion product of set1 and set2
		}
	}
label2:
	cout << "\n\n1. The Total number of relations\n2. Reflexive Relations\n3. Symmetric Relations\n";
	cout << "4. Anti-Symmetric Relations\n5. Both Reflexive and Symmetric Relations\n";
	cout << "6. Both symmetric and Anti-Symmetric Relations\n7. Exit\n\n";
	cout << "Enter your choice: ";
	cin >> n;
	if (n == 1)
	{
		TotalNoRelation(noe);		// Calling function TotalNoRelation()
		system("pause");
		system("cls");		// Clears the screen
		goto label2;
	}
	else if (n == 2)
	{
		Reflexive(noe);		// Calling function Reflexive()
		system("pause");
		system("cls");
		goto label2;
	}
	else if (n == 3)
	{
		Symmetric(noe);		// Calling function Symmetric()
		system("pause");
		system("cls");
		goto label2;
	}
	else if (n == 4)
	{
		Anti_Sym(noe);		// Calling function Anti_Sym()
		system("pause");
		system("cls");
		goto label2;
	}
	else if (n == 5)
	{
		Ref_Sym(noe);		// Calling function Ref_Sym()
		system("pause");
		system("cls");
		goto label2;
	}
	else if (n == 6)
	{
		Sym_AntiSym(noe);		// Calling function Sym_AntiSym()
		system("pause");
		system("cls");
		goto label2;
	}
	else if (n == 7)
	{
		cout << "\nDevelopers:\n->  Muhammad Raza(21F-9521)\n->  Noman Ijaz(21F-9513)\n";
		system("pause");
		return 0;
	}
	else
	{
		cout << "Invalid Input";
		system("pause");
		system("cls");
		goto label2;
	}
}
