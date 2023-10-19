using SFML.Graphics;
using SFML.System;

namespace Invaders;

public class Explosion : Entity
{
    private float timer;
    public Explosion() : base("Explosion")
    {
        timer = 0;
        sprite.TextureRect = new IntRect(new Vector2i(0, 0), new Vector2i(96, 91));
    }

    public override void Update(float deltaTime, Scene scene)
    {
        sprite.TextureRect = new IntRect( new Vector2i(96 * (int)MathF.Round(timer), 0) , new Vector2i(96, 91));
        timer += 5 * deltaTime;
        
        if (timer > 7) Dead = true;
    }
}