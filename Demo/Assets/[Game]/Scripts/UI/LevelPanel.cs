using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LevelPanel : MonoBehaviour
{
    
    public Text LevelText;
    public Text FigureText;
    

   private void OnEnable() 
   {
       EventManager.OnEggCollected.AddListener(()=> FigureText.text = "X" + LevelManager.Instance.DuckCount );
        EventManager.OnFollowerDie.AddListener(()=> FigureText.text = "X" + LevelManager.Instance.DuckCount );
   }

   private void OnDisable() 
   {
       EventManager.OnEggCollected.RemoveListener(()=> FigureText.text = "X" + LevelManager.Instance.DuckCount );
         EventManager.OnFollowerDie.RemoveListener(()=> FigureText.text = "X" + LevelManager.Instance.DuckCount );
   }
}
