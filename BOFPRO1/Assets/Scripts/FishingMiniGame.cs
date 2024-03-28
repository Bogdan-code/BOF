using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class FIshingMiniGame : MonoBehaviour
{
    [SerializeField] Transform topPivot;
    [SerializeField] Transform bottomPivot;

    [SerializeField] Transform fish;

    float fishPosition;
    float fishDestination;

    float fishTimer;
    [SerializeField] float timerMultiplicator = 3f;

    float fishSpeed;
    [SerializeField] float smoothMotion = 1f;

    [SerializeField] Transform hook;
    float hookPosition;
    [SerializeField] float hookSize = 0.1f;
    [SerializeField] float hookPower = 0.5f; // �r v�rdet som visar hur snabbt fisken kommer att �ka sin hookProgress om den �r inne i hook omr�det
    float hookProgress;
    float hookPullVelocity; // �r den nuvarande hastigheten som din hook r�r sig inom fiskeomr�det, ett positivt v�rde v�rdeinneb�r att hooken stiger och ett negativt v�rde inneb�r att hooken faller ner
    [SerializeField] float hookPullPower = 0.01f; // power applicerad till din hook, ju h�gre v�rde desto snabbare kommer hook omr�det att h�jas
    [SerializeField] float hookGravityPower = 0.005f;// �r kraften som kommer att dra ner hooken
    [SerializeField] float hookProgressDegrationPower = 0.1f;// �r hastigheten f�r hookProgressDegration och n�r din fisk inte �r inom hookens range kommer hookProgress att sakta f�rs�mras

    [SerializeField] SpriteRenderer hookSpriteRenderer;

    [SerializeField] Transform progressBarContainer;

    bool pause = false;

    [SerializeField] float Failtimer = 10f; // inneb�r att om v�r firre �r utanf�r hook omr�det i 10 sekunder totalt tappar du firren

    public TextMeshProUGUI winText;
    public TextMeshProUGUI loseText;

    private void Start()
    {
        Resize();
        
        winText.enabled = false;
        loseText.enabled = false;
    }

    private void Update()
    {
        if (pause) { return; }

        Fish();
        Hook();
        ProgressCheck();
    }

    private void Resize()
    {
        // nu kommer vi att ber�kna storleken p� objektet baserat p� dess relativa storlek (f�rst�r men f�rst�r �nd� inte, �r f�r dum)
        // lagra gr�nserna f�r hookSprite i en variabel
        Bounds b = hookSpriteRenderer.bounds;
        // lagra h�jden p� gr�nserna i en variabel
        float ySize = b.size.y;
        // f�r att skala v�r hook �terst�ll dess nuvarande skala till en variabel
        Vector3 Is = hook.localScale;
        // storleken y kommer att representera en del av skalan fr�n botten till toppen s� d�rf�r lagrar vi avst�ndet mellan topPivot och bottomPivot
        float distance = Vector3.Distance(topPivot.position, bottomPivot.position);
        // anv�nd alla dessa variablar med en massa matte
        Is.y = (distance / ySize * hookSize);
        hook.localScale = Is;
    }

    private void ProgressCheck()
    {
        Vector3 Is = progressBarContainer.localScale;
        // s�tt hooken i y position
        Is.y = hookProgress;
        progressBarContainer.localScale = Is;

        // nu vill vi kolla om v�ran firre �r inuti hook omr�det, f�r att g�ra detta r�knar vi ut l�ngden p� v�r hook bar
        float min = hookPosition - hookSize / 2;
        float max = hookPosition + hookSize / 2;
        // kolla sedan om firren �r inuti denna rangen 
        if (min  < fishPosition && fishPosition < max)
        {
            hookProgress += hookPower * Time.deltaTime;

        }
        else
        {
            hookProgress -= hookProgressDegrationPower * Time.deltaTime;

            Failtimer -= Time.deltaTime;
            if (Failtimer < 0)
            {
                Lose();
            }
        }

        if(hookProgress >= 1f)
        {
            Win();
        }

        hookProgress = Mathf.Clamp(hookProgress, 0f, 1f);
    }

    private void Lose()
    {
        pause = true;
        loseText.enabled = true;
        Debug.Log("T�nt");
    }

    private void Win()
    {
        pause = true;
        winText.enabled = true;
        Debug.Log("Bra att du kan g� n�t i ditt pissliv iallafall");
    }

    void Hook ()
    {
        if(Input.GetMouseButton(0))
        {
            hookPullVelocity += hookPullPower * Time.deltaTime;
        }
        hookPullVelocity -= hookGravityPower * Time.deltaTime;

        hookPosition += hookPullVelocity;

        if(hookPosition - hookSize / 2 < 0f && hookPullVelocity < 0f)
        {
            hookPullVelocity = 0f;
        }
        if(hookPosition + hookSize / 2 >= 1f && hookPullVelocity > 0f)
        {
            hookPullVelocity = 0f;
        }

        // nu vill vi kl�mma ihop v�r hook till att stanna mellan topPivot och bottomPivot, topPivot = 1 och bottomPivot = 0, hookSize / 2 anv�nds f�r att firren inte ska �ka utanf�r en bit p� grund av att dess collider ligger i mitten p� den
        hookPosition = Mathf.Clamp(hookPosition, hookSize / 2, 1 - hookSize / 2);
        hook.position = Vector3.Lerp(bottomPivot.position, topPivot.position, hookPosition);

    }

    void Fish()
    {
        // nedast�ende funktion anv�nds f�r att avg�ra n�r du beh�ver �ndra destinationspositionen f�r fisken, detta f�r att simulera att v�r fisk k�mpar eller r�r sig i vattnet
        fishTimer -= Time.deltaTime;
        // om det inte finns n�gon tid kvar inuti timern, skapa i s� fall ett nytt v�rde f�r timer, med hj�lp av ett slumpm�ssigt v�rde
        if (fishTimer < 0)
        {
            fishTimer = UnityEngine.Random.value * timerMultiplicator;

            // tilldela ny fiskdestination genom att anv�nda ett slumpm�ssigt v�rde
            fishDestination = UnityEngine.Random.value;
        }

        // massa matte som jag inte f�rst�r (s�ndercoppat)
        fishPosition = Mathf.SmoothDamp(fishPosition, fishDestination, ref fishSpeed, smoothMotion);
        // nu m�ste vi flytta v�r fisk mellan tv� pivotpunkter
        fish.position = Vector3.Lerp(bottomPivot.position, topPivot.position, fishPosition);
    }
}
