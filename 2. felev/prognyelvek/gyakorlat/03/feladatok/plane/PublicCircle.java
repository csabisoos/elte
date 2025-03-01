package plane;

public class PublicCircle {
    public double x;
    public double y;
    public double radius;

    public PublicCircle() {
        x = 0.0;
        y = 0.0;
        radius = 1.0;
    }

    public double getArea() {
        return radius*radius*Math.PI;
    }
}