using MoveLogic;
using UnityEngine;
using UnityEngine.UI;

public class MoveCamera : MonoBehaviour
{
    public Slider zoom;
   
    private const float step = 0.01F;
    
    void Start()
    {
        //ResetPlayer()
        LoadPlayer(); 
    }

    void Update()
    {
        if (Time.timeScale == 0) return;
        if (Input.GetKey(KeyCode.Minus))
            if (transform.position.x < zoom.maxValue)
            {
                transform.position = new Vector3(transform.position.x + step, transform.position.x + step, transform.position.z);
                zoom.value = zoom.maxValue + zoom.minValue - transform.position.x;
                SaveSystem.SavePlayer(this);
            }

        if (transform.position.x > zoom.minValue)
            if (Input.GetKey(KeyCode.Equals))
            {
                transform.position = new Vector3(transform.position.x - step, transform.position.x - step, transform.position.z);
                zoom.value = zoom.maxValue + zoom.minValue - transform.position.x;
                SaveSystem.SavePlayer(this); 
            }
    }
    public void ValueChangeCheck()
    {
        transform.position = new Vector3(zoom.maxValue + zoom.minValue - zoom.value, zoom.maxValue + zoom.minValue - zoom.value, transform.position.z);
        zoom.value = zoom.minValue + zoom.maxValue - transform.position.x;
        SaveSystem.SavePlayer(this);
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer(GetType().Name);
        zoom.value = data.zoom;
        transform.position = new Vector3(data.x,data.y,data.z);
    }

    private void ResetPlayer()
    {
        zoom.value = zoom.minValue + zoom.maxValue - transform.position.x;
        SaveSystem.SavePlayer(this);
    }
}
