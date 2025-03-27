package text.to.numbers;

import java.io.IOException;

import static check.CheckThat.*;
import static org.junit.jupiter.api.Assertions.*;
import org.junit.jupiter.api.*;
import org.junit.jupiter.api.condition.*;
import org.junit.jupiter.api.extension.*;
import org.junit.jupiter.params.*;
import org.junit.jupiter.params.provider.*;
import check.*;

public class MultiLineFileTest {
    @Test
    public void noFile() {
        assertThrows(IOException.class, () -> text.to.numbers.MultiLineFile.addNumbers("test.txt", ' '));
    }

    @Test
    public void correctFile() throws IOException {
        assertEquals(-117, text.to.numbers.MultiLineFile.addNumbers("./text/to/numbers/correcttest.txt", ' '));
    }

    @Test
    public void correctFile2() throws IOException {
        assertEquals(12, text.to.numbers.MultiLineFile.addNumbers("./text/to/numbers/correcttest2.txt", ','));
    }
}