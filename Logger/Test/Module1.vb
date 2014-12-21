Imports Logger.Logger

Module Module1

    Sub Main()
        printInformation()
        log("Core", Threat.INFO, "Started")
        log("Core", Threat.WARN, "Calculating 3 + 5...")
        log("Math", Threat.ERRR, "Result: " & (3 + 5).ToString)
        Console.ReadKey()

    End Sub

End Module
