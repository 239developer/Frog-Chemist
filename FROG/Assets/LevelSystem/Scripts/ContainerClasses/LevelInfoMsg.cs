public class LevelInfoMsg : LevelInfo //for levels w/ messages
{
    public int messageID;

    public LevelInfoMsg(int id)
    {
        messageID = id;
    }

    override public string GetLevelType()
    {
        return "Message";
    }
}