package plane.but.not.flying;

public class CircleMain {
    public static void main (String[] args) {
        plane.PublicCircle pc = new plane.PublicCircle();
        System.out.println(pc.getArea());
        pc.x=5.0;
        pc.y=2.0;
        pc.radius=10.0;
        System.out.println(pc.getArea());

        plane.Circle circle = new plane.Circle();
        System.out.println(circle.getArea());
        circle.setX(5);
        circle.setY(2);
        circle.setRadius(10);
        System.out.println(circle.getArea());

        plane.Circle circle2 = new plane.Circle(5.0, 8.5, 12.4);
        System.out.println(circle2.getArea());
    }
}