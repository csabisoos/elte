public class Circle {
    public double x;
    public double y;
    public double radius;

    public void enlarge(int f){
        this.radius = this.radius*f;
    }

    public double getArea() {
        return Math.PI*Math.pow(this.radius, 2);
    }
}