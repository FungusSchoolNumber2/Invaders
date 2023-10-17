using SFML.Graphics;

namespace Invaders;

public class Scene
{
  public static AssetsManager Assets = new AssetsManager();
  private List<Entity> entities = new List<Entity>();

  public Scene()
  {
    Player player = new Player();
    Enemy enemy = new Enemy();
    entities.Add(player);
    entities.Add(enemy);
  }

  public void UpdateAll(float deltaTime)
  {
    for (int i = entities.Count - 1; i >= 0; i--)
    {
      entities[i].Update(deltaTime);
    }
  }

  public void RenderAll(RenderTarget target)
  {
    foreach (var entity in entities)
    {
      entity.Render(target);
    }
  }
  
  
  
}