package text.util;

import org.junit.jupiter.api.*;
import static org.junit.jupiter.api.Assertions.*;
import java.util.*;

public class CharacterStatisticsTest {

    @Test
    public void testEmptyString() {
        CharacterStatistics stats = new CharacterStatistics("");
        assertEquals(0, stats.getCount('a'));
        assertEquals("", stats.toString());  
    }

    @Test
    public void testRepeatedCharacter() {
        CharacterStatistics stats = new CharacterStatistics("aaaaaaaa");
        assertEquals(8, stats.getCount('a'));  
        assertEquals("a(8)", stats.toString()); 
    }

    @Test
    public void testMixedCase() {
        CharacterStatistics stats = new CharacterStatistics("HgFeDcBa");
        assertEquals(1, stats.getCount('H'));
        assertEquals(1, stats.getCount('g'));
        assertEquals(1, stats.getCount('F'));
        assertEquals(1, stats.getCount('e'));
        assertEquals(1, stats.getCount('D'));
        assertEquals(1, stats.getCount('c'));
        assertEquals(1, stats.getCount('B'));
        assertEquals(1, stats.getCount('a'));

        String expected = "a(1) B(1) c(1) D(1) e(1) F(1) g(1) H(1)";
        assertEquals(expected, stats.toString());
    }


    @Test
    public void testSpecialCharacters() {
        CharacterStatistics stats = new CharacterStatistics("a?!_#@{}");
        assertEquals(1, stats.getCount('@'));
        assertEquals(1, stats.getCount('a'));
        assertEquals(1, stats.getCount('!'));
        assertEquals(1, stats.getCount('#'));
        assertEquals(1, stats.getCount('{'));
        assertEquals(1, stats.getCount('}'));
        assertEquals(1, stats.getCount('?'));
        assertEquals(1, stats.getCount('_'));

        String expected = "@(1) a(1) !(1) #(1) {(1) }(1) ?(1) _(1)";
        assertEquals(expected, stats.toString());
    }

    @Test
    public void testHelloWorld() {
        CharacterStatistics stats = new CharacterStatistics("Hello world!");
        assertEquals(1, stats.getCount('H'));
        assertEquals(1, stats.getCount('e'));
        assertEquals(3, stats.getCount('l'));
        assertEquals(2, stats.getCount('o'));
        assertEquals(1, stats.getCount('w'));
        assertEquals(1, stats.getCount('r'));
        assertEquals(1, stats.getCount('d'));
        assertEquals(1, stats.getCount('!'));

        String expected = "(1) !(1) r(1) d(1) e(1) w(1) H(1) l(3) o(2)";
        assertEquals(expected, stats.toString());
    }
}