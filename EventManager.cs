using SFML.System;

namespace Invaders;

public delegate void FireShotEvent(Vector2f direction, Vector2f position, bool player);
public delegate void PlayerHitEvent();
public delegate void TimeToBlowEvent(Vector2f position);

public class EventManager
{
    public event FireShotEvent Shot;
    public event PlayerHitEvent PlayerHit;
    public event TimeToBlowEvent TimeToBlow;

    private bool changeShot;
    private Vector2f shotDirection;
    private Vector2f shotPosition;
    private bool shotPlayer;

    private bool changePlayerHit;
    private bool changeTTB;
    private Vector2f TTBPosition;

    public void handleEvents()
    {
        if (changeShot)
        {
            Shot?.Invoke(shotDirection, shotPosition, shotPlayer);
            changeShot = false;
        }

        if (changePlayerHit)
        {
            PlayerHit?.Invoke();
            changePlayerHit = false;
        }

        if (changeTTB)
        {
            TimeToBlow?.Invoke(TTBPosition);
            changeTTB = false;
        }
    }


    public void PublishShot(Vector2f direction, Vector2f position, bool player)
    {
        shotDirection = direction;
        shotPosition = position;
        shotPlayer = player;
        changeShot = true;
    }

    public void PublishPlayerHit()
    {
        changePlayerHit = true;
    }

    public void PublishTimeToBlow(Vector2f position)
    {
        Console.WriteLine("sidfgh");
        TTBPosition = position;
        changeTTB = true;
    }
}