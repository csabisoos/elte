public abstract class PlaneFigure {
    // Fields
    protected double centerX;
    protected double centerY;

    // Constructors
    protected PlaneFigure(double centerX, double centerY) {
        this.centerX = centerX;
        this.centerY = centerY;
    }

    // Methods
    protected abstract double circumference();
    protected abstract double area();

    /**
     * A terület és a kerület különbségének abszolút értéke.
     *
     * @return |circumference - area|
     */
    public double difference() {
        return Math.abs(circumference() - area());
    }
}
