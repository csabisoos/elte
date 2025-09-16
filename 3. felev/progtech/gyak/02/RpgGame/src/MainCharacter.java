public class MainCharacter extends Character {

    protected double defense;

    public MainCharacter(String name, int HP, int attack, double defense) {
        super(name, HP, attack);
        this.defense = defense;
    }
    
    @Override
    public void applyDamageFrom(Character character) {
        HP -= (int) (character.attack / defense);
    }

}
