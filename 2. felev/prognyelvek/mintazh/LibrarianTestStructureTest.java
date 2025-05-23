import static check.CheckThat.*;
import static check.CheckThat.Condition.*;
import org.junit.jupiter.api.*;
import org.junit.jupiter.api.condition.*;
import org.junit.jupiter.api.MethodOrderer.*;
import check.*;

@TestMethodOrder(OrderAnnotation.class)
public class LibrarianTestStructureTest {
    @BeforeAll
    public static void init() {
        CheckThat.theClass("library.test.LibrarianTest")
                 .thatIs(FULLY_IMPLEMENTED, INSTANCE_LEVEL, VISIBLE_TO_ALL)
                 ;
    }

    @Test @DisabledIf(notApplicable) @Order(3_00)
    public void methodTestLibrarianConstructor01() {
        it.hasMethod("testLibrarianConstructor", withNoParams())
          .thatIs(FULLY_IMPLEMENTED, INSTANCE_LEVEL, VISIBLE_TO_ALL)
          .thatReturnsNothing();
    }

    @Test @DisabledIf(notApplicable) @Order(3_01)
    public void methodTestKnownLanguages02() {
        it.hasMethod("testKnownLanguages", withNoParams())
          .thatIs(FULLY_IMPLEMENTED, INSTANCE_LEVEL, VISIBLE_TO_ALL)
          .thatReturnsNothing();
    }

    @Test @DisabledIf(notApplicable) @Order(3_02)
    public void methodTestTranslate03() {
        it.hasMethod("testTranslate", withParams("languageFrom: String", "languageTo: String"))
          .thatIs(FULLY_IMPLEMENTED, INSTANCE_LEVEL, VISIBLE_TO_ALL)
          .thatReturnsNothing();
    }

    @Test @DisabledIf(notApplicable) @Order(3_03)
    public void methodTestTranslateUnknownLanguage04() {
        it.hasMethod("testTranslateUnknownLanguage", withNoParams())
          .thatIs(FULLY_IMPLEMENTED, INSTANCE_LEVEL, VISIBLE_TO_ALL)
          .thatReturnsNothing();
    }

}

