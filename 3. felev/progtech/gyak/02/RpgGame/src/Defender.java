public class Defender extends Orc {

    public Defender(String name, int HP, int attack) {
        super(name, HP, attack);
    }

    @Override
    public void applyDamageFrom(Character character) {
        HP -= character.attack / 2;
    }

}
