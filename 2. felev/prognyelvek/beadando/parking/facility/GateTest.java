package parking.facility;

import org.junit.jupiter.api.*;
import static org.junit.jupiter.api.Assertions.*;
import java.util.*;
import vehicle.Car;
import vehicle.Size;
import parking.ParkingLot;

public class GateTest {

    private static ParkingLot parkingLot;
    private static Gate gate;

    @BeforeAll
    public static void setUp() {
        parkingLot = new ParkingLot(2, 5);
        gate = new Gate(parkingLot);
    }

    @Test
    public void testFindAnyAvailableSpaceForCar() {
        Car smallCar = new Car("ABC123", Size.SMALL, 0);
        Space space = gate.findAnyAvailableSpaceForCar(smallCar);
        assertNotNull(space, "Expected an available space for the small car.");
        assertFalse(space.isTaken(), "The space should be available.");
    }

    @Test
    public void testFindPreferredAvailableSpaceForCar() {
        Car preferredCar = new Car("XYZ789", Size.SMALL, 0);
        parkingLot.getFloorPlan()[0][0].addOccupyingCar(preferredCar); 
        Car carWithPreferredFloor = new Car("LMN456", Size.SMALL, 1); 

        Space space = gate.findPreferredAvailableSpaceForCar(carWithPreferredFloor);
        assertNotNull(space, "Expected to find a preferred available space.");
        assertFalse(space.isTaken(), "The space should be available.");
    }

    @Test
    public void testRegisterCar() {
        Car carToRegister = new Car("JKL123", Size.LARGE, 0);
        boolean registered = gate.registerCar(carToRegister);
        assertTrue(registered, "The car should be successfully registered.");
        assertNotNull(carToRegister.getTicketId(), "The car should have a ticket ID.");
    }

    @Test
    public void testDeRegisterCar() {
        Car carToDeRegister = new Car("XYZ123", Size.SMALL, 1); 
        Space space = new Space(0, 0);

        space.addOccupyingCar(carToDeRegister);

        Gate gate = new Gate(new ParkingLot(3, 10));
        gate.registerCar(carToDeRegister); 

        gate.deRegisterCar(carToDeRegister.getTicketId());

        assertNull(space.getCarLicensePlate(), "The space should be available after de-registering the car.");
        assertNull(space.getOccupyingCarSize(), "The space should no longer have an occupying car.");
    }
}