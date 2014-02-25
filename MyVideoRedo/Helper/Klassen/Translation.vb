
''' <summary>
''' These will be loaded with the language files content
''' if the selected lang file is not found, it will first try to load en(us).xml as a backup
''' if that also fails it will use the hardcoded strings as a last resort.
''' </summary>
Public NotInheritable Class Translation

    
    Private Sub New()
    End Sub
    ' A
    Public Shared SelRecording As String = "Wähle eine Aufnahme"
    Public Shared addReplaceString As String = "Replace-String hinzufügen"
    Public Shared AutoEndCutLabel As String = "Endmarker automatisch setzen wenn nötig"
    Public Shared AdDetectiveDone As String = "Der AdDetective Scan wurde abgeschlossen."
    Public Shared AdDetectiveRunning As String = "AdDetective Scan läuft"
    Public Shared Abbruch As String = "Abbruch"
    Public Shared AudioSyncLabel As String = "Nachsyncronisierung der Audiospur:"
    Public Shared AudioSyncLabelContext As String = "Audiospur syncronisieren"

    ' B
    Public Shared ButtonCheckTVsuite4 As String = "Auf TVsuite 4 prüfen..."

    ' C
    Public Shared Complete As String = "Abgeschlossen"
    Public Shared CalculateResttime As String = "Berechne"
    Public Shared CalculatedResttime As String = "Voraussichtliche Restzeit: "
    Public Shared ChooseSeries As String = "Wähle die Serie aus..."
    Public Shared ConfigureSeekSteps As String = "Spulsprünge Konfigurieren"
    Public Shared CreateFilmsubfolder As String = "Erstelle Unterordner für Filme"
    Public Shared ClearCutlist As String = "Lösche alle Cut`s"
    Public Shared ClearCutsAtClose As String = "Schnitte verwerfen?"
    Public Shared ClearCutsAtClose1 As String = "Willst du die Schnitte verwerfen?"
    Public Shared ContinueScan As String = "Continue scan?"
    Public Shared ContinueScan1 As String = "Continue the scan in the background?"
    Public Shared CloseVRD As String = "VideoRedo schliessen?"
    Public Shared CloseVRD1 As String = "Möchtest du VideoReDo schliessen und alles vorhandenen Schnitte löschen?"

    ' D
    Public Shared duration As String = "Gesamtlaufzeit:{0}"
    Public Shared DescriptionRecPathDialog As String = "Wähle den Ordner der gespeicherten Aufnahmen"
    Public Shared DescriptionSavePathDialog As String = "Wähle den Ordner in dem die fertigen Videos gespeichert werden sollen"
    Public Shared delReplaceString As String = "Ausgewählten String entfernen"
    Public Shared Done As String = "Fertig"
    Public Shared DeleteCutDialog As String = "Gewählte Scene ausschneiden"
    Public Shared DescriptionTVsuiteProfiles As String = "Wenn die TVsuite 4 auf Ihrem System aktiv ist können Sie hier das aktive standardprofil wählen welches aktiv sein soll. Sie müssen zuerst prüfen ob die TVsuite 4 als aktive VideoRedo-Applikation verwendet wird damit anschließend die Profile ermittelt werden können. Klicken Sie auf den Button und warten Sie einen moment bis Sie ein Profil auswählen können."
    Public Shared DeleteOriginalFile As String = "Möchtest du das Originalfile löschen?"
    Public Shared DeleteOriginalFileTitle As String = "Original löschen?"
    Public Shared DeinterlaceMode As String = "DeInterlacemodus:"


    ' E
    Public Shared EpisodeFound As String = "Episode gefunden"
    Public Shared editReplacementString As String = "Replacement-Strings bearbeiten"
    Public Shared EpisodeTitle As String = "Episodetitel"
    Public Shared EditVideo As String = "Schneiden"
    Public Shared EditEndFilename As String = "End-Dateinamen bearbeiten"
    Public Shared EncodingType As String = "Encodingtype:"

    ' F
    Public Shared FollowEpisodeWasFound As String = "Folgende Episode wurde gefunden. Verwenden?"
    Public Shared Forward As String = "Vorspulen"
    Public Shared ForwardStep As String = "Vor"
    Public Shared ForbittenCutCompleteVideo As String = "Es ist nicht möglich das ganze Video zu beschneiden!!"
    Public Shared FrageSetzeEndmarker As String = "Wenn diese Option aktiviert ist wird beim laden des Videos ein StartCut erstellt. Sollte aktiviert sein wenn eine Vorlaufzeit für Aufnahmen eingestellt ist."
    Public Shared FrageSetzeStartmarker As String = "Wenn diese Option aktiviert ist wird beim speichern des Videos ein EndCut automatisch erstellt sofern nicht vorhanden. Sollte aktiviert sein wenn eine Nachlaufzeit für Aufnahmen eingestellt ist."
    Public Shared FrageParseVideoFile As String = "Konfigurieren Sie dieses Feld nach deinen wünschen. Mit klick auf den Button rechts können sie die möglichen Optionen sehen"
    Public Shared FrageParseSerienfile As String = "Konfigurieren Sie dieses Feld nach deinen wünschen. Mit klick auf den Button rechts können sie die möglichen Optionen sehen"
    Public Shared Filetype As String = "Filetype:"
    Public Shared Framerate As String = "Bildrate:"


    ' G
    Public Shared generalOptions As String = "Grundeinstellungen"
    Public Shared GroupCutSettingCaption As String = "Schneideeinstellungen"
    Public Shared GroupRecordingSettingCaption As String = "Pfadeinstellungen"
    Public Shared GroupStringSettingCaption As String = "Dateibenennungseinstellungen"
    Public Shared GroupOnPlayCaption As String = "Während der Wiedergabe"
    Public Shared GroupOnPauseCaption As String = "Während der Pause"
    Public Shared Genre As String = "Genre"
    Public Shared GetNewFilename As String = "Bestimme neuen Dateinamen"


    ' H
    Public Shared HowHandleVideo As String = "Was ist das für ein Video?"

    ' I
    Public Shared IdentifiedEpisode As String = "Gefundene Episode:"

    'K
    Public Shared KeinEndmarker As String = "Kein Endmarker"

    ' L
    Public Shared LabelSavePath As String = "Video-Speicherpfad:"
    Public Shared LabelRecordingsPath As String = "Aufnahmeordner:"
    Public Shared LoadOtherVideo As String = "Lade Video"

    ' M
    Public Shared MakeCut As String = "Schneide hier"
    Public Shared Movie As String = "Film"

    ' N
    Public Shared NoEpisodesFoundDialog As String = "Es wurde keine Episode gefunden. Es wird normal gespeichert..."
    Public Shared NoSeriesFoundDialog As String = "Für die Serie wurde nichts gefunden. Es wird normal gespeichert..."
    Public Shared NewFilename As String = "Neuer Dateiname"
    Public Shared NothinFound As String = "Nichts gefunden"
    Public Shared NoRecordingsAviable As String = "Keine Aufnahmen vorhanden. Abbruch"

    ' O
    Public Shared optionsCutBars As String = "Progressbaroptionen"

    ' P
    Public Shared position As String = "Aktuelle Position:{0}"
    Public Shared ParseVideoFileLabel As String = "Filmdateimuster:"
    Public Shared ParseSeriesFileLabel As String = "Episodendateimuster:"

    ' R
    Public Shared resttime As String = "Restdauer:{0}"
    Public Shared Rewind As String = "Zurückspulen"
    Public Shared RewindStep As String = "Zurück"
    Public Shared RecordingDialogDescription As String = "Ordner der gespeicherten Aufnahmen"
    Public Shared RecordingPathIncorrect As String = "Ungültiger Pfad zu den Aufnahmen, bitte öffne die Configuration!!"
    Public Shared Resolution As String = "Auflösung:"
    Public Shared Ratio As String = "Verhältniss:"

    ' S
    Public Shared StartCutAtStart As String = "Startmarker beim Abspielen setzten"
    Public Shared searchFolder As String = "Ordner suchen"
    Public Shared SaveVideo As String = "Video speichern"
    Public Shared SaveCuttedVideo As String = "Speichere Video mit Schnitten..."
    Public Shared SaveProgressLabel As String = "Speichern zu {0}% abgeschlossen"
    Public Shared SeriesEpisode As String = "Serienfolge"
    Public Shared SaveHere As String = "Hier speichern"
    Public Shared SeekToCutDialog As String = "Springe zum gewählten Marker"
    Public Shared SearchWithAnotherString As String = "Suche mit anderer Zeichenfolge"
    Public Shared StartAdDetectiveScan As String = "Starte AdDetective-Scan"
    Public Shared SavingProfile As String = "Speicherprofil"

    'Public Shared SeriesEpisodeNumber As String = "Episodennummer"
    Public Shared ShowFileParserStrings As String = "Zeige Strings"
    Public Shared [Step] As String = "Sprung {0}"
    Public Shared SaveDialogDescription As String = "Ordner wo die Filme gespeichert werden sollen"


    ' T
    Public Shared Title As String = "Titel"

    ' U
    Public Shared UserAbortDialog As String = "Benutzerabbruch - Es wird normal gespeichert..."
    Public Shared Unknown As String = "Unbekannt"
    Public Shared UseVideoAsSeries As String = "Aufnahme ist eine Serienfolge!"

    ' V
    Public Shared VideoRedoCanNotHD As String = "Deine Version von VideoRedo kann kein HD Material verarbeiten, es wird abgebrochen."

    ' W

    ' X

    ' Y

    ' Z
End Class

