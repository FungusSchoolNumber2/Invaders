using SFML.Graphics;
using SFML.System;

namespace Invaders;

public class Scene
{
  public static AssetsManager Assets = new AssetsManager();
  public static EventManager Events = new EventManager();
  private List<Entity> entities = new List<Entity>();
  private float timer = 2;
  private float difficulty = 2;

  public Scene()
  {
    Player player = new Player();
    entities.Add(player);
    GUI gui = new GUI();
    entities.Add(gui);

    Events.Shot += OnShot;
    Events.TimeToBlow += OnTimeToBlow;
  }

  public void UpdateAll(float deltaTime)
  {
    foreach (var entity in entities)
    {
      if (entity is GUI gui && gui.Health <= 0)
      {
        Reset();
        break;
      }
    }
    
    EnemySpawner(deltaTime);
    for (int i = entities.Count - 1; i >= 0; i--)
    {
      entities[i].Update(deltaTime, this);
    }
    
    Events.handleEvents();

    for (int i = 0; i < entities.Count;)
    {
      Entity entity = entities[i];
      if (entity.Dead) entities.RemoveAt(i);
      else i++;
    }
  }

  public void RenderAll(RenderTarget target)
  {
    foreach (var entity in entities)
    {
      entity.Render(target);
    }
    
  }
  
  public IEnumerable<Entity> FindIntersects(FloatRect bounds)
  {
    int lastEntity = entities.Count - 1;
    for (int i = lastEntity; i >= 0; i--)
    {
      Entity entity = entities[i];
      if (entity.Dead) continue;
      if (entity.Bounds.Intersects(bounds))
      {
        yield return entity;
      }
    }
  }

  private void OnShot(Vector2f direction, Vector2f position, bool player)
  {
    Bullet bullet = new Bullet(direction, player);
    bullet.Position = position;
    entities.Add(bullet);
  }

  private void EnemySpawner(float deltaTime)
  {
    int counter = 0;
    foreach (var entity in entities)
    {
      if (entity is Enemy) counter++;
    }
    
    timer -= deltaTime;
    if (counter < 20)
    {
      if (timer <= 0)
      {
        entities.Add(new Enemy()
        {
          Position = new Vector2f(new Random().Next((int)Program.windowW), -new Random().Next(150, 300))
        });

        timer = MathF.Max(difficulty, 0.3f);
        difficulty *= 0.9f;
      }
    }
  }

  private void Reset()
  {
    for (int i = entities.Count - 1; i >= 0; i--)
    {
      Entity entity = entities[i];
      entities.RemoveAt(i);
    }

    Player player = new Player();
    entities.Add(player);
    GUI gui = new GUI();
    entities.Add(gui);
  }

  private void OnTimeToBlow(Vector2f position)
  {
    entities.Add(new Explosion()
    {
      Position = position
    });
  }
}