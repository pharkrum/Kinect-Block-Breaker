using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapturarMovimentos : MonoBehaviour, KinectGestures.GestureListenerInterface {

    private bool swipeLeft;
    private bool swipeRight;
    private bool swipeUp;
    private bool swipeDown;

    // Criação da instancia dessa classe.
	public static CapturarMovimentos instancia = null; // é um padrão de singleton que só permite que exista uma instancia disso.

    //Metodo para retornar  Instancia dessa classe publciamente para uso em outras classes.
    public static CapturarMovimentos Instance {
        get
        {
            return instancia;
        }
    }

    //Metodo que é chamado assim que essa classe é carregada, uma unica vez
    void Awake()
	{
		if (instancia != null) {
			Destroy (gameObject);
			print ("Duplicate Listener self-destructing!");
		} else {
			instancia = this;
			//Há uma diferença entre o GameObject e o gameObject! o gameObject é o objeto que chamou esse script!
			GameObject.DontDestroyOnLoad(gameObject);
		}
	}

    //Essa verificação no IF é feita para que o programa aguarde o fim da execução do gesto capturado.
	public bool IsSwipeLeft()
    {
		if (swipeLeft)
        {
			swipeLeft = false;
            return true;
        }

        return false;
    }

	public bool IsSwipeRight()
    {
		if (swipeRight)
        {
			swipeRight = false;
            return true;
        }

        return false;
    }

	public bool IsSwipeUp()
    {
		if (swipeUp)
        {
			swipeUp = false;
            return true;
        }

        return false;
    }

	public bool IsSwipeDown()
    {
		if (swipeDown)
        {
			swipeDown = false;
            return true;
        }

        return false;
    }
		

    public void UserDetected(uint userId, int userIndex)
    {
        //intancia um gerenciador que irá capturar os gestos do player em questão.
        KinectManager gereciador = KinectManager.Instance;

        //Diz ao gerenciador quais saos os movimentos que devem ser capturados desse determinador usuário, baseado no ENUM de gestos
        // da classe KinectGesture
        gereciador.DetectGesture(userId, KinectGestures.Gestures.SwipeLeft);
        gereciador.DetectGesture(userId, KinectGestures.Gestures.SwipeRight);
        gereciador.DetectGesture(userId, KinectGestures.Gestures.SwipeUp);
        gereciador.DetectGesture(userId, KinectGestures.Gestures.SwipeDown);
    }

    public void UserLost(uint userId, int userIndex)
    {
        // criar variável para verificar se o usuario foi perdido.
       // throw new System.NotImplementedException();
    }

    public void GestureInProgress(uint userId, int userIndex, KinectGestures.Gestures gesture, float progress, KinectWrapper.SkeletonJoint joint, Vector3 screenPos)
    {
        // criar procedimentos para verificar se um gesto está sendo executado sem ter finalizado.
       // throw new System.NotImplementedException();
    }

    //Metodo que é chamado assim que o usuario termina de executar um dos gestos
    public bool GestureCompleted(uint userId, int userIndex, KinectGestures.Gestures gesture, KinectWrapper.SkeletonJoint joint, Vector3 screenPos)
    {


        string sGestureText = gesture + " detected";
        Debug.Log(sGestureText);

        if (gesture == KinectGestures.Gestures.SwipeLeft)
			swipeLeft = true;
        else if (gesture == KinectGestures.Gestures.SwipeRight)
			swipeRight = true;
        else if (gesture == KinectGestures.Gestures.SwipeUp)
			swipeUp = true;
        else if (gesture == KinectGestures.Gestures.SwipeDown)
			swipeDown = true;

        return true;
    }

    public bool GestureCancelled(uint userId, int userIndex, KinectGestures.Gestures gesture, KinectWrapper.SkeletonJoint joint)
    {
        // throw new System.NotImplementedException();
        return true;
    }
}
