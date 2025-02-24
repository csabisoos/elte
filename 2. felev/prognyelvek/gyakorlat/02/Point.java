public class Point {
    private double x;
    private double y;

    public Point(double x, double y) {
        this.x = x;
        this.y = y;
    }

    public double getX() {
        return x;
    }

    public double getY() {
        return y;
    }

    public void setX(double x) {
        this.x = x;
    }

    public void setY(double y) {
        this.y = y;
    }

    public void move(double dx, double dy) {
        this.x += dx;
        this.y += dy;
    }

    /* public void mirror(double cx, double cy) {
        this.x += (cx - this.x) * 2;
        this.y += (cy - this.y) * 2;
    } */

    public void mirror(Point p) {
        this.x += (p.x - this.x) * 2;
        this.y += (p.y - this.y) * 2;
    }

    public double distance(Point p) {
        return Math.sqrt(Math.pow((this.x-p.x), 2)+Math.pow((this.y-p.y), 2));
    }
}