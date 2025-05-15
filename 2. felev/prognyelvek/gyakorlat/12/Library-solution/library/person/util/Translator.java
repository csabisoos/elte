package library.person.util;

import library.book.Book;
import library.book.util.*;

public interface Translator {
    public abstract Book translate(Book book) throws UnknownLanguageException;
}