namespace MathGame;

public static class Extensions {
    public static string IntoOperator(this GameMode mode) {
        return mode switch {
            GameMode.Addition => "+",
            GameMode.Subtract => "-",
            GameMode.Divide => "/",
            GameMode.Multiply => "*",
            GameMode.GameplayHistory => "Unknown",
            _ => "Unknown"
        };
    }
}