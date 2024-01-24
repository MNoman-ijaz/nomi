#include <iostream>
#include <queue>
using namespace std;
class BuildingHeap 
{
private:
	priority_queue<pair<int, int>> maxHeap; // {number of floors, building ID}
	int buildingCount;

public:
	BuildingHeap() : buildingCount(0) {}       //intializing

	// Add a building to the construction queue
	void addBuilding(int buildingID, int numFloors)
	{
		maxHeap.push(make_pair(numFloors, buildingID));
		buildingCount++;
	}

	// Construct the building with the highest priority
	void constructBuilding() 
	{
		if (buildingCount == 0)
		{
			cout << "No buildings in the queue.\n";
			return;
		}
		pair<int, int> topBuilding = maxHeap.top();
		maxHeap.pop();
		buildingCount--;
		cout << "Constructing Building ID: " << topBuilding.second << " with " << topBuilding.first << " floors.\n";
	}
	// Get the ID of the building with the highest number of floors in the queue
	int getHighestPriorityBuilding()
	{
		if (buildingCount == 0) {
			cout << "No buildings in the queue.\n";
			return -1; // Assuming -1 indicates no building in the queue
		}
		return maxHeap.top().second;
	}
};
int main() {
	BuildingHeap obj;
	obj.addBuilding(1, 3);
	obj.addBuilding(2, 6);
	obj.addBuilding(3, 9);
	obj.addBuilding(4, 20);

	int highestPrioBuild = obj.getHighestPriorityBuilding();
	cout << "Building with the highest priority (ID): " << highestPrioBuild << endl;
	obj.constructBuilding();
	highestPrioBuild = obj.getHighestPriorityBuilding();
	cout << "Building with the highest priority : " << highestPrioBuild << endl;
	system("pause");
	return 0;
}
