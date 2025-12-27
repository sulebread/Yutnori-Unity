using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class YutnoriManager : MonoBehaviour
{
    private static YutnoriManager instance;
    public static YutnoriManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameObject($"@YutnoriManager").AddComponent<YutnoriManager>();
            }
            return instance;
        }
    }

    public List<Point> points;
    public Transform pointRoot;

    public List<Player> players;

    [SerializeField] private Transform waitTransform;
    [SerializeField] private Transform finishTrnasform;

    private Player currentPlayer;

    private void Start()
    {
        instance = this;
        points = pointRoot.GetComponentsInChildren<Point>().ToList();
        players = waitTransform.GetComponentsInChildren<Player>().ToList();
    }

    public void MovePlayer(Point point)
    {
        if (currentPlayer == null)
            return;

        var teamPlayers = players.FindAll(player => player.pointIndex == currentPlayer.pointIndex && player.team == currentPlayer.team && currentPlayer.pointIndex != -999 && currentPlayer.pointIndex != 999);

        currentPlayer.pointIndex = point.index;
        if (point.index == -999)
            currentPlayer.transform.parent = waitTransform;
        else if (point.index == 999)
            currentPlayer.transform.parent = finishTrnasform;
        else
        {
            currentPlayer.transform.parent = point.transform;
            foreach (var teamPlayer in teamPlayers)
            {
                teamPlayer.transform.parent = point.transform;
                teamPlayer.pointIndex = point.index;
            }

            var deadPlayers = players.FindAll(player => player.pointIndex == point.index && player.team != currentPlayer.team);
            foreach (var deadPlayer in deadPlayers)
            {
                deadPlayer.transform.parent = waitTransform;
                deadPlayer.pointIndex = -999;
            }
        }
        currentPlayer = null;
    }

    public void SetPlayer(Player player)
    {
        currentPlayer = player;
    }
}
