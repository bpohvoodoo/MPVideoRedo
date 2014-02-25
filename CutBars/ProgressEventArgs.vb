Public Class ProgressEventArgs
    Inherits EventArgs

    Public Sub New()
    End Sub


    Private m_Linemarkerposition As Single
    Public Property Linemarkerposition() As Single
        Get
            Return m_Linemarkerposition
        End Get
        Set(ByVal value As Single)
            m_Linemarkerposition = value
        End Set
    End Property

    Private m_StartValues As List(Of Single)
    Public Property StartValues() As List(Of Single)
        Get
            Return m_StartValues
        End Get
        Set(ByVal value As List(Of Single))
            m_StartValues = value
        End Set
    End Property

    Private m_EndValues As List(Of Single)
    Public Property EndValues() As List(Of Single)
        Get
            Return m_EndValues
        End Get
        Set(ByVal value As List(Of Single))
            m_EndValues = value
        End Set
    End Property




End Class
