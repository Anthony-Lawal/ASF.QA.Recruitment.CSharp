
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

## Anthony Lawal Solutions

Q1. Do you think the application satisfies the acceptance criteria?  
*Run the application to see the output, browse the implementation and write 
a short summary of why you think the application does / doesn't meet the
acceptance criteria*
 

Q1 Answer:

1.The application may not always return UK time if the user is not in the UK. The variable ukDateTime, in the solution, was implemented using DateTime.Now, which captures the system’s local time. This approach assumes the local machine is set to UK time, which may not always be the case.

2. The application does not successfully display the difference in time between UK and Canada, running the application returns zero as the timespan difference between Canada and UK.

3.The code successfully meets the requirement to display the date in the specified format (dddd dd MMMM yyyy HH:mm:ss). 
 

Q2. Refactor the code to be more testable.
 
Q2 Answer: 
The project was the refactored to the classes and method below:
*ITimeApiService Interface: ITimeApiService is defined as an abstraction for fetching the current time. The change will allow for easy mocking during tests.
*WorldTimeApiService Implementation: This class implements ITimeApiService and uses HttpClient to retrieve time from the API.
*TimeDifferenceEvaluator Class: This class handles the logic for formatting the date, displaying time, and calculating the time difference. By extracting this logic, we are able to test it independently from the API calls.
*DisplayTimeDifferenceMessage Method: This method isolates the logic for displaying time difference messages, making it easy to test the method without having to rely on real date values.
*An Interface should have been created for the Client. It was not implemented to avoid complicating the change.
 
Q3. What types of automated tests, and test cases would you write to test
this application?
*Q3 Answer:
I implemented two types of automated tests: unit tests and integration tests. The unit tests focus on validating the logic within the TimeDifferenceEvaluator class, ensuring that its core functionality is quickly and efficiently tested. The integration test is designed specifically to verify connectivity to the Time API service, confirming that we can retrieve valid data from the service. By isolating connectivity in the integration test, I avoided duplicating scenarios already covered by the unit tests.
 
The following unit tests were written:
1. DisplayTimeDifferenceShouldReturnCorrectMessageWhenCanadaIsAheadOfUk
2. DisplayTimeDifferenceShouldReturnCorrectMessageWhenUkIsAheadOfCanada
3. FormatDateTimeShouldReturnFormattedDateTime
4. GetTimeDifferenceShouldReturnCorrect
 
Integration test:
1. VerifyThatTheUserCanGetTimeFromService
