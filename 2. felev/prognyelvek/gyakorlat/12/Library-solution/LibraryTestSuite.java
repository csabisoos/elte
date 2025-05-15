import org.junit.platform.suite.api.SelectClasses;
import org.junit.platform.suite.api.Suite;

import library.test.BookTest;
import library.test.LibrarianTest;
import library.test.LibraryTest;

@SelectClasses({
      LibraryTestSuite.StructuralTests.class
    , LibraryTestSuite.FunctionalTests.class
})
@Suite public class LibraryTestSuite {
    @SelectClasses({
          LanguageStructureTest.class
        , BookNotFoundExceptionStructureTest.class
        , UnknownLanguageExceptionStructureTest.class

        , BookStructureTest.class

        , PersonStructureTest.class
        , TranslatorStructureTest.class

        , LibrarianStructureTest.class

        , LibraryStructureTest.class
    })
    @Suite public static class StructuralTests {}

    @SelectClasses({
          BookTest.class

        , LibrarianTest.class

        , LibraryTest.class
    })
    @Suite public static class FunctionalTests {}
}

