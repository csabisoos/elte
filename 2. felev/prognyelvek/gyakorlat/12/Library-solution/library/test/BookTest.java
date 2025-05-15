package library.test;

import static org.junit.jupiter.api.Assertions.*;
import org.junit.jupiter.api.*;
import org.junit.jupiter.params.*;
import org.junit.jupiter.params.provider.*;

import library.book.*;
import library.book.util.*;

public class BookTest {
    @Test
    public void testBookConstructor() {
        Book book = new Book("J. R. R. Tolkien", "The Hobbit", 310, "George Allen & Unwin", Language.ENGLISH);

        assertEquals("J. R. R. Tolkien", book.getAuthor());
        assertEquals("The Hobbit", book.getTitle());
        assertEquals(310, book.getPages());
        assertEquals("George Allen & Unwin", book.getPublisher());
        assertEquals(Language.ENGLISH, book.getLanguage());
    }

    @Test
    public void testBookText() {
        Book book = new Book("J. R. R. Tolkien", "The Hobbit", 310, "George Allen & Unwin", Language.ENGLISH);
        String expected = "Author: J. R. R. Tolkien\nTitle: The Hobbit\nPages: 310\nPublisher: George Allen & Unwin\nLanguage: ENGLISH";

        assertEquals(expected, book.toString());
    }

    @Test
    public void testBookEquals() {
        Book book1 = new Book("J. R. R. Tolkien", "The Hobbit", 0, "George Allen & Unwin", Language.ENGLISH);
        Book book2 = new Book("J. R. R. Tolkien", "The Hobbit", 310, "George Allen & Unwin", Language.ENGLISH);

        assertTrue(book1.equals(book2));
    }

    @Test
    public void testBookNotEquals() {
        Book book1 = new Book("J. R. R. Tolkien", "The Hobbit", 0, "George Allen & Unwin", Language.ENGLISH);
        Book book2 = new Book("J. R. R. Tolkien", "The", 310, "George Allen & Unwin", Language.ENGLISH);

        assertFalse(book1.equals(book2));
    }
}