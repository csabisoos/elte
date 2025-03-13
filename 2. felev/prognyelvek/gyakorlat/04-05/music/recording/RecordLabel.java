package music.recording;

public class RecordLabel {
    private final String name;
    public String getName() {
        return name;
    }

    private int cash;
    public int getCash() {
        return cash;
    }

    public RecordLabel(String name, int cash) {
        this.name = name;
        this.cash = cash;
    }

    public void gotIncome(int sum) {
        
    }
}