using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public GameObject [] panels;
    public Text distanceText;
    public Text scoreText;
    public Slider cooldown;

    private float cooldownTime;

    void Update()
    {
        distanceText.text = "" + (int)SharedValues.distance;

        if(cooldown.value < cooldownTime)
        {
            cooldown.value += Time.deltaTime;
        }
    }

    public void SetCooldown(float value)
    {
        cooldown.maxValue = value;
        cooldown.value    = value;
        cooldownTime      = value;
    }

    public void ResetCooldown()
    {
        cooldown.value = 0;
    }

    public void ShowPanel (int index)
    {
        for (int i = 0; i < panels.Length; i++)
        {
            bool isActive = (i == index);
            
            if (panels[i].activeSelf != isActive)
            {
                panels[i].SetActive(isActive);
            }
        }
    }

    public void PrintScore ()
    {
        scoreText.text = "Your Score: " + SharedValues.score;
    }
}
