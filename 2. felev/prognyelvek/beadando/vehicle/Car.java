package vehicle;

import vehicle.Size;

public class Car{
    // Fields
    private final String licensePlate;
    private final Size spotOccupation;
    private int preferredFloor;
    private String ticketId;

    // Properties
    public String getLicensePlate(){
        return licensePlate;
    }
    public Size getSpotOccupation(){
        return spotOccupation;
    }
    public int getPreferredFloor(){
        return preferredFloor;
    }
    public void setPreferredFloor(int preferredFloor){
        this.preferredFloor = preferredFloor;
    }
    public String getTicketId(){
        return ticketId;
    }
    public void setTicketId(String ticketId){
        this.ticketId = ticketId;
    }

    // Constructors
    public Car(String licensePlate, Size spotOccupation, int preferredFloor){
        this.licensePlate = licensePlate;
        this.spotOccupation = spotOccupation;
        this.preferredFloor = preferredFloor;
    }
}