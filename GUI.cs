using SFML.Graphics;
using SFML.System;

namespace Invaders;

public class GUI : Entity
{
    private float score;
    private Text text;
    public GUI() : base("spaceShips_001")
    {
        sprite.Origin = new Vector2f(53, 40);
        sprite.Scale *= 0.5f;
        text = new Text();
        text.Font = Scene.Assets.LoadFont("Kenney Space");
        text.CharacterSize = 20;
        
        Health = 3;
        score = 0;

        Scene.Events.PlayerHit += OnPlayerHit;
    }

    public int Health
    {
        get;
        private set;
    }

    public override void Update(float deltaTime, Scene scene)
    {
        score += 10 * deltaTime;
    }

    public override void Render(RenderTarget target)
    {
        text.DisplayedString = $"Score: {String.Format("{0:0}", score)}";
        text.Position = new Vector2f(Program.windowW - 10 - text.GetGlobalBounds().Width, text.GetGlobalBounds().Height + 5);
        target.Draw(text);

        sprite.Position = new Vector2f(Bounds.Width / 2 + 5, 20);
        for (int i = 0; i < Health; i++)
        {
            target.Draw(sprite);
            sprite.Position += new Vector2f(Bounds.Width, 0);
        }
    }
    
    private void OnPlayerHit()
    {
        Health--;
    }
}