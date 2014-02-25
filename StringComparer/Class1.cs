using System;
using System.Collections.Generic;
using System.Text;


/// <summary>
/// Ein Textvergleicher, der als Rückgabe die prozentuale Übereinstimmung zurück gibt. 
/// Es können dabei mehrere verschiedene Einstellungen vorgenommen werden.
/// Alle Prozentangaben, egal ob Rückgabe oder Festlegen, 100 Prozent = 1
/// 
/// Beim Vergleichen wird ganz normal von vorne angefangen. Jede Übereinstimmung ist 100 Prozent.
/// Diese werden beim Debuggen in der Matrix gespeichert und anschließend zusammengezählt und die Prozente
/// dann von ersten Zeichenfolgen (die Länge) berechnet.
/// 
/// Es gibt für beide Zeichenfolgen zwei seperate Indexe, die beide seperat hochgezählt werden, bzw. der zweite Index auch springen kann,
/// wenn ein Zeichen an der falschen Stelle ist.
/// 
/// Wenn ein Zeichen nicht vorhanden ist, wird als nächstes gesucht, wo sich das zusuchende Zeichen als nächstes befinden.
/// Dabei wird die aktuelle Position als Ausgangspunkt genommen. Das näher gelegene Zeichen hat gewonnen und wird als neuer Index für
/// die 2. Zeichenfolge genommen. Die Prozente für die aktuelle Position berechnen sich aus dem Abstand der aktuellen Position, mit dem 
/// gefundenem Zeichen, welches am nächsten liegt. Als Basislänge, wird wieder die Länge von der ersten Zeichenkette verwendet. Dies Lässt sich
/// aber mit den 2 Eigenschaften zum Sortieren ändern.
/// 
/// Wenn nach einander mehrere Zeichen nicht an der richtigen Position sind, wird ein extra Zähler hochgezählt,
/// der die Anzahl der falschen Zeichen misst und dann von der bereits errechneten Übereinstimmung nochmal ein Prozentsatz abgezogen.
/// Wenn PutBack auf true ist, wird wenn ein Zeichen wieder an der richtigen Position ist, der bereits falschen Zeichen zurück auf 0 gesetzt.
/// 
/// Mit MaxAway lässt sich einstellen, weit ein Zeichen von der aktuellen Position entfernt sein darf, bzw. wieviel Prozent für ein zeichen
/// mind. erreicht werden müssen. Ist dies kleiner, hat die aktuelle Position 0 Prozent.
/// 
/// Die neue aktuelle Position für die zweite Zeichenfolge ist dann das gerade eben gefundene Zeichen. Wurde keins gefunden, bleibt die
/// Position unverändert.
/// </summary>
public class MyStringComparer
{
    #region Felder

    /// <summary>
    /// Unterscheidung zwischen Groß und Kleinschreibung
    /// </summary>
    private bool _ignoreCase = true;

    /// <summary>
    /// Der Abstand in Prozent, die ein zu suchendes Zeichen maximal von der aktuellen Position entfernt sein darf.
    /// </summary>
    private float _maxAway = 0.90F;

    /// <summary>
    /// Wenn true, werden die zwei übergebenen Strings bei Bedarf getauscht, dass die Längere Zeichenfolge als erstes Argument und die kürzere als zweites Argument.
    /// </summary>
    private bool _sortVars = false;

    /// <summary>
    /// Wenn true und wenn _sortVars true, dann wird beim Tauschen der Zeichenfolgen die Längere Zeichenfolge zuerst genommen.
    /// </summary>
    private bool _LongerVarFirst = false;

    /// <summary>
    /// Wenn auf true gesetzt wurde, wird nach dem Fehler aufgetreten sind und das aktuelle Zeichen wieder stimmt, die Fehleranzahl zurückgesetzt.
    /// </summary>
    private bool _putBack = true;

    /// <summary>
    /// Entfernt überschüssige Leerzeichen.
    /// </summary>
    private bool _removeDoubleWhitespaces = true;

#if DEBUG
        /// <summary>
        /// 
        /// </summary>
        private float[] _lastmatrix;
#endif

    #endregion

    #region Eigenschaften

#if DEBUG

        /// <summary>
        /// Gibt die letzte Matrix mit den Prozenten zurück für Debugzwecke.
        /// </summary>
        public float[] LastMatrix
        {
            get
            {
                return this._lastmatrix;
            }
        }

#endif

    /// <summary>
    /// Gibt zurück, ob doppelte oder mehrmals hintereinander vorkommende Leerzeichen entfernt werden sollen, oder legt dies fest.
    /// </summary>
    public bool RemoveDoubleWhitespaces
    {
        get
        {
            return this._removeDoubleWhitespaces;
        }
        set
        {
            this._removeDoubleWhitespaces = value;
        }
    }

