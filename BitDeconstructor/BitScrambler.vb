Imports System.Security.Cryptography

Public Class BitScrambler
    Public Const Ext = ".BitScrambler"
    Private _sha512 As SHA512Cng
    Private _hash As Byte()
    Private _idx As Integer
    Private _syncRoot As New Object

    Public Sub New(key As Byte())
        If key IsNot Nothing Then
            _sha512 = New SHA512Cng()
            Refresh(key)
            For i = 1 To 65536 * 128
                Refresh(_hash)
            Next
        Else
            _sha512 = Nothing
        End If
    End Sub

    Public Function ProcessByte(data As Byte) As Byte
        If _sha512 IsNot Nothing Then
            SyncLock _syncRoot
                Dim result = data Xor _hash(_idx)
                _idx += 1
                If _idx > _hash.Length - 1 Then
                    Refresh(_hash)
                End If
                Return result
            End SyncLock
        Else
            Return data
        End If
    End Function

    Public Sub Process(data As Byte())
        If _sha512 IsNot Nothing Then
            SyncLock _syncRoot
                Parallel.For(0, data.Length, Sub(i As Integer)
                                                 data(i) = data(i) Xor _hash(i)
                                             End Sub)
                _hash = _sha512.ComputeHash(_hash)
            End SyncLock
        End If
    End Sub

    Private Sub Refresh(hash As Byte())
        If _sha512 IsNot Nothing Then
            _hash = _sha512.ComputeHash(hash)
            _idx = 0
        End If
    End Sub
End Class
