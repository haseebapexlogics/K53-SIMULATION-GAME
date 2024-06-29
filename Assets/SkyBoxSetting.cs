using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SkyBoxSetting : MonoBehaviour
{

    public Material Skybox1;
    public Material Skybox2;
    public Material Skybox3;

    public int DesiredSkyBox;
    


    // Start is called before the first frame update
    void Start()
    {
        if (DesiredSkyBox == 1)
        {
            RenderSettings.skybox = Skybox1;
        }
        else if (DesiredSkyBox == 2)
        {
            RenderSettings.skybox = Skybox2;
        }
        else if (DesiredSkyBox == 3)
        {
            RenderSettings.skybox = Skybox3;
        }
    }

}
