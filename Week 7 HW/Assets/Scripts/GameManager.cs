using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text title; //holds ui title
    public Text description;  //holds ui description

    public Button Forward;  //north 
    public Button Backward;  //south
    public Button Right;  //east
    public Button Left;  //west

    public int numLocations;

    public Location currentLocation; //the current location

    public Location[] locations; //array of all the locations

    string filePath = "/TextFiles/Location<num>.json"; //default path to location files

    //once at the start
    void Start()
    {
        filePath = Application.dataPath + filePath; //full path to files

        locations = new Location[numLocations]; //init array to have numLocation slots

        for (int i = 0; i < locations.Length; i++)
        { //0 to locations.Length
            string locPath = filePath.Replace("<num>", "" + i); //creating a path to file num "i"

            string fileContent = File.ReadAllText(locPath); //fileContent will hold all the text from the file at locPath

            Location l = JsonUtility.FromJson<Location>(fileContent);

            locations[i] = l;
        }

        UpdateLocation(0);
    }

    public void GoFront()
    {
        UpdateLocation(currentLocation.ForwardLocation);
    }

    public void GoBack()
    {
        UpdateLocation(currentLocation.BackwardLocation);
    }

    public void GoRight()
    {
        UpdateLocation(currentLocation.RightLocation);
    }

    public void GoLeft()
    {
        UpdateLocation(currentLocation.LeftLocation);
    }

    public void UpdateLocation(int locNum)
    {
        currentLocation = locations[locNum];

        title.text = currentLocation.title;
        description.text = currentLocation.description;

        if (currentLocation.ForwardLocation < 0)
        {
            Forward.gameObject.SetActive(false);
        }
        else
        {
            Forward.gameObject.SetActive(true);
        }

        if (currentLocation.BackwardLocation < 0)
        {
            Backward.gameObject.SetActive(false);
        }
        else
        {
            Backward.gameObject.SetActive(true);
        }

        if (currentLocation.RightLocation < 0)
        {
            Right.gameObject.SetActive(false);
        }
        else
        {
            Right.gameObject.SetActive(true);
        }

        if (currentLocation.LeftLocation < 0)
        {
            Left.gameObject.SetActive(false);
        }
        else
        {
            Left.gameObject.SetActive(true);
        }
    }
}
