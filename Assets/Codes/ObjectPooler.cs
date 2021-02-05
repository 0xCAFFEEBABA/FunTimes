using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System;

public class ObjectPooler : MonoBehaviour
{
    #region Pool Class
    // Sets the class as Serializable
    [System.Serializable]
    public class Pool
    {
        // Every Pool will contain...
        /// <summary>
        /// A Card for the cards. 
        /// </summary>
        public Card card;
        /// <summary>
        ///  A String for the category.
        /// </summary>
        public CategoryEnum category;
        /// <summary>
        /// A GameObject for the image.
        /// </summary>
        public GameObject gameObject;
        /// <summary>
        /// An integer for the pool's size.
        /// </summary>
        public int size;
    }
    #endregion

    #region Variables
    //---------- For Text Color ----------
    /// <summary>
    /// The text color when the light theme is active
    /// </summary>
    public Color darkCardTextColor;
    /// <summary>
    /// The text color when the dark theme is active
    /// </summary>
    public Color lightCardTextColor;
    //---------- For Countdown ----------
    /// <summary>
    /// Keeps count of the "next card" button's clicks.
    /// </summary>
    public int count;
    /// <summary>
    /// The total number of cards in the selected categories.
    /// </summary>
    public int total;
    /// <summary>
    /// The countdown's UI element in Unity.
    /// </summary>
    public TextMeshProUGUI countdown;
    //---------- For Pools and Dictionaries ----------
    /// <summary>
    /// A list that contains all Pool objects
    /// </summary>
    public List<Pool> pools = new List<Pool>();
   /// <summary>
    /// A list of all the tasks inside a JSON file.
    /// </summary>
    public List<string> TaskList = new List<string>();
    //---------- For the Queues ----------
    /// <summary>
    /// A list that contains all the active categories' cards.
    /// </summary>
    public List<GameObject> totalCardsList = new List<GameObject>();
    /// <summary>
    ///  A queue that has all the cards of the selected categories in random order.
    /// </summary>
    public Queue<GameObject> randomCardsQueue = new Queue<GameObject>();
    #endregion

    /// <summary>
    /// It's called before the scene is loaded.
    /// Creates the Pool Objects and adds them to a list
    /// Gets the images from the Global Variables class
    /// Sets the <see cref="GlobalVariables.dataAndPools"/> to the returned dictionary of the <see cref="CreateDataAndPoolsDictionary"/> method
    /// </summary>
    public void Awake()
    {
        // Unlocks the appropriate JSON files when the according toggle is on.
        // In this case it unlocks the family JSON file as it is our default category.
        GlobalVariables.OpenJsonCardsFiles();
        // Every time when opening the game scene the pool dictionary and the data and pools dictionary too,
        // must be empty so that there are no conflicts with previous game plays.
        GlobalVariables.poolDictionary = new Dictionary<CategoryEnum, Queue<GameObject>>();
        GlobalVariables.dataAndPools = new Dictionary<Data, Pool>();
        // Creates a list of pools
        CreatePoolList();
        // Gets the images from the dataList.
        GlobalVariables.GetImages();
        // Fills the dataAndPoolsDictionary.
        CreateDataAndPoolsDictionary();
        // For each and every pool in the pools list...
        foreach (Pool pool in pools)
        {
            foreach (var data in GlobalVariables.dataList)
                // If the pool is NOT empty...
                if (pool.category == data.Category
                    && pool.size > 0
                    && data.ToggleBool == true)
                {
                    pool.gameObject = Resources.FindObjectsOfTypeAll<GameObject>().FirstOrDefault(g => g.CompareTag(pool.category + "Card"));

                    // Creates a new Queue.
                    var objectPool = new Queue<GameObject>();
                    // For as many times as the pool's size...
                    for (var i = 0; i <= pool.size - 1; i++)
                    {
                        var completeCard = Instantiate(pool.gameObject);

                        completeCard.SetActive(false);
                        // Puts the game object back to the queue
                        objectPool.Enqueue(completeCard);
                    }
                    GlobalVariables.poolDictionary.Add(pool.category, objectPool);
                }
        }
    }