    /// <summary>
    /// Gibt zurück, ob nach dem ein oder mehrere Zeichen falsch gewesen sind und anschließend wieder ein richtiges Zeichen, ob dann der Zähler mit den Anzahl der falschen Zeichen zurückgesetzt werden soll, oder legt dies fest.
    /// </summary>
    public bool PutBack
    {
        get
        {
            return this._putBack;
        }
        set
        {
            this._putBack = value;
        }
    }

    /// <summary>
    /// Gibt zurück, ob die beiden übergebenen Zeichenfolgen nach ihrer Länge sortiert bzw. getauscht werden sollen oder legt dies fest. 
    /// </summary>
    public bool SortVars
    {
        get
        {
            return this._sortVars;
        }
        set
        {
            this._sortVars = false;
        }
    }

    /// <summary>
    /// Gibt zurück, ob die längere Zeichenfolge als erste Zeichenfolge nach dem sortieren bzw. tauschen festgelegt werden soll, oder legt die Eigenschaft fest.
    /// Wenn SortVars nicht auf true gesetzt ist, hat diese Eigenschaft keine Auswirkung.
    /// </summary>
    public bool LongerVarFirst
    {
        get
        {
            return this._LongerVarFirst;
        }
        set
        {
            this._LongerVarFirst = value;
        }
    }

    /// <summary>
    /// Gibt die Prozente zurück, wie weit maximal ein zu suchendes Zeichen von dem Orginal entfernt sein darf oder legt dieses fest.
    /// Eine weitere Einschränkung ist, wie oft bereits vorangegangen Zeichen nicht der Position von der anderen Zeichenfolge gestanden hat.
    /// </summary>
    public float MaxAway
    {
        get
        {
            return this._maxAway;
        }
        set
        {
            this._maxAway = value;
        }
    }

    /// <summary>
    /// Gibt zurück, ob Groß- und Kleinschreibung berücksichtigt werden soll, oder legt es fest.
    /// </summary>
    public bool IgnoreCase
    {
        get
        {
            return this._ignoreCase;
        }
        set
        {
            this._ignoreCase = value;
        }
    }

    #endregion

    #region Konstruktoren

    /// <summary>
    /// Erstellt eine neue MyStringComparer-Klasse.
    /// </summary>
    public MyStringComparer()
    {
    }

    #endregion

    #region Funktionen

