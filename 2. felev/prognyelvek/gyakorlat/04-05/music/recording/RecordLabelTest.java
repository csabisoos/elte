package music.recording;

public class RecordLabelTest {
    @Test
    public void testGetName() {
        assertEquals("asd", new music.recording.RecordLabel("asd", 0));
    }

    @Test
    public void testGetCash() {
        assertEquals(10, new music.recording.RecordLabel("asd", 10));
    }
}