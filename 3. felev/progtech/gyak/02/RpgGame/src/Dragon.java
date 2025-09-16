public abstract class Dragon extends Character {
 
    protected final int ATTACK_THRESHOLD;

    public Dragon(String name, int HP, int attack, int ATTACK_THRESHOLD) {
        super(name, HP, attack);
        this.ATTACK_THRESHOLD = ATTACK_THRESHOLD;
    }

    @Override
    public void applyDamageFrom(Character character) {
        if (character.attack > ATTACK_THRESHOLD) {
            HP -= character.attack;
        }
    }
    
}
