using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(Button))]
public class SolutionController : MonoBehaviour
{
    private PointsController pointsLeftText;
    public Text tierTracker;
    private Button plusButton;
    private Button minusButton;
    public string resourcename;
    public int resourcecount;
    private SpriteRenderer render;
    private Sprite startsprite;
    public Image solImage;
    private Sprite startcircle;
    private SpriteRenderer tier_circle;
    public Image tier_circle_img;
        //private Sprite[] resource;
    public int count = 0;
    public int cost;
    public Text costText;
    public int startcount;
    public int bulkheadTier, sandduneTier, sandbagTier, seagrassTier;
    //values go land, human, animal
    public float inactive_opacity;
    private Color inactive;
    private Color active;
    private Color start_tier_color;
    private Color diff_tier_color;
    private Color initTierCircleCol;

    private float effectiveness;
    //effectiveness bar display
    //current progress


    void Awake()
    {
        initTierCircleCol = tier_circle_img.color;
        inactive = new Color(1f, 1f, 1f, inactive_opacity);
        active = new Color(1f, 1f, 1f, 1f);
        start_tier_color = new Color(70 / 255.0f, 193 / 255.0f, 73 / 255.0f, 1f);
        diff_tier_color = new Color(140 / 255.0f, 25 / 255.0f, 36 / 255.0f, 1f);
        Button[] buttons = this.GetComponentsInChildren<Button>();
        //Text[] textinp = this.GetComponentsInChildren<Text>();
        //tierTracker = textinp[1];
        //costText = textinp[0];
        costText.text = cost.ToString();
        plusButton = buttons[0].GetComponent<Button>();
        minusButton = buttons[1].GetComponent<Button>();
        SpriteRenderer[] spritelist = this.GetComponentsInChildren<SpriteRenderer>();
        //render = spritelist[2];
        //startsprite = render.sprite;
        //tier_circle = spritelist[3];
        //startcircle = tier_circle.sprite;
        //Debug.Log(tier_circle);
        pointsLeftText = GameObject.FindGameObjectWithTag("Points").GetComponent<PointsController>();
        /*resource = new Sprite[resourcecount];
        for (int i = 0; i < resourcecount; i++)
        {
            resource[i] = Resources.Load<Sprite>("Solutions/" + resourcename + (i + 1));
        }*/
        plusButton.onClick.AddListener(PlusTaskOnClick);
        minusButton.onClick.AddListener(MinusTaskOnClick);
    }


    void Update()
    {
        if (count == 0)
        {
            //render.sprite = null;
            solImage.color = Color.clear;
            tier_circle_img.color = Color.clear;
            //tier_circle.sprite = null;
            tierTracker.text = "";
        }
        else
        {
            solImage.color = Color.white;
            tier_circle_img.color = initTierCircleCol;
            //render.sprite = startsprite;
            //tier_circle.sprite = startcircle;
            tierTracker.text = count.ToString();
        }
        /*if (count == startcount)
        {
            tier_circle.color = start_tier_color;
        }
        else
        {
            tier_circle.color = diff_tier_color;
        }*/
        /*if (count == 0)
        {
            render.sprite = null;
        }
        else if (count == 1)
        {
            render.sprite = resource[0];
        }
        else if (count == 2)
        {
            render.sprite = resource[1];
        }
        else if (count == 3)
        {
            render.sprite = resource[2];
        }*/
    }

    void PlusTaskOnClick()
    {
        Debug.Log("Clicked plus button");
        Debug.Log("startcount:" + startcount);
        /* if (count < startcount && count != resourcecount && (pointsLeftText.pointsCount- (int)(cost * 0.5)) >= 0)
         {
             pointsLeftText.pointsCount -= (int)(cost * 0.5);
             count++;
         }
         else if (count >= startcount && count != resourcecount && (pointsLeftText.pointsCount - cost) >= 0)
         {
             pointsLeftText.pointsCount -= cost;
             count++;
         }*/
        if ((count+1) == 3 && (pointsLeftText.pointsCount - cost) >= 0)
        {
            count++;
            pointsLeftText.pointsCount -= cost;
        } else if((count+1) < 3 && (pointsLeftText.pointsCount - cost) >= 0)
        {
            count++;
            pointsLeftText.pointsCount -= cost;
        }
        Debug.Log(count);
    }

    void MinusTaskOnClick()
    {
        Debug.Log("Clicked minus button");
        Debug.Log("startcount:" + startcount);

        /*if (count <= startcount && count != 0)
        {
            pointsLeftText.pointsCount += (int)(cost * 0.5);
            count--;
        }
        else if (count != 0 && count > startcount)
        {
            pointsLeftText.pointsCount += cost;
            count--;
        }*/
        if ((count-1) == 0)
        {
            count--;
            pointsLeftText.pointsCount += cost;
        } else if((count-1) > 0)
        {
            count--;
            pointsLeftText.pointsCount += cost;
        }
        Debug.Log(count);
    }

}
