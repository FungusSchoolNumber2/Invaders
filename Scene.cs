using SFML.Graphics;
using SFML.System;

namespace Invaders;

public class Scene
{
  public static AssetsManager Assets = new AssetsManager();
  public static EventManager Events = new EventManager();
  private List<Entity> entities = new List<Entity>();

  public Scene()
  {
    Player player = new Player();
    Enemy enemy = new Enemy();
    Bullet bullet = new Bullet(new Vector2f(0, 1), false);
    entities.Add(player);
    entities.Add(enemy);
    entities.Add(bullet);

    Events.Shot += OnShot;
  }

  public void UpdateAll(float deltaTime)
  {
    for (int i = entities.Count - 1; i >= 0; i--)
    {
      entities[i].Update(deltaTime);
    }
    
    Events.handleEvents();
  }

  public void RenderAll(RenderTarget target)
  {
    foreach (var entity in entities)
    {
      entity.Render(target);
    }
  }

  private void OnShot(Vector2f direction, Vector2f position, bool player)
  {
    Bullet bullet = new Bullet(direction, player);
    bullet.Position = position;
    entities.Add(bullet);
  }
  
}