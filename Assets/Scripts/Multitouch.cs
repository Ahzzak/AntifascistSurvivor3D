using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;

public class Multitouch : MonoBehaviour
{
    public RectTransform zone;    // la zone cliquable du joystick
    public RectTransform handle;  // l’élément visuel qui bouge
    public float radius = 80f;    // rayon max du stick

    private Finger finger;        // le doigt assigné à ce joystick
    public Vector2 value;         // la direction (X,Y)

    void Update()
    {
        // Si aucun doigt n'est assigné → essayer d'en trouver un
        if (finger == null)
        {
            foreach (var touch in UnityEngine.InputSystem.EnhancedTouch.Touch.activeTouches)
            {
                if (IsInsideZone(touch.screenPosition))
                {
                    finger = touch.finger;
                    break;
                }
            }
        }

        // Si on a un doigt, mettre le joystick à jour
        if (finger != null)
        {
            var touch = finger.currentTouch;

            if (touch.isInProgress)
            {
                Vector2 posLocal;
                RectTransformUtility.ScreenPointToLocalPointInRectangle(
                    zone,
                    touch.screenPosition,
                    null,
                    out posLocal
                );

                // clamping du déplacement
                Vector2 clamped = Vector2.ClampMagnitude(posLocal, radius);

                handle.anchoredPosition = clamped;

                value = clamped / radius; // valeur normalisée -1 à 1
            }
            else
            {
                // doigt relâché → reset
                finger = null;
                handle.anchoredPosition = Vector2.zero;
                value = Vector2.zero;
            }
        }
    }

    bool IsInsideZone(Vector2 screenPos)
    {
        return RectTransformUtility.RectangleContainsScreenPoint(zone, screenPos);
    }
}
