using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mutation : MonoBehaviour
{
    public int lArmMutation = 1, rArmMutation = 1, lLegMutation = 1, rLegMutation = 1;
    public int lArmPts, rArmPts, lLegPts, rLegsPts;

    private int lArmMaxPts, rArmMaxPts, lLegMaxPts, rLegsMaxPts;

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
