package music.recording;

public class Artist {
    private final String name;
    public String getName() {
        return name;
    }

    private final music.recording.RecordLabel label;
    public music.recording.RecordLabel getLabel() {
        return label;
    }

    public Artist(String name, music.recording.RecordLabel label) {
        this.name = name;
        this.label = label;
    }
}