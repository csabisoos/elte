package printed.material;

import printed.material.Book;

public class BookCollection{
    // Fields 
    private ArrayList<Book> books = new ArrayList<>();


    // Properties
    public ArrayList<Book> getBooks(){
        return books;
    }

    // Constructors
    public BookCollection(){
        this.books = new ArrayList<Book>();
    }

    // Methods 
    public void add(Book[] books){
        for (Book book : books){
            this.books.add(book);
        }
    }

    public static BookCollection load(String filename){
        return new BookCollection();
    }

    public boolean save(String filename){
        return true;
    }

}