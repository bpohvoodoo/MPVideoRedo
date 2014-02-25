Imports System.Diagnostics
Imports System.Drawing
Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Text

Public Class ShellThumbnail
    Implements IDisposable

    <Flags()> _
    Private Enum ESTRRET
        STRRET_WSTR = 0
        STRRET_OFFSET = 1
        STRRET_CSTR = 2
    End Enum

    <Flags()> _
    Private Enum ESHCONTF
        SHCONTF_FOLDERS = 32
        SHCONTF_NONFOLDERS = 64
        SHCONTF_INCLUDEHIDDEN = 128
    End Enum

    <Flags()> _
    Private Enum ESHGDN
        SHGDN_NORMAL = 0
        SHGDN_INFOLDER = 1
        SHGDN_FORADDRESSBAR = 16384
        SHGDN_FORPARSING = 32768
    End Enum

    <Flags()> _
    Private Enum ESFGAO
        SFGAO_CANCOPY = 1
        SFGAO_CANMOVE = 2
        SFGAO_CANLINK = 4
        SFGAO_CANRENAME = 16
        SFGAO_CANDELETE = 32
        SFGAO_HASPROPSHEET = 64
        SFGAO_DROPTARGET = 256
        SFGAO_CAPABILITYMASK = 375
        SFGAO_LINK = 65536
        SFGAO_SHARE = 131072
        SFGAO_READONLY = 262144
        SFGAO_GHOSTED = 524288
        SFGAO_DISPLAYATTRMASK = 983040
        SFGAO_FILESYSANCESTOR = 268435456
        SFGAO_FOLDER = 536870912
        SFGAO_FILESYSTEM = 1073741824
        SFGAO_HASSUBFOLDER = -2147483648
        SFGAO_CONTENTSMASK = -2147483648
        SFGAO_VALIDATE = 16777216
        SFGAO_REMOVABLE = 33554432
        SFGAO_COMPRESSED = 67108864
    End Enum

    Private Enum EIEIFLAG
        IEIFLAG_ASYNC = 1
        IEIFLAG_CACHE = 2
        IEIFLAG_ASPECT = 4
        IEIFLAG_OFFLINE = 8
        IEIFLAG_GLEAM = 16
        IEIFLAG_SCREEN = 32
        IEIFLAG_ORIGSIZE = 64
        IEIFLAG_NOSTAMP = 128
        IEIFLAG_NOBORDER = 256
        IEIFLAG_QUALITY = 512
    End Enum

    <StructLayout(LayoutKind.Sequential, Pack:=4, Size:=0, CharSet:=CharSet.Auto)> _
    Private Structure STRRET_CSTR
        Public uType As ESTRRET
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=520)> _
        Public [cStr] As Byte()
    End Structure

    <StructLayout(LayoutKind.Explicit, CharSet:=CharSet.Auto)> _
    Private Structure STRRET_ANY
        <FieldOffset(0)> _
        Public uType As ESTRRET
        <FieldOffset(4)> _
        Public pOLEString As IntPtr
    End Structure
    <StructLayoutAttribute(LayoutKind.Sequential)> _
    Private Structure cSIZE
        Public cx As Integer
        Public cy As Integer
    End Structure

    <ComImport(), Guid("00000000-0000-0000-C000-000000000046")> _
    <InterfaceType(ComInterfaceType.InterfaceIsIUnknown)> _
    Private Interface IUnknown

        <PreserveSig()> _
        Function QueryInterface(ByRef riid As Guid, ByRef pVoid As IntPtr) As IntPtr

        <PreserveSig()> _
        Function AddRef() As IntPtr

        <PreserveSig()> _
        Function Release() As IntPtr
    End Interface

    <ComImportAttribute()> _
    <GuidAttribute("00000002-0000-0000-C000-000000000046")> _
    <InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)> _
    Private Interface IMalloc

        <PreserveSig()> _
        Function Alloc(ByVal cb As Integer) As IntPtr

        <PreserveSig()> _
        Function Realloc(ByVal pv As IntPtr, ByVal cb As Integer) As IntPtr

        <PreserveSig()> _
        Sub Free(ByVal pv As IntPtr)

        <PreserveSig()> _
        Function GetSize(ByVal pv As IntPtr) As Integer

        <PreserveSig()> _
        Function DidAlloc(ByVal pv As IntPtr) As Integer

        <PreserveSig()> _
        Sub HeapMinimize()
    End Interface

    <ComImportAttribute()> _
    <GuidAttribute("000214F2-0000-0000-C000-000000000046")> _
    <InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)> _
    Private Interface IEnumIDList

        <PreserveSig()> _
        Function [Next](ByVal celt As Integer, ByRef rgelt As IntPtr, ByRef pceltFetched As Integer) As Integer

        Sub Skip(ByVal celt As Integer)

        Sub Reset()

        Sub Clone(ByRef ppenum As IEnumIDList)
    End Interface

    <ComImportAttribute()> _
    <GuidAttribute("000214E6-0000-0000-C000-000000000046")> _
    <InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)> _
    Private Interface IShellFolder

        Sub ParseDisplayName(ByVal hwndOwner As IntPtr, ByVal pbcReserved As IntPtr, <MarshalAs(UnmanagedType.LPWStr)> ByVal lpszDisplayName As String, ByRef pchEaten As Integer, ByRef ppidl As IntPtr, ByRef pdwAttributes As Integer)

        Sub EnumObjects(ByVal hwndOwner As IntPtr, <MarshalAs(UnmanagedType.U4)> ByVal grfFlags As ESHCONTF, ByRef ppenumIDList As IEnumIDList)

        Sub BindToObject(ByVal pidl As IntPtr, ByVal pbcReserved As IntPtr, ByRef riid As Guid, ByRef ppvOut As IShellFolder)

        Sub BindToStorage(ByVal pidl As IntPtr, ByVal pbcReserved As IntPtr, ByRef riid As Guid, ByVal ppvObj As IntPtr)

        <PreserveSig()> _
        Function CompareIDs(ByVal lParam As IntPtr, ByVal pidl1 As IntPtr, ByVal pidl2 As IntPtr) As Integer

        Sub CreateViewObject(ByVal hwndOwner As IntPtr, ByRef riid As Guid, ByVal ppvOut As IntPtr)

        Sub GetAttributesOf(ByVal cidl As Integer, ByVal apidl As IntPtr, <MarshalAs(UnmanagedType.U4)> ByRef rgfInOut As ESFGAO)

        Sub GetUIObjectOf(ByVal hwndOwner As IntPtr, ByVal cidl As Integer, ByRef apidl As IntPtr, ByRef riid As Guid, ByRef prgfInOut As Integer, ByRef ppvOut As IUnknown)

        Sub GetDisplayNameOf(ByVal pidl As IntPtr, <MarshalAs(UnmanagedType.U4)> ByVal uFlags As ESHGDN, ByRef lpName As STRRET_CSTR)

        Sub SetNameOf(ByVal hwndOwner As IntPtr, ByVal pidl As IntPtr, <MarshalAs(UnmanagedType.LPWStr)> ByVal lpszName As String, <MarshalAs(UnmanagedType.U4)> ByVal uFlags As ESHCONTF, ByRef ppidlOut As IntPtr)
    End Interface
    <ComImportAttribute(), GuidAttribute("BB2E617C-0920-11d1-9A0B-00C04FC2D6C1"), InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)> _
    Private Interface IExtractImage
        Sub GetLocation(<Out(), MarshalAs(UnmanagedType.LPWStr)> ByVal pszPathBuffer As StringBuilder, ByVal cch As Integer, ByRef pdwPriority As Integer, ByRef prgSize As SIZE, ByVal dwRecClrDepth As Integer, ByRef pdwFlags As Integer)

        Sub Extract(ByRef phBmpThumbnail As IntPtr)
    End Interface

    Private Class UnmanagedMethods

        <DllImport("shell32", CharSet:=CharSet.Auto)> _
        Friend Shared Function SHGetMalloc(ByRef ppMalloc As IMalloc) As Integer
        End Function

        <DllImport("shell32", CharSet:=CharSet.Auto)> _
        Friend Shared Function SHGetDesktopFolder(ByRef ppshf As IShellFolder) As Integer
        End Function

        <DllImport("shell32", CharSet:=CharSet.Auto)> _
        Friend Shared Function SHGetPathFromIDList(ByVal pidl As IntPtr, ByVal pszPath As StringBuilder) As Integer
        End Function

        <DllImport("gdi32", CharSet:=CharSet.Auto)> _
        Friend Shared Function DeleteObject(ByVal hObject As IntPtr) As Integer
        End Function

    End Class

    Protected Overrides Sub Finalize()
        Try
            Dispose()
        Finally
            MyBase.Finalize()
        End Try
    End Sub

    Private alloc As IMalloc = Nothing
    Private disposed As Boolean = False
    Private _desiredSize As New Size(100, 100)
    Private _thumbNail As Bitmap

    Public ReadOnly Property ThumbNail() As Bitmap
        Get
            Return _thumbNail
        End Get
    End Property

    Public Property DesiredSize() As Size
        Get
            Return _desiredSize
        End Get
        Set(ByVal value As Size)
            _desiredSize = value
        End Set
    End Property
    Private ReadOnly Property Allocator() As IMalloc
        Get
            If Not disposed Then
                If alloc Is Nothing Then
                    UnmanagedMethods.SHGetMalloc(alloc)
                End If
            Else
                Debug.Assert(False, "Object has been disposed.")
            End If
            Return alloc
        End Get
    End Property

    Public Function GetThumbnail(ByVal fileName As String) As Bitmap
        If Not File.Exists(fileName) AndAlso Not Directory.Exists(fileName) Then
            Throw New FileNotFoundException(String.Format("The file '{0}' does not exist", fileName), fileName)
        End If
        If _thumbNail IsNot Nothing Then
            _thumbNail.Dispose()
            _thumbNail = Nothing
        End If
        Dim folder As IShellFolder = Nothing
        Try
            folder = getDesktopFolder
        Catch ex As Exception
            Throw ex
        End Try
        If folder IsNot Nothing Then
            Dim pidlMain As IntPtr = IntPtr.Zero
            Try
                Dim cParsed As Integer = 0
                Dim pdwAttrib As Integer = 0
                Dim filePath As String = Path.GetDirectoryName(fileName)
                folder.ParseDisplayName(IntPtr.Zero, IntPtr.Zero, filePath, cParsed, pidlMain, pdwAttrib)
            Catch ex As Exception
                Marshal.ReleaseComObject(folder)
                Throw ex
            End Try
            If pidlMain <> IntPtr.Zero Then
                Dim iidShellFolder As New Guid("000214E6-0000-0000-C000-000000000046")
                Dim item As IShellFolder = Nothing
                Try
                    folder.BindToObject(pidlMain, IntPtr.Zero, iidShellFolder, item)
                Catch ex As Exception
                    Marshal.ReleaseComObject(folder)
                    Allocator.Free(pidlMain)
                    Throw ex
                End Try
                If item IsNot Nothing Then
                    Dim idEnum As IEnumIDList = Nothing
                    Try
                        item.EnumObjects(IntPtr.Zero, (ESHCONTF.SHCONTF_FOLDERS Or ESHCONTF.SHCONTF_NONFOLDERS), idEnum)
                    Catch ex As Exception
                        Marshal.ReleaseComObject(folder)
                        Allocator.Free(pidlMain)
                        Throw ex
                    End Try
                    If idEnum IsNot Nothing Then
                        Dim hRes As Integer = 0
                        Dim pidl As IntPtr = IntPtr.Zero
                        Dim fetched As Integer = 0
                        Dim complete As Boolean = False
                        While Not complete
                            hRes = idEnum.[Next](1, pidl, fetched)
                            If hRes <> 0 Then
                                pidl = IntPtr.Zero
                                complete = True
                            Else
                                If _getThumbNail(fileName, pidl, item) Then
                                    complete = True
                                End If
                            End If
                            If pidl <> IntPtr.Zero Then
                                Allocator.Free(pidl)
                            End If
                        End While
                        Marshal.ReleaseComObject(idEnum)
                    End If
                    Marshal.ReleaseComObject(item)
                End If
                Allocator.Free(pidlMain)
            End If
            Marshal.ReleaseComObject(folder)
        End If
        Return ThumbNail
    End Function

    Private Function _getThumbNail(ByVal file As String, ByVal pidl As IntPtr, ByVal item As IShellFolder) As Boolean
        Dim hBmp As IntPtr = IntPtr.Zero
        Dim extractImage As IExtractImage = Nothing
        Try
            Dim pidlPath As String = PathFromPidl(pidl)
            If Path.GetFileName(pidlPath).ToUpper().Equals(Path.GetFileName(file).ToUpper()) Then
                Dim iunk As IUnknown = Nothing
                Dim prgf As Integer = 0
                Dim iidExtractImage As New Guid("BB2E617C-0920-11d1-9A0B-00C04FC2D6C1")
                item.GetUIObjectOf(IntPtr.Zero, 1, pidl, iidExtractImage, prgf, iunk)
                extractImage = DirectCast(iunk, IExtractImage)
                If extractImage IsNot Nothing Then
                    Debug.WriteLine("Got an IExtractImage object!")
                    Dim sz As New cSIZE()
                    sz.cx = DesiredSize.Width
                    sz.cy = DesiredSize.Height
                    Dim location As New StringBuilder(260, 260)
                    Dim priority As Integer = 0
                    Dim requestedColourDepth As Integer = 32
                    Dim flags As EIEIFLAG = EIEIFLAG.IEIFLAG_ASPECT Or EIEIFLAG.IEIFLAG_SCREEN
                    Dim uFlags As Integer = CInt(flags)
                    extractImage.GetLocation(location, location.Capacity, priority, New Size(sz.cx, sz.cy), requestedColourDepth, uFlags)
                    extractImage.Extract(hBmp)
                    If hBmp <> IntPtr.Zero Then
                        _thumbNail = Bitmap.FromHbitmap(hBmp)
                    End If
                    Marshal.ReleaseComObject(extractImage)
                    extractImage = Nothing
                End If
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            If hBmp <> IntPtr.Zero Then
                UnmanagedMethods.DeleteObject(hBmp)
            End If
            If extractImage IsNot Nothing Then
                Marshal.ReleaseComObject(extractImage)
            End If
            'Throw ex
        End Try
    End Function

    Private Function PathFromPidl(ByVal pidl As IntPtr) As String
        Dim path As New StringBuilder(260, 260)
        Dim result As Integer = UnmanagedMethods.SHGetPathFromIDList(pidl, path)
        If result = 0 Then
            Return String.Empty
        Else
            Return path.ToString()
        End If
    End Function

    Private ReadOnly Property getDesktopFolder() As IShellFolder
        Get
            Dim ppshf As IShellFolder = Nothing
            Dim r As Integer = UnmanagedMethods.SHGetDesktopFolder(ppshf)
            Return ppshf
        End Get
    End Property

    Public Sub Dispose() Implements IDisposable.Dispose
        If Not disposed Then
            If alloc IsNot Nothing Then
                Marshal.ReleaseComObject(alloc)
            End If
            alloc = Nothing
            If _thumbNail IsNot Nothing Then
                _thumbNail.Dispose()
            End If
            disposed = True
        End If
    End Sub

End Class


