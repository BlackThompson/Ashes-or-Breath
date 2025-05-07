using Oculus.Interaction;
using UnityEngine;

public class ArtWork : MonoBehaviour {

    public void Grabbed() {
        MuseumManager.SetHoldingStateArt();
    }

}