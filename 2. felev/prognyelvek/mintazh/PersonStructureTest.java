import static check.CheckThat.*;
import static check.CheckThat.Condition.*;
import org.junit.jupiter.api.*;
import org.junit.jupiter.api.condition.*;
import org.junit.jupiter.api.MethodOrderer.*;
import check.*;

@TestMethodOrder(OrderAnnotation.class)
public class PersonStructureTest {
    @BeforeAll
    public static void init() {
        CheckThat.theClass("library.person.util.Person")
                 .thatIs(NOT_IMPLEMENTED, INSTANCE_LEVEL, VISIBLE_TO_ALL)
                 ;
    }

    @Test @DisabledIf(notApplicable) @Order(1_00)
    public void fieldName() {
        it.hasField("name: String")
          .thatIs(INSTANCE_LEVEL, NOT_MODIFIABLE, VISIBLE_TO_NONE);
    }

    @Test @DisabledIf(notApplicable) @Order(1_01)
    public void fieldAge() {
        it.hasField("age: int")
          .thatIs(INSTANCE_LEVEL, NOT_MODIFIABLE, VISIBLE_TO_NONE);
    }

    @Test @DisabledIf(notApplicable) @Order(2_00)
    public void constructor() {
        it.hasConstructor(withParams("name: String", "age: int"))
          .thatIs(VISIBLE_TO_ALL);
    }

    @Test @DisabledIf(notApplicable) @Order(3_00)
    public void methodGetName01() {
        it.hasMethod("getName", withNoParams())
          .thatIs(FULLY_IMPLEMENTED, INSTANCE_LEVEL, VISIBLE_TO_ALL)
          .thatReturns("String");
    }

    @Test @DisabledIf(notApplicable) @Order(3_01)
    public void methodGetAge02() {
        it.hasMethod("getAge", withNoParams())
          .thatIs(FULLY_IMPLEMENTED, INSTANCE_LEVEL, VISIBLE_TO_ALL)
          .thatReturns("int");
    }

}

