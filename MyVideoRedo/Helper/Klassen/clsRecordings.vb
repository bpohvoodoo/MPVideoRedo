Imports MediaPortal.Util
Imports MediaPortal.GUI.Library
Imports System.Xml

Public Class clsRecordings

    Private varRecPath As String
    Friend Property RecPath() As String
        Get
            Return varRecPath
        End Get
        Set(ByVal value As String)
            varRecPath = value
        End Set
    End Property

    Private varlRecordings As New List(Of Recordings)
    Friend Property lRecordings() As List(Of Recordings)
        Get
            Return varlRecordings
        End Get
        Set(ByVal value As List(Of Recordings))
            varlRecordings = value
        End Set
    End Property


    Friend Sub New(ByVal RecordingPath As String)


        'TODO
        'Den Pfad für die Aufnahme automatisch auslesen
        RecPath = RecordingPath

        Me.lRecordings = GetRecordings()

        'MsgBox(GUIPropertyManager.GetProperty("#urltonavigate").ToString)
    End Sub


    Private Function GetRecordings() As List(Of Recordings)
        Dim sFile As String
        Dim sPath As String

        Dim newRec As New List(Of Recordings)

        ' Startverzeichnis
        sPath = RecPath

        ' alle Dateien im Startverzeichnis einschl. Unterordner 
        ' prüfen und laden
        Try
            For Each sFile In My.Computer.FileSystem.GetFiles( _
              sPath, FileIO.SearchOption.SearchTopLevelOnly, "*.xml")
                Dim itm As New Recordings
                'XML lesen
                Dim doc As New XmlDocument
                doc.Load(sFile)

                Dim root As XmlElement = doc.DocumentElement

                For Each simpleTag As XmlNode In root.ChildNodes
                    For Each simple As XmlNode In simpleTag.ChildNodes

                        itm.Filename = sFile
                        If IO.File.Exists(Replace(sFile, "xml", "ts")) Then
                            itm.VideoFilename = Replace(sFile, "xml", "ts")

                            Select Case simple("name").InnerText
                                Case "GENRE"
                                    itm.Genre = simple("value").InnerText
                                Case "CHANNEL_NAME"
                                    itm.Channelname = simple("value").InnerText
                                Case "TITLE"
                                    itm.Title = simple("value").InnerText
                                Case "COMMENT"
                                    itm.Comment = simple("value").InnerText
                                Case "EPISODENAME"
                                    itm.Episodename = simple("value").InnerText
                                Case "SERIESNUM"
                                    Dim originString As String = IIf(simple("value").InnerText = "", 0, simple("value").InnerText)
                                    Dim newInt As Integer = 0
                                    If Int32.TryParse(originString, newInt) = True Then
                                        itm.SeriesNum = newInt
                                    Else
                                        originString = Left(IIf(simple("value").InnerText = "", 0, simple("value").InnerText), 1)
                                        If Int32.TryParse(originString, newInt) = True Then
                                            itm.SeriesNum = newInt
                                        Else
                                            itm.SeriesNum = 0
                                        End If
                                        itm.SeriesNum = 0
                                    End If
                                Case "EPISODENUM"
                                    Dim originString As String = IIf(simple("value").InnerText = "", 0, simple("value").InnerText)
                                    Dim newInt As Integer = 0
                                    If Int32.TryParse(originString, newInt) = True Then
                                        itm.EpisodeNum = newInt
                                    Else
                                        originString = Left(IIf(simple("value").InnerText = "", 0, simple("value").InnerText), 1)
                                        If Int32.TryParse(originString, newInt) = True Then
                                            itm.EpisodeNum = newInt
                                        Else
                                            itm.EpisodeNum = 0
                                        End If
                                        itm.EpisodeNum = 0
                                    End If
                                Case "EPISODEPART"
                                    itm.EpisodePart = IIf(simple("value").InnerText = "", 0, simple("value").InnerText)
                                Case "STARTTIME"
                                    itm.StartTime = simple("value").InnerText
                                Case "ENDTIME"
                                    itm.EndTime = simple("value").InnerText
                            End Select
                        Else
                            MyLog.Warn("Die Aufnahme '" & Replace(sFile, "xml", "ts") & "' kann nicht gefunden werden")
                            Exit For
                        End If





                    Next
                Next
                newRec.Add(itm)
            Next
        Catch ex As IO.IOException
            MyLog.Warn("Fehler in GetRecordings():{0}", ex.ToString)
            Return newRec
        End Try
        Return newRec



    End Function


    Public Structure Recordings
        Dim Filename As String
        Dim VideoFilename As String
        Dim Title As String
        Dim Comment As String
        Dim Genre As String
        Dim Channelname As String
        Dim Seriesname As String
        Dim Episodename As String
        Dim EpisodeNum As Integer
        Dim SeriesNum As Integer
        Dim EpisodePart As Integer
        Dim StartTime As Date
        Dim EndTime As Date
        Dim SavingFilename As String
    End Structure

End Class
