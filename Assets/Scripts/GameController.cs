using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private GameObject[] mWaypoints;
    private bool mRandomWaypoints;
    private bool mUsingMouseControl;
    private int mNumEnemiesTouched;

    [SerializeField]
    private Text mRandomWaypointText;

    [SerializeField]
    private Text mHeroMovementText;

    [SerializeField]
    private Text mTouchedEnemiesText;

    public GameObject[] getWayPoints()
    {
        return mWaypoints;
    }

    public GameObject getWayPoint(int counter)
    {
        Debug.Assert(counter >= 0 && counter < mWaypoints.Length);
        return mWaypoints[counter];
    }

    public bool GetRandomWaypoints()
    {
        return mRandomWaypoints;
    }

    public bool ToggleRandomWaypoints()
    {
        return mRandomWaypoints = !mRandomWaypoints;
    }

    public bool GetUsingMouseControl()
    {
        return mUsingMouseControl;
    }

    public bool ToggleUsingMouseControl()
    {
        return mUsingMouseControl = !mUsingMouseControl;
    }

    public void IncrementNumEnemiesTouched()
    {
        ++mNumEnemiesTouched;
    }

    private void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            ToggleRandomWaypoints();
        }
    }

    private void UpdateUI()
    {
        if (mRandomWaypoints)
        {
            mRandomWaypointText.text = "Waypoints: random";
        }
        else
        {
            mRandomWaypointText.text = "Waypoints: sequence";
        }

        if (mUsingMouseControl)
        {
            mHeroMovementText.text = "Hero movement: mouse";
        }
        else
        {
            mHeroMovementText.text = "Hero movement: keyboard";
        }

        mTouchedEnemiesText.text = "Touched enemies: " + mNumEnemiesTouched;
        //TODO
    }

    void Update()
    {
        HandleInput();
        UpdateUI();
    }
}
