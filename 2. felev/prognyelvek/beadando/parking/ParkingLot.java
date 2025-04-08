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
        if (floorNumber <= 0 || spaceNumber <= 0) {
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
        return "";
    }
}