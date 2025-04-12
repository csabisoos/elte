package parking.facility;

import java.util.*;
import java.io.IOException;
import static check.CheckThat.*;
import static org.junit.jupiter.api.Assertions.*;
import org.junit.jupiter.api.*;
import org.junit.jupiter.api.condition.*;
import org.junit.jupiter.api.extension.*;
import org.junit.jupiter.params.*;
import org.junit.jupiter.params.provider.*;
import check.*;
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
        Space smallSpace = gate.findAnyAvailableSpaceForCar(smallCar);
        assertNotNull(smallSpace, "Expected an available space for the small car.");
        assertFalse(smallSpace.isTaken(), "The space should be available.");

        Car largeCar = new Car("XYZ789", Size.LARGE, 1);
        Space largeSpace = gate.findAnyAvailableSpaceForCar(largeCar);
        assertNotNull(largeSpace, "Expected an available space for the large car.");
        assertFalse(largeSpace.isTaken(), "The space should be available.");
    }


    @ParameterizedTest(name = "testFindPreferredAvailableSpaceForCar")
    @CsvSource(textBlock = """
        ABC123, SMALL, 0,
        XYZ789, LARGE, 1,
        LMN456, SMALL, 1,
        JKL123, LARGE, 0
    """)
    @DisableIfHasBadStructure
    public void testFindPreferredAvailableSpaceForCar(String plate, Size size, int preferredFloor) {
        ParkingLot parkingLot = new ParkingLot(3, 10);
        Gate gate = new Gate(parkingLot);

        Car preferredCar = new Car(plate, size, preferredFloor);

        Space space = gate.findPreferredAvailableSpaceForCar(preferredCar);

        assertNotNull(space, "Expected to find a preferred available space.");
        assertFalse(space.isTaken(), "The space should be available.");
        assertEquals(preferredFloor, space.getFloorNumber(), "The space should be on the preferred floor.");
    }

    @ParameterizedTest(name = "testFindPreferredAvailableSpaceForCar")
    @CsvSource(textBlock = """
        ABC123, SMALL, 0,
        XYZ789, LARGE, 1,
        LMN456, SMALL, 1,
        JKL123, LARGE, 0
    """)
    @DisableIfHasBadStructure
    public void testRegisterCar( String plate, Size size, int preferredFloor) {
        ParkingLot parkingLot = new ParkingLot(3, 10);
        Gate gate = new Gate(parkingLot);

        Car carToRegister = new Car(plate, size, preferredFloor);

        boolean registered = gate.registerCar(carToRegister);
        assertTrue(registered, "The car should be successfully registered.");
        assertNotNull(carToRegister.getTicketId(), "The car should have a ticket ID.");
    }

    @ParameterizedTest(name = "testFindPreferredAvailableSpaceForCar")
    @CsvSource(textBlock = """
        ABC123, SMALL, 0,
        XYZ789, LARGE, 1,
        LMN456, SMALL, 1,
        JKL123, LARGE, 0
    """)
    @DisableIfHasBadStructure
    public void testDeRegisterCar(String plate, Size size, int preferredFloor) {
        ParkingLot parkingLot = new ParkingLot(3, 10);
        Gate gate = new Gate(parkingLot);

        Car carToDeRegister = new Car(plate, size, preferredFloor);
        Space space = gate.findPreferredAvailableSpaceForCar(carToDeRegister);
        space.addOccupyingCar(carToDeRegister);

        gate.registerCar(carToDeRegister);

        gate.deRegisterCar(carToDeRegister.getTicketId());

        assertFalse(space.isTaken(), "The space should be available after de-registering the car.");

    }
}