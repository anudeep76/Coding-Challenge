#Coding-Challenge

# Assumption
This is a coding challenge to prepare the Depth Chart of the NFL team Tampa Bay Buccaneers. 

The code should take the sample inputs given and should produce the outputs as listed in the given questionnaire PDF. 

# Introduction
You can find the different entities in this coding challenge and they are namely Player Number, Player Name, Player Position and Depth. 

Different Player Positions includes LWR,RWR, LT, LG, C, RG, RT, TE,TE,QB, RB etc..


# Structure
This Console App consists of different folders and structure. 

Code separability and extendability are the main things considered when designing this. As of now this is dedicated to NFL but we can add more sports and teams in the future. 

This Console App consists different layers like Interfaces, Models, and Services. 

# Tools needed to run
Visual Studio 2022

.NET 6.0

# Steps to run this Console App
1.Download and install the Visual Studio 2022 from this link: https://visualstudio.microsoft.com/vs/

2.Download this Coding-Challenges console as a ZIP file (Make sure you downloaded the Interfaces, Models, Services, Depth Chart Test.csproj, Depth Chart Test.sln and Program.cs).

3.Open the Depth Chart Test.sln in the Visual Studio 2022, Build and Run. You should see the outputs as the like given in Some Inputs/Outputs in the Questionnaire PDF.

4.You can give different inputs by adding/modifying in the Program.cs file and the different functionalities you can test could be AddPlayerToDepthChart, RemovePlayerFromDepthChart, GetBackups and GetFullDepthChart.  

# NOTE: 
 1.In the given example  getBackups(“QB”, JaelonDarden)  Output: #10 – Scott Miller
 
     Here it should be getBackups(“LWR”, JaelonDarden) then only we get output as #10- Scott Miller. 
                          
 2.In the given example removePlayerFromDepthChart(“WR”, MikeEvans) Output: #13 – MikeEvans
 
     Here it should be "LWR" in the position instead of the "WR". Then only we get the output as the 13- MikeEvans. 
                                

