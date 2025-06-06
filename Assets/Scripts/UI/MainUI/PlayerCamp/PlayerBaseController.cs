using UnityEngine;
using UnityEngine.UIElements;

/// <summary>
/// 玩家大本营 / 主界面控制器：
/// 1. 进入游戏时隐藏 CardInventoryPage，显示 MainUI & PlayerBaseMap.
/// 2. 点击 “CardInventoryBuilding” 按钮时：
///    - 关闭 MainUI & PlayerBaseMap
///    - 打开 CardInventoryPage
/// 3. CardInventoryPage 里点击 “返回” 时，调用 HideCardInventoryPage() 恢复主界面。
/// </summary>
[RequireComponent(typeof(UIDocument))]
public class PlayerBaseController : MonoBehaviour
{
    /* Inspector 拖入 */
    [SerializeField] private GameObject mainUIPanel;
    [SerializeField] private GameObject playerBaseMap;
    [SerializeField] private GameObject cardInventoryPage;
    [SerializeField] private GameObject gachaPage;
    [SerializeField] private GameObject armyControlPage;


    private Button cardInventoryBtn;
    private Button armyControlBtn;

    /*———— 启动时默认状态 ————*/
    void Awake()
    {
        cardInventoryPage.SetActive(false);
        mainUIPanel.SetActive(true);
        playerBaseMap.SetActive(true);
        gachaPage.SetActive(false);
        armyControlPage.SetActive(false);
    }

    /*———— 每次重新启用时重新取 root 并绑定事件 ————*/
    void OnEnable()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        cardInventoryBtn = root.Q<Button>("CardInventoryBuilding");
        cardInventoryBtn.clicked += ShowCardInventoryPage;

        armyControlBtn = root.Q<Button>("ArmyControlBuilding");
        armyControlBtn.clicked += ShowArmyControlPage;

    }

    /*———— 对应卸载，避免重复绑定 ————*/
    void OnDisable()
    {
        if (cardInventoryBtn != null)
            cardInventoryBtn.clicked -= ShowCardInventoryPage;
    }

    /*———— 打开 / 关闭 逻辑保持不变 ————*/
    void ShowCardInventoryPage()
    {
        cardInventoryPage.SetActive(true);
        mainUIPanel.SetActive(false);
        playerBaseMap.SetActive(false);
    }

    public void HideCardInventoryPage()
    {
        cardInventoryPage.SetActive(false);
        mainUIPanel.SetActive(true);
        playerBaseMap.SetActive(true);
    }
    public void ShowGachaPage()
    {
        gachaPage.SetActive(true);
        cardInventoryPage.SetActive(false);
        mainUIPanel.SetActive(false);
        playerBaseMap.SetActive(false);
    }

    public void HideGachaPage()
    {
        gachaPage.SetActive(false);
        cardInventoryPage.SetActive(true);   // 或 mainUIPanel，看你的返回逻辑
        mainUIPanel.SetActive(false);
        playerBaseMap.SetActive(false);
    }

    public void ShowArmyControlPage()
    {
        cardInventoryPage.SetActive(false);
        mainUIPanel.SetActive(false);
        playerBaseMap.SetActive(false);
        armyControlPage.SetActive(true);
    }
    public void HideArmyControlPage()
    {
        armyControlPage.SetActive(false);
        mainUIPanel.SetActive(true);
        playerBaseMap.SetActive(true);
        cardInventoryPage.SetActive(false);
    }
}

