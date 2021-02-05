using UnityEngine.Events;

public static class EventManager 
{

  public static UnityEvent OnPathNewCreated = new UnityEvent();
  public static UnityEvent OnEggCollected = new UnityEvent();
  public static UnityEvent OnStartDrawing = new UnityEvent();
  public static UnityEvent OnFollowerDie =new UnityEvent();

  public static UnityEvent OnMove  = new UnityEvent();
  public static UnityEvent OnStop = new UnityEvent();
  public static UnityEvent OnGameStart = new UnityEvent();
  public static UnityEvent OnGameEnd = new UnityEvent();
  public static UnityEvent OnLevelStart = new UnityEvent();
  public static UnityEvent OnLevelSucces = new UnityEvent();
  public static UnityEvent OnLevelRestart = new UnityEvent();
  public static UnityEvent OnLevelFail = new UnityEvent();
  public static UnityEvent OnTap = new UnityEvent();
  public static UnityEvent OnTapRelease =new UnityEvent();
  public static UnityEvent OnCharacterDie = new UnityEvent();
  public static UnityEvent OnEnemyShoot = new UnityEvent();
  public static UnityEvent OnEnemyTurnLeft  = new UnityEvent();
    public static UnityEvent OnEnemyTurnRight = new UnityEvent();
    public static UnityEvent OnEnemyTurn180 =new UnityEvent();
    
    
 

 

}
