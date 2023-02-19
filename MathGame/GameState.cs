namespace MathGame;

public class GameState {
    public static GameState Instance = new(); // Singleton.
    /// <summary>
    /// The history of the game.
    /// </summary>
    public List<GameInformation> gameHistory;

    private GameState() {
        gameHistory = new();
    }

    public void PrintGameHistory() {
        for (var i = 0; i < gameHistory.Count; i++) {
            var infoGame = gameHistory[i];
            var answerStatus = infoGame.GuessStatus() ? "correct!" : "incorrect";
            Console.WriteLine($"Game {i + 1}/{gameHistory.Count}");
            Console.WriteLine($"{infoGame.ToString()} = ?");
            Console.Write($"Player answered with {infoGame.GetGuess()}, this answer was {answerStatus}");
            if (!infoGame.GuessStatus())
                Console.Write($", The correct answer was {infoGame.GetAnswer()}!");
            Console.WriteLine("\n----------------------------------------------");
        }
    }
}