using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textUpdate : MonoBehaviour {
    public string MyText;
    public GameObject Kp_Display;

    public void MyFunction(string MyCount)
    {
        if (MyCount == "CANCELED")
        {
            print("Canceled");
            MyText = "";
            MyCount = "";
        }

        MyText += MyCount;
        print(MyText);
    }

    void Update()
    {
        Text text = Kp_Display.GetComponent<Text>();
        text.text = MyText;
    }
}
