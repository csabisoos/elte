package data.structure;

import org.junit.jupiter.api.*;
import static org.junit.jupiter.api.Assertions.*;
import java.util.*;

public class ListUtilTest {
    @Test
    public void testDivisors() {
        assertEquals(new ArrayList<>(), ListUtil.divisors(0));
        assertEquals(new ArrayList<>(List.of(1)), ListUtil.divisors(1));
        assertEquals(new ArrayList<>(List.of(1, 2, 4, 8, 16, 32, 64)), ListUtil.divisors(64));
    }

    @Test
    public void testWithSameStartEnd() {
        ArrayList<String> list = new ArrayList<>();

        assertEquals(new ArrayList<>(), ListUtil.withSameStartEnd(list));

        list.add("");
        assertEquals(new ArrayList<>(), ListUtil.withSameStartEnd(list));

        list.add(null);
        assertEquals(new ArrayList<>(), ListUtil.withSameStartEnd(list));

        list.add(" ");
        assertEquals(new ArrayList<>(List.of(" ")), ListUtil.withSameStartEnd(list));

        list.add("x");
        assertEquals(new ArrayList<>(List.of(" ", "x")), ListUtil.withSameStartEnd(list));

        list.add("");
        assertEquals(new ArrayList<>(List.of(" ", "x")), ListUtil.withSameStartEnd(list));

        list.add("different start and end?");
        assertEquals(new ArrayList<>(List.of(" ", "x")), ListUtil.withSameStartEnd(list));

        list.add("ends and starts the same");
        assertEquals(new ArrayList<>(List.of(" ", "x", "ends and starts the same")), ListUtil.withSameStartEnd(list));
    }

    @Test
    public void testMaxToFront() {
        ListUtil.maxToFront(null);

        ArrayList<String> emptyList = new ArrayList<>();
        ListUtil.maxToFront(emptyList);
        assertEquals(new ArrayList<>(), emptyList);

        ArrayList<String> singleElementList = new ArrayList<>(List.of("onlyOne"));
        ListUtil.maxToFront(singleElementList);
        assertEquals(List.of("onlyOne"), singleElementList);

        ArrayList<String> list1 = new ArrayList<>(List.of("can", "you", "succeed"));
        ListUtil.maxToFront(list1);
        assertEquals(List.of("you", "can", "succeed"), list1);

        ArrayList<String> list2 = new ArrayList<>(List.of("-123", "2000", "100"));
        ListUtil.maxToFront(list2);
        assertEquals(List.of("2000", "100", "-123"), list2);
    }
}