    /// <summary>
    /// For every key value pair in the <see cref="GlobalVariables.dataAndPools"/> checks and adds the proper image to its cards
    /// Calculates the total number of cards from the selected files and basically begins counting.
    /// </summary>
    public void Start()
    {
        // For each and every key value pair in the dictionary...
        foreach (var dataAndPool in GlobalVariables.dataAndPools)
        {
            // If the pair's pool's gameObject is NOT null...
            if (dataAndPool.Value.gameObject != null)
            {
                // Adds to the specific pool's game object an image.
                var cardImage = dataAndPool.Value.gameObject.AddComponent<Image>();
                // For the sprite...
                // If the player has set the theme to dark...
                if (GlobalVariables.Theme == ThemeEnum.DarkTheme)
                    // Sets the image's sprite to the dark image of the card in the pool.
                    cardImage.sprite = dataAndPool.Value.card.spiteDark;
                // If the player has set the theme to light...
                else if (GlobalVariables.Theme == ThemeEnum.LightTheme)
                    // Sets the image's sprite to the light image of the card in the pool.
                    cardImage.sprite = dataAndPool.Value.card.spriteLight;
                // Else...
                else
                    // By default sets the image's sprite to the light image of the card in the pool.
                    cardImage.sprite = dataAndPool.Value.card.spriteLight;
                // For the image's dimensions
                // Sets a RectTransform for the image.
                var cardsPosition = cardImage.transform as RectTransform;
                // Creates a new vector with the wanted width and height.
                cardsPosition.sizeDelta = new Vector2(StringsAndConsants.cardWidth, StringsAndConsants.cardHeight);
            }
        }
        // Calculates the number of cards selected.
        total = TotalCards();
        // Sets count equal to 0.
        count = 0;
        // For every selected category set the images and tasks accordingly to each queue.
        ForTheQueues();
        // Puts every active category's cards in a queue in random order
        CreateRandomQueue();
        // Begins the countdown.
        CalculateCountdown();
        // Dequeues from the random queue each time a card and puts it back again in the queue.
        SpawnFromRandomQueue();
    }
    
    #region DataAndPools

    /// <summary>
    /// Creates pools for every category and adds them to a list.
    /// </summary>
    public void CreatePoolList()
    {
        // Creates the Pool Object...
        // for Family
        Pool familyPool = new Pool() { category = CategoryEnum.family, card = ScriptableObject.CreateInstance<Card>() };
        // for Sexy
        Pool sexyPool = new Pool() { category = CategoryEnum.sexy, card = ScriptableObject.CreateInstance<Card>() };
        // for Macho
        Pool machoPool = new Pool() { category = CategoryEnum.macho, card = ScriptableObject.CreateInstance<Card>() };
        // for Girly
        Pool girlyPool = new Pool() { category = CategoryEnum.girly, card = ScriptableObject.CreateInstance<Card>() };
        // for Daring
        Pool daringPool = new Pool() { category = CategoryEnum.daring, card = ScriptableObject.CreateInstance<Card>() };
        // for School
        Pool schoolPool = new Pool() { category = CategoryEnum.school, card = ScriptableObject.CreateInstance<Card>() };

        // Adds all Pool objects to a List.
        pools.Add(familyPool);
        pools.Add(sexyPool);
        pools.Add(machoPool);
        pools.Add(girlyPool);
        pools.Add(daringPool);
        pools.Add(schoolPool);
    }

    /// <summary>
    /// Creates a dictionary of <see cref="Data"/> and <see cref="Pool"/> that are matched by their category variable.
    /// Adds the images for dark and light theme's cards to the <see cref="Pool.gameObject"/> accordingly.
    /// </summary>
    /// <returns></returns>
    public void CreateDataAndPoolsDictionary()
    {
        // For each and every pool in pools...
        foreach (var pool in pools)
        {
            // For each and every data in dataList...
            foreach (var data in GlobalVariables.dataList)
            {
                // If the data's category matches the pool's category...
                if (data.Category == pool.category)
                {
                    pool.card.category = pool.category;
                    pool.size = data.Length;
                    // Adds the data and pool to the dictionary as key and value.
                    GlobalVariables.dataAndPools.Add(data, pool);
                    // Gets out of the loop.
                    break;
                }
            }
        }
        // For each and every KeyValuePair in the dictionary...
        foreach (var dataAndPool in GlobalVariables.dataAndPools)
        {
            // Sets the card's sprite of the dark theme to the data's dark themed image
            dataAndPool.Value.card.spiteDark = dataAndPool.Key.DarkImage;
            // Sets the card's sprite of the light theme to the data's light themed image
            dataAndPool.Value.card.spriteLight = dataAndPool.Key.LightImage;
        }
    }

