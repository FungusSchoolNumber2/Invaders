using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace Invaders
{
    class Program
    {
        public static uint windowW = 675;
        public static uint windowH = 1350;
        static void Main(string[] args)
        {
            using (var window = new RenderWindow(new VideoMode(450, 900), "Invaders"))
            {
                window.Closed += (o, e) => window.Close();
                Scene scene = new();
                Clock clock = new Clock();
                window.SetView(new View(new FloatRect(0, 0, windowW, windowH)));
                
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