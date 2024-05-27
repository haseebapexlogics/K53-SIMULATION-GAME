using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class MCQPicker : MonoBehaviour
{
    public Text questionText;
    public Text questionNumberText;
    public GameObject optionPrefab;
    public Transform optionsParent;
    [SerializeField] private List<Question> questions = new List<Question>();
    [SerializeField] private List<Question> questionsOfAdvanceSearch = new List<Question>();
    public int currentQuestionIndex = 0;
    public string excelFileName;
    [HideInInspector] public List<Toggle> radioButtons;
    public string selectedLabelText;
    public string correctedOptionText;
    int NumberOfRows;
    public Transform progressPanel;
    public GameObject optionPrefabProgress;
    public Transform optionsParentProgress;
    public Text questionTextProgress;
    public Text questionProgressNumberText;
    public int currentQuestionIndexProgress = 0;
    public GameObject AlertPanel;
    public string ProgressType;
    bool QuestionStatus;
    [SerializeField] int RulesCount;
    [SerializeField] int SignCount;
    [SerializeField] int ControlCount;
    public bool SearchRules;
    public bool SearchControls;
    public bool SearchSign;
    public bool EnableAdvanceSearch;
    public bool ToggleCorrectSimpleTest;
    public bool ToggleInCorrectSimpleTest;
    public bool ToggleCorrectAdvanceTest;
    public bool ToggleInCorrectAdvanceTest;
    public Button RulesBtn;
    public Button ControlBtn;
    public Button SignBtn;
    int SignsMarks;
    int ControlMarks;
    int RulesMarks;
    public Text RulesText;
    public Text SignText;
    public Text ControlText;
    public Text RulesStatusText;
    public Text SignStatusText;
    public Text ControlStatusText;
    public Text OverAllResult;
    public ImageReferenceScriptable Images;
    public Image QuestionImage;
    public Image QuestionImageProgress;  
    public GameObject TimesAlertPanel;
    public static MCQPicker Instance;
    TextAsset csvFile;
    string[] lines;
    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        ProgressType = "FullTest";
        //StartTest();
    }
    public void StartTest()
    {
        questions.Clear();
        questionsOfAdvanceSearch.Clear();
        radioButtons.Clear();
        currentQuestionIndex = 0;
        currentQuestionIndexProgress = 0;
        RulesCount = 0;
        SignCount = 0;
        ControlCount = 0;
        SignsMarks = 0;
        RulesMarks = 0;
        ControlMarks = 0;
        LoadQuestions();
        DisplayQuestion(currentQuestionIndex);
    }
    
    public void ClickOnRestartBtn()
    {
        TimesAlertPanel.SetActive(false);
       
        currentQuestionIndex = 0;
        DisplayQuestion(currentQuestionIndex);
    }
    void LoadQuestions()
    {
        csvFile = null;
        lines = null;
        excelFileName = MenuHandler.Instance.CurrentFileName;
        csvFile = Resources.Load<TextAsset>(excelFileName);
        lines = csvFile.text.Split('\n');
        NumberOfRows = lines.Length - 1;
        //Debug.Log(lines.Length-1);
        foreach (string line in lines)
        {
            string[] values = line.Split(',');
            if (values.Length >= 8)
            {
                string question = values[0];
                string optionA = values[1];
                string optionB = values[2];
                string optionC = values[3];
                string CorrectAnswer = values[4];
                string CodeType = values[5];
                string ImageName = values[6];
                string Id = values[7];
                Question newQuestion = new Question(question, optionA, optionB, optionC, CorrectAnswer, CodeType, ImageName,Id);
                questions.Add(newQuestion);

                if (CodeType == "Rule")
                {
                    RulesCount++;
                }
                else if (CodeType == "Control")
                {
                    ControlCount++;
                }
                else if (CodeType == "Sign")
                {
                    SignCount++;
                }

            }
        }
    }
   void DisplayQuestion(int index)
    {
        questionNumberText.text = "Question " + questions[index].Id;
        questionText.text = questions[index].question;
        radioButtons.Clear();
        // Clear existing options
        foreach (Transform child in optionsParent)
        {
            Destroy(child.gameObject);
        }
        // Instantiate options
        InstantiateOption(questions[index].optionA);
        InstantiateOption(questions[index].optionB);
        InstantiateOption(questions[index].optionC);
        if (questions[index].ImageName.Trim().ToUpper() != "0")
        {
            QuestionImage.gameObject.SetActive(true);
            SetImageOfQuetion(questions[index].ImageName); ;
        }
        else
        {
            QuestionImage.gameObject.SetActive(false);
        }
        
        if (questions[currentQuestionIndex].selectedOption == null)
        {
            if (radioButtons.Count > 0)
            {
                radioButtons[0].isOn = true;
                RadioButtonToggled(radioButtons[0]);
            }
        }
        else
        {
            Debug.Log("already selected");
            if (questions[currentQuestionIndex].optionA == questions[currentQuestionIndex].selectedOption)
            {
                SetAlreadySelectedOptionBydefault(true, false, false);
            }
            else if (questions[currentQuestionIndex].optionB == questions[currentQuestionIndex].selectedOption)
            {
                SetAlreadySelectedOptionBydefault(false, true, false);
            }
            else if (questions[currentQuestionIndex].optionC == questions[currentQuestionIndex].selectedOption)
            {
                SetAlreadySelectedOptionBydefault(false, false, true);
            }
        }
    }
    public void ShowQuestionOfProgress(int i)
    {
        int dummyNumber=0;
        if (!EnableAdvanceSearch)
        {
            foreach (Question question in questions)
            {
                if (ProgressType == "Correct")
                {
                    if (question.selectedOption.Trim().ToUpper() == question.correctOption.Trim().ToUpper())
                    {
                        dummyNumber++;
                    }

                }
                else if (ProgressType == "Incorrect")
                {
                    if (question.selectedOption.Trim().ToUpper() != question.correctOption.Trim().ToUpper())
                    {
                        dummyNumber++;
                    }
                }
                else
                {
                    dummyNumber++;
                }
            }
            if (dummyNumber == 0)
            {
                Debug.Log("No record");
                return;
            }
           // Debug.Log(questions.Count);
            progressPanel.gameObject.SetActive(true);
            if (questions[i].ImageName.Trim().ToUpper() != "0")
            {
                QuestionImageProgress.gameObject.SetActive(true);
                SetImageOfQuetionProgress(questions[i].ImageName); ;
            }
            else
            {
                QuestionImageProgress.gameObject.SetActive(false);
            }
            questionProgressNumberText.text = "Question " + (i + 1);
            questionTextProgress.text = questions[i].question;
            // radioButtons.Clear();
            // Clear existing options
            foreach (Transform child in optionsParentProgress)
            {
                Destroy(child.gameObject);
            }
            // Instantiate UI elements for options
            GameObject optionAObject = Instantiate(optionPrefabProgress, optionsParentProgress.transform);
            Text optionAText = optionAObject.transform.GetChild(0).transform.GetChild(0).transform.GetComponent<Text>();
            optionAText.text = "A. " + questions[i].optionA;
            Text optionAText1 = optionAObject.transform.GetChild(1).transform.GetChild(0).transform.GetComponent<Text>();
            optionAText1.text = "A. " + questions[i].optionA;
            Text optionAText2 = optionAObject.transform.GetChild(2).transform.GetChild(0).transform.GetComponent<Text>();
            optionAText2.text = "A. " + questions[i].optionA;
            GameObject optionBObject = Instantiate(optionPrefabProgress, optionsParentProgress.transform);
            Text optionBText = optionBObject.transform.GetChild(0).transform.GetChild(0).transform.GetComponent<Text>();
            optionBText.text = "B. " + questions[i].optionB;
            Text optionBText1 = optionBObject.transform.GetChild(1).transform.GetChild(0).transform.GetComponent<Text>();
            optionBText1.text = "B. " + questions[i].optionB;
            Text optionBText2 = optionBObject.transform.GetChild(2).transform.GetChild(0).transform.GetComponent<Text>();
            optionBText2.text = "B. " + questions[i].optionB;
            GameObject optionCObject = Instantiate(optionPrefabProgress, optionsParentProgress.transform);
            Text optionCText = optionCObject.transform.GetChild(0).transform.GetChild(0).transform.GetComponent<Text>();
            optionCText.text = "C. " + questions[i].optionC;
            Text optionCText1 = optionCObject.transform.GetChild(1).transform.GetChild(0).transform.GetComponent<Text>();
            optionCText1.text = "C. " + questions[i].optionC;
            Text optionCText2 = optionCObject.transform.GetChild(2).transform.GetChild(0).transform.GetComponent<Text>();
            optionCText2.text = "C. " + questions[i].optionC;
            // Check the correctness of options and apply visual indicators
            ApplyVisualIndicators(optionAText, questions[i].optionA, questions[i].correctOption, questions[i].selectedOption);
            ApplyVisualIndicators(optionBText, questions[i].optionB, questions[i].correctOption, questions[i].selectedOption);
            ApplyVisualIndicators(optionCText, questions[i].optionC, questions[i].correctOption, questions[i].selectedOption);
        }
        else  //In case of Advance Search
        {
            if (questionsOfAdvanceSearch.Count ==0 )
            {
                Debug.Log("No record adnavc");
                return;
            }
           // Debug.Log(questionsOfAdvanceSearch.Count);
            progressPanel.gameObject.SetActive(true);
            if (questionsOfAdvanceSearch[i].ImageName.Trim().ToUpper() != "0")
            {
                QuestionImageProgress.gameObject.SetActive(true);
                SetImageOfQuetionProgress(questionsOfAdvanceSearch[i].ImageName); ;
            }
            else
            {
                QuestionImageProgress.gameObject.SetActive(false);
            }
            questionProgressNumberText.text = "Question " + questionsOfAdvanceSearch[i].Id;
            questionTextProgress.text = questionsOfAdvanceSearch[i].question;
            // radioButtons.Clear();
            // Clear existing options
            foreach (Transform child in optionsParentProgress)
            {
                Destroy(child.gameObject);
            }
            // Instantiate UI elements for options
            GameObject optionAObject = Instantiate(optionPrefabProgress, optionsParentProgress.transform);
            Text optionAText = optionAObject.transform.GetChild(0).transform.GetChild(0).transform.GetComponent<Text>();
            optionAText.text = "A. " + questionsOfAdvanceSearch[i].optionA;
            Text optionAText1 = optionAObject.transform.GetChild(1).transform.GetChild(0).transform.GetComponent<Text>();
            optionAText1.text = "A. " + questionsOfAdvanceSearch[i].optionA;
            Text optionAText2 = optionAObject.transform.GetChild(2).transform.GetChild(0).transform.GetComponent<Text>();
            optionAText2.text = "A. " + questionsOfAdvanceSearch[i].optionA;
            GameObject optionBObject = Instantiate(optionPrefabProgress, optionsParentProgress.transform);
            Text optionBText = optionBObject.transform.GetChild(0).transform.GetChild(0).transform.GetComponent<Text>();
            optionBText.text = "B. " + questionsOfAdvanceSearch[i].optionB;
            Text optionBText1 = optionBObject.transform.GetChild(1).transform.GetChild(0).transform.GetComponent<Text>();
            optionBText1.text = "B. " + questionsOfAdvanceSearch[i].optionB;
            Text optionBText2 = optionBObject.transform.GetChild(2).transform.GetChild(0).transform.GetComponent<Text>();
            optionBText2.text = "B. " + questionsOfAdvanceSearch[i].optionB;
            GameObject optionCObject = Instantiate(optionPrefabProgress, optionsParentProgress.transform);
            Text optionCText = optionCObject.transform.GetChild(0).transform.GetChild(0).transform.GetComponent<Text>();
            optionCText.text = "C. " + questionsOfAdvanceSearch[i].optionC;
            Text optionCText1 = optionCObject.transform.GetChild(1).transform.GetChild(0).transform.GetComponent<Text>();
            optionCText1.text = "C. " + questionsOfAdvanceSearch[i].optionC;
            Text optionCText2 = optionCObject.transform.GetChild(2).transform.GetChild(0).transform.GetComponent<Text>();
            optionCText2.text = "C. " + questionsOfAdvanceSearch[i].optionC;
            // Check the correctness of options and apply visual indicators
            ApplyVisualIndicators(optionAText, questionsOfAdvanceSearch[i].optionA, questionsOfAdvanceSearch[i].correctOption, questionsOfAdvanceSearch[i].selectedOption);
            ApplyVisualIndicators(optionBText, questionsOfAdvanceSearch[i].optionB, questionsOfAdvanceSearch[i].correctOption, questionsOfAdvanceSearch[i].selectedOption);
            ApplyVisualIndicators(optionCText, questionsOfAdvanceSearch[i].optionC, questionsOfAdvanceSearch[i].correctOption, questionsOfAdvanceSearch[i].selectedOption);
        }

    }
    public void SetTestType(string str)
    {
        ProgressType = str;
        switch (ProgressType)
        {
            case "FullTest":
                currentQuestionIndexProgress = 0;
                break;
            case "Incorrect":
                currentQuestionIndexProgress = 0;
                break;
            case "Correct":
                currentQuestionIndexProgress = 0;
                break;
            default:
                break;

        }
    } 
    public void SetAlreadySelectedOptionBydefault(bool OptionA, bool OptionB, bool OptionC)
    {
        if (OptionA)
        {
            Debug.Log("A");
            radioButtons[0].isOn = true;
            radioButtons[1].isOn = false;
            radioButtons[2].isOn = false;
        }
        if (OptionB)
        {
            Debug.Log("B");
            radioButtons[0].isOn = false;
            radioButtons[1].isOn = true;
            radioButtons[2].isOn = false;

        }
        if (OptionC)
        {
            Debug.Log("C");
            radioButtons[0].isOn = false;
            radioButtons[1].isOn = false;
            radioButtons[2].isOn = true;

        }
    }
    public void SetImageOfQuetion(string imgName)
    {
        QuestionImage.sprite = Images.Get_Image(imgName);
    }
    public void SetImageOfQuetionProgress(string imgName)
    {
        QuestionImageProgress.sprite = Images.Get_Image(imgName);
    }
    void InstantiateOption(string optionText)
    {
        //radioButtons.Clear();
        GameObject optionObject = Instantiate(optionPrefab, optionsParent);
        optionObject.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = optionText;
        optionObject.transform.GetChild(1).transform.GetChild(0).GetComponent<Text>().text = optionText;
        optionObject.GetComponent<Toggle>().group = optionsParent.GetComponent<ToggleGroup>();
        radioButtons.Add(optionObject.GetComponent<Toggle>());

        foreach (Toggle radioButton in radioButtons)
        {
            if (radioButton.GetComponentInChildren<Text>().text == optionText)
            {
                radioButton.onValueChanged.AddListener(delegate { RadioButtonToggled(radioButton); });
            }
        }
    }
    private void RadioButtonToggled(Toggle selectedRadioButton)
    {
        if (selectedRadioButton.isOn)
        {
            foreach (Toggle radioButton in radioButtons)
            {
                if (radioButton != selectedRadioButton)
                {
                    radioButton.isOn = false;
                    radioButton.transform.GetChild(1).gameObject.SetActive(false);
                }
            }
            selectedRadioButton.transform.GetChild(1).gameObject.SetActive(true);
            selectedLabelText = selectedRadioButton.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text;
            correctedOptionText = questions[currentQuestionIndex].correctOption;
            SaveSelectedOption(selectedRadioButton);
        }
    }
    public void OnSubmitButton()
    {
        MenuHandler.Instance.StopTimer();
        foreach (Question question in questions)
        {
            if (question.CodeType == "Sign"&&question.selectedOption.Trim().ToUpper()== question.correctOption.Trim().ToUpper())
            {
                SignsMarks++;
            }
            else if (question.CodeType == "Rule" && question.selectedOption.Trim().ToUpper() == question.correctOption.Trim().ToUpper())
            {
                RulesMarks++;
            }
            else if (question.CodeType == "Control" && question.selectedOption.Trim().ToUpper() == question.correctOption.Trim().ToUpper())
            {
                ControlMarks++;
            }
        }
        SignText.text = (SignsMarks + "/30").ToString();
        RulesText.text = (RulesMarks + "/30").ToString();
        ControlText.text = (ControlMarks + "/8").ToString();
        PlayerPrefs.SetInt("SignsMarks", SignsMarks);
        PlayerPrefs.SetInt("RulesMarks", RulesMarks);
        PlayerPrefs.SetInt("ControlMarks", ControlMarks);
        if (SignsMarks >= 23)
        {
            SignStatusText.text = "Pass";
            SignStatusText.color = Color.white;
        }
        else
        {
            SignStatusText.text = "Fail";
            SignStatusText.color = Color.red;
        }
        if (RulesMarks >= 22)
        {
            RulesStatusText.text = "Pass";
            RulesStatusText.color = Color.white;
        }
        else
        {
            RulesStatusText.text = "Fail";
            RulesStatusText.color = Color.red;
        }
        if (ControlMarks >= 6)
        {
            ControlStatusText.text = "Pass";
            SignStatusText.color = Color.white;
        }
        else
        {
            ControlStatusText.text = "Fail";
            ControlStatusText.color = Color.red;
        }
        if (SignsMarks >= 30 && RulesMarks >= 30 && ControlMarks >= 6)
        {
            OverAllResult.text = "Test Passed";
            OverAllResult.color = Color.white;
        }
        else
        {
            OverAllResult.text = "Test Failed";
            OverAllResult.color = Color.red;
        }
    }
    public void ClickOnNextQuetion()
    {
        if (currentQuestionIndex < NumberOfRows - 1)
        {
            currentQuestionIndex++;
            DisplayQuestion(currentQuestionIndex);
        }
        else if (currentQuestionIndex == NumberOfRows - 1)
        {
            ShowAlertPanel();
        }
    }
    public void ClickOnPreviousBtn()
    {
        if (currentQuestionIndex < NumberOfRows && currentQuestionIndex > 0)
        {
            currentQuestionIndex--;
            DisplayQuestion(currentQuestionIndex);
        }
    }
    public void ClickOnNextQuetionProgress()
    {
        if (!EnableAdvanceSearch)
        {
            if (questions.Count > 0)
            {
                if (ProgressType == "Correct" || ProgressType == "Incorrect")
                {
                    // Find the next question index based on progress type
                    int nextIndex = currentQuestionIndexProgress + 1;
                    while (nextIndex < NumberOfRows)
                    {
                        bool isCorrect = CheckQuestion(nextIndex);
                        if ((ProgressType == "Correct" && isCorrect) || (ProgressType == "Incorrect" && !isCorrect))
                        {
                            currentQuestionIndexProgress = nextIndex;
                            ShowQuestionOfProgress(currentQuestionIndexProgress);
                            return;
                        }
                        nextIndex++;
                    }

                    Debug.Log("No more questions found.");
                }
                else
                {
                    if (currentQuestionIndexProgress < NumberOfRows - 1)
                    {
                        currentQuestionIndexProgress++;
                        ShowQuestionOfProgress(currentQuestionIndexProgress);
                    }
                }
            }
            else
            {
                Debug.Log("sorry next");
            }        
        }
        else
        {
            if (questionsOfAdvanceSearch.Count > 0)
            {
                if (currentQuestionIndexProgress < NumberOfRows - 1)
                {
                    currentQuestionIndexProgress++;
                    ShowQuestionOfProgress(currentQuestionIndexProgress);
                }
            }
            else
            {
                Debug.Log("sorry next1");
            }       
        }
    }
    public void ClickOnPreviousBtnProgress()
    {      
        if (!EnableAdvanceSearch)
        {
            if (questions.Count > 0)
            {
                if (ProgressType == "Correct" || ProgressType == "Incorrect")
                {
                    // Find the previous question index based on progress type
                    int previousIndex = currentQuestionIndexProgress - 1;
                    while (previousIndex >= 0)
                    {
                        bool isCorrect = CheckQuestion(previousIndex);
                        if ((ProgressType == "Correct" && isCorrect) || (ProgressType == "Incorrect" && !isCorrect))
                        {
                            currentQuestionIndexProgress = previousIndex;
                            ShowQuestionOfProgress(currentQuestionIndexProgress);
                            return;
                        }
                        previousIndex--;
                    }

                    Debug.Log("No more questions found.");
                }
                else
                {
                    if (currentQuestionIndexProgress < NumberOfRows && currentQuestionIndexProgress > 0)
                    {
                        currentQuestionIndexProgress--;
                        ShowQuestionOfProgress(currentQuestionIndexProgress);
                    }
                }
            }
            else
            {
                Debug.Log("sorry pre");
            }         
        }
        else
        {
            if (questionsOfAdvanceSearch.Count > 0)
            {
                if (currentQuestionIndexProgress < NumberOfRows && currentQuestionIndexProgress > 0)
                {
                    currentQuestionIndexProgress--;
                    ShowQuestionOfProgress(currentQuestionIndexProgress);
                }
            }
            else
            {
                Debug.Log("sorry pre1");
            }
        }
    }
    void SaveSelectedOption(Toggle selectedRadioButton)
    {
        questions[currentQuestionIndex].selectedOption = selectedRadioButton.GetComponentInChildren<Text>().text;
    }
    public void ShowAlertPanel()
    {
        AlertPanel.SetActive(true);
    } 
    void ApplyVisualIndicators(Text optionText, string option, string correctOption, string selectedOption)
    {
        bool isCorrectAnswer;
        string OptionLabelText = option.Trim().ToUpper();
        string correctOptionString = correctOption.Trim().ToUpper();
        if (OptionLabelText.Equals(correctOptionString))
        {
            isCorrectAnswer = true;
        }
        else
        {
            isCorrectAnswer = false;
        }
        bool isSelectedAnswer = option.Equals(selectedOption); // Checks if the option matches the user-selected answer.
        Toggle toggle = optionText.transform.parent.transform.parent.GetComponent<Toggle>();
        // Set the text color based on correctness
        if (!isSelectedAnswer)
        {
            if (isCorrectAnswer)
            {
                // Mark correct answer as green
                optionText.color = Color.green;
                toggle.transform.GetChild(1).gameObject.SetActive(true);
            }
        }
        // Set the toggle state based on selection
        if (isSelectedAnswer)
        {
            if (OptionLabelText.Equals(correctOptionString))
            {
                optionText.color = Color.green;
                toggle.transform.GetChild(1).gameObject.SetActive(true);
            }
            else
            {
                optionText.color = Color.red;
                toggle.transform.GetChild(2).gameObject.SetActive(true);
            }
        }

        toggle.isOn = isSelectedAnswer;
    }
    public bool CheckQuestion(int i)
    {
        string correctOption = questions[i].correctOption;
        string selectedOption = questions[i].selectedOption;
        string LabelCorrectOption = correctOption.Trim().ToUpper();
        string LebelSelectedOption = selectedOption.Trim().ToUpper();
        if (LabelCorrectOption == LebelSelectedOption)
        {
            QuestionStatus = true;
        }
        else
        {
            QuestionStatus = false;
        }
        return QuestionStatus;
    }

    public bool CheckQuestionStr(Question q)
    {
        string correctOption = q.correctOption;
        string selectedOption = q.selectedOption;
        string LabelCorrectOption = correctOption.Trim().ToUpper();
        string LebelSelectedOption = selectedOption.Trim().ToUpper();
        if (LabelCorrectOption == LebelSelectedOption)
        {
            QuestionStatus = true;
        }
        else
        {
            QuestionStatus = false;
        }
        return QuestionStatus;
    }

    public void ClickOnAdvanceBtnSearch()
    {
        if (SearchControls || SearchSign || SearchRules)
        {
            EnableAdvanceSearch = true;
            if (ToggleCorrectAdvanceTest == false && ToggleInCorrectAdvanceTest == false)
            {
                ToggleCorrectAdvanceTest = true;
            }
            if (ToggleCorrectAdvanceTest)
            {
                SetTestType("Correct");
            }
            if (ToggleInCorrectAdvanceTest)
            {
                SetTestType("Incorrect");
            }
            OnAdvanceSearch(SearchRules, SearchSign, SearchControls, ProgressType);         
            ShowQuestionOfProgress(currentQuestionIndexProgress);
            if (questionsOfAdvanceSearch.Count > 0)
            {
                ClickOnNextQuetionProgress();
            }
            else
            {
                Debug.Log("NoRecordsFound");
            }          
        }     
    }
    public void OnAdvanceSearch(bool searchRules, bool searchSigns, bool searchControls, string progressType)
    {
        // Clear existing questions list to populate filtered questions
        questionsOfAdvanceSearch.Clear();
        bool isProgressTypeCorrect=false;

        bool isProgressTypeIncorrect=false;
        // Filter questions based on selected criteria
        foreach (Question question in questions)
        {
            
            if (progressType == "Correct")
            {
                if (question.selectedOption.Trim().ToUpper() == question.correctOption.Trim().ToUpper())
                {
                    isProgressTypeCorrect=true;
                }
                else
                {
                    isProgressTypeCorrect = false;
                }
            }
            else if (progressType == "Incorrect")
            {
                if (question.selectedOption.Trim().ToUpper() != question.correctOption.Trim().ToUpper())
                {
                    isProgressTypeIncorrect = true;
                }
                else
                {
                    isProgressTypeIncorrect = false;
                }
            }
            if (isProgressTypeCorrect)
            {
                if ((searchRules && question.CodeType == "Rule") ||
                (searchSigns && question.CodeType == "Sign") ||
                (searchControls && question.CodeType == "Control"))
                {
                    questionsOfAdvanceSearch.Add(question);
                }
            }
            else if (isProgressTypeIncorrect)
            {
                if ((searchRules && question.CodeType == "Rule") ||
               (searchSigns && question.CodeType == "Sign") ||
               (searchControls && question.CodeType == "Control"))
                {
                    questionsOfAdvanceSearch.Add(question);
                }
            }         
        }

        // Display the first question of the filtered list
        NumberOfRows = questionsOfAdvanceSearch.Count;
        currentQuestionIndexProgress = 0;
        if (questionsOfAdvanceSearch.Count > 0)
        {
            ShowQuestionOfProgress(currentQuestionIndexProgress);
        }      
    }
    public void ClickOnViewTestBtn()
    {
        EnableAdvanceSearch = false;
        NumberOfRows = questions.Count;
        currentQuestionIndexProgress = 0;
        SetTestType("FullTest");
        if (questions.Count > 0)
        {
            ClickOnNextQuetionProgress();
        }
    }
    public void ClickOnSimpleViewTestBtn()
    {
        EnableAdvanceSearch = false;
        if(ToggleCorrectSimpleTest==false&& ToggleInCorrectSimpleTest==false)
        {
            ToggleCorrectSimpleTest = true;
        }
        if (ToggleCorrectSimpleTest)
        {
            SetTestType("Correct");
        }
        if (ToggleInCorrectSimpleTest)
        {
            SetTestType("Incorrect");
        }
        NumberOfRows = questions.Count;
        ShowQuestionOfProgress(currentQuestionIndexProgress);
        if (questions.Count > 0)
        {
            ClickOnNextQuetionProgress();
        }    
    }  
    public void ClickOnToggleSimpleTestCorrect()
    {
        ToggleCorrectSimpleTest = true;
        ToggleInCorrectSimpleTest = false;
    }
    public void ClickOnToggleSimpleTestInCorrect()
    {
        ToggleCorrectSimpleTest = false;
        ToggleInCorrectSimpleTest = true;
    }
    public void ClickOnToggleAdvanceTestCorrect()
    {
        ToggleCorrectAdvanceTest = true;
        ToggleInCorrectAdvanceTest = false;
    }
    public void ClickOnToggleAdvanceTestInCorrect()
    {
        ToggleCorrectAdvanceTest = false;
        ToggleInCorrectAdvanceTest = true;
    }
    public void ClickOnToggleRules()
    {
        if (SearchRules == false)
        {
            SearchRules = true;
        }
        else
        {
            SearchRules = false;
        }
       
        RulesBtn.transform.GetChild(0).transform.GetChild(0).GetComponent<Image>().enabled = SearchRules;
    }
    public void ClickOnToggleSign()
    {
        if (SearchSign == false)
        {
            SearchSign = true;
        }
        else
        {
            SearchSign = false;
        }

        SignBtn.transform.GetChild(0).transform.GetChild(0).GetComponent<Image>().enabled = SearchSign;
    }
    public void ClickOnToggleControls()
    {
        if (SearchControls == false)
        {
            SearchControls = true;
        }
        else
        {
            SearchControls = false;
        }
        ControlBtn.transform.GetChild(0).transform.GetChild(0).GetComponent<Image>().enabled = SearchControls;
    }
}
public class Question
{
    public string question;
    public string optionA;
    public string optionB;
    public string optionC;
    public string correctOption;
    public string selectedOption; // Added field for storing user's selected option
    public string CodeType;
    public string ImageName;
    public string Id;
    public Question(string question, string optionA, string optionB, string optionC,string CorrectOption,string CodeType,string ImageName,string id)
    {
        this.question = question;
        this.optionA = optionA;
        this.optionB = optionB;
        this.optionC = optionC;
        this.correctOption = CorrectOption;
        this.CodeType = CodeType;
        this.ImageName = ImageName;
        this.Id = id;
    }
}
