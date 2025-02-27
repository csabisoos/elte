package string.main;

public class Main {
    public static void main(String[] args) {
        int len = Integer.parseInt(args[0]);
        string.utils.IterLetter text = new string.utils.IterLetter(args[1]);
        for (int i = 0; i< len; ++i) {
            //System.out.println(text.hasNext());
            text.printNext();
        }
    }
}