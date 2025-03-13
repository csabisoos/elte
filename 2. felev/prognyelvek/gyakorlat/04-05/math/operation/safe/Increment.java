package math.operation.safe;

public class Increment {
    public static int increment(int value) {
        return (value == Integer.MAX_VALUE) ? Integer.MAX_VALUE : value + 1;
    }
}