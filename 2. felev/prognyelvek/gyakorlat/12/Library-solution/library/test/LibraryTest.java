package library.test;

import static org.junit.jupiter.api.Assertions.*;
import org.junit.jupiter.api.*;
import org.junit.jupiter.params.*;
import org.junit.jupiter.params.provider.*;

import java.util.List;

import library.book.*;
import library.book.util.*;
import library.person.*;
import library.person.util.*;
import library.*;

public class LibraryTest {
    @Test
    public void testLibraryConstructor() {
        Library library = new Library();

        assertEquals(0, library.getBookCount());
    }

    @ParameterizedTest
    @CsvSource(textBlock="""
        3, 3
        5, 5
        12, 12
    """)
    public void testPlaceBook(int expectedBookCount, int bookCountToPlaceInLibrary) {
        Library library = new Library();

        for (int i = 0; i < bookCountToPlaceInLibrary; ++i) {
            library.placeBook(new Book("J. R. R. Tolkien", "The Hobbit", 310, "George Allen & Unwin", Language.ENGLISH));
        }

        assertEquals(expectedBookCount, library.getBookCount());
    }

    @ParameterizedTest
    @CsvSource(textBlock="""
         3,  5,  2
         5, 10,  5
        12, 35, 23
    """)
    public void testRentBook(int expectedBookCount, int bookCountToPlaceInLibrary, int rentCount) throws BookNotFoundException {
        Library library = new Library();

        for (int i = 0; i < bookCountToPlaceInLibrary; ++i) {
            library.placeBook(new Book("J. R. R. Tolkien", "The Hobbit", 310, "George Allen & Unwin", Language.ENGLISH));
        }
        
        for (int i = 0; i < rentCount; ++i) {
            library.rentBook("J. R. R. Tolkien", "The Hobbit", Language.ENGLISH);
        }

        assertEquals(expectedBookCount, library.getBookCount());
    }

    @Test
    public void testEmptyLibraryRentBook() {
        Library library = new Library();

        try {
            library.rentBook("J. R. R. Tolkien", "The Hobbit", Language.ENGLISH);
            fail();
        }
        catch (BookNotFoundException e) {}
    }

    @Test
    public void testBookOrder() {
        Book book1 = new Book("Author3", "Title1", Language.HUNGARIAN);
        Book book2 = new Book("Author2", "Title1", Language.ENGLISH);
        Book book3 = new Book("Author1", "Title3", Language.GERMAN);

        Library library = new Library();

        library.placeBook(book1);
        library.placeBook(book2);
        library.placeBook(book3);

        assertEquals(List.of(book3, book2, book1), library.getBooksWithCapital(book1));
    }

    @Test
    public void testBookOrderAfterRent() throws BookNotFoundException {
        Book book1 = new Book("Author3", "Title1", Language.HUNGARIAN);
        Book book2 = new Book("Author2", "Title1", Language.ENGLISH);
        Book book3 = new Book("Author1", "Title3", Language.GERMAN);

        Library library = new Library();

        library.placeBook(book1);
        library.placeBook(book2);
        library.placeBook(book3);

        assertEquals(List.of(book3, book2, book1), library.getBooksWithCapital(book1));

        library.rentBook("Author1", "Title3", Language.GERMAN);

        assertEquals(List.of(book2, book1), library.getBooksWithCapital(book1));
    }
}