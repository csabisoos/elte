package text.to.numbers;

import java.io.IOException;
import java.io.FileReader;
import java.io.BufferedReader;

public class SingleLineFile{
    public SingleLineFile(){}

    public static int addNumbers(String path) throws IOException{
        int sum = 0;
        try (BufferedReader br = new BufferedReader(new FileReader(path))) {
            if (!br.ready()) {
                throw new IllegalArgumentException("Empty file");
            }

            String line = br.readLine();
            String[] lineArray = line.split(" ");

            for (String l : lineArray) {
                try {
                    sum += Integer.parseInt(l);
                }
                catch (NumberFormatException e) {
                    System.err.println(l);
                }
            }
        }
        return sum;
    }
}