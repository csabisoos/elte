import static check.CheckThat.*;
import static check.CheckThat.Condition.*;
import org.junit.jupiter.api.*;
import org.junit.jupiter.api.condition.*;
import org.junit.jupiter.api.MethodOrderer.*;
import check.*;

@TestMethodOrder(OrderAnnotation.class)
public class TranslatorStructureTest {
    @BeforeAll
    public static void init() {
        CheckThat.theInterface("library.person.util.Translator")
                 .thatIs(NOT_IMPLEMENTED, INSTANCE_LEVEL, VISIBLE_TO_ALL)
                 ;
    }

    @Test @DisabledIf(notApplicable) @Order(3_00)
    public void methodTranslate() {
        it.hasMethod("translate", withParams("book: library.book.Book"))
          .thatIs(NOT_IMPLEMENTED, INSTANCE_LEVEL, VISIBLE_TO_ALL)
          .thatReturns("library.book.Book");
    }

}

