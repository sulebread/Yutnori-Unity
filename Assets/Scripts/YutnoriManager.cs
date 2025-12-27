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

    public void MovePlayer()
    {
        
    }

    public void EnableBoard(bool isEnable)
    {
        
    }
}
