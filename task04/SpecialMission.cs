namespace task04;

public class SpecialMission
{
    private readonly ISpaceship _spaceship;

    public SpecialMission(ISpaceship spaceship)
    {
        _spaceship = spaceship;
    }

    public void StartMission()
    {
        _spaceship.MoveForward();
        _spaceship.Rotate(90);
    }

    public void StartAttack()
    {
        _spaceship.Fire();
    }
}
