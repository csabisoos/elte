package music.fan;

public class Fan {
    private final String name;
    public String getName(){
        return name;
    }

    private final music.recording.Artist favourite;
    public music.recording.Artist getFavourite(){
        return favourite;
    }

    private int moneySpent;
    public int getMoneySpent() {
        return moneySpent;
    }

    public Fan(String name, music.recording.Artist favourite) {
        this.name = name;
        this.favourite = favourite;
        this.moneySpent = 0;
    }

    public int buyMerchandise(int price, Fan... friends) {
        return 0;
    }

    public boolean favesAtSameLabel(Fan fan) {
        return true;
    }

    public String toString1() {
        return "";
    }

    public String toString2() {
        return "";
    }

    public String toString3() {
        return "";
    }

    public String toString4() {
        return "";
    }
}