public class LevelInfo
{
    public bool isOpened = false;
    public bool isFinished = false;

    public LevelInfo(){}

    public virtual string GetLevelType()
    {
        return "";
    }
}