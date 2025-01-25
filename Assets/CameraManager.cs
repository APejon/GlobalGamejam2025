using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraManager : MonoBehaviour
{
    //REMEMBER THIS SEQUENCE:
    // 1- Disable Initial Followee
    // 2- Activate next camera
    // 3- Spawn or move players
    // 4- Activate next followee
    // 5- Disable last camera
    
    //PLEASE UPDATE THIS IF MORE STAGES ARE AVAILABLE
    private int noOfStages = 3;
    [SerializeField] GameObject[] Cameras;
    [SerializeField] GameObject[] Pos;

    void Start()
    {
        for (int i = 0; i < Cameras.Length; i++)
            Cameras[i].SetActive(false);
        for (int i = 0; i < Pos.Length; i++)
            Pos[i].SetActive(false);
    }

    public void ShowPlayer1()
    {
        Cameras[3].SetActive(true);
    }

    public void ShowPlayer2()
    {
        Cameras[4].SetActive(true);
    }

    public void ShowStage(int stageNumber)
    {
        Cameras[stageNumber].SetActive(true);
    }

    public void ActivateFollowee(int followeeNumber)
    {
        Pos[followeeNumber]. SetActive(true);
    }

    public int FindActiveCamera(int avoid)
    {
        for (int i = 0; i < Cameras.Length; i++)
        {
            if (Cameras[i].activeSelf && i != avoid)
            {
                return (i);
            }
        }
        return (-1);
    }
}
