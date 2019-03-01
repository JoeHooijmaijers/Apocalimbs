using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mutation : MonoBehaviour
{
    public List<GameObject> rightArms;
    public List<GameObject> leftArms;
    public Animator anim;

    public int lArmMutation = 1, rArmMutation = 1, lLegMutation = 1, rLegMutation = 1;
    public int lArmPts, rArmPts, lLegPts, rLegsPts;

    private int lArmMaxPts, rArmMaxPts, lLegMaxPts, rLegsMaxPts;

    private void Start()
    {
        Destroy(gameObject.transform.Find("RightArm/RightShoulder").gameObject);
        GameObject newArm = (GameObject)Instantiate(rightArms[1], gameObject.transform.Find("RightArm").transform);
        newArm.name = "RightShoulder";
        Destroy(gameObject.transform.Find("LeftArm/LeftShoulder").gameObject);
        GameObject newArm2 = (GameObject)Instantiate(leftArms[0], gameObject.transform.Find("LeftArm").transform);
        newArm2.name = "LeftShoulder";
    }

    public void MutateTemp()
    {
        anim.Rebind();
    }

    public void LArmAbsorb(int amount)
    {
        lArmPts += amount;
        Mutate();
        
    }

    public void RArmAbsorb(int amount)
    {
        rArmPts += amount;
        Mutate();
    }

    public void LLegAbsorb(int amount)
    {
        lLegPts += amount;
        Mutate();
    }

    public void RLegAbsorb(int amount)
    {
        rLegsPts += amount;
        Mutate();
    }

    private void Mutate()
    {
        if(lArmPts >= lArmMaxPts)
        {
            lArmMutation++;
            lArmMaxPts *= 3;

        }
        if(rArmPts >= rArmMaxPts)
        {
            rArmMutation++;
            rArmMaxPts *= 3;
        }
        if(lLegPts >= lLegMaxPts)
        {
            lLegMutation++;
            lLegMaxPts *= 3;
        }
        if(rLegsPts >= rLegsMaxPts)
        {
            rLegMutation++;
            rLegsMaxPts *= 3;
        }
    }
}
