package famous.sequence;

import static check.CheckThat.*;
import static org.junit.jupiter.api.Assertions.*;
import org.junit.jupiter.api.*;
import org.junit.jupiter.api.condition.*;
import org.junit.jupiter.api.extension.*;
import org.junit.jupiter.params.*;
import org.junit.jupiter.params.provider.*;
import check.*;

public class TriangularNumbersTest {
    @Test
    public void testOne() {
        assertEquals(1, TriangularNumbers.getTriangularNumber(1));
    }

    @Test
    public void testTwo() {
        assertEquals(3, TriangularNumbers.getTriangularNumber(2));
    }

    @Test
    public void testThree() {
        assertEquals(6, TriangularNumbers.getTriangularNumber(3));
    }

    @Test
    public void testFour() {
        assertEquals(10, TriangularNumbers.getTriangularNumber(4));
    }
}