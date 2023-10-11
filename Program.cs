using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace Invaders
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var window = new RenderWindow(new VideoMode(500, 700), "Invaders"))
            {
                window.Closed += (o, e) => window.Close();

                Clock clock = new Clock();
                //window.SetView(new View(new FloatRect(18, 0, 414, 450)));
                while (window.IsOpen)
                {
                    window.DispatchEvents();
                    float deltaTime = clock.Restart().AsSeconds();
                    deltaTime = MathF.Min(deltaTime, 0.01f);
                    window.Clear(new Color(223, 246, 245));
                    window.Display();
                }
            }
        }
    }
}