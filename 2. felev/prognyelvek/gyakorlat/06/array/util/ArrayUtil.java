package array.util;

public class ArrayUtil {

    public ArrayUtil() {

    }

    public static int max(int[] array) {
        if (array.length == 0) {
            return 0;
        }
        int max = Integer.MIN_VALUE;
        for (int i = 0; i < array.length; ++i) {
            if (max < array[i]) {
                max = array[i];
            }
        }
        return max;
    }

    public static int max2(int[] array) {
        if (array.length == 0) {
            return 0;
        }
        int max = Integer.MIN_VALUE;
        for (int i = 0; i < array.length; ++i) {
            max = (max < array[i]) ? array[i] : max;
        }
        return max;
    }

    public static int max3(int[] array) {
        if (array.length == 0) {
            return 0;
        }
        int max = Integer.MIN_VALUE;
        for (int i = 0; i < array.length; ++i) {
            max = Math.max(max, array[i]);
        }
        return max;
    }

    public static int max4(int[] array) {
        if (array.length == 0) {
            return 0;
        }
        int max = Integer.MIN_VALUE;
        for (int i : array) {
            if (max < i) {
                max = i;
            }
        }
        return max;
    }

    public static int[] minMax(int[] array) {
        if (array.length == 0) {
            return new int[] {0, 0};
        }
        int min = Integer.MIN_VALUE;
        int max = Integer.MAX_VALUE;
        for (int i : array) {
            if (max < i) max = i;
            if (i < min) min = i;
        }
        
        return new int[] {min, max};
    }
}