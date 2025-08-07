using UnityEngine;
using System;
using Cinemachine;
using DBUS.Events.Turns;

public struct PlayerView
{
    public CinemachineVirtualCamera camera;
    public Canvas canvas;

    public void SetActive(bool active)
    {
        camera.Priority = active ? 100 : 0;
        canvas.enabled = active;
    }
}
public class TurnViewController
{
    private Player p1;
    private Player p2;
    private PlayerView p1View;
    private PlayerView p2View;

    public TurnViewController(Player p1, Player p2, PlayerView p1View,  PlayerView p2View)
    {
        this.p1 = p1;
        this.p2 = p2;
        this.p1View = p1View;
        this.p2View = p2View;

        EventBus.Instance.Subscribe<TurnStartedEvent>(OnTurnStart);
    }

    private void OnTurnStart(TurnStartedEvent evt)
    {
        p1View.SetActive(evt.player == p1);
        p2View.SetActive(evt.player == p2);
    }

}
