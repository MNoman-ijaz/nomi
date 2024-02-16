#include<iostream>
#include<string>
using namespace std;
class car
{
    public:                        //This is Access specifier like private ,protected ....
    string Brand;                   //These are attributes,or we can also say these are data members..
    string model;
    int year;
    void display()
    {
        cout<<carobj1.Brand<<" "<<carobj1.model<<" "<<carobj1.year<<endl;
        cout<<carobj2.Brand<<" "<<carobj2.model<<" "<<carobj2.year<<endl;
    }
};
int main()
{
    //creating an object of car
    car carobj1;                     
    carobj1.Brand="BMW";
    carobj1.model="X6";
    carobj1.year=2022;
    //creating another object of car
    car carobj2;
    carobj2.Brand="BUGATI";
    carobj2.model="MUSTArd";
    carobj2.year=2023;
     carobj1.display();                  //Function calling
     carobj2.display();
    system("pause");
}