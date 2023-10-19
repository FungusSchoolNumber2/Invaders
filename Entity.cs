using SFML.Graphics;
using SFML.System;

namespace Invaders;

public class Entity
{
    public Vector2f Direction = new Vector2f();
    public bool Dead;
    protected float speed;
    protected Sprite sprite;
    

    protected Entity(string textureName)
    {
        sprite = new Sprite();
        sprite.Texture = Scene.Assets.LoadTexture(textureName);
        Dead = false;
    }
    
    public Vector2f Position
    {
        get => sprite.Position;
        set => sprite.Position = value;
    }

    public FloatRect Bounds => sprite.GetGlobalBounds();

    public virtual void Update(float deltaTime, Scene scene)
    {
        sprite.Position += Direction * speed * deltaTime;
        foreach (Entity found in scene.FindIntersects(Bounds))
        {
            CollideWith(scene, found);
        }
    }
    
    protected virtual void CollideWith(Scene scene, Entity entity){}

    public virtual void Render(RenderTarget target)
    {
        target.Draw(sprite);
    }
}