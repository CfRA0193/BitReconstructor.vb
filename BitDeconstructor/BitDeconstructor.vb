Imports System.IO

Public Module BitDeconstructor
    Private _rnd = New Random(Now.Ticks Mod Integer.MaxValue)
    Public Property SyncRoot As New Object

    Public Sub Seed(seed As Long)
        SyncLock SyncRoot
            _rnd = New Random(seed Mod Integer.MaxValue)
        End SyncLock
    End Sub

    Public Sub Deconstruction(fileName As String, N As Integer)
        SyncLock SyncRoot
            Dim inputStream = New BufferedStream(New FileStream(fileName, FileMode.Open))
            Dim outStreams = New Stream(N - 1) {}
            For i = 0 To N - 1
                Dim outFileName = String.Format("{0}.bitd.{1}", fileName, i)
                If File.Exists(outFileName) Then
                    File.SetAttributes(fileName, FileAttributes.Normal)
                    File.Delete(outFileName)
                End If
                outStreams(i) = New BufferedStream(New FileStream(outFileName, FileMode.CreateNew))
            Next
            Dim mixBuffer = New Byte(N - 1) {}
            For i = 0 To inputStream.Length - 1
                Dim s = inputStream.ReadByte()
                For j = 0 To mixBuffer.Length - 1
                    mixBuffer(j) = s
                Next
                Dim errorIdxs = GetErrorPositions(N)
                For Each errorIdx In errorIdxs
                    mixBuffer(errorIdx) = RND(s) Mod Byte.MaxValue
                Next
                For j = 0 To mixBuffer.Length - 1
                    outStreams(j).WriteByte(mixBuffer(j))
                Next
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
        Return (seed + R + T) Mod Integer.MaxValue
    End Function
End Module