    /// <summary>
    /// Creates a random queue from the <see cref="totalCardsList"/> that contains all the cards of the selected categories.
    /// </summary>
    public void CreateRandomQueue()
    {
        // While the list with all the cards is NOT empty...
        while (totalCardsList.Count != 0)
        {
            // Sets the index to a random integer from 0 to the number of total cards - 1.
            var index = UnityEngine.Random.Range(0, totalCardsList.Count - 1);
            // Enqueues in the random queue a card that the index is currently pointing at.
            randomCardsQueue.Enqueue(totalCardsList[index]);
            // Removes the card that the index is pointing at from the list.
            totalCardsList.RemoveAt(index);
        }
    }

    public GameObject spawnedObject;

    /// <summary>
    /// Spawns a clone of a card by dequeuing it from the random queue and then en queuing it back.
    /// </summary>
    public void SpawnFromRandomQueue()
    {

        // If the last card has not been displayed...
        if (count <= total)
        {
            // Sets the card's position.
            var cardPosition = new Vector3(900f, 25f, 0f);
            // Dequeues a card from the queue that has the cards in random order.
            var objectToSpawn = randomCardsQueue.Dequeue();
            // Sets active the dequeued card. 
            objectToSpawn.SetActive(true);
            // Sets the parent of the cards to the "themes" gameObject.
            var parent = GameObject.Find("Themes");
            // Sets the spawned card as the instance of the card.
            spawnedObject = Instantiate(objectToSpawn, cardPosition, Quaternion.identity, parent.transform);
            // Sets the spawned card's parent to the parent.
            spawnedObject.transform.SetParent(parent.transform);
            // Sets the spawned cards position.
            spawnedObject.transform.localPosition = cardPosition;
            // Sets the spawned card's scale to 1.
            spawnedObject.transform.localScale = new Vector3(1f, 1f, 1f);
            // Slide in the new card 
            spawnedObject.GetComponent<RectTransform>().DOAnchorPos(new Vector2(0f, 25f), 0.25f);
            // Sets the spawned card's parent as the "Cards" game object.
            spawnedObject.transform.SetParent(GameObject.Find("Cards").transform);
            // Enqueues the card that was cloned.
            randomCardsQueue.Enqueue(objectToSpawn);
        }
    }
    // Method that brings in the new card.
    public void ShowCardAnimation()
    {
        // Slide in the new card 
        spawnedObject.GetComponent<RectTransform>().DOAnchorPos(new Vector2(0f, 25f), 0.25f);
    }
    // Method that gets out of the frame the previous card.
    public void CloseCardAnimation()
    {
        // Slide out of the frame the card 
        spawnedObject.GetComponent<RectTransform>().DOAnchorPos(new Vector2(-900f, 25f), 0.25f);
        // Destroy the spawned object
        Destroy(spawnedObject,1f);
    }
    /// <summary>
    /// Creates for every data an array of all the tasks in the according JSON file.
    /// </summary>
    public void CreateTaskArray()
    { 
        // For each and every data in the list of data...
        foreach(var data in GlobalVariables.dataList)
        {
            // If the data's toggle is on...
            if (data.ToggleBool == true)
            {
                // Parses the "cards" array in the according JSON file to a JArray. 
                JArray cards = (JArray)data.JsonData["cards"];
                // For each and every object inside the "cards[]" array...
                foreach (JObject content in cards.Children<JObject>())
                {
                    // For each property of the specified object...
                    foreach (JProperty prop in content.Properties())
                    {
                        // If the property's name is "task"... (ex. "id","task")
                        if (prop.Name == "task")
                        {
                            // Sets a temporary string to the property's value. (ex. "D-R-I-N-K")
                            var tempString = prop.Value.ToString();
                            // Adds the string to the data's TaskList.
                            TaskList.Add(tempString);
                        }
                    }
                }
            }
            // Parses the list of tasks to a string array of tasks.
            data.TaskArray = TaskList.ToArray();
            TaskList = new List<string>();
        }
    }

