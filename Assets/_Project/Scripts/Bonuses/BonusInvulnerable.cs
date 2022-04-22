public class BonusInvulnerable : Bonus
{
    protected override void UseBonus()
    {
        if (_player == null) return;

        if (_player.IsUsingBonus) return;
        _player.DisallowUsingBonus();

        _player.PlayBonusEffect(BonusType.Invulnerable);
    }
}
