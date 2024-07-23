
namespace UnitTests.Tests
{
    public static class WorldsDumbestFunctionTests
    {
        //Naming Convention - ClassName_MethodName_ExpectedResult
        public static void WorldsDumbestFunction_ReturnsDumbThingsIfZero_ReturnString()
        {
            try
            {
                //Arrange - Get your variables, classes, functions
                int num = 0;
                WorldsDumbestFunction dumbFunction = new WorldsDumbestFunction();

                //Act - Execute the function
                string result = dumbFunction.ReturnsDumbThingsIfZero(num);

                //Assert - What should the result be
                if (result == "This Is Dumb")
                {
                    Console.WriteLine("PASSED: WorldsDumbestFunction_ReturnsDumbThingsIfZero_ReturnString");
                }
                else
                {
                    Console.WriteLine("FAILED: WorldsDumbestFunction_ReturnsDumbThingsIfZero_ReturnString");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