    /// <summary>
    /// For every active category Queue sets the image and task of every card
    /// </summary>
    public void ForTheQueues()
    {
        // Creates an array of tasks for active categories.
        CreateTaskArray();
        // For each and every key value pair in the dictionary of strings and pools...
        foreach (var stringQueuePair in GlobalVariables.poolDictionary)
        {
            // Parses the queue to an array.
            var queueArray = stringQueuePair.Value.ToArray();
            // For each and every key value pair in the dictionary of data and pools...
            foreach (var dataPoolPair in GlobalVariables.dataAndPools)
            {
                // If the stringQueuePair's string is equal to the dataPoolPair's Data's Category...
                if (stringQueuePair.Key == dataPoolPair.Key.Category)
                {
                    // For as many times as the number of tasks in the JSON file...
                    for (int i = 0; i <= dataPoolPair.Key.Length - 1; i++)
                    {
                        // Sets task as the task component in the i-th pool of the Queue Array. 
                        var task = queueArray[i].gameObject.transform.Find("Task").GetComponent<TextMeshProUGUI>();
                        // Sets task's text to the i-th task in the array of tasks.
                        task.text = dataPoolPair.Key.TaskArray[i];
                        // Adds to the specific pool's game object an image.
                        var cardImage = queueArray[i].gameObject.AddComponent<Image>();
                        // For the sprite and text color...
                        // If the player has set the theme to dark...
                        if (GlobalVariables.Theme == ThemeEnum.DarkTheme)
                        {
                            // Sets the image's sprite to the dark image of the card in the pool.
                            cardImage.sprite = dataPoolPair.Value.card.spiteDark;
                            // If the string is a color...
                            if (ColorUtility.TryParseHtmlString("#292F36", out lightCardTextColor))
                                // Sets the task to that color, which in this case is the dark one.
                                task.color = lightCardTextColor;
                        }
                        // If the player has set the theme to light...
                        else if (GlobalVariables.Theme == ThemeEnum.LightTheme)
                        {
                            // Sets the image's sprite to the light image of the card in the pool.
                            cardImage.sprite = dataPoolPair.Value.card.spriteLight;
                            // If the string is a color...
                            if (ColorUtility.TryParseHtmlString("#F1EEE0", out darkCardTextColor))
                                // Sets the task to that color, which in this case is the light one.
                                task.color = darkCardTextColor;
                        }
                        // Else...
                        else
                        {
                            // By default sets the image's sprite to the light image of the card in the pool.
                            cardImage.sprite = dataPoolPair.Value.card.spriteLight;
                            // If the string is a color...
                            if (ColorUtility.TryParseHtmlString("#F1EEE0", out darkCardTextColor))
                                // Sets the task to that color, which in this case is the light one.
                                task.color = darkCardTextColor;
                        }
                        // For the image's dimensions
                        // Sets a RectTransform for the image.
                        var cardsPosition = cardImage.transform as RectTransform;
                        // Creates a new vector with the wanted width and height.
                        cardsPosition.sizeDelta = new Vector2(StringsAndConsants.cardWidth, StringsAndConsants.cardHeight);
                        // Adds the card to a list that contains every card.
                        totalCardsList.Add(queueArray[i]);
                    }
                }
            }
        }
    }
    #endregion

    #region Countdown
    /// <summary>
    /// Calculates how many cards have been played by adding 1 every time the player presses the "next card" button
    /// </summary>
    public void CalculateCountdown()
    {
        // Sets count equal to its previous value plus one.
        count = count + 1;
        foreach(var card in randomCardsQueue)
        {
            // Sets countdown equal to the text object assigned for the countdown.
            var countdown = card.gameObject.transform.Find("Countdown").GetComponent<TextMeshProUGUI>();
            // Sets the text equal to the current count's value / the total number of cards selected.
            countdown.SetText(count.ToString() + "/" + total.ToString());
            // If the player has set the theme to dark...
            if (GlobalVariables.Theme == ThemeEnum.DarkTheme)
            {
                // If the string is a color...
                if (ColorUtility.TryParseHtmlString("#292F36", out lightCardTextColor))
                    // Sets the task to that color, which in this case is the dark one.
                    countdown.color = lightCardTextColor;
            }
            // If the player has set the theme to light...
            else if (GlobalVariables.Theme == ThemeEnum.LightTheme)
            {
                // If the string is a color...
                if (ColorUtility.TryParseHtmlString("#F1EEE0", out darkCardTextColor))
                    // Sets the task to that color, which in this case is the light one.
                    countdown.color = darkCardTextColor;
            }
            // Else...
            else
            {
                // By default sets the light theme's countdown active 
                if (ColorUtility.TryParseHtmlString("#F1EEE0", out darkCardTextColor))
                    // Sets the task to that color, which in this case is the light one.
                    countdown.color = darkCardTextColor;
            }
        }
    }

    /// <summary>
    /// Calculates the number of elements in every JSON file's array and adds them.
    /// Also sets for every data their length equal to length.
    /// </summary>
    /// <returns>The total number of tasks from the selected categories</returns>
    public int TotalCards()
    {
        // By default the length is 0
        var length = 0;
        // For each data in the dataList...
        foreach (var data in GlobalVariables.dataList)
        {
            // If the data is NOT null...
            if (data.ToggleBool == true)
            {
                // Sets length equal to it's previous value plus the new array's size.
                length += data.Length;
            }
        }
        // Returns the total amount of elements
        return length;
    }
    #endregion

}
