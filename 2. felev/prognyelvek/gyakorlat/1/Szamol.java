public class Szamol {
    public static void main(String[] args) {
        if (args.length != 2) {
            System.err.println("Hibás számú parancssori paraméter!");
            System.exit(1);
        }
        try {
            int elso = Integer.parseInt(args[0]);
            int masodik = Integer.parseInt(args[1]);
            System.out.println("A két szám összege: " + (elso + masodik));
            if (elso < masodik)
            {
                System.out.println("A két szám különbsége: " + (masodik-elso));
            }
            else {
                System.out.println("A két szám különbsége: " + (elso - masodik));
            }
            System.out.println("A két szám szorzata: " + (elso*masodik));
            if (masodik == 0)
            {
                System.out.println("Az osztás nem elvégezhető mivel a második szám (s hányados) nulla!");
            }
            else {
                System.out.println("A két szám hányadosa: " + (elso/masodik));
                System.out.println("A két szám osztási maradéka: " + (elso%masodik));
            }
        } catch (NumberFormatException e) {
            System.err.println("Hibás számformátum!");
            System.exit(1);
        }

        
    }
}