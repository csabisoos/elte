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
        for (Space[] floor : parkingLot.getFloorPlan()){
            for (Space space : floor){
                if (space.isTaken() && (space.getCarLicensePlate() == c.getLicensePlate())){
                    return space;
                }
            }
        }
        return null;
    }

    private Space findAvailableSpaceOnFloor(int floor, Car c){
        Space[][] floorPlan = parkingLot.getFloorPlan();
        Space[] currentFloor = floorPlan[floor];

        for (int i=0; i<currentFloor.length; ++i){
            if (c.getSpotOccupation() == vehicle.Size.SMALL){
                if (!currentFloor[i].isTaken()){
                    return currentFloor[i];
                }
            } else {
                if (i< currentFloor.length-1 && !currentFloor[i].isTaken() && !currentFloor[i+1].isTaken()){
                    return currentFloor[i+1];
                }
            }
        }
        return null;
    }

    public Space findAnyAvailableSpaceForCar(Car c){
        for (int i=0; i<parkingLot.getFloorPlan().length; ++i){
            Space space = findAvailableSpaceOnFloor(i, c);
            if (space != null){
                return space;
            }
        }
        return null;
    }

    public Space findPreferredAvailableSpaceForCar(Car c){
        int preferredFloor = c.getPreferredFloor();
        int floorCount = parkingLot.getFloorPlan().length;

        for (int i=0; i<floorCount; ++i){
            int down = preferredFloor-i;
            int up = preferredFloor+i;

            if (down>=0) {
                Space space = findAvailableSpaceOnFloor(down, c);
                if (space!=null) return space;
            }

            if (i>0 && up<floorCount){
                Space space = findAvailableSpaceOnFloor(up, c);
                if (space!=null) return space;
            }
        }
        return null;
    }

    public boolean registerCar(Car c){
        Space space = findPreferredAvailableSpaceForCar(c);
        if (space == null) space = findAnyAvailableSpaceForCar(c);
        if (space == null) return false;

        int floor = space.getFloorNumber();
        int spot = space.getSpaceNumber();
        Space[][] floorPlan = parkingLot.getFloorPlan();

        if (c.getSpotOccupation() == vehicle.Size.LARGE){
            floorPlan[floor][spot-1].addOccupyingCar(c);
            floorPlan[floor][spot].addOccupyingCar(c);
        } else {
            floorPlan[floor][spot].addOccupyingCar(c);
        }

        c.setTicketId("TICKET_" + floor + "_" + spot);
        cars.add(c);
        return true;
    }

    public void registerCars(Car... cars){
        for (Car c : cars) {
            boolean l = registerCar(c);
            if (!l) {
                System.err.println("Could not register car:" + c.getLicensePlate());
            }
        }
    }

    public void deRegisterCar(String ticketId){
        for (Car c : cars){
            if (c.getTicketId() == ticketId){
                Space space = findTakenSpaceByCar(c);
                if (space != null){
                    int floor = space.getFloorNumber();
                    int spot = space.getSpaceNumber();
                    Space[][] floorPlan = parkingLot.getFloorPlan();

                    if (c.getSpotOccupation() == vehicle.Size.LARGE) {
                        floorPlan[floor][spot].removeOccupyingCar();
                        floorPlan[floor][spot-1].removeOccupyingCar();
                    } else {
                        floorPlan[floor][spot].removeOccupyingCar();
                    }

                    cars.remove(c);
                    break;
                }
            }
        }
    }
}