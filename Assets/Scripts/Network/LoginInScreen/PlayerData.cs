using UnityEngine;
//运行期间玩家数据（只保存在内存，关掉游戏就没了）
// PlayerData.I.uuid 获取例子
public class PlayerData : MonoBehaviour
{
    public static PlayerData I { get; private set; } // 单例
    [Header("玩家数据")]
    [Header("账号 & 会话")]
    public string uid;
    public string userToken;
    public string username;          // 你的账号 / 显示名

    [Header("角色信息")]
    public string cid;              // 角色 ID
    public string characterToken;    // 角色令牌

    [Header("游戏服")]
    public int serverId;
    public string serverIpAddress;
    public int serverPort;

    void Awake()
    {
        if (I != null && I != this)
        {
            Destroy(gameObject);
            return;
        }
        I = this;
        DontDestroyOnLoad(gameObject); // 不销毁
    }

    public void SetSession(
        string uid,
        string userToken,
        string cid,
        string characterToken,
        int serverId,
        string serverIpAddress,
        int serverPort,
        string username = null)
    {
        this.uid = uid;
        this.userToken = userToken;
        this.cid = cid;
        this.characterToken = characterToken;
        this.serverId = serverId;
        this.serverIpAddress = serverIpAddress;
        this.serverPort = serverPort;
        if (username != null) this.username = username;
    }

        public void Dump()
    {
        Debug.Log($"[PlayerData]\n" +
                $"uid={uid}\n" +
                $"userToken={userToken}\n" +
                $"username={username}\n" +
                $"cid={cid}\n" +
                $"characterToken={characterToken}\n" +
                $"serverId={serverId}\n" +
                $"server={serverIpAddress}:{serverPort}");
    }

}

