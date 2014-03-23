
''' <summary>
''' These will be loaded with the language files content
''' if the selected lang file is not found, it will first try to load en(us).xml as a backup
''' if that also fails it will use the hardcoded strings as a last resort.
''' </summary>
Public NotInheritable Class Translation

    
    Private Sub New()
    End Sub
    ' A
    Public Shared Abort As String = "Abbruch"
    Public Shared AddReplaceString As String = "Replace-String hinzufügen"
    Public Shared AdDetectiveDone As String = "Der AdDetective Scan wurde abgeschlossen."
    Public Shared AdDetectiveRunning As String = "AdDetective Scan läuft"
    Public Shared AlwaysKeepCuts As String = "Beim Beenden Schnitte immer behalten"
    Public Shared AlwaysKeepOriginalFile As String = "Beim Speichern immer die Originaldatei behalten"
    Public Shared AlwaysRefreshMoviestripThumbs As String = "Die Filmstreifen Vorschaubilder immer aktualisieren"
    Public Shared AlwaysRefreshMoviestripThumbsDelay As String = "Wiederholungsintervall"
    Public Shared AudioSyncLabel As String = "Nachsyncronisierung der Audiospur:"
    Public Shared AudioSyncLabelContext As String = "Audiospur syncronisieren"
    Public Shared AutoEndCutLabel As String = "Endmarker automatisch setzen wenn nötig"

    ' B
    Public Shared ButtonCheckTVsuite4 As String = "Auf TVsuite 4 prüfen..."
    Public Shared BackgroundSave As String = "Es wird im Hintergrund weiter gespeichert!"

    ' C
    Public Shared CalculateTimeLeft As String = "Berechne die Restzeit"
    Public Shared CalculatedTimeLeft As String = "Voraussichtliche Restzeit: "
    Public Shared ChooseSeries As String = "Wähle die Serie aus..."
    Public Shared ClearCutlist As String = "Lösche alle Cut`s"
    Public Shared ClearCutsAtClose As String = "Schnitte verwerfen?"
    Public Shared ClearCutsAtClose1 As String = "Willst du die Schnitte verwerfen?"
    Public Shared CloseVRD As String = "VideoRedo schließen!"
    Public Shared CloseVRD1 As String = "Möchten Sie, dass beim"
    Public Shared CloseVRD2 As String = "Schliessen alle vorhanden"
    Public Shared CloseVRD3 As String = "Schnitte gelöscht werden?"
    Public Shared Complete As String = "Abgeschlossen"
    Public Shared ConfigureSeekSteps As String = "Spulsprünge Konfigurieren"
    Public Shared ContinueScan As String = "Continue scan?"
    Public Shared ContinueScan1 As String = "Continue the scan in the background?"
    Public Shared CreateMovieSubfolder As String = "Erstelle Unterordner für Filme"
    Public Shared CreateSeriesSubfolder As String = "Erstelle Unterordner für Serien"
    Public Shared CutContextMenu As String = "Schnittmenü"
    Public Shared CutContextChange As String = "Gewählten Schnitt ändern"
    Public Shared CutContextDelete As String = "Gewählte Szene löschen"
    Public Shared CutContextJumpTo As String = "Springe zum gewählten Marker"

    ' D
    Public Shared DebugMode As String = "Debug Modus"
    Public Shared DeleteOriginalFile As String = "Möchtest du das Originalfile löschen?"
    Public Shared DeleteOriginalFileTitle As String = "Original löschen?"
    Public Shared DelReplaceString As String = "Ausgewählten String entfernen"
    Public Shared DescriptionRecPathDialog As String = "Wähle den Ordner der gespeicherten Aufnahmen"
    Public Shared DescriptionSavePathDialog As String = "Wähle den Ordner in dem die geschnittenen Videos gespeichert werden sollen."
    Public Shared DescriptionTVsuiteProfiles As String = "Wenn TVsuite 4 auf Ihrem System aktiv ist, können Sie hier das Standardprofil für die Konvertierung auswählen. Wenn dies der Fall ist wird eine Profile Liste erzeugt. Klicken Sie auf den Button um zu prüfen, ob die TVSuite 4 Anwendung aktiv ist und warten Sie einen Moment bis Sie die Profile auswählen können. Die Details des Profile werden dann angezeigt."
    Public Shared Deinterlacemode As String = "De-Interlace Modus:"
    Public Shared DisableProfileDetails As String = "Deaktivieren der Profildetailanzeige beim Profilwechsel"
    Public Shared Done As String = "Fertig"
    Public Shared Duration As String = "Gesamtlaufzeit:{0}"

    ' E
    Public Shared EditEndFilename As String = "End-Dateinamen bearbeiten"
    Public Shared EditReplacementString As String = "Replacement-Strings bearbeiten"
    Public Shared EditVideo As String = "Schneiden"
    Public Shared Encodingtype As String = "Encodierungstyp:"
    Public Shared EpisodeFound As String = "Episode gefunden"
    Public Shared EpisodeTitle As String = "Episodetitel"
    Public Shared ErrorOccured As String = "Fehler"

    ' F
    Public Shared FollowEpisodeWasFound As String = "Folgende Episode wurde gefunden. Verwenden?"
    Public Shared Forward As String = "Vorspulen"
    Public Shared ForwardStep As String = "Vor"
    Public Shared ForbiddenCutCompleteVideo As String = "Es ist nicht möglich das ganze Video zu beschneiden!!"
    Public Shared Filetype As String = "Dateityp:"
    Public Shared Framerate As String = "Bildrate:"
    Public Shared Frames As String = "Bilder"

    ' G
    Public Shared GeneralOptions1 As String = "Grundeinstellungen 1"
    Public Shared GeneralOptions2 As String = "Grundeinstellungen 2"
    Public Shared Genre As String = "Genre"
    Public Shared GetNewFilename As String = "Bestimme neuen Dateinamen"
    Public Shared GroupAlwaysRefreshMoviestripThumbs = "Vorschaubilder"
    Public Shared GroupCutSettingCaption As String = "Schnitt-Einstellungen"
    Public Shared GroupDialogs As String = "Dialog Einstellungen"
    Public Shared GroupModuleName As String = "Modul Name"
    Public Shared GroupOnPauseCaption As String = "Während der Pause"
    Public Shared GroupOnPlayCaption As String = "Während der Wiedergabe"
    Public Shared GroupRecordingSettingCaption As String = "Pfadeinstellungen"
    Public Shared GroupStringSettingCaption As String = "Datei/Ordner Benennungseinstellungen"
    Public Shared GroupTVSuiteProfile As String = "Standard Profil"
    Public Shared GroupTVSuiteProfileH264 As String = "Standard Profil H.264"

    ' H
    Public Shared HelpSetEndmarker As String = "Wenn diese Option aktiviert ist wird beim laden des Videos ein StartCut erstellt. Sollte aktiviert sein wenn eine Vorlaufzeit für Aufnahmen eingestellt ist."
    Public Shared HelpSetStartmarker As String = "Wenn diese Option aktiviert ist wird beim speichern des Videos ein EndCut automatisch erstellt sofern nicht vorhanden. Sollte aktiviert sein wenn eine Nachlaufzeit für Aufnahmen eingestellt ist."
    Public Shared HelpParseMovieFile As String = "Konfigurieren Sie dieses Feld nach Ihren Wünschen. Mit klick auf den Button rechts können sie die möglichen Optionen sehen"
    Public Shared HelpParseSeriesFile As String = "Konfigurieren Sie dieses Feld nach Ihren Wünschen. Mit klick auf den Button rechts können sie die möglichen Optionen sehen"
    Public Shared HelpDisableProfileDetails As String = "Konfigurieren Sie dieses Feld nach Ihren Wünschen. Mit klick auf den Button rechts können sie die möglichen Optionen sehen"
    Public Shared HowHandleVideo As String = "Was ist das für ein Video?"

    ' I
    Public Shared IdentifiedEpisode As String = "Gefundene Episode:"

    ' J

    ' K

    ' L
    Public Shared LabelSavePath As String = "Video-Speicherpfad:"
    Public Shared LabelRecordingsPath As String = "Aufnahmeordner:"
    Public Shared LoadOtherVideo As String = "Lade Video"

    ' M
    Public Shared MakeCut As String = "Schneide hier"
    Public Shared ModuleFunction As String = "Plugin zum Schneiden von Videos mit Hilfe von VideoRedo"
    Public Shared ModuleName As String = "Modul Name"
    Public Shared ModuleMain = "Film schneiden"
    Public Shared ModuleStart = "Film Auswahl"
    Public Shared ModuleSaveVideo = "Film speichern"
    Public Shared Movie As String = "Film"

    ' N
    Public Shared NoEndmarker As String = "Kein Endmarker"
    Public Shared NoEpisodesFoundDialog As String = "Es wurde keine Episode gefunden. Es wird normal gespeichert..."
    Public Shared NoSeriesFoundDialog As String = "Für die Serie wurde nichts gefunden. Es wird normal gespeichert..."
    Public Shared NewFilename As String = "Neuer Dateiname"
    Public Shared NothingFound As String = "Nichts gefunden"
    Public Shared NoRecordingsAviable As String = "Keine Aufnahmen vorhanden. Abbruch"

    ' O
    Public Shared optionsCutBars As String = "Progressbaroptionen"
    Public Shared OriginalString As String = "Orig. Zeichenkette"

    ' P
    Public Shared Position As String = "Aktuelle Position:{0}"
    Public Shared ParseMovieFileLabel As String = "Filmdateimuster:"
    Public Shared ParseSeriesFileLabel As String = "Episodendateimuster:"

    ' Q

    ' R
    Public Shared Ratio As String = "Verhältnis:"
    Public Shared RecordingDialogDescription As String = "Ordner der gespeicherten Aufnahmen"
    Public Shared RecordingPathIncorrect As String = "Ungültiger Pfad zu den Aufnahmen, bitte öffne die Configuration!!"
    Public Shared ReplacementString As String = "Ersatz Zeichenkette"
    Public Shared Resolution As String = "Auflösung:"
    Public Shared Rewind As String = "Zurückspulen"
    Public Shared RewindStep As String = "Zurück"

    ' S
    Public Shared SaveCuttedVideo As String = "Speichere Video mit Schnitten..."
    Public Shared SaveDialogDescription As String = "Ordner wo die Filme gespeichert werden sollen"
    Public Shared SaveHere As String = "Hier speichern"
    Public Shared SavingProfile As String = "Speicherprofil"
    Public Shared SaveProgressLabel As String = "Speichern zu {0}% abgeschlossen"
    Public Shared SaveVideo As String = "Video speichern"
    Public Shared SearchFolder As String = "Ordner suchen"
    Public Shared SearchWithAnotherString As String = "Suche mit anderer Zeichenfolge"
    Public Shared Seconds As String = "Sek."
    Public Shared SelRecording As String = "Wähle Sie eine Aufnahme"
    Public Shared ShowFileParserStrings As String = "Zeige Strings"
    Public Shared StartAdDetectiveScan As String = "Starte AdDetective-Scan"
    Public Shared StartCutAtStart As String = "Startmarker beim Abspielen setzten"
    Public Shared [Step] As String = "Sprung {0}"

    ' T
    Public Shared TimeLeft As String = "Restdauer:{0}"
    Public Shared Title As String = "Titel"
    Public Shared TVSuite As String = "TV Suite"

    ' U
    Public Shared Unknown As String = "Unbekannt"
    Public Shared UserAbortDialog As String = "Benutzerabbruch - Es wird normal gespeichert..."
    Public Shared UseVideoAsSeries As String = "Ist eine Serienfolge"

    ' V
    Public Shared VideoRedoCanNotHD As String = "Diese Version von VideoRedo kann kein HD Material verarbeiten, es wird abgebrochen."

    ' W

    ' X

    ' Y

    ' Z
End Class

