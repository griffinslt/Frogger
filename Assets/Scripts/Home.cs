using UnityEngine;

public class Home : MonoBehaviour
{
    private bool _hasBeenVisited;
    private bool _hasBeenVisitedWithLady;

    public bool HasBeenVisited()
    {
        return _hasBeenVisited;
    }
    public bool HasBeenVisitedWithLady()
    {
        return _hasBeenVisitedWithLady;
    }

    public void Visit()
    {
        _hasBeenVisited = true;
    }
    
    public void VisitWithLady()
    {
        _hasBeenVisitedWithLady = true;
    }
    
    


}