    /// <summary>
    /// Vergleicht zwei Strings auf Gleichheit und gibt die Ähnlichkeit in Prozent zurück.
    /// </summary>
    /// <param name="var1">Die 1. Zeichenfolge</param>
    /// <param name="var2">Die 2. Zeichenfolge</param>
    /// <returns>Die Ähnlichkeit der beiden Zeichenfolgen in Prozent (100% = 1)</returns>
    public float IsEqual(string var1, string var2)
    {
#if !DEBUG
        float currentMatrix;				//Das aktuelle Ergebnis
#endif
        int indexVar2;						//Der aktuelle Index bei der größeren Zeichenkette
        float prozentGesamt;				//Die Gesamtprozente
        int lastNot100PercentChars;			//Die Anzahl der letzten Zeichen, die nicht 100 Prozent übereingestimmt haben

        //1. Vorbereitung
        //Doppelte Leerzeichen entfernen
        if (this._removeDoubleWhitespaces)
        {
            var1 = var1.Replace("  ", " ");
            var2 = var2.Replace("  ", " ");
        }

        //Nach Länge sortieren. 
        if (this._sortVars)
        {
            if (this._LongerVarFirst)
            {
                if (var1.Length < var2.Length)
                {
                    string tmpVar = var1;
                    var1 = var2;
                    var2 = tmpVar;
                }
            }
            else
            {
                if (var1.Length > var2.Length)
                {
                    string tmpVar = var2;
                    var2 = var1;
                    var1 = tmpVar;
                }
            }
        }

        if (this._ignoreCase)
        {
            var1 = var1.ToUpper();
            var2 = var2.ToUpper();
        }

#if DEBUG
            this._lastmatrix = new float[var1.Length];
#endif
        indexVar2 = 0;
        prozentGesamt = 0;
        lastNot100PercentChars = 0;

        //Vergleichen
        /*
         * Zeichen die nicht zugeordnet werden konnten
         */
        for (int indexVar1 = 0; indexVar1 < var1.Length; indexVar1++)
        {
#if !DEBUG
            currentMatrix = 0;
#endif

            char currentZeichen1 = var1[indexVar1];
            char currentZeichen2 = var2[indexVar2];

            if (var1[indexVar1] == var2[indexVar2])
            {
#if DEBUG
                    this._lastmatrix[indexVar1] = 1F;
#else
                currentMatrix = 1F;
#endif

                if (this._putBack)
                    lastNot100PercentChars = 0;
            }
            else
            {
                int tmpNewIndexZur = -1;
                int tmpNewIndexVor = -1;

                //Indexbestimmtung
                if (indexVar2 == 0)
                    tmpNewIndexZur = -1;
                else
                {
                    if (indexVar1 >= var2.Length)
                        tmpNewIndexZur = var2.LastIndexOf(var1[indexVar1], var2.Length - 1);
                    else
                        tmpNewIndexZur = var2.LastIndexOf(var1[indexVar1], indexVar1);
                }

                if (indexVar2 == var2.Length)
                    tmpNewIndexVor = -1;
                else
                {
                    if (indexVar1 >= var2.Length)
                    {
                        if (var1[indexVar1] == var2[var2.Length - 1])
                            tmpNewIndexVor = var2.Length - 1;
                        else
                            tmpNewIndexVor = -1;
                    }
                    else
                        tmpNewIndexVor = var2.IndexOf(var1[indexVar1], indexVar1);
                }

                //Vergleichen, welcher Index am nächsten liegt
                int abstandVor = (int)Math.Sqrt(Math.Pow(indexVar1 - tmpNewIndexVor, 2));
                int abstandZur = (int)Math.Sqrt(Math.Pow(indexVar1 - tmpNewIndexZur, 2));

                //Neues Zeichen nicht gefunden, egal ob zurück oder vorwärts
                if (tmpNewIndexVor == -1 && tmpNewIndexZur == -1)
#if DEBUG
                        this._lastmatrix[indexVar1] = 0;
#else
                    currentMatrix = 0;
#endif

                //Neues Zeichen nur Rückwärts gefunden
                else if (tmpNewIndexVor == -1)
                {
                    float tmpF = 1F - (float)abstandZur / var2.Length;
                    if (lastNot100PercentChars > 0) tmpF = 1F - (float)lastNot100PercentChars / var1.Length;
                    if (tmpF < this._maxAway) tmpF = 0;

#if DEBUG
                        this._lastmatrix[indexVar1] = tmpF;
#else
                    currentMatrix = tmpF;
#endif
                    indexVar2 = tmpNewIndexZur;
                }

                //Neues Zeichen nur Vorwärts gefunden
                else if (tmpNewIndexZur == -1)
                {
                    float tmpF = 1F - (float)abstandVor / var2.Length;
                    if (lastNot100PercentChars > 0) tmpF = 1F - (float)lastNot100PercentChars / var1.Length;
                    if (tmpF < this._maxAway) tmpF = 0;

#if DEBUG
                        this._lastmatrix[indexVar1] = tmpF;
#else
                    currentMatrix = tmpF;
#endif
                    indexVar2 = tmpNewIndexVor;
                }

                //Abstand von beiden Zeichen gleich
                else if (abstandVor == abstandZur)
                {
                    //Nehme das zurückliegende Zeichen
                    float tmpF = 1F - (float)abstandZur / var2.Length;
                    if (lastNot100PercentChars > 0) tmpF = 1F - (float)lastNot100PercentChars / var1.Length;
                    if (tmpF < this._maxAway) tmpF = 0;

#if DEBUG
                        this._lastmatrix[indexVar1] = tmpF;
#else
                    currentMatrix = tmpF;
#endif
                    indexVar2 = tmpNewIndexZur;
                }

                //Abstand zum zurückliegenden Zeichen ist größer als zum vorliegenden
                else if (abstandZur > abstandVor)
                {
                    //Nächstes Zeichen nehmen
                    float tmpF = 1F - (float)abstandVor / var2.Length;
                    if (lastNot100PercentChars > 0) tmpF = 1F - (float)lastNot100PercentChars / var1.Length;
                    if (tmpF < this._maxAway) tmpF = 0;

#if DEBUG
                        this._lastmatrix[indexVar1] = tmpF;
#else
                    currentMatrix = tmpF;
#endif
                    indexVar2 = tmpNewIndexVor;
                }

                //Abstand zum vorliegenden Zeichen ist größer als zurückliegenden
                else if (abstandZur < abstandVor)
                {
                    //Das zurückliegende Zeichen verwenden
                    float tmpF = 1F - (float)abstandZur / var2.Length;
                    if (lastNot100PercentChars > 0) tmpF = 1F - (float)lastNot100PercentChars / var1.Length;
                    if (tmpF < this._maxAway) tmpF = 0;

#if DEBUG
                        this._lastmatrix[indexVar1] = tmpF;
#else
                    currentMatrix = tmpF;
#endif
                    indexVar2 = tmpNewIndexZur;
                }

                lastNot100PercentChars++;
            }

#if DEBUG
                prozentGesamt += this._lastmatrix[indexVar1];
#else
            prozentGesamt += currentMatrix;
#endif

            //indexMax hochzählen
            if (indexVar2 < var2.Length - 1) indexVar2++;
        }

        //Prozente zusammenzählen
        prozentGesamt /= (float)var1.Length;

        return prozentGesamt;
    }

    #endregion
}

