using SFML.System;
using SFML.Window;

namespace Invaders;

public class Player : Entity
{
    public Player() : base("spaceShips_001")
    {
        sprite.Rotation = 180;
        sprite.Origin = new Vector2f(53, 40);
        speed = 200;
        Position = new Vector2f(Program.windowW / 2, Program.windowH - 100);
    }

    public override void Update(float deltaTime)
    {
        Direction = movment();
        base.Update(deltaTime);
        CheckEdges();
    }

    private Vector2f movment()
    {
        Vector2f temp1 = new Vector2f();
        Vector2f temp2 = new Vector2f();
        Vector2f temp3 = new Vector2f();
        Vector2f temp4 = new Vector2f();
        
        if (Keyboard.IsKeyPressed(Keyboard.Key.Right)) temp1 = new Vector2f(1, 0);
        else temp1 = new Vector2f(0, 0);
        
        if (Keyboard.IsKeyPressed(Keyboard.Key.Left)) temp2 = new Vector2f(-1, 0);
        else temp2 = new Vector2f(0, 0);
        
        if (Keyboard.IsKeyPressed(Keyboard.Key.Up)) temp3 = new Vector2f(0, -1);
        else temp3 = new Vector2f(0, 0);
        
        if (Keyboard.IsKeyPressed(Keyboard.Key.Down)) temp4 = new Vector2f(0, 1);
        else temp4 = new Vector2f(0, 0);

        return temp1 + temp2 + temp3 + temp4;
    }

    private void CheckEdges()
    {
        if (Position.X >= Program.windowW - 53) Position = new Vector2f(Program.windowW - 53 , Position.Y);
        if (Position.X <= 53) Position = new Vector2f(53 , Position.Y);
        if (Position.Y >= Program.windowH - 40) Position = new Vector2f(Position.X , Program.windowH - 40);
        if (Position.Y <= 40) Position = new Vector2f(Position.X , 40);    
    }
}