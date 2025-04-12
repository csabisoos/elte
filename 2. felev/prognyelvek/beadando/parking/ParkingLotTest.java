package parking;

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
import parking.facility.Space;
import vehicle.Size;
import vehicle.Car;
import parking.facility.Gate;

public class ParkingLotTest{
    @Test
    public void testConstructorWithInvalidValues() {
        assertThrows(IllegalArgumentException.class, () -> { new ParkingLot(-1, 5); }, "Expected exception for negative floor number");

        assertThrows(IllegalArgumentException.class, () -> { new ParkingLot(3, -2); }, "Expected exception for negative space number");

        assertThrows(IllegalArgumentException.class, () -> { new ParkingLot(-1, -1); }, "Expected exception for negative floor and space numbers");

        assertDoesNotThrow(() -> { new ParkingLot(1, 0); });
    }

    @Test
    public void testTextualRepresentation(){
        ParkingLot parkingLot = new ParkingLot(2, 3);
        Gate gate = new Gate(parkingLot);
    
        Car car1 = new Car("AAA111", Size.SMALL, 0);
        Car car2 = new Car("BBB222", Size.LARGE, 0);
        Car car3 = new Car("CCC333", Size.SMALL, 1);
    
        gate.registerCar(car1);
        gate.registerCar(car2);
        gate.registerCar(car3);
    
        gate.deRegisterCar(car2.getTicketId()); 
    
        String expected = "S X X\n" + "S X X";
    
        assertEquals(expected, parkingLot.toString());
    }
}