public class Complex {
    private double valos;
    private double kepzetes;

    public double abs() {
        return Math.sqrt(Math.pow(this.valos, 2) + Math.pow(this.kepzetes, 2));
    }

    public void add(Complex c) {
        this.valos += c.valos;
        this.kepzetes += c.kepzetes;
    }

    public void sub(Complex c) {
        this.valos -= c.valos;
        this.kepzetes -= c.kepzetes;
    }

    public void mul(Complex c) {
        this.valos = (this.valos*c.valos-this.kepzetes*c.kepzetes);
        this.kepzetes = (this.valos*c.kepzetes+this.kepzetes*c.valos);
    }

}