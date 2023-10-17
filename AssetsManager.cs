using SFML.Graphics;
namespace Invaders;

public class AssetsManager
{
    private readonly Dictionary<string, Texture> textures;

    public AssetsManager()
    {
        textures = new Dictionary<string, Texture>();
    }
    
    public Texture LoadTexture(string name)
    {
        if (textures.TryGetValue(name, out Texture found))
        {
            return found;
        }

        string filename = $"assets/{name}.png";
        Texture texture = new Texture(filename);
        textures.Add(name, texture);
        return texture;
    }
}