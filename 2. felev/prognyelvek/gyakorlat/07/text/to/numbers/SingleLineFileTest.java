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

public class SingleLineFileTest {
    @Test
    public void noFile() {
        assertThrows(IOException.class, () -> text.to.numbers.SingleLineFile.addNumbers("test.txt"));
    }

    @Test
    public void emptyFile() {
        assertThrows(IllegalArgumentException.class, () -> text.to.numbers.SingleLineFile.addNumbers("./text/to/numbers/emptytest.txt"));
    }

    @Test
    public void correctFile() throws IOException{
        assertEquals(-117, text.to.numbers.SingleLineFile.addNumbers("./text/to/numbers/correcttest.txt"));
    }
}