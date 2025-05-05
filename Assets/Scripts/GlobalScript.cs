using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TMPro;

public class GlobalScript : MonoBehaviour
{
    
    // Storing Design Elements Selection at Each Task
    private string task1_selection = null;
    private string task2_selection = null;
    private string task3_selection = null;
    private string task4_selection = null;

    // Storing Questionnaire Choices
    public string user_name;
    public Canvas task1_question1_canvas;
    public ToggleGroup task1_toggleGroup;
    public Button task1_submitButton;
    private string task1_toggleLabel;

    // CSV file path
    private string csvFilePath;

    void Start()
    {
        
        task1_submitButton.onClick.AddListener(task1_OnSubmit);

        // File setup
        //csvFilePath = Path.Combine(Application.persistentDataPath, "Selections.csv");
        csvFilePath = "./AngerQuestionnaire.csv";

        if (!File.Exists(csvFilePath))
        {
            File.WriteAllText(csvFilePath, "Timestamp,UserName,ButtonSelection,ToggleSelection\n");
        }
        
    }

    // Choice of Shape from Task 1
    public void OnButtonTask1(Button clickedButton)
    {
        task1_selection = clickedButton.GetComponentInChildren<TMP_Text>().text;
        //Debug.Log("Task 1 selection: " + task1_selection);
    }

    // Choice of Color from Task 2
    public void OnButtonTask2(Button clickedButton)
    {
        task2_selection = clickedButton.GetComponentInChildren<TMP_Text>().text;
        //Debug.Log("Task 1 selection: " + task1_selection);
    }

    // Choice of Shape from Task 3
    public void OnButtonTask3(Button clickedButton)
    {
        task3_selection = clickedButton.GetComponentInChildren<TMP_Text>().text;
        //Debug.Log("Task 3 selection: " + task3_selection);
    }

    // Choice of Shape from Task 4
    public void OnButtonTask4(Button clickedButton)
    {
        task4_selection = clickedButton.GetComponentInChildren<TMP_Text>().text;
        //Debug.Log("Task 4 selection: " + task4_selection);
    }

    

    
   void task1_OnSubmit()
{
    // Original code
            Toggle selectedToggle = task1_toggleGroup.ActiveToggles().FirstOrDefault();
            
            if (selectedToggle != null)
            {
                task1_toggleLabel = selectedToggle.GetComponentInChildren<Text>().text;
                string timestamp = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                
                string csvLine = $"{timestamp},{user_name},{task1_selection},{task1_toggleLabel}\n";
                File.AppendAllText(csvFilePath, csvLine);
                
                task1_question1_canvas.gameObject.SetActive(false);

                Debug.Log("Saved selection: " + csvLine.Trim());
            }
            else
            {
                Debug.Log("No toggle selected in ActiveToggles().");
            }
}
    
}
