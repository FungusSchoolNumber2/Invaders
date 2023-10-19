using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace Invaders;

public class Player : Entity
{
    private bool keyPressed;
    private int shots;
    private float invincibleTimer;
    private float shotTimer;

    public Player() : base("spaceShips_001")
    {
        sprite.Rotation = 180;
        sprite.Origin = new Vector2f(53, 40);
        speed = 400;
        Position = new Vector2f(Program.windowW / 2, Program.windowH - 100);
        Scene.Events.PlayerHit += OnPlayerHit;
        shotTimer = 0;
    }

    public bool Invincible
    {
        get;
        private set;
    }

    public override void Update(float deltaTime, Scene scene)
    {
        if (invincibleTimer > 0)
        {
            Invincible = true;
            sprite.Color = new Color(255, 255, 255, 150);
            invincibleTimer -= deltaTime;
        }
        else
        {
            Invincible = false;
            sprite.Color = new Color(255, 255, 255, 255);
        }

        Direction = Movment();
        base.Update(deltaTime, scene);
        CheckEdges();

        if (Keyboard.IsKeyPressed(Keyboard.Key.Space) )
        {
            if (!keyPressed && shotTimer <= 0)
            {
                shots = 2;
                keyPressed = true;
                shotTimer = 0.5f;
            }
        }
        else keyPressed = false;
        Shoot();
        shotTimer -= deltaTime;
        
        // funny BeyBlade
        if (Keyboard.IsKeyPressed(Keyboard.Key.B))
        {
            sprite.Rotation += 1;
        }
    }

    private Vector2f Movment()
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

    private void Shoot()
    {
        if (shots == 2)
        {
            Scene.Events.PublishShot(Direction, Position + new Vector2f(25, -30), true);
            shots--;
        }
        else if (shots == 1)
        {
            Scene.Events.PublishShot(Direction, Position + new Vector2f(-25, -30), true);
            shots--;
        }
    }

    private void OnPlayerHit()
    {
        invincibleTimer = 3;
    }
}