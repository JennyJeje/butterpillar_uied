using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;

public class ChangeText : MonoBehaviour
{
    public TMP_Text title;
    public TMP_Text desc;
    public GameObject dialogBox;
    public bool isDialogBoxActive = true;
    public Button btn;
    public TMP_Text btnName;
    
    private List<Caterpillar> caterpillar = new List<Caterpillar>();
    private int count;
    

    public void Start()
    {
        btn = btn.GetComponent<Button>();
        btnName = btnName.GetComponent<TMP_Text>();

        // Quelle: https://de.wikipedia.org/wiki/Raupe_(Schmetterling)
        caterpillar.Add(new Caterpillar("Merkmale der Raupe", "Die Raupen der Schmetterlinge bestehen, ähnlich wie bei anderen Insekten mit vollständiger Metamorphose, aus gleichmäßig aneinandergereihten Segmenten, die den Körper bilden."));
        caterpillar.Add(new Caterpillar("Merkmale der Raupe", "Schmetterlingsraupen haben (hinter dem Kopf) 14 Segmente, von denen meistens die letzten drei zu einem Analsegment verwachsen sind. Wie die Falter lassen sich auch die Raupen in die drei Bereiche Kopf, Brust und Hinterleib unterteilen."));
        caterpillar.Add(new Caterpillar("Der Kopf", "Der Kopf ist gewöhnlich durch Sklerotisierung verhärtet. Auf der Unterseite außen trägt er meist je sechs Punktaugen (Stemmata). Das wichtigste Merkmal sind die Mundwerkzeuge. Sie sind im Gegensatz zu den stummelförmig angelegten Fühlern stark ausgeprägt."));
        caterpillar.Add(new Caterpillar("Die Brust", "Die ersten drei Segmente bilden die Brust. Auf ihnen ist je ein Beinpaar platziert, die zu denen der Falter homolog, nur kürzer ausgebildet sind. Am Rücken des ersten Segments befindet sich normalerweise ein Nackenschild, der aus einer verhärteten Platte (einem Sklerit) besteht."));
        caterpillar.Add(new Caterpillar("Das Stigma oder die Atemlöcher", "Seitlich davon gibt es je eine porenartige Öffnung (ein Stigma), mit der das Tracheensystem mit Sauerstoff versorgt wird. Nur selten sind auf den anderen Brustsegmenten ebenfalls solche Öffnungen vorhanden."));
        caterpillar.Add(new Caterpillar("Das Abdomen oder das Hinterleib", "Die darauf folgenden 11 Segmente bilden das Abdomen, das aber nicht deutlich vom vorderen Teil des Körpers getrennt ist. Jedes dieser Segmente trägt ein Stigma für die Atmung. Einige dieser Segmente, meistens das sechste bis neunte, tragen Gliedmaßen, die aber keine eigentlichen Beine sind, sie tragen am Ende Hakenkränze zum besseren Festklammern."));
        caterpillar.Add(new Caterpillar("Die Bauchbeine", "Diese sogenannten Bauchbeine (oder Bauchfüße) sind in ihrer Gestalt im Gegensatz zu den echten Beinen ungegliedert, nicht sklerotisiert (verhärtet) und am Ende meist saugnapfartig verbreitert. Das vierte und fünfte Segment der Hinterleibs ist im Unterschied zu den sehr ähnlichen Larven der Blattwespen beinlos, diese besitzen lediglich ein beinfreies Segment."));
        
        count = 0;
        title.text = caterpillar[count].getTitle();
        desc.text = caterpillar[count].getDesc();
        btnName.text = "Info ausblenden";
    }
    
    public void SwitchBoxStatus()
    {
        if (isDialogBoxActive)
        {
            dialogBox.SetActive(false);
            isDialogBoxActive = false;
            btnName.text = "Info einblenden";
        } 
        else
        {
            dialogBox.SetActive(true);
            isDialogBoxActive = true;
            btnName.text = "Info ausblenden";
        }
    }

    public void ChangeBoxText()
    {
        if (count < caterpillar.Count-1)
        {
            count += 1;
            title.text = caterpillar[count].getTitle();
            desc.text = caterpillar[count].getDesc();
        }
        else
        {
            count = 0;
            title.text = caterpillar[count].getTitle();
            desc.text = caterpillar[count].getDesc();
            //dialogBox.SetActive(false);
        }

    } 
}

public class Caterpillar
{
    private string title;
    private string desc;

    public Caterpillar(string title, string desc)
    {
        this.title = title;
        this.desc = desc;
    }
    
    public string getTitle()
    {
        return title;
    }
    
    public void setTitle(string t){
        title = t;
    }

    public string getDesc()
    {
        return desc;
    }

    public void setDesc(string d)
    {
        desc = d;
    }
    
}
