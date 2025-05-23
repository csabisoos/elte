import static check.CheckThat.*;
import static check.CheckThat.Condition.*;
import org.junit.jupiter.api.*;
import org.junit.jupiter.api.condition.*;
import org.junit.jupiter.api.MethodOrderer.*;
import check.*;

@TestMethodOrder(OrderAnnotation.class)
public class LibraryTestStructureTest {
    @BeforeAll
    public static void init() {
        CheckThat.theClass("library.test.LibraryTest")
                 .thatIs(FULLY_IMPLEMENTED, INSTANCE_LEVEL, VISIBLE_TO_ALL)
                 ;
    }

    @Test @DisabledIf(notApplicable) @Order(3_00)
    public void methodTestLibraryConstructor01() {
        it.hasMethod("testLibraryConstructor", withNoParams())
          .thatIs(FULLY_IMPLEMENTED, INSTANCE_LEVEL, VISIBLE_TO_ALL)
          .thatReturnsNothing();
    }

    @Test @DisabledIf(notApplicable) @Order(3_01)
    public void methodTestPlaceBook02() {
        it.hasMethod("testPlaceBook", withParams("expectedBookCount: int", "bookCountToPlaceInLibrary: int"))
          .thatIs(FULLY_IMPLEMENTED, INSTANCE_LEVEL, VISIBLE_TO_ALL)
          .thatReturnsNothing();
    }

    @Test @DisabledIf(notApplicable) @Order(3_02)
    public void methodTestRentBook03() {
        it.hasMethod("testRentBook", withParams("expectedBookCount: int", "bookCountToPlaceInLibrary: int", "rentCount: int"))
          .thatIs(FULLY_IMPLEMENTED, INSTANCE_LEVEL, VISIBLE_TO_ALL)
          .thatReturnsNothing();
    }

    @Test @DisabledIf(notApplicable) @Order(3_03)
    public void methodTestEmptyLibraryRentBook04() {
        it.hasMethod("testEmptyLibraryRentBook", withNoParams())
          .thatIs(FULLY_IMPLEMENTED, INSTANCE_LEVEL, VISIBLE_TO_ALL)
          .thatReturnsNothing();
    }

    @Test @DisabledIf(notApplicable) @Order(3_04)
    public void methodTestBookOrder05() {
        it.hasMethod("testBookOrder", withNoParams())
          .thatIs(FULLY_IMPLEMENTED, INSTANCE_LEVEL, VISIBLE_TO_ALL)
          .thatReturnsNothing();
    }

    @Test @DisabledIf(notApplicable) @Order(3_05)
    public void methodTestBookOrderAfterRent06() {
        it.hasMethod("testBookOrderAfterRent", withNoParams())
          .thatIs(FULLY_IMPLEMENTED, INSTANCE_LEVEL, VISIBLE_TO_ALL)
          .thatReturnsNothing();
    }

}

