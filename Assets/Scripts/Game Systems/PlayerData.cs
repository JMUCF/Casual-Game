[System.Serializable]
public class PlayerData
{
    public int totalPoints;
    public int skinCount = 10; // Adjust this if necessary
    public bool[] skinsUnlocked;

    // Constructor when creating new player data
    public PlayerData(GameManager gameManager)
    {
        totalPoints = gameManager.pointsEarned;

        // Initialize skinsUnlocked array to default size
        skinsUnlocked = new bool[skinCount];
    }

    // Ensure skinsUnlocked is initialized if null or the wrong size
    public void InitializeSkins(int skinCount)
    {
        if (skinsUnlocked == null || skinsUnlocked.Length != skinCount)
        {
            skinsUnlocked = new bool[skinCount];
        }
    }
}
