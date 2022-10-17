using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName= "SectionData")]
public class SectionData : ScriptableObject
{
    public enum Direction 
    {
        North, 
        South, 
        East, 
        West
    }

    public Vector2 sectionSize = new Vector2(10f,10f);

    [SerializeField] private GameObject[] sectionObjects;
    [SerializeField] private Direction entryDirection;
    [SerializeField] private Direction exitDirection;

    public Direction getEntryDirection() {
        return this.entryDirection;
    }

    public Direction getExitDirection() {
        return this.exitDirection;
    }

    public GameObject[] getSectionObjects() {
        return this.sectionObjects;
    }

    
}
