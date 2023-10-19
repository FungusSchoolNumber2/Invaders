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
                // Display FPS
                /*float test = 1;
                int test1 = 0;*/
                while (window.IsOpen)
                {
                    window.DispatchEvents();
 
                    float deltaTime = clock.Restart().AsSeconds();
                    deltaTime = MathF.Min(deltaTime, 0.01f);
                    scene.UpdateAll(deltaTime);
                    window.Clear(new Color(0, 0, 0));
                    scene.RenderAll(window);
                    window.Display();
                    
                    // Display FPS
                    /*test -= deltaTime;
                    test1++;
                    if (test <= 0)
                    {
                        Console.WriteLine(test1);
                        test = 1;
                        test1 = 0;
                    }*/
                }
            }
        }
    }
}