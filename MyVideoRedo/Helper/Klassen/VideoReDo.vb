Imports System.Windows.Forms
Imports System.Drawing
Imports System.Runtime.InteropServices

Public Class VideoReDo
    Implements IDisposable


    Private VRD As Object

    Private SeekStopWatch As Stopwatch
    Public IsSeekTimeOverrun As Boolean = False


    Public Event AdScanStarted(ByVal sender As Object, ByVal e As AdDetectiveEventArgs)
    Public Event AdScanFinished(ByVal sender As Object, ByVal e As AdDetectiveEventArgs)
    Public Event AdScanCutAdded(ByVal sender As Object, ByVal e As AdDetectiveEventArgs)
    Public Event AdScanAborted(ByVal sender As Object, ByVal e As AdDetectiveEventArgs)
    Public Event SaveVideoStart(ByVal sender As Object, ByVal e As SaveVideoEvenArgs)
    Public Event SaveVideoProgressCanged(ByVal sender As Object, ByVal e As SaveVideoEvenArgs)
    Public Event SaveVideoFinished(ByVal sender As Object, ByVal e As SaveVideoEvenArgs)
    Public Event SaveVideoAborted(ByVal sender As Object, ByVal e As SaveVideoEvenArgs)
    Public Event QuickStreamFixNeeded(sender As Object, e As EventArgs)


    Public ReadOnly Property VRDobj() As Object
        Get
            Return VRD
        End Get
    End Property

    Private mInSilentMode As Boolean
    Public ReadOnly Property InSilentMode() As Boolean
        Get

            Return mInSilentMode

        End Get
    End Property

    Private _MaximumSeekTime As New TimeSpan(0, 0, 2)
    Public Property MaximumSeekTime As TimeSpan
        Get
            Return _MaximumSeekTime
        End Get
        Set(value As TimeSpan)
            _MaximumSeekTime = value
        End Set
    End Property


    Public ReadOnly Property GetCursorTime() As Long
        Get
            Try
                If VRD IsNot Nothing Then
                    Dim ret As Long = VRD.GetCursorTimeMsec()
                    MyLog.DebugM("Return GetCursorTime: {0} / {1}", ret, PlayerHelper.GetPlayerTimeString(ret))
                    Return ret
                Else
                    Return 0
                End If
            Catch comex As COMException
                MyLog.DebugM(comex.ToString)
            End Try
        End Get
    End Property

    Private mRedoVersion As String = ""
    Public ReadOnly Property ReDoVersion() As String
        Get
            Return mRedoVersion
        End Get
    End Property

    Private mVRDLoaded As Boolean = False
    Public Property VRDLoaded() As Boolean
        Get
            Return mVRDLoaded
        End Get
        Set(ByVal value As Boolean)
            mVRDLoaded = value

        End Set
    End Property

    Public ReadOnly Property OutputInProgress() As Boolean
        Get
            Return VRD.IsOutputInProgress
        End Get
    End Property

    Private mMediaToCut As String
    Public ReadOnly Property MediaToCut() As String
        Get
            Return mMediaToCut
        End Get
    End Property

    Public ReadOnly Property AdScanInProgress() As Boolean
        Get
            Return VRD.IsScanInProgress
        End Get
    End Property

    Private mCutMarker As New List(Of Long)
    Public Property CutMarkerList() As List(Of Long)
        Get
            Return mCutMarker
        End Get
        Set(ByVal value As List(Of Long))
            mCutMarker = value
        End Set
    End Property

    Public Property LoadCutMarkerList() As List(Of Long)
        Get

            Dim CutMarker As New List(Of Long)
            For i As Integer = 0 To VRD.GetCutSceneListCount - 1
                CutMarker.Add(GetCutFromList(i, CutterFlag.StartFlag))
                CutMarker.Add(GetCutFromList(i, CutterFlag.EndFlag))
            Next
            If mCutMarker.Count Mod 2 = 1 Then
                CutMarker.Add(mCutMarker(mCutMarker.Count - 1))
            End If
            mCutMarker = CutMarker
            Return mCutMarker
        End Get
        Set(ByVal value As List(Of Long))
        End Set
    End Property

    Private mLoadedVideoDuration As Long = 0
    Public Property LoadedVideoDuration() As Long
        Get
            Return mLoadedVideoDuration
        End Get
        Set(ByVal value As Long)
            mLoadedVideoDuration = value
        End Set
    End Property

    Private mAktSavingProfile As String
    Public Property AktSavingProfile() As String
        Get
            Return mAktSavingProfile
        End Get
        Set(ByVal value As String)
            If value <> "Nothing" Then mAktSavingProfile = value
        End Set
    End Property

    Public Sub Pause()
        VRD.Pause()
    End Sub

    Public Sub Close()
        Try
            VRD.close()
        Catch
        End Try
    End Sub

    Public Function GetProfileList() As List(Of String)
        Dim AnzProfiles As Integer = VRD.GetProfilesCount
        Dim ProfileList As New List(Of String)
        For i As Integer = 1 To AnzProfiles
            'If VRD.IsProfileEnabled(i) = True Then ProfileList.Add(VRD.GetProfileName(i))
            ProfileList.Add(VRD.GetProfileName(i))
        Next
        Return ProfileList
    End Function

    Public Function GetProfileInfo(ByVal Profile As String) As VRDProfileInfo
        Dim AktProfile As New VRDProfileInfo
        Dim ProfileIndex As Integer = 1
        Dim pList As List(Of String) = GetProfileList()
        For i As Integer = 0 To pList.Count - 1
            If pList(i) = Profile Then
                ProfileIndex = i + 1
                Exit For
            End If
        Next
        Dim ProfileString As String = VRD.GetProfileXML(ProfileIndex)
        Dim ProfileXML As New Xml.XmlDocument
        ProfileXML.LoadXml(ProfileString)
        Dim FileType As Xml.XmlNodeList = ProfileXML.GetElementsByTagName("FileType")
        AktProfile.Filetype = FileType.Item(0).InnerText
        Dim VideoAttributes As Xml.XmlNodeList = ProfileXML.GetElementsByTagName("VideoAttributes")
        For Each Attribute In VideoAttributes
            Dim InfoNodes As Xml.XmlNodeList
            InfoNodes = Attribute.childnodes
            For Each InfoNode As Xml.XmlNode In InfoNodes
                Select Case InfoNode.Name
                    Case "Encoder"
                        AktProfile.Encodingtype = InfoNode.InnerText
                    Case "AspectRatio"
                        AktProfile.Ratio = InfoNode.InnerText
                    Case "EncodeDimensions"
                        AktProfile.Resolution = InfoNode.InnerText
                    Case "DeinterlaceMethod"
                        AktProfile.DeintarlaceModus = InfoNode.InnerText
                    Case "FrameRate"
                        AktProfile.FrameRate = InfoNode.InnerText

                End Select
            Next
        Next
        'I-Pod, IPhone, Sony PSP
        If AktProfile.Filetype.Contains("MP4") Then
            AktProfile.Filetype = "MP4"
        End If
        'Mpeg2 Elementary
        If AktProfile.Filetype = "Elementary" And AktProfile.Encodingtype = "MPEG2" Then
            AktProfile.Filetype = "M2V"
        End If
        'H264 Elementary Stream
        If AktProfile.Filetype = "Elementary" And AktProfile.Encodingtype = "H264" Then
            AktProfile.Filetype = "H264"
        End If
        'Audio Only
        If AktProfile.Encodingtype = "None" And AktProfile.Filetype = "Elementary" Then
            AktProfile.Filetype = "MPA"
        End If
        Return AktProfile

    End Function


    Private _AudioSyncValue As Single = 0
    Public Property AudioSyncValue() As Single
        Get
            Return _AudioSyncValue
        End Get
        Set(ByVal value As Single)
            If VRD.AdjustAudioSync(value) = True Then
                _AudioSyncValue = value
            End If
        End Set
    End Property


    Public Sub AddMarker(ByVal Pos As Long)
        'If Pos >= 0 And Pos <= LoadedVideoDuration Then
        mCutMarker.Add(Pos)
        'VRD.AddSceneMark(Pos)
        If mCutMarker.Count Mod 2 = 0 Then
            VRD.SelectScene(mCutMarker(mCutMarker.Count - 2), mCutMarker(mCutMarker.Count - 1))
            'VRD.SelectScene(50000, 400000)
        End If
        ' Else
        ' Throw New Exception("Der neue Marker kann nicht hinzugefügt werden da ausserhalb der Videolänge. Wert = " & Pos.ToString)
        ' End If
    End Sub

    Public Sub New(Optional ByVal SilentMode As Boolean = True)
        If SilentMode Then
            Dim VideoReDoSilent = CreateObject("VideoReDo.VideoReDoSilent")
            'Dim videoReDoSilent As New redo.VideoReDoSilent
            VRD = VideoReDoSilent.vrdinterface
            'Threading.Thread.Sleep(2000)
            VRD.SetQuietMode(True)
            mInSilentMode = True
        Else
            VRD = CreateObject("VideoReDo.Application")
            VRD.SetQuietMode(False)
            mInSilentMode = False
        End If
        'Threading.Thread.Sleep(4000)
        VRDLoaded = True
        Me.LoggingCOM = True
        Application.DoEvents()
        mRedoVersion = VRD.VersionNumber
        SeekStopWatch = New Stopwatch

    End Sub

    Private _ISInQucikStreamMode As Boolean
    Public Property IsInQuickStreamMode() As Boolean
        Get
            Return _ISInQucikStreamMode
        End Get
        Set(ByVal value As Boolean)
            _ISInQucikStreamMode = value
        End Set
    End Property


    Public Function LoadMediaToCut(ByVal VideoFile As String, Optional DoQuickStreamFix As Boolean = False) As Boolean
        If IO.File.Exists(VideoFile) Then
            IsInQuickStreamMode = DoQuickStreamFix
            Dim mFile As New IO.FileInfo(VideoFile)
            If mFile.Extension.ToLower = ".ts" Or mFile.Extension.ToLower = ".mpeg" Or mFile.Extension = ".mpg" Then
                If mFile.Length > 10000000 Then
                    mMediaToCut = VideoFile
                    If DoQuickStreamFix Then
                        VRD.FileOpenBatch(VideoFile)
                    Else
                        VRD.FileOpen(VideoFile)
                    End If
                    LoadedVideoDuration = VRD.GetProgramDuration * 1000
                    If VRD.setcutmode(1) = 1 Then
                        MyLog.DebugM("Cutmode von VideoRedo erfolgreich auf CutMode gestellt")
                    Else
                        MyLog.Warn("Cutmode von VideoRedo konnte nicht umgestellt werden.")
                    End If
                    Return True
                Else
                    Throw New Exception("Bitte die Datei prüfen, die größe der Datei scheint fragwürdig", New Exception("Die größe der Datei " & VideoFile & " war unter 10000000 bytes, was für ein Videofile eher fragwürdig ist. Bitte prüfen"))
                    mMediaToCut = Nothing
                    Return False
                End If
            Else
                Throw New Exception("Die Dateiendung wird nicht unterstützt", New Exception("Die geladene Datei hat die Dateiendung '" & mFile.Extension.ToString & "'. Diese Endung wird nicht unterstützt."))
                mMediaToCut = Nothing
                Return False
            End If
        Else
            Throw New Exception("Die Angegebene Datei kann nicht gefunden werden!")
            mMediaToCut = Nothing
            Return False
        End If
    End Function

    Public Property LoggingCOM As Boolean
        Get
            Return IIf(VRD.LoggingLevel, 1, 0)
        End Get
        Set(value As Boolean)
            If value = True Then
                VRD.LoggingLevel = 1
            Else
                VRD.LoggingLevel = 0
            End If
        End Set
    End Property


    Private TemporarySeekTime As Long = 0
    Dim SeekStopWatchThread As Threading.Thread

    Public Function SeekToTime(ByVal Millisekunden, Optional BarPosition = 0) As Boolean
        Dim sobj As New SeekingObject(Millisekunden, BarPosition)
        MyLog.DebugM("Starting SeekingInBackground Thread...")
        Dim SeekThread As New Threading.Thread(AddressOf SeekInBackground)
        'SeekThread.IsBackground = True
        SeekThread.Name = "SeekThread"
        SeekThread.Priority = Threading.ThreadPriority.Lowest
        SeekThread.Start(sobj)
        MyLog.DebugM("SeekingInBackground Thread was started...")


        'MyLog.DebugM("TemporarySeekTime: {0}", Millisekunden)
        'Dim SeekingFinished As Boolean = VRD.SeekToTimeMsec(Millisekunden)

        SeekThread.Join()

        'VRD.SeekToTimeMsec(Millisekunden)

        'MyLog.DebugM("ERGEBNISS: {0}", Me.GetCursorTime = sobj.SeekTime)
        Return True
    End Function

    Public Function MakeScreenshotToClipboard(ByVal MSek As Long, Optional ByVal Quali As ScreenshotQuality = ScreenshotQuality.poor, Optional BarPosition As Integer = 0) As Image

        If VRD.IsScanInProgress Then
            If VRD.CaptureFrame(0, "", Quali) = True Then
                'Threading.Thread.Sleep(100)
                Return Clipboard.GetImage()
            Else
                Dim bmp3 As New Bitmap(20, 20)
                Return bmp3
            End If
        Else
            If Me.SeekToTime(MSek) = True Then
                'Dim a As Long = GetCursorTime
                Try
                    If VRD.CaptureFrame(0, "", Quali) = True Then
                        'Threading.Thread.Sleep(100)
                        MyLog.DebugM("Thumbnail of millisecond {0} successfully created. VRD-Position: {1}", MSek.ToString, Me.GetCursorTime)
                        Return Clipboard.GetImage()
                    End If
                Catch excom As Exception
                    Dim bmp As New Bitmap(20, 20)
                    Return bmp
                    'MyLog.DebugM(excom.Message)
                End Try
            Else
                Dim bmp1 As New Bitmap(20, 20)
                Return bmp1
            End If
        End If
        Dim bmp2 As New Bitmap(20, 20)
        Return bmp2
    End Function
    Public Function MakeScreenshot(ByVal MSek As Integer, ByVal FileName As String, Optional ByVal Quali As ScreenshotQuality = ScreenshotQuality.poor) As Boolean
        If VRD.SeekToTimeMsec(MSek) = True Then
            If VRD.CaptureFrame(1, FileName, Quali) = True Then Return True Else Return False
        Else
            Return False
        End If

    End Function
    Public Function MakeScreenshotImage(ByVal MSek As Integer, ByVal FileName As String, Optional ByVal Quali As ScreenshotQuality = ScreenshotQuality.poor) As Image
        If VRD.SeekToTimeMsec(MSek) = True Then
            If VRD.CaptureFrame(1, FileName, Quali) = True Then
                Return Image.FromFile(FileName)
            Else
                Return Nothing
            End If
        Else
            Return Nothing
        End If
    End Function

    Public Function GetFramerate() As Long
        Return VRD.GetFrameRate()
    End Function

    Public Function GetCutFromList(ByVal Index As Integer, ByVal CutArt As CutterFlag) As Long
        Return VRD.GetCutSceneListData(Index + 1, CutArt)
    End Function

    Private AbortAdScan As Boolean = False
    Public Sub AbortScan()
        AbortAdScan = True
        VRD.Pause()
        VRD.AbortOutput()
    End Sub

    Public Sub StartAdScan(ByVal FastSearch As Boolean, ByVal AutoCut As Boolean, Optional ByVal DisableDisplay As Boolean = True)
        Dim e As New AdDetectiveEventArgs
        Me.SeekToTime(0)
        If VRD.StartAdScan(IIf(FastSearch, 1, 0), IIf(AutoCut, 1, 0), IIf(DisableDisplay, 1, 0)) = True Then
            RaiseEvent AdScanStarted(Me, e)
            Dim LastCutterCount As Integer = 0
            Do While VRD.IsScanInProgress
                If VRD.GetCutSceneListCount > LastCutterCount Then
                    Threading.Thread.Sleep(200)
                    Dim e1 As New AdDetectiveEventArgs
                    e1.CutterAdd = GetCutFromList(VRD.GetCutSceneListCount - 1, CutterFlag.StartFlag)
                    e1.CutterAdd = GetCutFromList(VRD.GetCutSceneListCount - 1, CutterFlag.EndFlag)
                    mCutMarker.Add(GetCutFromList(VRD.GetCutSceneListCount - 1, CutterFlag.StartFlag))
                    mCutMarker.Add(GetCutFromList(VRD.GetCutSceneListCount - 1, CutterFlag.EndFlag))
                    LastCutterCount = VRD.GetCutSceneListCount
                    RaiseEvent AdScanCutAdded(Me, e1)
                End If
                ' Threading.Thread.Sleep(200)
                If AbortAdScan Then
                    RaiseEvent AdScanAborted(Me, New AdDetectiveEventArgs)
                    AbortAdScan = False
                    Exit Sub
                End If
            Loop
            RaiseEvent AdScanFinished(Me, e)
        Else
            Throw New Exception("Error on running 'AdDetective'")
        End If

    End Sub

    Private AbortSaving As Boolean = False
    Public Sub AbortVideoSaving()
        AbortSaving = True
        VRD.Pause()
        VRD.AbortOutput()
    End Sub

    Public Sub StartVideoSave(ByVal Filename As String)
        If SaveFileAsEx(Filename, VideoSaveFormat.MPEGtivo) Then
            Dim e As New SaveVideoEvenArgs
            RaiseEvent SaveVideoStart(Me, e)
            Threading.Thread.Sleep(2000)
            Do While VRD.IsOutputInProgress
                e.PercentageComplete = VRD.OutputPercentComplete
                RaiseEvent SaveVideoProgressCanged(Me, e)
                Threading.Thread.Sleep(500)
                If AbortSaving = True Then
                    RaiseEvent SaveVideoAborted(Me, New SaveVideoEvenArgs)
                    AbortSaving = False
                    e.PercentageComplete = 0
                    Exit Sub
                End If
            Loop
            e.PercentageComplete = 100
            RaiseEvent SaveVideoFinished(Me, e)
        Else
            Throw New Exception("Video could not be saved.")
        End If
    End Sub

    Public Sub ClearAllSelections()
        If Not VRD.ClearAllSelections() Then
            Throw New Exception("Error on deleting the cutmarkers!")
        End If
    End Sub

    Public Function SaveFileAsEx(ByVal Filename As String, Optional ByVal OutputType As VideoSaveFormat = 1) As Boolean
        'Return VRD.SaveFileAsEx(Filename, 7)
        If Left(Me.ReDoVersion, 1) = 4 Then
            'Es handelt sich um die TVsuite H264
            Dim temp As Object = VRD.FileSaveProfile(Filename, AktSavingProfile)
            If temp IsNot Nothing Then Return True
        Else
            Return VRD.FileSaveAsEx(Filename, 7)
        End If
    End Function

    Public Enum CutterFlag As Integer
        StartFlag = 0
        EndFlag = 1
    End Enum

    Public Enum VideoSaveFormat As Integer
        ProgramStream = 1
        ElementaryStream = 2
        VOB = 3
        MPEGtivo = 7
    End Enum

    Public Enum ScreenshotQuality As Integer
        original = 1
        verygood = 2
        good = 3
        middle = 4
        poor = 5
        verypoor = 6
        Thumbnail = 7
        MiniThumbnail = 8
    End Enum

    Private disposedValue As Boolean = False        ' So ermitteln Sie überflüssige Aufrufe

    ' IDisposable
    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: Anderen Zustand freigeben (verwaltete Objekte).

            End If
            System.Runtime.InteropServices.Marshal. _
            ReleaseComObject(VRD)
            VRD = Nothing
            ' TODO: Eigenen Zustand freigeben (nicht verwaltete Objekte).
            ' TODO: Große Felder auf NULL festlegen.
        End If
        Me.disposedValue = True
    End Sub

    Public Structure VRDProfileInfo
        Dim Profilename As String
        Dim Encodingtype As String
        Dim Filetype As String
        Dim Resolution As String
        Dim Ratio As String
        Dim DeintarlaceModus As String
        Dim FrameRate As String
    End Structure

