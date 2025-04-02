package worker.schedule;

import java.util.*;

public class WorkerSchedule {
    private HashMap<Integer, HashSet<String>> weekToWorkers;

    public WorkerSchedule() {
        weekToWorkers = new HashMap<>();
    }

    public void add(int week, HashSet<String> workers) {
        int internalWeek = week - 1;
        weekToWorkers.putIfAbsent(internalWeek, new HashSet<>());
        weekToWorkers.get(internalWeek).addAll(workers);
    }

    public void add(HashSet<Integer> weeks, ArrayList<String> workers) {
        for (int week : weeks) {
            add(week, new HashSet<>(workers));
        }
    }

    public boolean isWorkingOnWeek(String worker, int week) {
        int internalWeek = week - 1;
        return weekToWorkers.getOrDefault(internalWeek, new HashSet<>()).contains(worker);
    }

    public HashSet<Integer> getWorkWeeks(String worker) {
        HashSet<Integer> workWeeks = new HashSet<>();
        for (Map.Entry<Integer, HashSet<String>> entry : weekToWorkers.entrySet()) {
            if (entry.getValue().contains(worker)) {
                workWeeks.add(entry.getKey() + 1);
            }
        }
        return workWeeks;
    }
}
