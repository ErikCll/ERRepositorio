Module Module1
    Private Declare Auto Function SetProcessWorkingSetSize Lib "kernel32.dll" (ByVal procHandle As IntPtr, ByVal min As Int32, ByVal max As Int32) As Boolean

    Public Sub LiberarMemoria()

        Try

            Dim memoria As Process
            memoria = Process.GetCurrentProcess()
            SetProcessWorkingSetSize(memoria.Handle, -1, -1)

        Catch ex As Exception

        End Try

    End Sub
End Module
