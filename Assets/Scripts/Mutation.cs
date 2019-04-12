using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mutation : MonoBehaviour
{
    public List<GameObject> rightArms;
    public List<GameObject> leftArms;
    public Animator anim;

    public int lArmMutation = 0, rArmMutation = 0, lLegMutation = 0, rLegMutation = 0;
    public int lArmPts, rArmPts, lLegPts, rLegsPts;

   [SerializeField]private int lArmMaxPts, rArmMaxPts, lLegMaxPts, rLegsMaxPts;

    private void Start()
    {
        Destroy(gameObject.transform.Find("RightArm/RightShoulder").gameObject);
        GameObject newArm = (GameObject)Instantiate(rightArms[rArmMutation], gameObject.transform.Find("RightArm").transform);
        newArm.name = "RightShoulder";
        Destroy(gameObject.transform.Find("LeftArm/LeftShoulder").gameObject);
        GameObject newArm2 = (GameObject)Instantiate(leftArms[0], gameObject.transform.Find("LeftArm").transform);
        newArm2.name = "LeftShoulder";
        StartCoroutine(Rebind());
    }

    IEnumerator Rebind()
    {
        yield return new WaitForSeconds(0.01f);
        anim.Rebind();
    }

    public void AbsorbMutations(int lArmAmount, int rArmAmount, int lLegAmount, int rLegAmount)
    {
        lArmPts += lArmAmount;
        rArmPts += rArmAmount;
        lLegPts += lLegAmount;
        rLegsPts += rLegAmount;
        Mutate();
    }

    private void Mutate()
    {
        if(lArmPts >= lArmMaxPts)
        {
            lArmMutation++;
            Destroy(gameObject.transform.Find("LeftArm/LeftShoulder").gameObject);
            GameObject newArm = (GameObject)Instantiate(leftArms[lArmMutation], gameObject.transform.Find("LeftArm").transform);
            newArm.name = "LeftShoulder";
            StartCoroutine(Rebind());
            lArmMaxPts *= 3;
        }
        if(rArmPts >= rArmMaxPts)
        {
            rArmMutation++;
            Destroy(gameObject.transform.Find("RightArm/RightShoulder").gameObject);
            GameObject newArm = (GameObject)Instantiate(rightArms[rArmMutation], gameObject.transform.Find("RightArm").transform);
            newArm.name = "RightShoulder";
            StartCoroutine(Rebind());
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
