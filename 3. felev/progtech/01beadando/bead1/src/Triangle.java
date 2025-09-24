public class Triangle extends Polygon {
    // Constructors
    public Triangle(double x, double y, double side) {
        super(x, y, side);
    }

    // Methods
    @Override
    protected int sideNum() {
        return 3;
    }
}