package worker.schedule;

import org.junit.jupiter.api.*;
import static org.junit.jupiter.api.Assertions.*;
import java.util.*;

public class WorkerScheduleTest {

    @Test
    public void emptySchedule() {
        WorkerSchedule schedule = new WorkerSchedule();
        assertFalse(schedule.isWorkingOnWeek("Alice", 1));
        assertTrue(schedule.getWorkWeeks("Alice").isEmpty());
    }

    @Test
    public void schedule() {
        WorkerSchedule schedule = new WorkerSchedule();

        // Egyéni hetekhez adás
        HashSet<String> week1Workers = new HashSet<>(List.of("Alice", "Bob"));
        schedule.add(1, week1Workers);

        HashSet<String> week2Workers = new HashSet<>(List.of("Charlie"));
        schedule.add(2, week2Workers);

        // Több héthez adás
        HashSet<Integer> multipleWeeks = new HashSet<>(List.of(3, 4));
        ArrayList<String> workersList = new ArrayList<>(List.of("David", "Eve"));
        schedule.add(multipleWeeks, workersList);

        // Ellenőrzések
        assertTrue(schedule.isWorkingOnWeek("Alice", 1));
        assertFalse(schedule.isWorkingOnWeek("Alice", 2));
        assertTrue(schedule.isWorkingOnWeek("Charlie", 2));
        assertTrue(schedule.isWorkingOnWeek("David", 3));
        assertTrue(schedule.isWorkingOnWeek("Eve", 4));

        assertEquals(new HashSet<>(List.of(1)), schedule.getWorkWeeks("Alice"));
        assertEquals(new HashSet<>(List.of(2)), schedule.getWorkWeeks("Charlie"));
        assertEquals(new HashSet<>(List.of(3, 4)), schedule.getWorkWeeks("David"));
    }
}
