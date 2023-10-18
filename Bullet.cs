using SFML.Graphics;
using SFML.System;

namespace Invaders;

public class Bullet : Entity
{
    private bool playerBulletBool;
    private Texture playerBullet;
    private Texture enemyBullet;

    public Bullet(Vector2f direction, bool player) : base("spaceMissiles_004")
    {
        sprite.Scale *= 0.75f;
        sprite.Origin = new Vector2f(9, 25.5f);
        //sprite.Origin = Program.multiply(new Vector2f(9, 25.5f), sprite.Scale);
        playerBullet = sprite.Texture;
        enemyBullet = Scene.Assets.LoadTexture("spaceMissiles_003");
        speed = 300;
        Direction = direction;
        playerBulletBool = player;

        if (playerBulletBool) Direction = new Vector2f(0, -1);
        else sprite.Texture = enemyBullet;
    }

    public override void Update(float deltaTime, Scene scene)
    {
        base.Update(deltaTime, scene);
        if (Position.Y > Program.windowH + 50 || Position.Y < -50) Dead = true;

        if (!playerBulletBool)
        {
            if (Direction == new Vector2f(1, 1)) sprite.Rotation = 180 - 45;
            else sprite.Rotation = 180 + 45;
        }
    }

    protected override void CollideWith(Scene scene, Entity entity)
    {
        if (entity is Player player && !playerBulletBool && !player.Invincible)
        {
            Scene.Events.PublishPlayerHit();
            Dead = true;
        }

        if (entity is Enemy  enemy && playerBulletBool)
        { 
            enemy.KillShip();
            Dead = true;
        }
    }
}