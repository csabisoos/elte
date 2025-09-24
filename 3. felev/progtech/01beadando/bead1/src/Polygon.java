public abstract class Polygon extends PlaneFigure{
    // Fields
    protected double side;

    // Constructors
    protected Polygon(double x, double y, double side) {
        super(x, y);
        this.side = side;
    }

    // Methods
    protected abstract int sideNum();

    @Override
    protected double circumference() {
        return side * sideNum();
    }

    @Override
    protected double area() {
        if (sideNum() <= 2) throw new IllegalArgumentException("n should be larger than 2.");
        if (side <= 0) throw new IllegalArgumentException("a should be larger than 0.");

        double angleDegrees = 180.0 / sideNum();
        double angleRad = Math.toRadians(angleDegrees);

        double tan = Math.tan(angleRad);
        if (Math.abs(tan) < 1e-15) {
            throw new IllegalArgumentException("cot(180/n) not interprtable (tan(180/n) too small).");
        }
        double cot = 1.0 / tan;

        return 0.25 * sideNum() * side * side * cot;
    }

    @Override
    public String toString() {
        return getClass().getSimpleName() +
                " (x=" + centerX + ", y=" + centerY +
                ", circumference=" + circumference() +
                ", area=" + area() + ")";
    }
}
