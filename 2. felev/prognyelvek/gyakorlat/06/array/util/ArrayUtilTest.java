package array.util;

import static check.CheckThat.*;
import static org.junit.jupiter.api.Assertions.*;
import org.junit.jupiter.api.*;
import org.junit.jupiter.api.condition.*;
import org.junit.jupiter.api.extension.*;
import org.junit.jupiter.params.*;
import org.junit.jupiter.params.provider.*;
import check.*;

public class ArrayUtilTest {
    @Test
    public void maxLength0() {
        assertEquals(0, array.util.ArrayUtil.max(new int[0]));
        assertEquals(0, array.util.ArrayUtil.max2(new int[0]));
        assertEquals(0, array.util.ArrayUtil.max3(new int[0]));
        assertEquals(0, array.util.ArrayUtil.max4(new int[0]));
    }

    @ParameterizedTest
    @CsvSource(textBlock = """
        0
        1
        999999
        -999999
    """)
    @DisableIfHasBadStructure
    public void maxLength1(int par) {
        assertAll(
            () -> assertEquals(par, array.util.ArrayUtil.max(new int[] {par})),
            () -> assertEquals(par, array.util.ArrayUtil.max2(new int[] {par})),
            () -> assertEquals(par, array.util.ArrayUtil.max3(new int[] {par})),
            () -> assertEquals(par, array.util.ArrayUtil.max4(new int[] {par}))
        );
        /* assertEquals(par, array.util.ArrayUtil.max(new int[] {par}));
        assertEquals(par, array.util.ArrayUtil.max2(new int[] {par}));
        assertEquals(par, array.util.ArrayUtil.max3(new int[] {par}));
        assertEquals(par, array.util.ArrayUtil.max4(new int[] {par})); */
    }

    @ParameterizedTest
    @CsvSource(textBlock = """
        -1, 1
    """)
    @DisableIfHasBadStructure
    public void maxLength2(int min, int max) {
        assertEquals(max, array.util.ArrayUtil.max(new int[] {min, max}));
        assertEquals(max, array.util.ArrayUtil.max2(new int[] {min, max}));
        assertEquals(max, array.util.ArrayUtil.max3(new int[] {min, max}));
        assertEquals(max, array.util.ArrayUtil.max4(new int[] {min, max}));

        assertEquals(max, array.util.ArrayUtil.max(new int[] {max, min}));
        assertEquals(max, array.util.ArrayUtil.max2(new int[] {max, min}));
        assertEquals(max, array.util.ArrayUtil.max3(new int[] {max, min}));
        assertEquals(max, array.util.ArrayUtil.max4(new int[] {max, min}));
    }
}