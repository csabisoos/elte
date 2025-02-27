package string.utils;

public class IterLetter {
    private String letter;
    private int ind;

    public IterLetter(String letter) {
        if (letter == null) {
            throw new IllegalArgumentException("Null parameter");
        }
        this.letter = letter;
        this.ind = 0;
    }

    public void printNext() {
        if (ind == letter.length()) {
            System.out.println();
        }
        else {
            System.out.println(letter.charAt(ind));
            ++ind;
        }
    }

    public void reset() {
        ind = 0;
    }

}