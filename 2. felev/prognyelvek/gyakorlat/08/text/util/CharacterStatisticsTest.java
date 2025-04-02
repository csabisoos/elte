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
        assertEquals("a: 8", stats.toString());
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
    
        String expected = "H: 1\ng: 1\nF: 1\ne: 1\nD: 1\nc: 1\nB: 1\na: 1";
        assertTrue(stats.toString().contains("H: 1"));
        assertTrue(stats.toString().contains("g: 1"));
        assertTrue(stats.toString().contains("F: 1"));
        assertTrue(stats.toString().contains("e: 1"));
        assertTrue(stats.toString().contains("D: 1"));
        assertTrue(stats.toString().contains("c: 1"));
        assertTrue(stats.toString().contains("B: 1"));
        assertTrue(stats.toString().contains("a: 1"));
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

        String expected = "@: 1\na: 1\n!: 1\n#: 1\n{: 1\n}: 1\n?: 1\n_: 1";
        assertTrue(stats.toString().contains("@: 1"));
        assertTrue(stats.toString().contains("a: 1"));
        assertTrue(stats.toString().contains("!: 1"));
        assertTrue(stats.toString().contains("#: 1"));
        assertTrue(stats.toString().contains("{: 1"));
        assertTrue(stats.toString().contains("}: 1"));
        assertTrue(stats.toString().contains("?: 1"));
        assertTrue(stats.toString().contains("_: 1"));
    }

    @Test
    public void testHelloWorld() {
        CharacterStatistics stats = new CharacterStatistics("Hello world!");
        assertEquals(1, stats.getCount('H'));
        assertEquals(1, stats.getCount('e'));
        assertEquals(1, stats.getCount('l'));
        assertEquals(3, stats.getCount('l'));  
        assertEquals(2, stats.getCount('o'));
        assertEquals(1, stats.getCount('w'));
        assertEquals(1, stats.getCount('r'));
        assertEquals(1, stats.getCount('d'));
        assertEquals(1, stats.getCount('!'));

        String expected = "H: 1\ne: 1\nl: 3\no: 2\nw: 1\nr: 1\nd: 1: 1";
        assertTrue(stats.toString().contains("H: 1"));
        assertTrue(stats.toString().contains("e: 1"));
        assertTrue(stats.toString().contains("l: 3"));
        assertTrue(stats.toString().contains("o: 2"));
        assertTrue(stats.toString().contains("w: 1"));
        assertTrue(stats.toString().contains("r: 1"));
        assertTrue(stats.toString().contains("d: 1"));
        assertTrue(stats.toString().contains("!: 1"));
    }
}