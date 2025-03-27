package text.to.numbers;

import java.io.IOException;
import java.io.FileReader;
import java.io.BufferedReader;

public class MultiLineFile {
    public MultiLineFile(){}

    public static int addNumbers(String path, char separator) throws IOException {
        int sum = 0;
        try (BufferedReader br = new BufferedReader(new FileReader(path))) {
            
            String line = br.readLine();
            String sep = String.valueOf(separator);
            String[] lineArray = line.split(sep);

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