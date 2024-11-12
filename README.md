
# Angstrom Sports Colleague Clock

## Setup
You will need [Visual Studio](https://visualstudio.microsoft.com/vs/community/) or similar IDE  
You will also need the [DotNet 7 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/7.0)  

1. Extract the application to your local machine
2. Open the solution with your editor of choice and build
3. Open Test Explorer, One test should be discovered called "ExampleTest"
4. Run "ExampleTest" and if everything is working, the test should pass

The Application project contains the code for the app under test.

The Tests project contains the example integration test of the
app under test using MSTest


## Returning the exercise

Once you've completed the exercise, please clean the solution to remove
build outputs etc.

ZIP the solution folder and email back to us, we will discuss your answers
as part of your interview

## Requirements

As a user working in a remote team  
I want to see the current time in the UK and Canada  
So I know what time it is for my colleagues  

**Acceptance Criteria**

* Must get the current date and time from https://worldtimeapi.org/
* Must display the current time for the UK and Canada
* Date and time must be displayed in the format `Monday 1 January 2023 17:00:00`
* Must display the difference in time between the UK and Canada


## Exercise

This exercise should take around 30m to 45m maximum.

The goal of this exercise is to gain insights into your thought process when
working on quality related tasks, and your knowledge of testability and best
practises. It is not a "LeetCode" style exercise!  Your recommendations, approach
and reasoning are more important than the written code.

Q1. Do you think the application satisfies the acceptance criteria?  
*Run the application to see the output, browse the implementation and write 
a short summary of why you think the application does / doesn't meet the
acceptance criteria*

Q2. Refactor the code to be more testable  
*Code does not have to be perfect, what is important here is your thought
process on what makes code testable. Leaving comments with TODO's if you
do not have enough time to refactor a section is perfectly fine*

Q3. What types of automated tests, and test cases would you write to test
this application?  
*There is a Unit Test project added already with MSTest (feel free to change
if you want), and an example test case in the Tests.cs file to get you started*
*Again, the code does not have to be perfect, we are looking at the tests you 
would write for this user story, not their implementation*