#Region " IDisposable Support "
    ' Dieser Code wird von Visual Basic hinzugefügt, um das Dispose-Muster richtig zu implementieren.
    Public Sub Dispose() Implements IDisposable.Dispose
        ' Ändern Sie diesen Code nicht. Fügen Sie oben in Dispose(ByVal disposing As Boolean) Bereinigungscode ein.
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
#End Region

    Private Sub CheckSeekingInBackground(SeekObject As Object)
        Dim sObj As SeekingObject = DirectCast(SeekObject, SeekingObject)
        Do
            'Debug.WriteLine("CheckSeekingInBackground: " & SeekStopWatch.ElapsedMilliseconds.ToString & " ms")
            If VRD IsNot Nothing And Me.GetCursorTime = sObj.SeekTime Then Exit Sub
            If DateDiff(DateInterval.Second, sObj.StartTime, Now) > _MaximumSeekTime.TotalSeconds Then
                MyLog.DebugM("SeekStopWatch.ElapsedMilliseconds > MaximumSeekTime.Milliseconds. QuickstreamFix is Needed!!!!")
                RaiseEvent QuickStreamFixNeeded(Me, New EventArgs())
                Exit Sub
            End If
            Threading.Thread.Sleep(200)
        Loop
    End Sub

    Private Sub SeekInBackground(SeekObject As Object)
        Try
            Dim sObj As SeekingObject = DirectCast(SeekObject, SeekingObject)
            MyLog.DebugM("Trying to seek position: {0}", sObj.SeekTime.ToString)

            Dim thSt As New Threading.ParameterizedThreadStart(Sub() CheckSeekingInBackground(SeekObject))
            Dim seekTr As New Threading.Thread(thSt)
            seekTr.Name = "CheckSeekingThread"
            seekTr.Priority = Threading.ThreadPriority.Lowest
            seekTr.Start()


            Dim result As Boolean = VRD.SeekToTimeMsec(sObj.SeekTime)
            MyLog.DebugM("SeekToTimeMsec aus dem SeekInBackground-Thread heraus war erfolgreich? " & result.ToString)


            'RaiseEvent SeekingComplete(Me, New SeekingEventArgs(SeekingEventArgs.enumStatus.Erfolgreich, sObj.SeekTime, sObj.BarPosition))
            Try
                seekTr.Abort()
            Catch ex As Threading.ThreadAbortException
                MyLog.DebugM("The CheckSeeking thread was aborted!")
            End Try
            'Try
            '    Threading.Thread.CurrentThread.Abort()
            'Catch
            'End Try
        Catch ex As COMException
            MyLog.DebugM("COM Exception: {0}", ex.ToString)
            'Es kann vorkommen das der Thread noch nicht beendet ist wenn der Process gekillt wurde.
            'hier brauche ich nichts ausgeben ausser vieleicht eine Logausgabe
        Catch ex As Threading.ThreadAbortException
            MyLog.DebugM("The Seeking thread was aborted!")
        Catch ex As Exception
            MyLog.Info(ex.ToString)
        End Try

    End Sub

    Public Event SeekingComplete(sender As Object, e As SeekingEventArgs)
