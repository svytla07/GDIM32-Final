using UnityEngine;
using System;

public class GameController : MonoBehaviour
{
    // =========================
    // Singleton
    // =========================
    public static GameController Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);   // 保留跨场景
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    // =========================
    // Game State FSM
    // =========================
    public enum GameState
    {
        Tutorial,
        CollectIngredients,
        Cooking,
        ServingCustomers,
        GameComplete
    }

    public GameState CurrentState { get; private set; }

    // 事件：任何系统都可以监听
    public static event Action<GameState> OnGameStateChanged;

    // =========================
    // Progress
    // =========================
    [Header("Progress")]
    [SerializeField] private int targetOrders = 5;
    private int completedOrders = 0;

    // =========================
    // Unity Lifecycle
    // =========================
    private void Start()
    {
        SetState(GameState.Tutorial);
    }

    // =========================
    // State Control
    // =========================
    public void SetState(GameState newState)
    {
        CurrentState = newState;
        Debug.Log($"[GameController] State → {newState}");

        // 广播事件给 UI / Audio / NPC / Spawner / Pot / Inventory
        OnGameStateChanged?.Invoke(newState);

        // 执行进入状态的行为
        HandleStateEnter(newState);
    }

    private void HandleStateEnter(GameState state)
    {
        switch (state)
        {
            case GameState.Tutorial:
                OnEnterTutorial();
                break;

            case GameState.CollectIngredients:
                OnEnterCollectIngredients();
                break;

            case GameState.Cooking:
                OnEnterCooking();
                break;

            case GameState.ServingCustomers:
                OnEnterServingCustomers();
                break;

            case GameState.GameComplete:
                OnEnterGameComplete();
                break;
        }
    }

    // =========================
    // State Behaviors
    // =========================
    private void OnEnterTutorial()
    {
        Debug.Log("Talk to the manager to start working.");
    }

    private void OnEnterCollectIngredients()
    {
        Debug.Log("Collect required ingredients.");
    }

    private void OnEnterCooking()
    {
        Debug.Log("Start cooking pho.");
    }

    private void OnEnterServingCustomers()
    {
        Debug.Log("Customers are coming in.");
        // 顾客生成不在这里做，由 CustomerSpawner 监听事件
    }

    private void OnEnterGameComplete()
    {
        Debug.Log("Game completed! All orders served.");
        // UIController 会监听这个状态并显示结束画面
    }

    // =========================
    // External Events
    // =========================

    public void TutorialFinished()
    {
        if (CurrentState == GameState.Tutorial)
            SetState(GameState.CollectIngredients);
    }

    public void IngredientsCollected()
    {
        if (CurrentState == GameState.CollectIngredients)
            SetState(GameState.Cooking);
    }

    public void CookingFinished()
    {
        if (CurrentState == GameState.Cooking)
            SetState(GameState.ServingCustomers);
    }

    public void OrderFinished(bool success)
    {
        if (CurrentState != GameState.ServingCustomers)
            return;

        if (success)
        {
            completedOrders++;
            Debug.Log($"Order completed! ({completedOrders}/{targetOrders})");
        }
        else
        {
            Debug.Log("Wrong order submitted.");
        }

        if (completedOrders >= targetOrders)
        {
            SetState(GameState.GameComplete);
        }
        else
        {
            // 下一位顾客由 CustomerSpawner 自动监听状态并生成
            // 或由 OrderManager 控制
        }
    }
}
