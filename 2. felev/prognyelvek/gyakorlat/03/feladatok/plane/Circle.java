package plane;

public class Circle {
    private double x;
    private double y;
    private double radius;

    public Circle() {
        x = 0.0;
        y = 0.0;
        radius = 1.0;
    }

    public Circle(double x, double y, double radius) {
        this.x = x;
        this.y = y;
        if (radius <= 0.0) {
            throw new IllegalArgumentException("Nem pozitív radiusz!");
        }
        this.radius = radius;
    }

    public double getX() {
        return x;
    }

    public double getY() {
        return y;
    }

    public double getRadius() {
        return radius;
    }

    public void setX(double x) {
        this.x = x;
    }

    public void setY(double y) {
        this.y = y;
    }

    public void setRadius(double radius) {
        if (radius <= 0.0) {
            throw new IllegalArgumentException("Nem pozitív radiusz!");
        }
        this.radius = radius;
    }

    public double getArea() {
        return radius*radius*Math.PI;
    }
}