/*
 * This script is used to count how many runs the trainer has done. At the moment it doesn't work.
 */

using UnityEngine.UI;
using UnityEngine;

public class Runs : MonoBehaviour
{

    public GameObject brain;
    MasterAgent agent;

    Text text;
    // Start is called before the first frame update
    void Start() {
        text = GetComponentInChildren<Text>();
        agent = brain.GetComponent<MasterAgent>();
    }

    // Update is called once per frame
    void Update() {
        text.text = "Runs: " + agent.CompletedEpisodes;
    }
}
