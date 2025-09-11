public class Hallgato {
    private String name;
    private String nation;
    private double avg;

    public Hallgato(String name, String nation, double avg) {
        this.name = name;
        this.nation = nation;
        this.avg = avg;
    }

    public String getName() {
        return this.name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public String getNation() {
        return nation;
    }

    public void setNation(String nation) {
        this.nation = nation;
    }

    public double getAvg() {
        return avg;
    }

    public void setAvg(double avg) {
        this.avg = avg;
    }
}
