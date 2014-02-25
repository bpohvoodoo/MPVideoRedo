Imports System.Collections.Generic
Imports System.Globalization
Imports System.IO
Imports System.Reflection
Imports System.Xml
Imports System.Text.RegularExpressions
Imports MediaPortal.Configuration
Imports MediaPortal.GUI.Library
Imports MediaPortal.Localisation


Public NotInheritable Class Translator
    Private Sub New()
    End Sub
#Region "Private variables"

    Private Shared _translations As Dictionary(Of String, String)
    Private Shared ReadOnly _path As String = String.Empty


#End Region

#Region "Constructor"

    Shared Sub New()
        Try
            Lang = GUILocalizeStrings.GetCultureName(GUILocalizeStrings.CurrentLanguage())

        Catch generatedExceptionName As Exception
            Lang = CultureInfo.CurrentUICulture.Name

        End Try

        MyLog.Info("Using language " & Lang)

        _path = Config.GetSubFolder(Config.Dir.Language, "MyVideoRedo")

        If Not Directory.Exists(_path) Then
            Directory.CreateDirectory(_path)
        End If

        LoadTranslations()
    End Sub

    Public Shared Sub SetProperty(ByVal [property] As String, ByVal value As String)
        If [property] Is Nothing Then
            Return
        End If

        'If the value is empty always add a space
        'otherwise the property will keep 
        'displaying it's previous value
        If [String].IsNullOrEmpty(value) Then
            value = " "
        End If

        GUIPropertyManager.SetProperty([property], value)
    End Sub

#End Region

#Region "Public Properties"

    ' Gets the language actually used (after checking for localization file and fallback).
    Public Shared Property Lang() As String
        Get
            Return m_Lang
        End Get
        Private Set(ByVal value As String)
            m_Lang = value
        End Set
    End Property
    Private Shared m_Lang As String

    ''' <summary>
    ''' Gets the translated strings collection in the active language
    ''' </summary>
    Public Shared ReadOnly Property Strings() As Dictionary(Of String, String)
        Get
            If _translations Is Nothing Then
                _translations = New Dictionary(Of String, String)()
                Dim transType As Type = GetType(Translation)
                Dim fields As FieldInfo() = transType.GetFields(BindingFlags.[Public] Or BindingFlags.[Static])
                For Each field As FieldInfo In fields
                    _translations.Add(field.Name, field.GetValue(transType).ToString())
                Next
            End If
            Return _translations
        End Get
    End Property

#End Region

    Private Shared Function LoadTranslations() As Integer
        Dim doc As New XmlDocument()
        Dim TranslatedStrings As New Dictionary(Of String, String)()
        Dim langPath As String = ""
        Try
            langPath = Path.Combine(_path, Lang & ".xml")
            doc.Load(langPath)
        Catch e As Exception
            If Lang = "de" Then
                Return 0
            End If
            ' otherwise we are in an endless loop!
            If e.[GetType]() Is GetType(FileNotFoundException) Then
                MyLog.Warn("Cannot find translation file {0}.  Falling back to German", langPath)
            Else
                MyLog.[Error]("Error in translation xml file: {0}. Falling back to German", Lang)
                MyLog.[Error](e)
            End If

            Lang = "de"
            Return LoadTranslations()
        End Try
        For Each stringEntry As XmlNode In doc.DocumentElement.ChildNodes
            If stringEntry.NodeType = XmlNodeType.Element Then
                Try
                    TranslatedStrings.Add(stringEntry.Attributes.GetNamedItem("Field").Value, stringEntry.InnerText)
                Catch ex As Exception
                    MyLog.[Error]("Error in Translation Engine")
                    MyLog.[Error](ex)
                End Try
            End If
        Next

        Dim TransType As Type = GetType(Translation)
        Dim fieldInfos As FieldInfo() = TransType.GetFields(BindingFlags.[Public] Or BindingFlags.[Static])
        For Each fi As FieldInfo In fieldInfos
            If TranslatedStrings IsNot Nothing AndAlso TranslatedStrings.ContainsKey(fi.Name) Then
                TransType.InvokeMember(fi.Name, BindingFlags.SetField, Nothing, TransType, New Object() {TranslatedStrings(fi.Name)})
            Else
                MyLog.Warn("Translation not found for field: {0}.  Using hard-coded German default.", fi.Name)
            End If
        Next
        Return TranslatedStrings.Count
    End Function

#Region "Public Methods"

    Public Shared Function GetByName(ByVal name As String) As String
        If Not Strings.ContainsKey(name) Then
            Return name
        End If

        Return Strings(name)
    End Function

    Public Shared Function GetByName(ByVal name As String, ByVal ParamArray args As Object()) As String
        Return [String].Format(GetByName(name), args)
    End Function

    ''' <summary>
    ''' Takes an input string and replaces all ${named} variables with the proper translation if available
    ''' </summary>
    ''' <param name="input">a string containing ${named} variables that represent the translation keys</param>
    ''' <returns>translated input string</returns>
    Public Shared Function ParseString(ByVal input As String) As String
        Dim replacements As New Regex("\$\{([^\}]+)\}")
        Dim matches As MatchCollection = replacements.Matches(input)
        For Each match As Match In matches
            input = input.Replace(match.Value, GetByName(match.Groups(1).Value))
        Next
        Return input
    End Function


    Public Shared Sub TranslateSkin()
        MyLog.Info("Translating skin")
        For Each name As String In Strings.Keys
            SetProperty("#MyVideoRedo.Translation." & name, Translator.Strings(name))
        Next
    End Sub

   
#End Region

End Class

