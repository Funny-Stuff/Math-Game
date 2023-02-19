/*   1. You need to create a Math game containing the 4 basic operations
 *   2. The divisions should result on INTEGERS ONLY and dividends should go from 0 to 100.
 *   3. Users should be presented with a menu to choose an operation
 *   4. You should record previous games in a List and there should be an option in the menu for the user to visualize a history of previous games.
 *   5. You don't need to record results on a database. Once the program is closed the results will be deleted.
 */
using System;
namespace MathGame;

public static class Program {
    private static Random random = new();
    public static void Main() {
        while (true) {
            RenderUI();
            var input = UISelection();
            var mode = GetGameMode(input);
            
            if (input is 6)
                Environment.Exit(0); // Exit

            GameInformation? currentGameInformation = null;
            switch (mode) {
                case GameMode.Addition:
                    currentGameInformation = Addition();
                    break;
                case GameMode.Subtract:
                    currentGameInformation = Subtract();
                    break;
                case GameMode.Divide:
                    currentGameInformation = Divide();
                    break;
                case GameMode.Multiply:
                    currentGameInformation = Multiply();
                    break;
                case GameMode.GameplayHistory:
                    GameState.Instance.PrintGameHistory();
                    break;
                default:
                    Console.WriteLine("Select a valid option.");
                    continue;
            }

            if (currentGameInformation == null)
                continue; // It's null, meaning it's PrintGameHistory()
            
            Console.WriteLine("Answer the following mathematical operation:");
            Console.Write($"{currentGameInformation} = ");

            var answerStr = Console.ReadLine();
            var result = -99999;
            if (answerStr == null || !int.TryParse(answerStr, out result) || result != currentGameInformation.GetAnswer()) {
                Console.WriteLine("Incorrect Answer :(");
                currentGameInformation.TryGuess(result);
                GameState.Instance.gameHistory.Add(currentGameInformation);
                continue;
            }
            Console.WriteLine("Correct Answer :)");
            currentGameInformation.TryGuess(result);

            GameState.Instance.gameHistory.Add(currentGameInformation);
            
            // TODO: Print game information and allow user to finish and answer game.
        }
    }

    private static GameInformation Divide() {
        int num1 = 1, num2 = 3;
        while (num1 % num2 != 0) { // Generate numbers until they result in zero, meaning it's an integer.
            num1 = random.Next(100);
            num2 = random.Next(100);
        }
        return new GameInformation(num1, num2, num1 / num2, GameMode.Divide);
    }

    private static GameInformation Multiply() {
        var num1 = random.Next(100);
        var num2 = random.Next(100);
        return new GameInformation(num1, num2, num1 * num2, GameMode.Multiply);
    }

    private static GameInformation Subtract() {
        var num1 = random.Next(100);
        var num2 = random.Next(100);
        return new GameInformation(num1, num2, num1 - num2, GameMode.Subtract);
    }

    private static GameInformation Addition() {
        var num1 = random.Next(100);
        var num2 = random.Next(100);
        return new GameInformation(num1, num2, num1 + num2, GameMode.Addition);
    }

    private static GameMode GetGameMode(int input) {
        return (GameMode)input;
    }

    /// <summary>
    /// Get the selection of the user in a safe and clean way.
    /// </summary>
    /// <returns>An integer obtained from the Standard input.</returns>
    private static int UISelection() {
        var number = 0;
        do {
            var str = Console.ReadLine();
            var success = int.TryParse(str, out number);

            if (success && number >= 1 || number <= 5)
                break;
            
            Console.WriteLine("Please give valid input, only numbers, and within the range of accepted numbers.");
        }
        while (true);

        return number;
    }

    private static void RenderUI() {
        Console.WriteLine("\t-- Math Game --");
        Console.WriteLine("1) Addition - Add one number and another.");
        Console.WriteLine("2) Subtraction - Subtract one number and another.");
        Console.WriteLine("3) Divide - Divide one number and another.");
        Console.WriteLine("4) Multiply - Multiply one number and another.");
        Console.WriteLine("5) History - Get the history of done operations.");
        Console.WriteLine("6) Exit - Exit this Console-Powered game.");
    }
}