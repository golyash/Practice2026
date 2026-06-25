using Moq;
using task04;
namespace task04tests;

public class SpaceshipTests
{
    [Fact]
    public void Cruiser_ShouldHaveCorrectStats()
    {
        ISpaceship cruiser = new Cruiser();
        Assert.Equal(50, cruiser.Speed);
        Assert.Equal(100, cruiser.FirePower);
    }

    [Fact]
    public void Fighter_ShouldHaveCorrectStats()
    {
        ISpaceship fighter = new Fighter();
        Assert.Equal(100, fighter.Speed);
        Assert.Equal(50, fighter.FirePower);
    }

    [Fact]
    public void Fighter_ShouldBeFasterThanCruiser()
    {
        var fighter = new Fighter();
        var cruiser = new Cruiser();
        Assert.True(fighter.Speed > cruiser.Speed);
    }

    [Fact]
    public void Cruiser_ShouldHaveMoreFirePowerThanFighter()
    {
        var fighter = new Fighter();
        var cruiser = new Cruiser();
        Assert.True(cruiser.FirePower > fighter.FirePower);
    }

    [Fact]
    public void Fighter_ShouldImplementISpaceship()
    {
        var fighter = new Fighter();
        Assert.IsAssignableFrom<ISpaceship>(fighter);
    }

    [Fact]
    public void Cruiser_ShouldImplementISpaceship()
    {
        var cruiser = new Cruiser();
        Assert.IsAssignableFrom<ISpaceship>(cruiser);
    }

    [Fact]
    public void StartMission_ShouldMoveShip()
    {
        var mock_ship = new Mock<ISpaceship>();
        var mission = new SpecialMission(mock_ship.Object);
        mission.StartMission();
        mock_ship.Verify(s => s.MoveForward(), Times.Once);
    }

    [Fact]
    public void StartMission_ShouldRotateShip()
    {
        var mock_ship = new Mock<ISpaceship>();
        var mission = new SpecialMission(mock_ship.Object);
        mission.StartMission();
        mock_ship.Verify(s => s.Rotate(90), Times.Once);
    }

    [Fact]
    public void StartMission_ShouldNotFire()
    {
        var mock_ship = new Mock<ISpaceship>();
        var mission = new SpecialMission(mock_ship.Object);
        mission.StartMission();
        mock_ship.Verify(s => s.Fire(), Times.Never);
    }

    [Fact]
    public void StartAttack_ShouldFireOnce()
    {
        var mock_ship = new Mock<ISpaceship>();
        var mission = new SpecialMission(mock_ship.Object);
        mission.StartAttack();
        mock_ship.Verify(s => s.Fire(), Times.Once);
    }

    [Fact]
    public void StartAttack_ShouldNotMoveAnywhere()
    {
        var mock_ship = new Mock<ISpaceship>();
        var mission = new SpecialMission(mock_ship.Object);
        mission.StartAttack();
        mock_ship.Verify(s => s.MoveForward(), Times.Never);
        mock_ship.Verify(s => s.Rotate(90), Times.Never);
    }
}
