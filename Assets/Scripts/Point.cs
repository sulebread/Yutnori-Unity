using UnityEngine;
using UnityEngine.UI;

public class Point : MonoBehaviour
{
    public int index;
    
    private Button button;

    private void Start()
    {
        index = int.Parse(this.name);

        button = GetComponent<Button>();
        button.onClick.AddListener(() =>
        {
            YutnoriManager.Instance.MovePlayer(this);
        });
    }
}
