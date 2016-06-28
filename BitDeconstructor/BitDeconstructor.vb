Imports System.IO

Public Module BitDeconstructor
    Private _rnd As New Random(Now.Ticks Mod Integer.MaxValue)
    Private _scr As BitScrambler
    Public Property SyncRoot As New Object

    Public Sub Seed(seed As Long)
        SyncLock SyncRoot
            _rnd = New Random(seed Mod Integer.MaxValue)
        End SyncLock
    End Sub

    Public Sub Deconstruction(fileName As String, N As Integer)
        Deconstruction(fileName, N, Nothing)
    End Sub

    Public Sub Deconstruction(fileName As String, N As Integer, key As Byte())
        SyncLock SyncRoot
            If key IsNot Nothing Then
                _scr = New BitScrambler(key)
            End If
            Dim inputStream = New BufferedStream(New FileStream(fileName, FileMode.Open, FileAccess.Read))
            Dim outStreams = New Stream(N - 1) {}
            For i = 0 To N - 1
                Dim outFileName = String.Format("{0}.bitd.{1}", fileName, i)
                If File.Exists(outFileName) Then
                    File.SetAttributes(fileName, FileAttributes.Normal)
                    File.Delete(outFileName)
                End If
                outStreams(i) = New BufferedStream(New FileStream(outFileName, FileMode.CreateNew))
            Next
            Dim buffer = New Byte(N - 1) {}
            For i = 0 To inputStream.Length - 1
                Dim s = inputStream.ReadByte()
                For j = 0 To buffer.Length - 1
                    buffer(j) = s
                Next
                Dim errorIdxs = GetErrorPositions(N)
                For Each errorIdx In errorIdxs
                    buffer(errorIdx) = RND(s) Mod Byte.MaxValue
                Next
                If _scr IsNot Nothing Then
                    For j = 0 To buffer.Length - 1
                        outStreams(j).WriteByte(_scr.ProcessByte(buffer(j)))
                    Next
                Else
                    For j = 0 To buffer.Length - 1
                        outStreams(j).WriteByte(buffer(j))
                    Next
                End If
            Next
            inputStream.Close()
            For i = 0 To N - 1
                outStreams(i).Flush()
                outStreams(i).Close()
            Next
        End SyncLock
    End Sub

    Private Function GetErrorPositions(N As Integer) As Integer()
        If N Mod 2 = 0 Then N = N - 1
        Dim E = (N \ 2)
        Dim idxList As New List(Of Integer)
        For i = 0 To N - 1
            idxList.Add(i)
        Next
        Dim errList As New List(Of Integer)
        For i = 0 To E - 1
            Dim idx = RND(0) Mod idxList.Count
            errList.Add(idx) : idxList.RemoveAt(idx)
        Next
        Return errList.ToArray()
    End Function

    Private Function RND(seed As Byte) As Integer
        Dim R = _rnd.Next()
        Dim T = Now.Ticks
        Dim UL As ULong = CLng(seed) + CLng(R) + CLng(T)
        Return UL Mod Integer.MaxValue
    End Function
End Module
