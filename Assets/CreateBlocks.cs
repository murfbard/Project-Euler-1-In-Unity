using UnityEngine;
using System.Collections;

public class CreateBlocks : MonoBehaviour {


	// Use this for initialization
	void Start () {
        CreateEachBlock();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnGUI()
    {
        var total = 0;
        
        GameObject[] gos = GameObject.FindGameObjectsWithTag("block");

        foreach (GameObject GO in gos)
        {
            TextMesh[] texts = GO.GetComponentsInChildren<TextMesh>();

            total += int.Parse(texts[0].text);
        }

        if (GUI.Button(new Rect(10, 50, 300, 100), "Remove numbers not divisible by 3 or 5"))
        {
            foreach (GameObject GO in gos)
            {
                int TryDivide = 0;

                TextMesh[] texts = GO.GetComponentsInChildren<TextMesh>();

                TryDivide += int.Parse(texts[0].text);

                if ((TryDivide % 5 != 0)
                    && (TryDivide % 3 != 0))
                {
                    Destroy(GO);
                }
            }
        }

        GUI.Label(new Rect(10, 10, 1000, 100), "Total Blocks: " + gos.Length);
        GUI.Label(new Rect(10, 30, 1000, 100), "Total Sum: " + total.ToString());
    }


    void CreateEachBlock()
    {
        int x = 0, y = 0, z = 0;

        for (int i = 1; i < 1000; i++)
        {
            GameObject go = (GameObject)Instantiate(Resources.Load("CubeWithText"));
            go.transform.position = new Vector3(x, y, z);
            go.tag = "block";

            var newtext = i.ToString();
            while (newtext.Length < 4)
            {
                newtext = "0" + newtext;
            }
            
            TextMesh[] texts = go.GetComponentsInChildren<TextMesh>();

            foreach (var text in texts)
            {
                text.text = newtext;
            }


            if (y == 9 && x == 9)
            {
                z++;
                x = 0;
                y = 0;
            }
            else
            {
                if (x < 9)
                {
                    x++;
                }
                else
                {
                    x = 0;
                    y++;
                }
            }

            
            

            

        }
    }
}
