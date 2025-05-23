import static check.CheckThat.*;
import static check.CheckThat.Condition.*;
import org.junit.jupiter.api.*;
import org.junit.jupiter.api.condition.*;
import org.junit.jupiter.api.MethodOrderer.*;
import check.*;

@TestMethodOrder(OrderAnnotation.class)
public class BookStructureTest {
    @BeforeAll
    public static void init() {
        CheckThat.theClass("library.book.Book")
                 .thatIs(FULLY_IMPLEMENTED, INSTANCE_LEVEL, VISIBLE_TO_ALL)
                 ;
    }

    @Test @DisabledIf(notApplicable) @Order(1_00)
    public void fieldAuthor() {
        it.hasField("author: String")
          .thatIs(INSTANCE_LEVEL, NOT_MODIFIABLE, VISIBLE_TO_NONE);
    }

    @Test @DisabledIf(notApplicable) @Order(1_01)
    public void fieldTitle() {
        it.hasField("title: String")
          .thatIs(INSTANCE_LEVEL, NOT_MODIFIABLE, VISIBLE_TO_NONE);
    }

    @Test @DisabledIf(notApplicable) @Order(1_02)
    public void fieldPages() {
        it.hasField("pages: int")
          .thatIs(INSTANCE_LEVEL, NOT_MODIFIABLE, VISIBLE_TO_NONE);
    }

    @Test @DisabledIf(notApplicable) @Order(1_03)
    public void fieldPublisher() {
        it.hasField("publisher: String")
          .thatIs(INSTANCE_LEVEL, NOT_MODIFIABLE, VISIBLE_TO_NONE);
    }

    @Test @DisabledIf(notApplicable) @Order(1_04)
    public void fieldLanguage() {
        it.hasField("language: library.book.util.Language")
          .thatIs(INSTANCE_LEVEL, NOT_MODIFIABLE, VISIBLE_TO_NONE);
    }

    @Test @DisabledIf(notApplicable) @Order(2_00)
    public void constructor01() {
        it.hasConstructor(withParams("author: String", "title: String", "pages: int", "publisher: String", "language: library.book.util.Language"))
          .thatIs(VISIBLE_TO_ALL);
    }

    @Test @DisabledIf(notApplicable) @Order(2_01)
    public void constructor02() {
        it.hasConstructor(withParams("author: String", "title: String", "language: library.book.util.Language"))
          .thatIs(VISIBLE_TO_ALL);
    }

    @Test @DisabledIf(notApplicable) @Order(2_02)
    public void constructor03() {
        it.hasConstructor(withParams("book: Book", "language: library.book.util.Language"))
          .thatIs(VISIBLE_TO_ALL);
    }

    @Test @DisabledIf(notApplicable) @Order(3_00)
    public void methodGetAuthor01() {
        it.hasMethod("getAuthor", withNoParams())
          .thatIs(FULLY_IMPLEMENTED, INSTANCE_LEVEL, VISIBLE_TO_ALL)
          .thatReturns("String");
    }

    @Test @DisabledIf(notApplicable) @Order(3_01)
    public void methodGetTitle02() {
        it.hasMethod("getTitle", withNoParams())
          .thatIs(FULLY_IMPLEMENTED, INSTANCE_LEVEL, VISIBLE_TO_ALL)
          .thatReturns("String");
    }

    @Test @DisabledIf(notApplicable) @Order(3_02)
    public void methodGetPages03() {
        it.hasMethod("getPages", withNoParams())
          .thatIs(FULLY_IMPLEMENTED, INSTANCE_LEVEL, VISIBLE_TO_ALL)
          .thatReturns("int");
    }

    @Test @DisabledIf(notApplicable) @Order(3_03)
    public void methodGetPublisher04() {
        it.hasMethod("getPublisher", withNoParams())
          .thatIs(FULLY_IMPLEMENTED, INSTANCE_LEVEL, VISIBLE_TO_ALL)
          .thatReturns("String");
    }

    @Test @DisabledIf(notApplicable) @Order(3_04)
    public void methodGetLanguage05() {
        it.hasMethod("getLanguage", withNoParams())
          .thatIs(FULLY_IMPLEMENTED, INSTANCE_LEVEL, VISIBLE_TO_ALL)
          .thatReturns("library.book.util.Language");
    }

    @Test @DisabledIf(notApplicable)
    public void text() {
        it.has(TEXTUAL_REPRESENTATION);
    }

    @Test @DisabledIf(notApplicable)
    public void eq() {
        it.has(EQUALITY_CHECK);
    }

    @Test @DisabledIf(notApplicable)
    public void naturalOrder() {
        it.has(NATURAL_ORDERING);
    }
}

