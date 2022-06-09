public class LevelInfoBC : LevelInfo //for "blaster challenge" levels
{
    public Class[] availableQuestions;
    public float speed;
    public float acceleration;
    public float spawnDelay;

    public LevelInfoBC(Class[] aq, float s, float a, float d)
    {
        availableQuestions = aq;
        speed = s;
        acceleration = a;
        spawnDelay = d;
    }

    override public string GetLevelType()
    {
        return "Blaster Challenge"; 
    }
}