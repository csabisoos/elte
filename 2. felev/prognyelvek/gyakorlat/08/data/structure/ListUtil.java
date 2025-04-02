package data.structure;

import java.util.*;

public class ListUtil {
    public static ArrayList<Integer> divisors(int n) {
        ArrayList<Integer> result = new ArrayList<>();
        if (n == 0) {
            return result;
        }
        for (int i = 1; i <= n; i++) {
            if (n % i == 0) {
                result.add(i);
            }
        }
        return result;
    }

    public static ArrayList<String> withSameStartEnd(ArrayList<String> list) {
        ArrayList<String> result = new ArrayList<>();
        for (String s : list) {
            if (s != null && !s.isEmpty() && s.charAt(0) == s.charAt(s.length() - 1)) {
                result.add(s);
            }
        }
        return result;
    }

    public static void maxToFront(ArrayList<String> list) {
        if (list == null || list.isEmpty()) return;

        String maxStr = Collections.max(list);
        
        list.remove(maxStr);
        list.add(0, maxStr);
    }
}