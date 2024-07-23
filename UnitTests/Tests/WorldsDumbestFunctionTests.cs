
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


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
