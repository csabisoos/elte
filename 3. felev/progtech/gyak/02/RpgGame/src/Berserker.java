public class Berserker extends Orc {

    public Berserker(String name, int HP, int attack) {
        super(name, HP, attack);
    }

    @Override
    public void applyDamageFrom(Character character) {
        HP -= character.attack * 2;
    }

}
