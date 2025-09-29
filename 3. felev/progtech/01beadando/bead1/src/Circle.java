public class Circle extends  PlaneFigure {
    // Fields
    private double radius;

    // Constructors
    /**
     * @param x center x
     * @param y center y
     * @param r radius (positive)
     * @throws IllegalArgumentException if r <= 0
     */
    public Circle(double x, double y, double r) {
        super(x, y);
        if (r <= 0) {
            throw new IllegalArgumentException("The radius must be positive: " + r);
        }
        this.radius = r;
    }

    // Methods
    @Override
    protected double circumference() {
        return Math.PI * radius * 2;
    }

    @Override
    protected double area() {
        return Math.PI * radius * radius;
    }

    @Override
    public String toString() {
        return "Circle(x:" + this.centerX + ", y:" + this.centerY + ", radius:" + this.radius + "circumference:" + this.circumference() + "area:" + this.area() + ")";
    }
}
