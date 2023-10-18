using SFML.System;

namespace Invaders;

public delegate void FireShotEvent(Vector2f direction, Vector2f position, bool player);
public class EventManager
{
    public event FireShotEvent Shot;

    private bool changeShot;
    private Vector2f shotDirection;
    private Vector2f shotPosition;
    private bool shotPlayer;

    public void handleEvents()
    {
        if (changeShot)
        {
            Shot?.Invoke(shotDirection, shotPosition, shotPlayer);
            Console.WriteLine("hej");
            changeShot = false;
        }
    }


    public void PublishShot(Vector2f direction, Vector2f position, bool player)
    {
        shotDirection = direction;
        shotPosition = position;
        shotPlayer = player;
        changeShot = true;
    }
}