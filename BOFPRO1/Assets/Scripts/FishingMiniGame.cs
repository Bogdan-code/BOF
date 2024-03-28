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
    [SerializeField] float hookPower = 0.5f; // är värdet som visar hur snabbt fisken kommer att öka sin hookProgress om den är inne i hook området
    float hookProgress;
    float hookPullVelocity; // är den nuvarande hastigheten som din hook rör sig inom fiskeområdet, ett positivt värde värdeinnebär att hooken stiger och ett negativt värde innebär att hooken faller ner
    [SerializeField] float hookPullPower = 0.01f; // power applicerad till din hook, ju högre värde desto snabbare kommer hook området att höjas
    [SerializeField] float hookGravityPower = 0.005f;// är kraften som kommer att dra ner hooken
    [SerializeField] float hookProgressDegrationPower = 0.1f;// är hastigheten för hookProgressDegration och när din fisk inte är inom hookens range kommer hookProgress att sakta försämras

    [SerializeField] SpriteRenderer hookSpriteRenderer;

    [SerializeField] Transform progressBarContainer;

    bool pause = false;

    [SerializeField] float Failtimer = 10f; // innebär att om vår firre är utanför hook området i 10 sekunder totalt tappar du firren

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
        // nu kommer vi att beräkna storleken på objektet baserat på dess relativa storlek (förstår men förstår ändå inte, är för dum)
        // lagra gränserna för hookSprite i en variabel
        Bounds b = hookSpriteRenderer.bounds;
        // lagra höjden på gränserna i en variabel
        float ySize = b.size.y;
        // för att skala vår hook återställ dess nuvarande skala till en variabel
        Vector3 Is = hook.localScale;
        // storleken y kommer att representera en del av skalan från botten till toppen så därför lagrar vi avståndet mellan topPivot och bottomPivot
        float distance = Vector3.Distance(topPivot.position, bottomPivot.position);
        // använd alla dessa variablar med en massa matte
        Is.y = (distance / ySize * hookSize);
        hook.localScale = Is;
    }

    private void ProgressCheck()
    {
        Vector3 Is = progressBarContainer.localScale;
        // sätt hooken i y position
        Is.y = hookProgress;
        progressBarContainer.localScale = Is;

        // nu vill vi kolla om våran firre är inuti hook området, för att göra detta räknar vi ut längden på vår hook bar
        float min = hookPosition - hookSize / 2;
        float max = hookPosition + hookSize / 2;
        // kolla sedan om firren är inuti denna rangen 
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
        Debug.Log("Tönt");
    }

    private void Win()
    {
        pause = true;
        winText.enabled = true;
        Debug.Log("Bra att du kan gö nåt i ditt pissliv iallafall");
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

        // nu vill vi klämma ihop vår hook till att stanna mellan topPivot och bottomPivot, topPivot = 1 och bottomPivot = 0, hookSize / 2 används för att firren inte ska åka utanför en bit på grund av att dess collider ligger i mitten på den
        hookPosition = Mathf.Clamp(hookPosition, hookSize / 2, 1 - hookSize / 2);
        hook.position = Vector3.Lerp(bottomPivot.position, topPivot.position, hookPosition);

    }

    void Fish()
    {
        // nedastående funktion används för att avgöra när du behöver ändra destinationspositionen för fisken, detta för att simulera att vår fisk kämpar eller rör sig i vattnet
        fishTimer -= Time.deltaTime;
        // om det inte finns någon tid kvar inuti timern, skapa i så fall ett nytt värde för timer, med hjälp av ett slumpmässigt värde
        if (fishTimer < 0)
        {
            fishTimer = UnityEngine.Random.value * timerMultiplicator;

            // tilldela ny fiskdestination genom att använda ett slumpmässigt värde
            fishDestination = UnityEngine.Random.value;
        }

        // massa matte som jag inte förstår (söndercoppat)
        fishPosition = Mathf.SmoothDamp(fishPosition, fishDestination, ref fishSpeed, smoothMotion);
        // nu måste vi flytta vår fisk mellan två pivotpunkter
        fish.position = Vector3.Lerp(bottomPivot.position, topPivot.position, fishPosition);
    }
}
