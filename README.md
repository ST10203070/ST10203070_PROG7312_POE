Municipal Services - Application
	The Municipal Services Application allows users to report municipal issues (such as sanitation, road conditions, utilities, and public safety), track the status of submitted service requests, and stay informed about upcoming local events and announcements. The system supports dark mode and sound notifications and offers personalised event recommendations based on user interactions.


Key Features:
1. Report Issues:
	Submit detailed reports on local municipal issues, with the ability to attach relevant images or files.
2. Local Events & Announcements:
	Search for local events by keyword, category, and date range.
	Receive personalised event recommendations based on search history.
3. Service Request Status:
	View and track the progress of service requests.
	Requests are prioritised and organised using efficient data structures (AVL Trees, Red-Black Trees, Min-Heap, Graph, and Minimum Spanning Tree).


Cloning Repository from GitHub:
1. Install Git:
	Ensure you have Git installed on your machine. 
2. Access the Repository:
	Go to the GitHub repository for this project: 	https://github.com/ST10203070/ST10203070_PROG7312_POE
3. Clone the Repository:
	Open a terminal or command prompt and run the following command:
	git clone https://github.com/ST10203070/ST10203070_PROG7312_POE.git
	This command will download all the project files to your local machine in a folder named ST10203070_PROG7312_POE.
4. Navigate to the Project Directory:
	After cloning, navigate to the project folder using the command:
	cd ST10203070_PROG7312_POE
5. Open the Project in Visual Studio
	Locate the .sln file in the cloned repository.
	Double click the .sln file to open the project in Visual Studio.
6. Build and Run the Application
	Follow the steps under the "Build the Solution" section in this README to build and execute the application. 
	

Getting Started:
Follow these instructions to compile, run, and use the application.

Prerequisites
	Visual Studio 2019 or later installed on your machine.
	.NET Framework 4.8 or higher installed.

How to Compile and Run
	Extract the ZIP File:
	Download and extract the ZIP file provided.

	Open the Solution:
	Double-click the .sln file in the extracted folder to open the project in Visual Studio.

	Restore NuGet Packages:
	If prompted, restore any NuGet packages by clicking "Restore" in the Visual Studio notification bar.

	Build the Solution:
	Go to Build > Build Solution or press Ctrl + Shift + B to compile the project.

	Run the Application:
	Click Start or press F5 to run the application.


Using the Application:
	Main Menu:
	The main screen displays a personalised greeting.
	Click the "Report Issues" button to navigate to the form for submitting issues.
	Click the "Local Events & Announcements" button to view upcoming events, and announcements, and receive personalised recommendations based on search history.
	Click the "Service Request Status" button to track the status of submitted service requests.

	Report Issues Form:
	Location: Enter the location of the issue.
	Category: Select the category from the dropdown.
	Description: Provide a detailed description of the issue.
	Attach Media: Click to attach relevant images or files.
	Submit: Submit the report.
	Back to Main Menu: Return to the main screen.
	
	Local Events and Announcements Page:
	Users can search for events based on a keyword, category, and date range.
	Upcoming local events will be displayed in an aesthetically formatted manner, with their date, title, category, and description.
	The application suggests recommended events based on user search patterns. Recommendations exclude events already displayed in the search results.

	Service Request Status Page:
	Displays a list of all submitted service requests, including details such as the request ID, description, submission date, and current status.
	The service requests are managed using AVL Trees, Red-Black Trees, Min-Heaps, and Graphs to ensure efficient data handling and prioritisation.

	Additional Features:
	Dark Mode: Toggle dark mode on or off using the checkbox.
	Sound On: Enable or disable sound notifications using the checkbox.


Troubleshooting:
	If the application does not start, ensure you have the correct version of Visual Studio and .NET Framework installed.
	If UI elements do not display correctly, try resizing the window or adjusting your display settings.
	If no events or recommendations are shown in the Local Events section, check your search criteria and ensure there are upcoming events that match your inputs.


Detailed Explanation of Implemented Data Structures:
	This section explains how each advanced data structure contributes to the efficiency of the Service Request Status feature.

1. AVL Tree (Balanced Binary Search Tree)
Role: 
	The AVL Tree is used to store and manage service requests by unique request IDs. It ensures that the tree remains balanced after every insertion, improving efficiency in searching, inserting, and deleting service requests.

Contribution:
	Maintains a logarithmic time complexity for insertions, deletions, and lookups by keeping the tree balanced. This ensures quick access to service requests, even as the number of requests grows.

Example:
	When a new service request is submitted (e.g., a road repair request), it is inserted into the AVL tree based on its request ID. The tree performs automatic balancing to ensure the height of the tree remains optimal, providing fast future lookups.

2. Red-Black Tree (Self-Balancing Binary Search Tree):
Role:
	The Red-Black Tree is another balanced tree used to store service requests. Like the AVL Tree, it guarantees that the tree remains balanced, but its balancing operations are more lenient, making insertions and deletions more efficient in some cases.

Contribution:
	The Red-Black Tree provides time complexity for insertion, deletion, and search operations. Compared to the AVL Tree, Red-Black Trees may allow for faster insertions due to fewer rotations, at the cost of being slightly less balanced than an AVL Tree.

Example:
	When multiple service requests are submitted in a short time, such as several road repair and sanitation requests, the Red-Black Tree's faster insertion times can help manage these requests efficiently while ensuring balance in the tree.

3. Min-Heap (Priority Queue)
Role: 
	The Min-Heap is used to prioritise service requests based on submission dates, ensuring that the oldest requests are addressed first.

Contribution:
	The Min-Heap allows for efficient extraction of the service request with the earliest submission date in time, ensuring that the system prioritises older requests.

Example:
	A service request submitted in January is processed before one submitted in March, as the Min-Heap ensures that the oldest request remains at the root of the heap for quick extraction.

4. Graph and Graph Traversal (Breadth-First Search)
Role: 
	The Graph is used to represent dependencies between service requests. For example, if one request depends on the completion of another, this relationship is represented in the graph.

Contribution:
	The Breadth-First Search (BFS) algorithm is used to traverse the graph of service requests, ensuring that all dependencies are resolved in the correct order.

Example:
	If a water leakage repair depends on a road being fixed first, the graph ensures that the road repair is completed before addressing the water leakage.

5. Prim's Algorithm (Minimum Spanning Tree)
Role: 
	Prim's Algorithm is used to compute the Minimum Spanning Tree (MST) for the graph of service request dependencies. This ensures that the minimum number of dependencies are followed when processing requests, optimizing the overall workflow.

Contribution:
	The MST minimises the number of edges (dependencies) that need to be traversed to cover all service requests, reducing the overall time spent resolving dependencies.

Example:
	Given a set of interconnected service requests with dependencies, Prim's Algorithm ensures that the requests are completed in the most efficient order, avoiding unnecessary work.


GitHub Repository:
https://github.com/ST10203070/ST10203070_PROG7312_POE