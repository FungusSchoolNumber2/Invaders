using SFML.Graphics;
namespace Invaders;

public class AssetsManager
{
    private readonly Dictionary<string, Texture> textures;
    private readonly Dictionary<string, Font> fonts;

    public AssetsManager()
    {
        textures = new Dictionary<string, Texture>();
        fonts = new Dictionary<string, Font>();
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
    
    public Font LoadFont(string name)
    {
        if (fonts.TryGetValue(name, out Font found))
        {
            return found;
        }

        string filename = $"assets/{name}.ttf";
        Font font = new Font(filename);
        fonts.Add(name, font);
        return font;
    }
}