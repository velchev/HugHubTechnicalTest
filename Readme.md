# Some notes for the reviewers.
- Before starting refactoring I have added test to prevent refactoring which changes the system. (BlackBoxTests_To_Verify_The_System_Before_Refactoring.cs)
- I have used Rules pattern to refactor the code. Every QuotationSystem is a rule which is run by the Price Engine. The Rules are defined and injected in Program.cs - main method. There could be added another level of abstraction if needed, but I thought for the example that is enough.
- I have added new QuotationSystem4 class to prove how easily the system can be extended.
- I have demonstrated the way the tests should be implemented, next step will be to add and configure IoC container so that dependency injection is not done manually.
- Following DDD principle QuotationSystems classes have domain knowledge in them. Only in QuotationSystem2 I have demonstrated call to external service. The principle is the same - we can mock the response from the service to test the QuotationSystem2 in isolation. Instead of dynamic using for request and response I have added Dtos for this - just to demonstrate how will be in actual system.
- I have added Option class which is used to avoid null results.
- Entering the user data is done by RiskDataConsoleInputReader class but for the purpose of the test I have used another implementation of IRiskDataConsoleInputReader -> RiskDataConsoleInputReaderStub just to get the data without User Input.
- Tests are started - not complete. They demonstrate testing different parts of the solution, but can be continued and completed once IoC conttainer is introduced. I think this is out of scope for this technical test as needed time is expected to be 1 to 2 hours.
