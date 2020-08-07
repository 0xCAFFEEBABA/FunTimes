using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Language : MonoBehaviour
{
    public enum language {English, Greek}
    public language setLanguage;

    public enum word {mainMenu, play, category1, category2, category3, category4, category5, category6}
    public word setWord;

    string[,] categories = new string[2, 8]
    {
        // English
        {"main menu", "play", "family time", "sexy time", "macho time", "girly time", "daring time", "school time"},
        // Greek
        {"μενού", "παίξε", "για ασφάλεια", "για ενηλίκους", "για αγόρια", "για κορίτσια", "για τολμηρούς", "για μαθητές"}
    };

    // Update is called once per frame
    void Update()
    {
        this.GetComponent<Text>().text = categories[(int)setLanguage, (int)setWord];
    }


    
}
