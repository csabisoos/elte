package famous.sequence;

import static check.CheckThat.*;
import static org.junit.jupiter.api.Assertions.*;
import org.junit.jupiter.api.*;
import org.junit.jupiter.api.condition.*;
import org.junit.jupiter.api.extension.*;
import org.junit.jupiter.params.*;
import org.junit.jupiter.params.provider.*;
import check.*;

public class FibonacciTest {
    @Test
    public void testOne() {
        assertEquals(1, Fibonacci.fib(1));
    }

    @Test
    public void testTwo() {
        assertEquals(1, Fibonacci.fib(2));
    }

    @Test
    public void testThree() {
        assertEquals(2, Fibonacci.fib(3));
    }

    @Test
    public void testFour() {
        assertEquals(3, Fibonacci.fib(4));
    }

    @Test
    public void test(int input, int expected) {
        assertEquals(expected, Fibonacci.fib(input));
    }
}