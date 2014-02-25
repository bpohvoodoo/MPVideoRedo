Imports MediaPortal.Profile
Imports MediaPortal.Configuration

<Serializable()> _
Public Class clsSeriesReplacer

    Private mReplacerList As New List(Of ReplacesStrings)
    Public Property ReplacerList() As List(Of ReplacesStrings)
        Get
            Return mReplacerList
        End Get
        Set(ByVal value As List(Of ReplacesStrings))
            mReplacerList = value
        End Set
    End Property

    Public Sub New()

    End Sub

    Public Sub Save()
        ' Aufrufen der generischen Serialize-Funktion für 
        ' die Klasse Kontoverwaltung
        clsSerializer.Serialize(Of clsSeriesReplacer)(True, HelpConfig.GetConfigString(ConfigKey.SeriesReplacerPath), Me)
    End Sub

    Public Function Load() As clsSeriesReplacer
        ' Dadurch, dass die Klasse "Sub New()" aufweist, kann die 
        ' Serializer-Klasse, wenn keine Datei vorhanden ist, 
        ' eine DefaultInstance zurückgeben.
        Return clsSerializer.DeSerialize(Of clsSeriesReplacer)(True, HelpConfig.GetConfigString(ConfigKey.SeriesReplacerPath))
    End Function

End Class

<Serializable()> _
Public Class ReplacesStrings

    Private mOriginalstring As String
    Public Property OriginalString() As String
        Get
            Return mOriginalstring
        End Get
        Set(ByVal value As String)
            mOriginalstring = value
        End Set
    End Property

    Private mReplacestring As String
    Public Property ReplaceString() As String
        Get
            Return mReplacestring
        End Get
        Set(ByVal value As String)
            mReplacestring = value
        End Set
    End Property

End Class
