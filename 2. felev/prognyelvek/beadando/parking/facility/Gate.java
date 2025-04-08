package parking.facility;

import java.util.ArrayList;

import vehicle.Car;
import parking.ParkingLot;
import vehicle.Car;
import parking.facility.Space;

public class Gate{
    // Fields
    private final ArrayList<Car> cars = new ArrayList<>();
    private final ParkingLot parkingLot;

    // Constructors
    public Gate(ParkingLot parkingLot){
        this.parkingLot = parkingLot;
    }

    // Methods
    private Space findTakenSpaceByCar(Car c){
        return null;
    }

    private Space findAvailableSpaceOnFloor(int floor, Car c){
        return null;
    }

    public Space findAnyAvailableSpaceForCar(Car c){
        return null;
    }

    public Space findPreferredAvailableSpaceForCar(Car c){
        return null;
    }

    public boolean registerCar(Car c){
        return true;
    }

    public void registerCars(Car... cars){

    }

    public void deRegisterCar(String ticketId){

    }
}