package action.user;

import java.util.Arrays;

import action.Scalable;
import action.Undoable;

public class MultiDimensionalPoint implements Scalable, Undoable, Comparable<MultiDimensionalPoint> {
    private int[] coordinates;
    private int[] lastCoordinates;

    public MultiDimensionalPoint(int... coordinates){
        this.coordinates = new int[coordinates.length];
        for (int i = 0; i < coordinates.length; i++) {
            this.coordinates[i] = coordinates[i];
        }
        saveToLast();
    }

    public int get(int index){
        return coordinates[index];
    }

    public void set(int x, int index){
        saveToLast();
        if (index <= coordinates.length){
            coordinates[index] = x;
        }
        
    }

    @Override
    public void scale(int factor){
        saveToLast();
        for (int i = 0; i < this.coordinates.length; i++) {
            this.coordinates[i] += factor;
        }
    }

    private void saveToLast(){
        lastCoordinates = coordinates;
    }

    @Override
    public void undoLast(){
        
        coordinates = lastCoordinates;
    }

    @Override
    public int compareTo(MultiDimensionalPoint mdp){
        //for (int i = 0; i<)
        return 0;
    }

    @Override
    public boolean equals(Object mdp){
        return false;
    }

    @Override
    public int hashCode(){
        return 0;
    }
}