package printed.material;

public class Book {
    // Fields
    public static final String defaultAuthor = "John Steinbeck";
    public static final String defaultTitle = "Of Mice and Men";
    public static final int defaultPageCount = 107;
    private String author;
    private String title;
    protected  int pageCount;

    // Properties
    public String getAuthor(){
        return author;
    }
    public String getTitle(){
        return title;
    }
    public int getPageCount(){
        return pageCount;
    }

    // Constructors
    public Book(){
        initBook(defaultAuthor, defaultTitle, defaultPageCount);
    }
    public Book(String author, String title, int pageCount){
        try {
            checkInitData(author, title, pageCount);
        }
        catch (Exception e) {
            throw e;
        }
        initBook(author, title, pageCount);
    }

    // Methods
    private void checkInitData(String author, String title, int pageCount){
        if (author.length() < 2 || title.length() < 4 || pageCount < 1){
            throw new IllegalArgumentException();
        }
    }

    public String createReference(String a, int b, int c){
        return "";
    }

    public static Book decode(String a){
        String[] elso = a.split(": ");
        String[] masodik = elso[1].split("; ");
        int pageCount = Integer.parseInt(masodik[1]);
        return new Book(elso[0], masodik[0], pageCount);
    }

    protected String getAuthorWithInitials(){
        return author[0] + ". " + author[1];
    }

    public int getPrice(){
        return pageCount;
    }

    public String getShortInfo(){
        return "";
    }

    protected void initBook(String author, String title, int pageCount){
        this.author = author;
        this.title = title;
        this.pageCount = pageCount;
    }

    @Override
    public String toString() {
        return author + ": " + title + "; " + pageCount;
    }

}