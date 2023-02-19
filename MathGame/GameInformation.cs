namespace MathGame; 

public class GameInformation {
    public GameInformation(int number1, int number2, int operationResult, GameMode operation) {
        if (operation == GameMode.GameplayHistory)
            throw new ArgumentException($"The enumerator {nameof(GameMode.GameplayHistory)} is not valid for {nameof(GameInformation)} data structures!");
        
        _operationNumbers = new[] { number1, number2 };
        _result = operationResult;
        _gameMode = operation;
    }

    private bool _guessed = false;
    private readonly GameMode _gameMode;
    private int _result;
    private int _playerGuess;
    private int[] _operationNumbers;
    public override string ToString() {
        return $"{_operationNumbers[0]} {_gameMode.IntoOperator()} {_operationNumbers[1]}";
    }

    public string GetOperationWithResult() {
        return $"{this} = {_result}";
    }

    public bool TryGuess(int result) {
        _guessed = _result == result;
        _playerGuess = result;
        return _guessed;
    }

    public bool GuessStatus() {
        return TryGuess(GetGuess());
    }
    public int GetGuess() {
        return _playerGuess;
    }

    public int GetAnswer() {
        return _result;
    }
}