package text.util;

import java.util.*;

public class CharacterStatistics {
    private HashMap<Character, Integer> charToCount;

    public CharacterStatistics(String text) {
        charToCount = new HashMap<>();
        if (text != null) {
            for (char c : text.toCharArray()) {
                charToCount.put(c, charToCount.getOrDefault(c, 0) + 1);
            }
        }
    }

    public int getCount(char c) {
        return charToCount.getOrDefault(c, 0);
    }

    @Override
    public String toString() {
        StringBuilder result = new StringBuilder();
        for (Map.Entry<Character, Integer> entry : charToCount.entrySet()) {
            result.append(entry.getKey()).append(": ").append(entry.getValue()).append("\n");
        }
        return result.toString().trim();
    }
}