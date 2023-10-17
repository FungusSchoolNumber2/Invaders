using SFML.System;
namespace Invaders;

public class Enemy : Entity
{
    private Vector2f Size = new Vector2f(126, 108);
    public Enemy() : base("spaceShips_004")
    {
        sprite.Rotation = -45;
        sprite.Position = new Vector2f(150, 0);
        sprite.Scale *= 0.75f;
        sprite.Origin = Program.multiply(new Vector2f(63, 54), sprite.Scale);
        Size = Program.multiply(Size, sprite.Scale);
        speed = 100;
        Direction = new Vector2f(1, 1);
    }

    public override void Update(float deltaTime)
    {
        WallCheck();
        base.Update(deltaTime);
    }

    private void WallCheck()
    {
        if (Position.X >= Program.windowW -  sprite.Origin.X) Direction.X *= -1;
        if (Position.X <= sprite.Origin.X) Direction.X *= -1;
    }
}