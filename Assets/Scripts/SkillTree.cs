using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillTree : MonoBehaviour {

    [SerializeField]
    Skill[] skillset_1;
    [SerializeField]
    Skill[] skillset_2;
    [SerializeField]
    Skill[] skillset_3;
    [SerializeField]
    Sprite blue_button_sprite;

	// Use this for initialization
	void Start ()
    {
        Debug.Log("Play");
        for (int a = 0; a < skillset_1.Length; a++)
        {
            if (skillset_1[a].ps.isPlaying)
                skillset_1[a].ps.Stop();
        }
        for (int b = 0; b < skillset_2.Length; b++)
        {
            if (skillset_2[b].ps.isPlaying)
                skillset_2[b].ps.Stop();
        }
        for (int c = 0; c < skillset_3.Length; c++)
        {
            if (skillset_3[c].ps.isPlaying)
                skillset_3[c].ps.Stop();
        }
        skillset_1[0].ps.Play();
    }
	
	// Update is called once per frame
	void Update ()
    {
        //if(skillset_1[0].ps.isPlaying)
        //{
        //    skillset_1[0].ps.Stop();
        //}
        //Debug.Log(skillset_1[0].ps.isPlaying);
	}

    public void Buy(Button button)
    {
        //skills.hasbeenBought = true;
        for(int a = 0; a < skillset_1.Length; a++)
        {
            if(button == skillset_1[a].button)
            {
                if(a == 0 || a != 0 && skillset_1[a - 1].hasbeenBought)
                {
                    skillset_1[a].hasbeenBought = true;
                }
                else
                {
                    //Say that it cannot be bought
                }
            }
        }

        for (int b = 0; b < skillset_2.Length; b++)
        {
            if (button == skillset_2[b].button)
            {
                if (b == 0 || b != 0 && skillset_2[b - 1].hasbeenBought)
                {
                    skillset_2[b].hasbeenBought = true;
                }
                else
                {
                    //Say that it cannot be bought
                }
            }
        }

        for (int c = 0; c < skillset_3.Length; c++)
        {
            if (button == skillset_3[c].button)
            {
                if (c == 0 || c != 0 && skillset_3[c - 1].hasbeenBought)
                {
                    skillset_3[c].hasbeenBought = true;
                }
                else
                {
                    //Say that it cannot be bought
                }
            }
        }
        Debug.Log(button);
        BuyingSkillsets();
    }

    void BuyingSkillsets()
    {
        Button[]temp = new Button[1];//to store button for setting interactable to be change later on
        bool similar = false;//if temp array has duplicate button
        bool added = false;//if a button has been added to the temp array
        for (int a = 0; a < skillset_1.Length; a++)//skillset1
        {
            if (skillset_1[a].hasbeenBought && skillset_1[a].button.interactable)
            {
                if (temp.Length > 0)
                {
                    Debug.Log(temp.Length);
                    for (int z = 0; z < temp.Length; z++)
                    {
                        if(temp[z] == skillset_1[a].button)
                            similar = true;
                    }
                    if (!similar)
                    {
                        temp[0] = skillset_1[a].button;
                        added = true;
                    }
                }

                skillset_1[a].ps.Stop();
                ChangeButton(skillset_1[a].button);
                if (a < (skillset_1.Length - 1))
                {
                    skillset_1[a + 1].ps.Play();
                }
            }
        }

        for (int b = 0; b < skillset_2.Length; b++)//skillset2
        {
            if (skillset_2[b].hasbeenBought && skillset_2[b].button.interactable)
            {
                if (temp.Length > 0)
                {
                    for (int z = 0; z < temp.Length; z++)
                    {
                        if (temp[z] == skillset_2[b].button)
                            similar = true;
                    }
                    if (!similar)
                    {
                        temp[0] = skillset_2[b].button;
                        added = true;
                    }
                }
                skillset_2[b].ps.Stop();
                ChangeButton(skillset_2[b].button);
                if (b < (skillset_2.Length - 1))
                    skillset_2[b + 1].ps.Play();
            }
        }

        for(int c = 0; c < skillset_3.Length;c++)//skillset3
        {
            if(skillset_3[c].hasbeenBought && skillset_3[c].button.interactable)
            {
                if (temp.Length > 0)
                {
                    for (int z = 0; z < temp.Length; z++)
                    {
                        if (temp[z] == skillset_3[c].button)
                            similar = true;
                    }
                    if (!similar)
                    {
                        temp[0] = skillset_3[c].button;
                        added = true;
                    }
                }

                skillset_3[c].ps.Stop();
                ChangeButton(skillset_3[c].button);
                if (c < (skillset_3.Length - 1))
                    skillset_3[c + 1].ps.Play();
            }
        }
        if (added)
        {
            for (int a = 0; a < temp.Length; a++)
            {
                temp[a].interactable = false;
            }
        }
    }

    void ChangeButton(Button button)
    {
        button.image.sprite = blue_button_sprite;
    }





}
