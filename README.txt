# FirstSemesterExamProject
Gruppe 6
Asgar Lange, Stefan Pedersen, Andreas Kirkegaard og Johannes Andersen

____________________________________________________________________________________________________________________
S�dan kommer du ind i et spil:
1 .exe filen �bnes
2 Antallet af spillere v�lges (3 & 4 spillere har en st�rre bane, og st�rrelsen p� grafikken tilpasses)
3 Klik p� en af (farve)Team knapperne, for at v�lge hvilket hold du �nsker at tilf�je Units til.
4 Tilpas hvilke og hvor mange units du �nsker at have p� dit hold.
  4a Hver Unit har forskellige attributter, pris og egenskaber
  4b Hold muse mark�ren over en Unit-knap for at f� en kort teksbeskrivelse af den. (tooltips)
  4c Alle hold skal mindst have en Unit for at kampen kan starte.
  4d Hvis du �nsker at fjerne en Unit, tryk p� "Remove Unit" knappen for at fjerne den sidste valgte Unit.
5 klik p� "Play" knappen for at starte kampen
_____________________________________________________________________________________________________________________
S�dan spiller du:
Du kan b�de spille spillet med tastatur og / eller mus!

1 Den spiller hvis tur det er (r�d starter altid f�rst), kan interagerer med de Unit som har tilsvarende farve.
2 Du kan flytte spillermark�ren ved at bruge W,A,S,D (eller piltasterne).
   2a hvis spiller mark�ren befinder sig over en Unit, vises relevant information i brugergr�nsefladen til h�jre.
3 Du kan interagerer med et felt vha.'Enter','Mellemrum', eller ved at klikke p� feltet med musen.
   3a hvis det felt du interagerer med, indeholder en allieret Unit, v�lges denne unit, og dens egenskaber
    printes ud til sk�rmens brugergr�nseflade i h�jre side.
   3b hvis du har valgt en Unit, kan du interagerer med felter hvorp� du �nsker din Unit skal udf�re en handling.
    Felter som har mulige handlinger vises med forskellige farver. M�rk betyder du kan flytter derhen, r�d 
    betyder at du kan angribe en fjendtlig Unit, og Bl� betyder at du kan helbredde en allieret Unit

4 OBS! Din unit har begr�nsede tr�k, og det har spilleren ogs�. For hver felt du rykker bliver et point trukket fra
   -b�de "player moves" og "unit moves". 
   4a hvis en Unit angriber eller helbreder bliver dens "move" points sat til 0, men spilleren mister kun 1 point.
   
5 N�r du er l�bet t�r for point eller du ikke �nsker at foretage flere tr�k, skal du trykke p� "End Turn" knappen 
  eller p� BackSpace-tasten for at give turen videre til den n�ste spiller.

6 N�r det bliver din tur igen, vil du have alle dine "move points" tilbage, og det overst�ende gentages.

7 N�r der kun er et holds units tilbage vinder det tilbagev�rende hold, og du vidersendes til 
   startsk�rmen efter 10 sekunder.
____________________________________________________________________________________________________________________

Tips:
- brug den information vi giver dig i brugergr�nsefladen til at vide hvilke Units vil v�re mere effektive imod hinanden

F.eks:
En mage "skader mere imod pansrede Units", hvilket g�r at den er meget mere effektiv imod en Knight/Artifact.

En scout har h�j mobilitet,og dens tr�k reducerer ikke dine player moves. Den kan bruges til at indhente s�rede Units
Eller til at omringe modstanderes h�r, for at forhindre dem i at rykke i en bestemt retning. 