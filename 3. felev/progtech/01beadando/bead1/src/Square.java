public class Square extends Polygon {
    // Constructors
    public Square(double x, double y, double side) {
        super(x, y, side);
    }

    // Methods
    @Override
    protected int sideNum() {
        return 4;
    }
}