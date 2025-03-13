package math.operation.safe;

import static check.CheckThat.*;
import static org.junit.jupiter.api.Assertions.*;
import org.junit.jupiter.api.*;
import org.junit.jupiter.api.condition.*;
import org.junit.jupiter.api.extension.*;
import org.junit.jupiter.params.*;
import org.junit.jupiter.params.provider.*;
import check.*;

public class IncrementTest {
    @Test
    public void testOne() {
        assertEquals(1, Increment.increment(0));
    }

    @Test
    public void testTwo() {
        assertEquals(Integer.MIN_VALUE + 1, Increment.increment(Integer.MIN_VALUE));
    }

    @Test
    public void testThree() {
        assertEquals(Integer.MAX_VALUE, Increment.increment(Integer.MAX_VALUE));
    }

    @Test
    public void testFour() {
        assertEquals(2346, Increment.increment(2345));
    }

    @Test
    public void testFive() {
        assertEquals(-1233, Increment.increment(-1234));
    }

    @Test
    public void testSix() {
        assertEquals(0, Increment.increment(-1));
    }
}