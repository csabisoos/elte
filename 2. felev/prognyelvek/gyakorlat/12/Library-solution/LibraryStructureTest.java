import static check.CheckThat.*;
import static check.CheckThat.Condition.*;
import org.junit.jupiter.api.*;
import org.junit.jupiter.api.condition.*;
import org.junit.jupiter.api.MethodOrderer.*;
import check.*;

@TestMethodOrder(OrderAnnotation.class)
public class LibraryStructureTest {
    @BeforeAll
    public static void init() {
        CheckThat.theClass("library.Library")
                 .thatIs(FULLY_IMPLEMENTED, INSTANCE_LEVEL, VISIBLE_TO_ALL)
                 ;
    }

    @Test @DisabledIf(notApplicable) @Order(1_00)
    public void fieldCapitalToBooks() {
        it.hasField("capitalToBooks: java.util.Map of Character to java.util.List of library.book.Book")
          .thatIs(INSTANCE_LEVEL, NOT_MODIFIABLE, VISIBLE_TO_NONE);
    }

    @Test @DisabledIf(notApplicable) @Order(2_00)
    public void constructor() {
        it.hasConstructor(withNoParams())
          .thatIs(VISIBLE_TO_ALL);
    }

    @Test @DisabledIf(notApplicable) @Order(3_00)
    public void methodRentBook01() {
        it.hasMethod("rentBook", withParams("author: String", "title: String", "language: library.book.util.Language"))
          .thatIs(FULLY_IMPLEMENTED, INSTANCE_LEVEL, VISIBLE_TO_ALL)
          .thatReturns("library.book.Book");
    }

    @Test @DisabledIf(notApplicable) @Order(3_01)
    public void methodPlaceBook02() {
        it.hasMethod("placeBook", withParams("book: library.book.Book"))
          .thatIs(FULLY_IMPLEMENTED, INSTANCE_LEVEL, VISIBLE_TO_ALL)
          .thatReturnsNothing();
    }

    @Test @DisabledIf(notApplicable) @Order(3_02)
    public void methodGetBooksWithCapital03() {
        it.hasMethod("getBooksWithCapital", withParams("book: library.book.Book"))
          .thatIs(FULLY_IMPLEMENTED, INSTANCE_LEVEL, VISIBLE_TO_ALL)
          .thatReturns("java.util.List of library.book.Book");
    }

    @Test @DisabledIf(notApplicable) @Order(3_03)
    public void methodGetBookCount04() {
        it.hasMethod("getBookCount", withNoParams())
          .thatIs(FULLY_IMPLEMENTED, INSTANCE_LEVEL, VISIBLE_TO_ALL)
          .thatReturns("int");
    }
}

