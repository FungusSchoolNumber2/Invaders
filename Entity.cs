using SFML.Graphics;
using SFML.System;

namespace Invaders;

public class Entity
{
    public Vector2f Direction = new Vector2f();
    protected Sprite sprite;
    private string textureName;

    protected Entity(string textureName)
    {
        sprite = new Sprite();
        this.textureName = textureName;
    }
    
    public Vector2f Position
    {
        get => sprite.Position;
        set => sprite.Position = value;
    }

    public FloatRect Bounds => sprite.GetGlobalBounds();

    public virtual void Update(float deltaTime){}
    public void Render(RenderTarget target){}

}