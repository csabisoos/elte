public class Hello {
    public static void main(String[] args) {
        String nev = System.console().readLine("Kérlek, add meg a neved: ");
        System.console().printf("Üdvözöllek, %s!\n", nev);
    }
}