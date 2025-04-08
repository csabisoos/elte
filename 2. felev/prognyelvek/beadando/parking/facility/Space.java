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
        return true;
    }

    public void addOccupyingCar(Car c){

    }

    public void removeOccupyingCar(){

    }

    public String getCarLicensePlate(){
        return "";
    }

    public Size getOccupyingCarSize(){
        return null;
    }
}