End Class

Public Class SeekingObject


    Public Sub New(ToTime As Long, OnBarPosition As Integer)
        Me.SeekTime = ToTime : Me.BarPosition = OnBarPosition
        Me.StartTime = Now
    End Sub

    Private _StarTime As DateTime
    Public Property StartTime() As DateTime
        Get
            Return _StarTime
        End Get
        Set(ByVal value As DateTime)
            _StarTime = value
        End Set
    End Property

    Private _SeekTime As Long
    Public Property SeekTime() As Long
        Get
            Return _SeekTime
        End Get
        Set(ByVal value As Long)
            _SeekTime = value
        End Set
    End Property

    Private _BarPosition As Integer
    Public Property BarPosition() As Integer
        Get
            Return _BarPosition
        End Get
        Set(ByVal value As Integer)
            _BarPosition = value
        End Set
    End Property
End Class


Public Class SeekingEventArgs
    Inherits EventArgs
    Public Sub New(Stat As enumStatus, ToTime As Long, ToBarPos As Integer)
        Me.Status = Stat : Me.Msek = ToTime : Me.FilmstripbarPosition = ToBarPos
    End Sub

    Private _Status As enumStatus
    Public Property Status() As enumStatus
        Get
            Return _Status
        End Get
        Set(ByVal value As enumStatus)
            _Status = value
        End Set
    End Property

    Private _Msek As Long
    Public Property Msek() As Long
        Get
            Return _Msek
        End Get
        Set(ByVal value As Long)
            _Msek = value
        End Set
    End Property

    Private _FilmStripbarPosition As Integer
    Public Property FilmstripbarPosition() As Integer
        Get
            Return _FilmStripbarPosition
        End Get
        Set(ByVal value As Integer)
            _FilmStripbarPosition = value
        End Set
    End Property

    Public Enum enumStatus
        Erfolgreich
        Zeitüberlauf
    End Enum

