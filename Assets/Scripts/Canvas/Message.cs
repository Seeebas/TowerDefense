using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/*Esta Classe serve para criar uma mesagem, um genero de notificador */
public class Message : MonoBehaviour
{
	public static Text messageText{ get; set;}
	public static Animator anim;

	public static IEnumerator WaitAnim(string message){
		ShowTextGame.messageText.text = message;
		yield return new WaitForSeconds (1.7f);
		ShowTextGame.messageText.text = "";
	}
}
	