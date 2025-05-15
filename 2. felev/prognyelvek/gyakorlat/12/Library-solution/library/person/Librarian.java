package library.person;

import library.person.util.*;
import library.book.util.*;
import library.book.*;

import java.util.Arrays;

public class Librarian extends Person implements Translator {
    private final Language[] knownLanguages;

    public Librarian(String name, int age, Language... languages) {
        super(name, age);
        this.knownLanguages = Arrays.copyOf(languages, languages.length);
    }

    public Language[] getKnownLanguages() {
        return Arrays.copyOf(knownLanguages, knownLanguages.length);
    }

    @Override
    public Book translate(Book book) throws UnknownLanguageException {
        Language languageFrom = book.getLanguage();
        Language languageTo = Language.values()[(languageFrom.ordinal() + 1) % Language.values().length];

        for (Language knownLanguage : knownLanguages) {
            if (knownLanguage == languageTo) {
                return new Book(book, languageTo);
            }
        }

        throw new UnknownLanguageException();
    }
}