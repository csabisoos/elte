public class Distance {
    public static void main(String[] args) {
        int k = args.length;
        Point[] points = new Point[k/2];
        for (int i = 0; i<k/2; ++i) {
            int x = Integer.parseInt(args[2*i]);
            int y = Integer.parseInt(args[2*i+1]);
            Point p = new Point(x,y);
            points[i] = p;
        }

        double tavolsag = 0;

        for (int i = 1; i<k/2; ++i) {
            tavolsag += points[i-1].distance(points[i]);
        }

        System.out.println(tavolsag);
    }
}