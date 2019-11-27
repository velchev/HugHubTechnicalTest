# Instructions:

- The attached solution has a class called PriceEngine. Its job is to take input from the user, retrieve price quotes based on that data from 3 external systems and return the best one.
- Apply SOLID and DDD to refactor the class to make it more readable, testable, configurable and extensible.
- Fix any bugs or code smells that you see
- Add tests
 

## Notes:

- ExpandoObjects and dynamic were used for class declarations, where implementation details aren’t relevant for this task (requests and responses for external systems).
- Some code was snipped to keep the task small, instead there’s a comment of what happens there.
- The solution is open ended, but we expect most people to spend no more than 1-2 hours on it. It doesn’t need to be perfect or complete, just demonstrating the main concepts is enough. We will go through the test during the interview, so you will have a chance to talk through anything else that could be done with more time.


# Some notes for the reviewers.
- Before starting refactoring I have added test to prevent refactoring which changes the system. (BlackBoxTests_To_Verify_The_System_Before_Refactoring.cs)
- I have used Rules pattern to refactor the code. Every QuotationSystem is a rule which is run by the Price Engine. The Rules are defined and injected in Program.cs - main method. There could be added another level of abstraction if needed, but I thought for the example that is enough.
- I have added new QuotationSystem4 class to prove how easily the system can be extended.
- I have demonstrated the way the tests should be implemented, next step will be to add and configure IoC container so that dependency injection is not done manually.
- Following DDD principle QuotationSystems classes have domain knowledge in them. Only in QuotationSystem2 I have demonstrated call to external service. The principle is the same - we can mock the response from the service to test the QuotationSystem2 in isolation. Instead of dynamic using for request and response I have added Dtos for this - just to demonstrate how will be in actual system.
- I have added Option class which is used to avoid null results.
- Entering the user data is done by RiskDataConsoleInputReader class but for the purpose of the test I have used another implementation of IRiskDataConsoleInputReader -> RiskDataConsoleInputReaderStub just to get the data without User Input.
- Tests are started - not complete. They demonstrate testing different parts of the solution, but can be continued and completed once IoC conttainer is introduced. I think this is out of scope for this technical test as needed time is expected to be 1 to 2 hours.
