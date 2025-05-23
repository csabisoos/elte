import static check.CheckThat.*;
import static check.CheckThat.Condition.*;
import org.junit.jupiter.api.*;
import org.junit.jupiter.api.condition.*;
import org.junit.jupiter.api.MethodOrderer.*;
import check.*;

@TestMethodOrder(OrderAnnotation.class)
public class LibrarianStructureTest {
    @BeforeAll
    public static void init() {
        CheckThat.theClass("library.person.Librarian", withParent("library.person.util.Person"), withInterface("library.person.util.Translator"))
                 .thatIs(FULLY_IMPLEMENTED, INSTANCE_LEVEL, VISIBLE_TO_ALL)
                 ;
    }

    @Test @DisabledIf(notApplicable) @Order(1_00)
    public void fieldKnownLanguages() {
        it.hasField("knownLanguages: array of library.book.util.Language")
          .thatIs(INSTANCE_LEVEL, NOT_MODIFIABLE, VISIBLE_TO_NONE);
    }

    @Test @DisabledIf(notApplicable) @Order(2_00)
    public void constructor() {
        it.hasConstructor(withParams("name: String", "age: int", "languages: vararg of library.book.util.Language"))
          .thatIs(VISIBLE_TO_ALL);
    }

    @Test @DisabledIf(notApplicable) @Order(3_00)
    public void methodGetKnownLanguages01() {
        it.hasMethod("getKnownLanguages", withNoParams())
          .thatIs(FULLY_IMPLEMENTED, INSTANCE_LEVEL, VISIBLE_TO_ALL)
          .thatReturns("array of library.book.util.Language");
    }

    @Test @DisabledIf(notApplicable) @Order(3_01)
    public void methodTranslate02() {
        it.implementsMethod("translate");
    }

}

