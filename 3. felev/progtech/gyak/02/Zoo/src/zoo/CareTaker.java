/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package zoo;

import java.awt.Point;
import java.util.ArrayList;

/**
 *
 * @author bli
 */
public class CareTaker {
    private final ArrayList<Animal> animals;
    public final Point p = new Point();
    
    public CareTaker() {
        animals = new ArrayList<>();
    }
    public CareTaker(ArrayList<Animal> animals) {
        
        this.animals = new ArrayList<>(animals);
    }
    
    public void addAnimal(Animal a) {
        this.animals.add(a);
    }
    
    public void removeAnimal(Animal a) {
        this.animals.remove(a);
    }
    
}
