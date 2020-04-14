WCF_WPF_parallel-programming
============================

Parallel addition of two matrices

The system consists of four main blocks: the user, the scheduler, database server and one or more executors.

Communication between blocks is via WCF.

-	User - enables the generation matrix of random values and their transmission to the data server. In addition, the user needs to provide input matrix A, B, and the number of executors N. After entering, the command is issued for a scheduler. 

-	Scheduler - enables the acceptance of user commands. Upon acceptance of command, scheduler addresses the data server and supplies matrices A and B, and organizes the addition of these two matrices to N executors. Scheduler initiates the executors after receiving the command, shuts them down after the completion of addition. When the addition is completed, the matrix C, which is the result of addition of A and B is recorded in the data server and a reference to the matrix C is returned to the user.  

-	Executor - performing its task received from the scheduler. 

-	Data - Input / output server for data. Input data is recorded in an XML file on disk. The output data is read from an XML file. 


Input: 

•	The matrix A 

•	The matrix B 

•	Number of executors N 


Output: 

•	The matrix C



![alt-link](https://raw.githubusercontent.com/jelenans/WCF_WPF_parallel-programming/master/New%20Picture%20(4).png)


![alt-link](https://raw.githubusercontent.com/jelenans/WCF_WPF_parallel-programming/master/New%20Picture%20(5).png)


![alt-link](https://raw.githubusercontent.com/jelenans/WCF_WPF_parallel-programming/master/New%20Picture%20(7).png)


![alt-link](https://raw.githubusercontent.com/jelenans/WCF_WPF_parallel-programming/master/New%20Picture%20(8).png)

