/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package zoo;

import java.util.ArrayList;

/**
 *
 * @author bli
 */
public class Zoo {
    
    private final ArrayList<Animal> animals;
    private final ArrayList<CareTaker> careTakers;
    private final Restaurant restaurant;

    public Zoo() {
        this(new ArrayList<>());
    }

    public Zoo(ArrayList<Animal> animals) {
        this.animals = new ArrayList<>(animals);
        restaurant = new Restaurant();
        careTakers = new ArrayList<>();
    }
    
    public void addAnimal(Animal a) {
        this.animals.add(a);
    }
    
    public void removeAnimal(Animal a) {
        this.animals.remove(a);
    }
    
    public void step() {
        for (Animal a : animals) {
            a.move();
            a.makeSound();
        }
    }
}
