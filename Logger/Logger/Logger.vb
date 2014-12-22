Public Class Logger
    ''' <summary>
    ''' The threat
    ''' </summary>
    ''' <remarks></remarks>
    Enum Threat
        INFO = 0
        WARN = 1
        ERRR = 2

    End Enum

    ''' <summary>
    ''' Prints general Information.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function printInformation() As Boolean
        Try
            Console.WriteLine("    -- PRINTING INFORMATION --     ")
            Console.WriteLine("    Application: Logger            ")
            Console.WriteLine("    License    : CC-BY(see LICENSE.txt)")
            Console.WriteLine("    Copyright  : (c) 2014 by Felipe M. M. Kaiser     ")
            Console.WriteLine("    General    : [Module][Threat][DD/MM/YYYY HH:MM:SS] Message     ")
            Console.WriteLine("    --   END OF PRINTING    --     ")

            Return True
        Catch
            Return False

        End Try
    End Function
    ''' <summary>
    ''' Logs something to the console
    ''' </summary>
    ''' <param name="modl">The current module(Core, Util, Save, Load or smth. else)</param>
    ''' <param name="t">The threat; see Enum Threat</param>
    ''' <param name="message">The message</param>
    ''' <returns>If the action was successful</returns>
    ''' <remarks></remarks>
    Public Shared Function log(ByVal modl As String, ByVal t As Threat, ByVal message As String) As Boolean
        Try
            Dim c As ConsoleColor = _getCol(t)
            ' [Modl][WARN][18:48:53 27.08.12] Hello there.
            _setCol(ConsoleColor.White)
            Console.Write("[" & modl & "]")
            _setCol(_getCol(t))
            Console.Write("[" & _getThreatString(t) & "]")
            _setCol(ConsoleColor.White)
            Console.Write("[" & _getDate() & "]")
            Console.Write(" " & message & vbCrLf)
            Return True
        Catch
            Return False

        End Try
    End Function


    Private Shared Function _setCol(ByVal c As ConsoleColor) As Boolean
        Try
            Console.ForegroundColor = c

            Return True

        Catch
            Return False

        End Try
    End Function
    Private Shared Function _getCol(ByVal t As Threat) As ConsoleColor
        Select Case t
            Case Threat.INFO
                Return ConsoleColor.Green

            Case Threat.WARN
                Return ConsoleColor.Yellow

            Case Threat.ERRR
                Return ConsoleColor.Red

        End Select
    End Function
    Private Shared Function _getThreatString(ByVal t As Threat) As String
        Select Case t
            Case Threat.INFO
                Return "INFO"
            Case Threat.WARN
                Return "WARN"
            Case Threat.ERRR
                Return "ERRR"
        End Select
    End Function
    Private Shared Function _getDate() As String
        Dim s As String = "DD/MM/YYYY HH:MM:SS"
        s = s.Replace("DD", Date.Today.Day.ToString)
        s = s.Replace("MM", Date.Today.Month.ToString)
        s = s.Replace("YYYY", Date.Today.Year.ToString)

        s = s.Replace("HH", Date.Now.Hour.ToString)
        s = s.Replace("MM", Date.Now.Minute.ToString)
        s = s.Replace("SS", Date.Now.Second.ToString)

        Return s

    End Function
End Class
