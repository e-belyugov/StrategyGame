namespace Sbt.Test.Refactoring.Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            TractorTest test = new TractorTest();
            
            test.TestShouldMoveForward();
            //test.TestShouldThrowExceptionIfFallsOffPlateau();
            //test.TestShouldTurn();
            //test.TestShouldTurnAndMoveInTheRightDirection();
        }
    }
}
