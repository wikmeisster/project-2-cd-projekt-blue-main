using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLayoutGenerator : MonoBehaviour
{
    [SerializeField] private SectionData[] sectionData;
    [SerializeField] private SectionData firstSection;
    private SectionData previousSection;
    [SerializeField] private Vector3 spawnOrigin;
    private Vector3 spawnPos;
    [SerializeField] private int numInitialSections = 5;

    void OnEnable() {
        TriggerExit.OnSectionExited += chooseAndGenerateSection;
    }

    private void OnDisable() {
        TriggerExit.OnSectionExited -= chooseAndGenerateSection;
    }



    // Start is called before the first frame update
    void Start()
    {
        this.previousSection = this.firstSection;
        Instantiate(firstSection.getSectionObjects()[0], spawnPos + spawnOrigin, Quaternion.identity);
        for (int i=1; i < numInitialSections; i++) {
            chooseAndGenerateSection();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T)) {
            chooseAndGenerateSection();
        }
    }

    private void chooseAndGenerateSection() {
        SectionData sectionToSpawn = chooseNextSection();

        GameObject objectFromSection = sectionToSpawn.getSectionObjects()[Random.Range(0,sectionToSpawn.getSectionObjects().Length)];
        this.previousSection = sectionToSpawn;
        Instantiate(objectFromSection, spawnPos + spawnOrigin, objectFromSection.transform.rotation);
    }

     SectionData chooseNextSection()
    {
        List<SectionData> allowedSections = new List<SectionData>();
        SectionData nextSection = null;

        SectionData.Direction nextRequiredDirection = SectionData.Direction.North;

        switch (previousSection.getExitDirection())
        {
            case SectionData.Direction.North:
                nextRequiredDirection = SectionData.Direction.South;
                this.spawnPos += new Vector3(0f, 0, previousSection.sectionSize.y);
                break;
            case SectionData.Direction.East:
                nextRequiredDirection = SectionData.Direction.West;
                this.spawnPos += new Vector3(previousSection.sectionSize.x, 0, 0);
                break;
            case SectionData.Direction.South:
                nextRequiredDirection = SectionData.Direction.North;
                this.spawnPos += new Vector3(0, 0, -previousSection.sectionSize.y);
                break;
            case SectionData.Direction.West:
                nextRequiredDirection = SectionData.Direction.East;
                spawnPos += new Vector3(-previousSection.sectionSize.x, 0, 0);
                break;
            default:
                break;
        }

        for (int i = 0; i < sectionData.Length; i++)
        {
            if (sectionData[i].getEntryDirection() == nextRequiredDirection)
            {
                allowedSections.Add(sectionData[i]);
            }
        }
        
        nextSection = allowedSections[Random.Range(0, allowedSections.Count)];

        return nextSection;

    }

    public void updateSpawnOrigin(Vector3 originDelta) {
        this.spawnOrigin += originDelta;
    }
}
