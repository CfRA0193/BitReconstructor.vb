Imports System.Runtime.CompilerServices
Imports System.IO

Public Module BinVoteTest
    Public Function CompareStreams(stream1 As Stream, stream2 As Stream)
        If stream1.Length <> stream2.Length Then Return False
        stream1.Seek(0, SeekOrigin.Begin) : stream2.Seek(0, SeekOrigin.Begin)
        For i = 0 To stream1.Length - 1
            Dim bt1 = stream1.ReadByte()
            Dim bt2 = stream2.ReadByte()
            If bt1 <> bt2 Then Return False
        Next
        Return True
    End Function

    <Extension()>
    Public Function GetRandomByte(rnd As Random) As Byte
        Return Math.Round(rnd.NextDouble() * Byte.MaxValue)
    End Function

    Public Sub FillAndPrepareStreams(etalon As Stream, inputs As Stream(), streamLength As Integer)
        Dim rnd As New Random(DateTime.Now.Ticks Mod Integer.MaxValue)
        Dim maxDamageCount As Integer = BinVote.GetMaxDamageCount(inputs.Length)
        For i = 1 To streamLength
            Dim bt = rnd.GetRandomByte()
            Dim inputsData As Byte() = New Byte(inputs.Length - 1) {}
            For j = 0 To inputs.Length - 1
                inputsData(j) = bt
            Next
            For k = 1 To maxDamageCount
                Dim randomDamageIdx = CInt(Math.Round(rnd.NextDouble() * (inputsData.Length - 1)))
                inputsData(randomDamageIdx) = rnd.GetRandomByte()
            Next
            For j = 0 To inputs.Length - 1
                inputs(j).WriteByte(inputsData(j))
            Next
            etalon.WriteByte(bt)
        Next
        etalon.Seek(0, SeekOrigin.Begin)
        For i = 0 To inputs.Length - 1
            inputs(i).Seek(0, SeekOrigin.Begin)
        Next
    End Sub

    Public Function Test(inputsCount As Integer, streamLength As Integer) As Double
        Dim etalon As New MemoryStream()
        Dim inputs As MemoryStream() = New MemoryStream(inputsCount - 1) {}
        Dim weights As Integer() = New Integer(inputsCount - 1) {}
        For i = 0 To inputsCount - 1
            inputs(i) = New MemoryStream(streamLength) : weights(i) = 1.0
        Next
        Dim output As New MemoryStream(streamLength)
        FillAndPrepareStreams(etalon, inputs, streamLength)
        Dim stopWatch As New Stopwatch()        
        stopWatch.Start() : BinVote.Process(inputs, weights, output, Nothing, Nothing) : stopWatch.Stop()
        Dim allOk = CompareStreams(etalon, output)
        For i = 0 To inputsCount - 1
            If inputs(i) IsNot Nothing Then inputs(i).Close()
        Next
        output.Close()
        If Not allOk Then Throw New Exception("CompareStreams(etalon, output): Fail!")
        Return streamLength / stopWatch.Elapsed.TotalSeconds
    End Function

    Public Function ShortTest(inputsCount As Integer, ByRef allOk As Boolean) As Double
        Dim result As Double
        Try
            result = Test(inputsCount, BinVote.InternalBufferSize)
        Catch ex As Exception
            allOk = False : Return 0
        End Try
        allOk = True : Return result
    End Function
End Module
