package array.util.main;

import java.util.Scanner;
import java.util.Arrays;
import array.util.ArrayUtil;

public class Main {
    public static void main(String[] args) {
        System.out.println("Kérem adja meg a tömb hosszát: ");

        Scanner scanner = new Scanner(System.in);
        String arrayLenTxt = scanner.nextLine();

        int arrayLen = Integer.parseInt(arrayLenTxt);

        int[] array = new int[arrayLen];

        for (int i = 0; i < arrayLen; ++i) {
            array[i] = scanner.nextInt();
        }

        System.out.println(java.util.Arrays.toString(array));
        System.out.println("max: " + ArrayUtil.max(array));
        System.out.println("max2: " + ArrayUtil.max2(array));
        System.out.println("max2: " + ArrayUtil.max3(array));
        System.out.println("max2: " + ArrayUtil.max4(array));
        System.out.println("minMax: " + java.util.Arrays.toString(ArrayUtil.minMax(array)));
    }
}