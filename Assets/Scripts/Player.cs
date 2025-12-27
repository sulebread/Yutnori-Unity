using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Team team;
    public Gender gender;
    public int pointIndex;

    private Button button;
    private Image background;

    private void Start()
    {
        button = GetComponent<Button>();
        background = GetComponent<Image>();

        var colorString = team switch
        {
            Team.Green => "#1F3D2B",
            Team.White => "#F4F1EA",
            Team.Brown => "#6B4F3F",
        };
        if (ColorUtility.TryParseHtmlString(colorString, out Color color))
        {
            background.color = color;
        }

        button.onClick.AddListener(() =>
        {
            YutnoriManager.Instance.SetPlayer(this);
        });
    }
}