End Class

Public Class AdDetectiveEventArgs
    Inherits EventArgs

    Friend Sub New()
        Me.DetectCutter.Clear()
    End Sub

    Private mDetectCutter As New List(Of Long)
    ''' <summary>
    ''' Gibt die Liste von bis jetzt erkannten Schnittmarken zurück
    ''' </summary>
    Public Property DetectCutter() As List(Of Long)
        Get
            Return mDetectCutter
        End Get
        Set(ByVal value As List(Of Long))
            mDetectCutter = value
        End Set
    End Property

    Public ReadOnly Property LastCutString() As String
        Get
            If mDetectCutter.Count Mod 2 = 0 Then
                Return FormatTime(mDetectCutter(mDetectCutter.Count - 2)) & " - " & FormatTime(mDetectCutter(mDetectCutter.Count - 1))
            Else
                Return "Error"
            End If
        End Get
    End Property

    Public ReadOnly Property LastStartCut() As Long
        Get
            Return mDetectCutter(mDetectCutter.Count - 2)
        End Get
    End Property
    Public ReadOnly Property LastEndCut() As Long
        Get
            Return mDetectCutter(mDetectCutter.Count - 1)
        End Get
    End Property

    Public WriteOnly Property CutterAdd() As Long
        Set(ByVal value As Long)
            mDetectCutter.Add(value)
        End Set
    End Property

    ' Millisekunden in lesbares Zeitformat umwandeln
    Private Function FormatTime(ByVal lMSec As Long) _
      As String
        Dim ts As TimeSpan = TimeSpan.FromMilliseconds(lMSec)
        Return ts.Hours & ":" & ts.Minutes & ":" & ts.Seconds & "'" & ts.Milliseconds
    End Function

End Class

Public Class SaveVideoEvenArgs
    Inherits EventArgs

    Dim SaveStartTime As New Stopwatch
    Dim CalcTimeLeft As String = Translation.CalculateTimeLeft


    Public Sub New()
        Me.PercentageComplete = 0
        SaveStartTime.Start()

    End Sub

    Public ReadOnly Property TimeLeft() As String
        Get
            Return CalcTimeLeft
        End Get
    End Property

    Private mPercentageComplete As Double = 0
    Public Property PercentageComplete() As Double
        Get
            Return mPercentageComplete
        End Get
        Set(ByVal value As Double)
            mPercentageComplete = value
            If value <= 10 Then
                CalcTimeLeft = Translation.CalculateTimeLeft
            ElseIf value = 100 Then
                CalcTimeLeft = Translation.Complete
            Else
                Dim TimeRunning As Integer = SaveStartTime.ElapsedMilliseconds
                Dim TotalTime As Integer = (TimeRunning / value) * 100
                CalcTimeLeft = FormatTime(TotalTime - TimeRunning)
            End If
        End Set
    End Property

    ' Millisekunden in lesbares Zeitformat umwandeln
    Private Function FormatTime(ByVal lMSec As Long) _
      As String

        Dim ts As TimeSpan = TimeSpan.FromMilliseconds(lMSec)
        Return Format(ts.Minutes, "00") & ":" & Format(ts.Seconds, "00")
    End Function
End Class
