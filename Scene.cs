using SFML.Graphics;

namespace Invaders;

public class Scene
{
  private List<Entity> entities = new List<Entity>();


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