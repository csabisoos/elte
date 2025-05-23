import static check.CheckThat.*;
import static check.CheckThat.Condition.*;
import org.junit.jupiter.api.*;
import org.junit.jupiter.api.condition.*;
import org.junit.jupiter.api.MethodOrderer.*;
import check.*;

@TestMethodOrder(OrderAnnotation.class)
public class BookNotFoundExceptionStructureTest {
    @BeforeAll
    public static void init() {
        CheckThat.theCheckedException("library.book.util.BookNotFoundException")
                 .thatIs(FULLY_IMPLEMENTED, INSTANCE_LEVEL, VISIBLE_TO_ALL)
                 ;
    }

}

