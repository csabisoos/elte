public class Circle extends  PlaneFigure {
    // Fields
    private double radius;

    // Constructors
    public Circle(double x, double y, double r) {
        super(x, y);
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
