package library;

import java.util.*;

import library.book.*;
import library.book.util.*;
import library.person.*;
import library.person.util.*;

public class Library {
    private final Map<Character, List<Book>> capitalToBooks;

    public Library() {
        capitalToBooks = new HashMap<>();

        for (char c = 'A'; c <= 'Z'; c++) {
            capitalToBooks.put(c, new ArrayList<>());
        }
    }

    public Book rentBook(String author, String title, Language language) throws BookNotFoundException {
        Book tempBook = new Book(author, title, language);

        List<Book> shelf = getBooksWithCapital(tempBook);
        int idxOfBook = shelf.indexOf(tempBook);

        if (-1 != idxOfBook) {
            return shelf.remove(idxOfBook);
        }

        throw new BookNotFoundException();
    }

    public void placeBook(Book book) {
        List<Book> shelf = getBooksWithCapital(book);
        
        shelf.add(book);
        Collections.sort(shelf);

        // int i = 0;
        // for (i = 0; i < shelf.size() && book < shelf.get(i); ++i) {}
        // shelf.add(i, book);
    }

    public List<Book> getBooksWithCapital(Book book) {
        String author = book.getAuthor();
        char capital = Character.toUpperCase(author.charAt(0));

        return capitalToBooks.get(capital);
    }

    public int getBookCount() {
        int sum = 0;

        for (Map.Entry<Character, List<Book>> entry : capitalToBooks.entrySet()) {
            sum += entry.getValue().size();
        }

        return sum;
    }
}