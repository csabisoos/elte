package parking.facility;

import vehicle.Car;
import vehicle.Size;

public class Space{
    // Fields
    private final int floorNumber;
    private final int spaceNumber;
    private Car occupyingCar;

    // Properties
    public int getFloorNumber(){
        return floorNumber;
    }
    public int getSpaceNumber(){
        return spaceNumber;
    }

    // Constructors
    public Space(int floorNumber, int spaceNumber){
        this.floorNumber = floorNumber;
        this.spaceNumber = spaceNumber;
    }

    // Methods
    public boolean isTaken(){
        return this.occupyingCar != null;
    }

    public void addOccupyingCar(Car c){
        this.occupyingCar = c;
    }

    public void removeOccupyingCar(){
        this.occupyingCar = null;
    }

    public String getCarLicensePlate(){
        return this.occupyingCar.getLicensePlate();
    }

    public Size getOccupyingCarSize(){
        return this.occupyingCar.getSpotOccupation();
    }
}