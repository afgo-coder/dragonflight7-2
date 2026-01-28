using UnityEngine;

public class UIcontrol : MonoBehaviour
{
    public Player player;

    public void Fire()
    {
        player.Fire();
    }

    public void LazerOn()
    {
        player.LazerOn();
    }

    public void LazerOff()
    {
        player.LazerOff();
    }
}
