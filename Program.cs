using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace Invaders
{
    class Program
    {
        public static uint windowW = 450;
        public static uint windowH = 900;
        static void Main(string[] args)
        {
            using (var window = new RenderWindow(new VideoMode(windowW, windowH), "Invaders"))
            {
                window.Closed += (o, e) => window.Close();
                Scene scene = new();
                Clock clock = new Clock();
                //window.SetView(new View(new FloatRect(18, 0, 414, 450)));
                
                while (window.IsOpen)
                {
                    window.DispatchEvents();
                    float deltaTime = clock.Restart().AsSeconds();
                    deltaTime = MathF.Min(deltaTime, 0.01f);
                    scene.UpdateAll(deltaTime);
                    window.Clear(new Color(0, 0, 0));
                    scene.RenderAll(window);
                    window.Display();
                }
            }
        }

        public static Vector2f multiply(Vector2f vector1, Vector2f vector2)
        {
            return new Vector2f(vector1.X * vector2.X, vector1.Y * vector2.Y);
        }
    }
}