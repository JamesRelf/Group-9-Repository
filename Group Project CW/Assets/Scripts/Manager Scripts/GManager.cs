using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GManager : MonoBehaviour
{

    public int GScore;
    public ProductDetails prodDetails;
    public float GTime;
    public float GBudget;
    public Vector3 Gplayerpos;
    public GameObject Playerlocation;
    public GameObject GPickupObjects;
    public string [] Gitems;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }
    void PlayerPosUpdate()
    {
        Gplayerpos = Playerlocation.transform.position;
        Debug.Log(Gplayerpos);
    }
    void ScoreUpdate()
    {

    }
    void BudgetUpdate()
    {

    }
    void TimeUpdate()
    {

    }
    void CurrentProducts()
    {

    }

}
