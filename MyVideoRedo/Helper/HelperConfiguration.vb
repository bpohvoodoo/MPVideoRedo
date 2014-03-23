Imports MediaPortal.Profile
Imports MediaPortal.Configuration

Module HelpConfig



    Friend Function GetConfigString(ByVal Key As ConfigKey) As String
        MyLog.DebugM("Loading the value for key '{0}' ...", Key)
        Using reader As New Settings(Config.GetFile(Config.Dir.Config, "mediaportal.xml"))
            Dim val As String = reader.GetValue("MyVideoRedo", Key.ToString)
            If val = "" Then
                MyLog.DebugM("Value(default): {0}", GetDefaultConfigValue(Key))
                Return GetDefaultConfigValue(Key)
            Else
                MyLog.DebugM("Value: {0}", val)
                Return val
            End If


        End Using
    End Function

    Friend Function SetConfigString(ByVal Key As ConfigKey, ByVal Value As String) As Boolean
        Using writer As New Settings(Config.GetFile(Config.Dir.Config, "mediaportal.xml"))
            Try
                MyLog.DebugM("Saving configstring in key '{0}' with value '{1}'...", Key, Value)
                writer.SetValue("MyVideoRedo", Key.ToString, Value)
            Catch ex As Exception
                MyLog.Error("Error on saving the configuration. Key: {0} ; Value: {1}", Key.ToString, Value)
            End Try
        End Using
    End Function

    Friend Enum ConfigKey
        RecordingsPath = 0
        VideoSavePath = 1
        CutOnPlay = 2
        SeekStepOnPlay1 = 3
        SeekStepOnPlay3 = 4
        SeekStepOnPlay4 = 5
        SeekStepOnPlay6 = 6
        SeekStepOnPlay7 = 7
        SeekStepOnPlay9 = 9
        SeekStepOnPause1 = 10
        SeekStepOnPause3 = 11
        SeekStepOnPause4 = 12
        SeekStepOnPause6 = 13
        SeekStepOnPause7 = 14
        SeekStepOnPause9 = 15
        SaveMovieFilename = 16
        FavSeriesLanguage = 17
        SeriesReplacerPath = 18
        TVdbAPI = 19
        TVdbAPICachePath = 20
        EpisodeString = 21
        SaveSeriesFilename = 22
        CutOnEnd = 23
        CreateMoviefolder = 24
        MovieFolder = 25
        DebugVideoRedo = 26
        TVsuiteProfile = 27
        TVsuiteProfileH264 = 28
        ProfileDetails = 29
        AlwaysKeepCuts = 30
        AlwaysKeepOriginalFile = 31
        CreateSeriesfolder = 32
        SeriesFolder = 33
        ModuleName = 34
        AlwaysRefreshMoviestripThumbs = 35
        AlwaysRefreshMoviestripThumbsDelay = 36
    End Enum

    Private Function GetDefaultConfigValue(ByVal Key As ConfigKey) As String
        Select Case Key
            Case ConfigKey.RecordingsPath
                Using reader As New Settings(Config.GetFile(Config.Dir.Base, "mediaportal.xml"))
                    Return reader.GetValue("movies", "sharepath1")
                End Using
            Case ConfigKey.VideoSavePath
                Using reader As New Settings(Config.GetFile(Config.Dir.Base, "mediaportal.xml"))
                    Return reader.GetValue("movies", "sharepath1")
                End Using
            Case ConfigKey.CutOnPlay
                Return True
            Case ConfigKey.SeekStepOnPlay1
                Return 10
            Case ConfigKey.SeekStepOnPlay3
                Return 10
            Case ConfigKey.SeekStepOnPlay4
                Return 60
            Case ConfigKey.SeekStepOnPlay6
                Return 60
            Case ConfigKey.SeekStepOnPlay7
                Return 180
            Case ConfigKey.SeekStepOnPlay9
                Return 180
            Case ConfigKey.SeekStepOnPause1
                Return 1
            Case ConfigKey.SeekStepOnPause3
                Return 1
            Case ConfigKey.SeekStepOnPause4
                Return 10
            Case ConfigKey.SeekStepOnPause6
                Return 10
            Case ConfigKey.SeekStepOnPause7
                Return 30
            Case ConfigKey.SeekStepOnPause9
                Return 30
            Case ConfigKey.SaveMovieFilename
                Return "%Title% - %ChannelName%"
            Case ConfigKey.SaveSeriesFilename
                Return "%Title% - S%SeasonNumber% E%EpisodeNumber% - %EpisodeName%"
            Case ConfigKey.FavSeriesLanguage
                Return "de"
            Case ConfigKey.SeriesReplacerPath
                Return Config.GetFile(Config.Dir.Database, "ReDoReplacer.dat")
            Case ConfigKey.TVdbAPI
                Return "F976ED9F8D3A47F4"
            Case ConfigKey.TVdbAPICachePath
                Return Environment.GetFolderPath(Environment.SpecialFolder.InternetCache) & "\SeriesTemp"
            Case ConfigKey.EpisodeString
                Return 90
            Case ConfigKey.CutOnEnd
                Return "True"
            Case ConfigKey.CreateMoviefolder
                Return "False"
            Case ConfigKey.MovieFolder
                Return "%Title%"
            Case ConfigKey.CreateSeriesfolder
                Return "False"
            Case ConfigKey.SeriesFolder
                Return "Season %SeasonNumber%"
            Case ConfigKey.DebugVideoRedo
                Return "False"
            Case ConfigKey.AlwaysKeepCuts
                Return "False"
            Case ConfigKey.AlwaysKeepOriginalFile
                Return "False"
            Case ConfigKey.AlwaysRefreshMoviestripThumbs
                Return "False"
            Case ConfigKey.AlwaysRefreshMoviestripThumbsDelay
                Return "5"
            Case ConfigKey.ProfileDetails
                Return "False"
            Case ConfigKey.TVsuiteProfile
                Return "MPEG2 Program Stream"
            Case ConfigKey.TVsuiteProfileH264
                Return "MPEG2 Program Stream"
            Case ConfigKey.ModuleName
                Return "MyVideoRedo"
            Case Else
                Return Nothing
        End Select
    End Function

End Module
