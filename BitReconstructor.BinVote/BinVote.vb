Imports System.Runtime.CompilerServices
Imports System.IO

Public Delegate Sub ProgressUpdated(progress As Single)

Public Module BinVote
    Public Const StreamsCountMin As Integer = 3
    Public Const StreamBufferSize As Integer = 8 * 1024 * 1024

    Public Function GetMaxDamageCount(inputsCount As Integer) As Integer
        If inputsCount Mod 2 = 0 Then inputsCount -= 1
        If inputsCount < StreamsCountMin Then Return 0 Else 
        Return Math.Floor(inputsCount / 2.0)
    End Function

    Public Sub Process(inputs As Stream(), output As Stream, progressUpdatedHandler As ProgressUpdated, Optional ByVal streamBufferSize As Integer = StreamBufferSize)
        Dim weights As Integer() = New Integer(inputs.Length - 1) {}
        For i = 0 To weights.Length - 1
            weights(i) = 1
        Next
        Process(inputs, weights, output, progressUpdatedHandler, streamBufferSize)
    End Sub

    Public Sub Process(inputs As Stream(), weights As Integer(), output As Stream, progressUpdatedHandler As ProgressUpdated, Optional ByVal streamBufferSize As Integer = StreamBufferSize)
        If inputs.Length <> weights.Length Then
            Throw New Exception("inputs.Length <> weights.Length")
        End If
        If StreamFilter(inputs, weights) < StreamsCountMin Then
            Throw New Exception(String.Format("The number of input streams is less than {0}, the binary vote is impossible!", StreamsCountMin))
        End If

        Dim inputsFilteredList As New List(Of Stream)
        Dim weightsFilteredList As New List(Of Integer)
        For i = 0 To inputs.Length - 1
            If inputs(i) IsNot Nothing Then
                inputsFilteredList.Add(inputs(i))
                weightsFilteredList.Add(weights(i))
            End If
        Next
        inputs = inputsFilteredList.ToArray()
        weights = weightsFilteredList.ToArray()
        Dim streamLength = inputs(0).Length
        Dim fullBufferIters = CLng(Math.Floor(streamLength / streamBufferSize))

        Dim inputBuffers As Byte()() = New Byte(inputs.Length - 1)() {}
        Dim outputBuffer As Byte()
        If fullBufferIters <> 0 Then
            For i = 0 To inputs.Length - 1
                inputBuffers(i) = New Byte(streamBufferSize - 1) {}
            Next
            outputBuffer = New Byte(streamBufferSize - 1) {}
            For i = 0 To fullBufferIters - 1
                FillInputBuffers(inputBuffers, inputs)
                Process(inputBuffers, weights, outputBuffer)
                output.Write(outputBuffer, 0, outputBuffer.Length)
                If progressUpdatedHandler IsNot Nothing Then progressUpdatedHandler.Invoke((i + 1) / CSng(fullBufferIters + 1))
            Next
        End If

        Dim remainBytes = streamLength - (streamBufferSize * fullBufferIters)
        If remainBytes <> 0 Then
            For i = 0 To inputs.Length - 1
                inputBuffers(i) = New Byte(remainBytes - 1) {}
            Next
            outputBuffer = New Byte(remainBytes - 1) {}
            FillInputBuffers(inputBuffers, inputs)
            Process(inputBuffers, weights, outputBuffer)
            output.Write(outputBuffer, 0, outputBuffer.Length)
        End If

        If progressUpdatedHandler IsNot Nothing Then progressUpdatedHandler.Invoke(1.0F)
        output.Flush()
    End Sub

    Private Function StreamFilter(inputs As Stream(), weights As Integer()) As Integer
        Dim equals As Integer() = New Integer(inputs.Length - 1) {}
        For i = 0 To inputs.Length - 1
            For j = 0 To inputs.Length - 1
                If inputs(i).Length = inputs(j).Length Then
                    equals(i) += weights(i)
                End If
            Next
        Next

        Dim maxEqualsVal = equals(0)
        Dim maxEqualsIdx As Integer = 0
        For i = 1 To equals.Length - 1
            If equals(i) >= maxEqualsVal Then
                maxEqualsVal = equals(i) : maxEqualsIdx = i
            End If
        Next

        Dim dominLength = inputs(maxEqualsIdx).Length
        Dim dominLengthCount As Integer = 0
        For i = 0 To inputs.Length - 1
            If inputs(i).Length = dominLength Then
                dominLengthCount += 1
                If inputs(i).CanSeek Then inputs(i).Seek(0, SeekOrigin.Begin)
            Else
                inputs(i).Close() : inputs(i) = Nothing
            End If
        Next

        Return dominLengthCount
    End Function

    Private Sub FillInputBuffers(inputBuffers As Byte()(), inputs As Stream())
        Dim rowsCount = inputBuffers(0).Length
        Parallel.For(0, inputs.Length, Sub(i As Integer)
                                           Dim done As Integer = 0
                                           Dim task As Integer = rowsCount
                                           While task > 0
                                               done += inputs(i).Read(inputBuffers(i), done, task)
                                               task = rowsCount - done
                                           End While
                                       End Sub)
    End Sub

    Private Sub Process(inputBuffers As Byte()(), weights As Integer(), output As Byte())
        Dim rowsCount = inputBuffers(0).Length
        Parallel.For(0, rowsCount, Sub(row As Integer)
                                       Dim slice As Byte() = New Byte(inputBuffers.Length - 1) {}
                                       For i = 0 To inputBuffers.Length - 1
                                           slice(i) = inputBuffers(i)(row)
                                       Next
                                       output(row) = Vote(slice, weights)
                                   End Sub)
        Return
    End Sub

    Private Function Vote(slice As Byte(), weights As Integer()) As Byte
        Dim c0, c1, c2, c3, c4, c5, c6, c7 As Integer
        Dim b0, b1, b2, b3, b4, b5, b6, b7 As Integer
        b0 = 1 : b1 = 2 : b2 = 4 : b3 = 8 : b4 = 16 : b5 = 32 : b6 = 64 : b7 = 128
        For i = 0 To slice.Length - 1
            Dim s = slice(i) : Dim w = weights(i)
            If (s And b0) <> 0 Then c0 += w Else c0 -= w
            If (s And b1) <> 0 Then c1 += w Else c1 -= w
            If (s And b2) <> 0 Then c2 += w Else c2 -= w
            If (s And b3) <> 0 Then c3 += w Else c3 -= w
            If (s And b4) <> 0 Then c4 += w Else c4 -= w
            If (s And b5) <> 0 Then c5 += w Else c5 -= w
            If (s And b6) <> 0 Then c6 += w Else c6 -= w
            If (s And b7) <> 0 Then c7 += w Else c7 -= w
        Next
        If c0 < 0 Then b0 = 0
        If c1 < 0 Then b1 = 0
        If c2 < 0 Then b2 = 0
        If c3 < 0 Then b3 = 0
        If c4 < 0 Then b4 = 0
        If c5 < 0 Then b5 = 0
        If c6 < 0 Then b6 = 0
        If c7 < 0 Then b7 = 0
        Return b0 Or b1 Or b2 Or b3 Or b4 Or b5 Or b6 Or b7
    End Function
End Module
