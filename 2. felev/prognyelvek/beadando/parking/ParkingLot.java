package parking;

import parking.facility.Space;

public class ParkingLot{
    // Fields
    private final Space[][] floorPlan;

    // Properties
    public Space[][] getFloorPlan(){
        return floorPlan;
    }

    // Constructors
    public ParkingLot(int floorNumber, int spaceNumber){
        if (floorNumber < 0 || spaceNumber < 0) {
            throw new IllegalArgumentException("Floor and space numbers must be positive.");
        }
        floorPlan = new Space[floorNumber][spaceNumber];
        for (int i = 0; i < floorNumber; i++) {
            for (int j = 0; j < spaceNumber; j++) {
                floorPlan[i][j] = new Space(i, j);
            }
        }
    }

    // Methods
    @Override
    public String toString() {
        String result = "";
        for (int i=0; i<floorPlan.length; ++i){
            String line = "";
            for (int j=0; j<floorPlan[i].length; ++j){
                Space space = floorPlan[i][j];
                if (!space.isTaken()) line += "X ";
                else if (space.getOccupyingCarSize() == vehicle.Size.LARGE) line += "L ";
                else line += "S ";
            }
            line = line.trim();
            result += line;
            if (i<floorPlan.length-1) result += "\n";
        }
        return result;
    }
}