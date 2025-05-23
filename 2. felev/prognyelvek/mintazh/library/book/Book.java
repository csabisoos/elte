package library.book;

import library.book.util.Language;

public class Book{
    // Fields 
    private final String author;
    private final String title;
    private final int pages;
    private final String publisher;
    private final Language language;
    
    // Constructors
    public Book(String author, String title, int pages, String publisher, Language language) {
        this.author = author;
        this.title = title;
        this.pages = pages;
        this.publisher = publisher;
        this.language = language;
    }

    public Book(String author, String title, Language language){
        this(author, title, 0, "", language);
    }

    public Book(Book book, Language language){
        this(book.author, book.title, book.pages, book.publisher, language);
    }

    // Methods
    public String getAuthor(){
        return author;
    }

    public String getTitle(){
        return title;
    }

    public int getPages(){
        return pages;
    }

    public String getPublisher(){
        return publisher;
    }

    public Language getLanguage(){
        return language;
    }

    @Override
    public String toString(){
        return "Author: %s\nTitle: %s\nPages: %d\nPublisher: %s\nLanguage: %s".formatted(author, title, pages, publisher, language);
    }

    @Override
    public boolean equals(Object obj){
        if (obj instanceof Book other){
            return this.author.equals(other.author) &&
                    this.title.equals(other.title) &&
                    this.language.equals(other.language);
        }
        return false;
    }

    @Override
    public int hashCode(){
        return Objects.hash(author, title, language);
    }

    @Override
    public int compareTo(Book other) {
        if (this.author.compareTo(other.author) == 0) {
            if (this.title.compareTo(other.title) == 0) {
                return this.language.ordinal() - other.language.ordinal();
            }
            else {
                return this.title.compareTo(other.title);
            }
        }
        else {
            return this.author.compareTo(other.author);
        }
    }
}