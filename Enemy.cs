using SFML.Graphics;
using SFML.System;
namespace Invaders;

public class Enemy : Entity
{
    private Vector2f Size = new Vector2f(126, 108);
    public Enemy() : base("spaceShips_004")
    {
        sprite.Rotation = -45;
        sprite.Position = new Vector2f(300, 0);
        sprite.Scale *= 0.75f;
        sprite.Origin = Program.multiply(new Vector2f(63, 54), sprite.Scale);
        Size = Program.multiply(Size, sprite.Scale);
        speed = 200;
        Direction = new Vector2f(1, 1);
    }

    public override void Update(float deltaTime)
    {
        WallCheck();
        base.Update(deltaTime);
    }

    public override void Render(RenderTarget target)
    {
        if (Direction.X == -1) sprite.Rotation = 45;
        else sprite.Rotation = -45;    
        base.Render(target);
    }

    private void WallCheck()
    {
        if (Position.X >= Program.windowW - 62.25f)
        {
            Position = new Vector2f(Position.X - 5, Position.Y); 
            Direction.X *= -1;
        }
        if (Position.X <= 62.25f - 15)
        {
            Position = new Vector2f(Position.X + 5, Position.Y);
            Direction.X *= -1;
        }
    }
}