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
        sprite.Origin = Program.multiply(new Vector2f(9, 25.5f), sprite.Scale);
        playerBullet = sprite.Texture;
        enemyBullet = Scene.Assets.LoadTexture("spaceMissiles_003");
        speed = 200;
        Direction = direction;
        playerBulletBool = player;

        if (playerBulletBool) Direction = new Vector2f(0, -1);
    }
    
    
}