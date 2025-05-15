package library.test;

import static org.junit.jupiter.api.Assertions.*;
import org.junit.jupiter.api.*;
import org.junit.jupiter.params.*;
import org.junit.jupiter.params.provider.*;

import library.book.*;
import library.book.util.*;
import library.person.*;
import library.person.util.*;

public class LibrarianTest {
    @Test
    public void testLibrarianConstructor() {
        Librarian librarian = new Librarian("Librarian1", 1, Language.ENGLISH, Language.GERMAN);

        assertEquals("Librarian1", librarian.getName());
        assertEquals(1, librarian.getAge());
    }
    
    @Test
    public void testKnownLanguages() {
        Librarian librarian = new Librarian("Librarian1", 1, Language.ENGLISH, Language.GERMAN);

        assertArrayEquals(new Language[] {Language.ENGLISH, Language.GERMAN}, 
                                          librarian.getKnownLanguages());
    }

    @ParameterizedTest
    @CsvSource(textBlock="""
        ENGLISH, HUNGARIAN
        HUNGARIAN, GERMAN
        GERMAN, ENGLISH
    """)
    public void testTranslate(String languageFrom, String languageTo) throws UnknownLanguageException {
        Librarian librarian = new Librarian("Librarian1", 1, Language.values());
        Book book = new Book("J. R. R. Tolkien", "The", 310, "George Allen & Unwin", Language.valueOf(languageFrom));

        assertEquals(Language.valueOf(languageTo), librarian.translate(book).getLanguage());
    }

    @Test
    public void testTranslateUnknownLanguage() {
        Librarian librarian = new Librarian("Librarian1", 1);
        Book book = new Book("J. R. R. Tolkien", "The", 310, "George Allen & Unwin", Language.ENGLISH);

        try {
            librarian.translate(book);
            fail();
            assertFalse(true);
        }
        catch (UnknownLanguageException e) {}
        catch (Exception e) {
            fail();
        }

        //assertThrows(UnknownLanguageException.class, () -> librarian.translate(book));
    }
}