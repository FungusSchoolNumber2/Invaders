﻿using SFML.Graphics;
using SFML.System;
namespace Invaders;

public class Enemy : Entity
{
    private float timer;
    public Enemy() : base("spaceShips_004")
    {
        sprite.Rotation = -45;
        sprite.Position = new Vector2f(300, 0);
        sprite.Scale *= 0.75f;
        sprite.Origin = new Vector2f(63, 54);
        //sprite.Origin = Program.multiply(new Vector2f(63, 54), sprite.Scale);
        speed = 200;
        Direction = new Vector2f(1, 1);
        timer = 2;
    }

    public override void Update(float deltaTime, Scene scene)
    {
        WallCheck();
        base.Update(deltaTime, scene);
        Firing(deltaTime);
    }

    public override void Render(RenderTarget target)
    {
        if (Direction.X == -1) sprite.Rotation = 45;
        else sprite.Rotation = -45;    
        base.Render(target);
    }

    public void KillShip()
    {
        Scene.Events.PublishTimeToBlow(Position);
        Dead = true;
    }

    protected override void CollideWith(Scene scene, Entity entity)
    {
        if (entity is Player player && !player.Invincible)
        {
            Scene.Events.PublishPlayerHit();
            KillShip();
        }
    }

    private void WallCheck()
    {
        if (Position.X >= Program.windowW - 62.25f + 15)
        {
            Position = new Vector2f(Position.X - 5, Position.Y); 
            Direction.X *= -1;
        }
        if (Position.X <= 62.25f - 15)
        {
            Position = new Vector2f(Position.X + 5, Position.Y);
            Direction.X *= -1;
        }

        if (Position.Y > Program.windowH + 50) Position = new Vector2f(Position.X, -100);
    }

    private void Firing(float deltaTime)
    {
        timer -= deltaTime;

        if (timer <= 0)
        {
            int temp = new Random().Next(2);
            if (temp == 1) Scene.Events.PublishShot(Direction, Position , false);
            timer = 1;
        }
    }
}