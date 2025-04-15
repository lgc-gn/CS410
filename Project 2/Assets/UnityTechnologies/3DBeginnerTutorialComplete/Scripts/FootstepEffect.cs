using UnityEngine;

public class FootstepEffect : MonoBehaviour
{

    public ParticleSystem RightFootEffect;
    public ParticleSystem LeftFootEffect;

    void FootstepEvent(string whichFoot)
    {
        //print("Footstep : " + whichFoot);

        if (whichFoot == "R")
        {
            print("Right foot effect");
            RightFootEffect.Play();
        }
        else if ( whichFoot == "L")
        {
            print("Left foot effect");
            LeftFootEffect.Play();
        }
    }

}
