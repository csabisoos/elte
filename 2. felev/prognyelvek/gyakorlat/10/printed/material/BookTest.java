package printed.material;

import java.util.*;
import java.io.IOException;
import static check.CheckThat.*;
import static org.junit.jupiter.api.Assertions.*;
import org.junit.jupiter.api.*;
import org.junit.jupiter.api.condition.*;
import org.junit.jupiter.api.extension.*;
import org.junit.jupiter.params.*;
import org.junit.jupiter.params.provider.*;
import check.*;

import printed.material.Book;

public class BookTest{

    @ParameterizedTest(name = "Test0")
    @CsvSource(textBlock = """
        John Steinbeck, Of Mice and Men, 107
        Kozsik Tamás, Java programozás, 234
        Alan Alexander Milne, Winnie-the-Pooh, 145
    """)
    @DisableIfHasBadStructure
    public void Test0(String author, String title, int pageCount){
        Book book = new Book(author, title, pageCount);
        assertEquals(author, book.getAuthor());
        assertEquals(title, book.getTitle());
        assertEquals(pageCount, book.getPageCount());
        assertEquals(pageCount, book.getPrice());
    }

    @ParameterizedTest(name = "Test1")
    @CsvSource(textBlock = """
        John Steinbeck: Of Mice and Men; 107, John Steinbeck, Of Mice and Men, 107
        Kozsik Tamás: Java programozás; 234, Kozsik Tamás, Java programozás, 234
        Alan Alexander Milne: Winnie-the-Pooh; 145, Alan Alexander Milne, Winnie-the-Pooh, 145
    """)
    @DisableIfHasBadStructure
    public void Test1(String a, String author, String title, int pageCount){
        assertEquals(author, decode(a).getAuthor());
        assertEquals(title, decode(a).getTitle());
        assertEquals(pageCount, decode(a).getPageCount());
        assertEquals(pageCount, decode(a).getPrice());
    }
}