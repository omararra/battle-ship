Imports System.IO
Imports System.Runtime.CompilerServices

Module Module1

    Public Positions1(6, 6) As String 'Declares a string array called Positions size 9x9
    Public Positions2(6, 6) As String
    Public Board1(6, 6) As String 'Declares a string array called Board size 9x9
    Public Board2(6, 6) As String
    Public Xco, Yco As Integer 'Declares Xco, Yco
    Public Hits As Integer = 0 'Declares Hits
    Public Hits2 As Integer = 0
    Public Ship As String
    Public player As Integer = 1
    Public go As Integer = 1
    Public winner1 = 0
    Public winner2 = 0
    Public yesno As Integer = 0
    Public userinput As String

    Sub Main() 'Main subroutine that tells the computer where to start
        For y = 0 To 6
            For x = 0 To 6
                Positions1(x, y) = "~"
                Positions2(x, y) = "~"
                Board1(x, y) = "~"
                Board2(x, y) = "~"
            Next
        Next
        DrawShip() ' prompts users to imput their ship locations
        Menu() 'Goes to Menu subroutine
        Console.Clear() 'Clears the screen
        Game()
        Console.ReadKey()
    End Sub

    Sub Menu()
        Console.WriteLine("                              #####################")
        Console.WriteLine()
        Console.WriteLine("                                   Battleship!")
        Console.WriteLine()
        Console.WriteLine("                              #####################")
        Console.WriteLine()
        Console.WriteLine()
        Console.WriteLine("                              Press SPACE to start")
        Console.ReadKey()
    End Sub

    Sub BoardDisplay()
        If player = 1 Then
            Console.WriteLine("                              Your Board looks like this.")
            For y = 0 To 6
                Console.Write("                              ")
                For x = 0 To 6
                    Console.Write(Positions1(x, y))
                Next
                Console.WriteLine()
            Next
        ElseIf player = 2 Then
            Console.WriteLine("                              Your Board looks like this.")
            For y = 0 To 6
                Console.Write("                              ")
                For x = 0 To 6
                    Console.Write(Positions2(x, y))
                Next
                Console.WriteLine()
            Next
        Else
            Console.WriteLine("                              PLayer 1 Board")
            For y = 0 To 6
                Console.Write("                              ")
                For x = 0 To 6
                    Console.Write(Board1(x, y))
                Next
                Console.WriteLine()
            Next
            Console.WriteLine("                              Hits: " & Hits)
            Console.WriteLine()
            Console.WriteLine()
            Console.WriteLine("                              Player 2 Board")
            For y = 0 To 6
                Console.Write("                              ")
                For x = 0 To 6
                    Console.Write(Board2(x, y))
                Next
                Console.WriteLine()
            Next
            Console.WriteLine("                              Hits: " & Hits2)
            Console.WriteLine()
            Console.WriteLine()
        End If
    End Sub

    Sub XcoAsk()
        Console.WriteLine("                              Hits: " & Hits)
        Console.Write("                              Xcoord: ")
        Try
            Xco = Console.ReadLine
        Catch Xco As Exception
            Console.WriteLine("                              Input not accepted, must be a number!")
            Console.WriteLine("                              Press a key to continue")
            Console.ReadKey()
            Console.Clear()
            BoardDisplay()
            XcoAsk()
        End Try
    End Sub
    Sub XcoAsk2()
        Console.Write("                              Xcoord: ")
        Try
            Xco = Console.ReadLine
        Catch Xco As Exception
            Console.WriteLine("                              Input not accepted, must be a number!")
            Console.WriteLine("                              Press a key to continue")
            Console.ReadKey()
            Console.Clear()
            BoardDisplay()
            XcoAsk2()
        End Try
    End Sub

    Sub YcoAsk()
        Console.Write("                              Ycoord: ")
        Try
            Yco = Console.ReadLine
        Catch Yco As Exception
            Console.WriteLine("                              Input not accepted, must be a number!")
            Console.WriteLine("                              Press a key to continue")
            Console.ReadKey()
            Console.Clear()
            BoardDisplay()
            YcoAsk()
        End Try
    End Sub
    Sub YcoAsk2()
        Console.Write("                              Ycoord: ")
        Try
            Yco = Console.ReadLine
        Catch Yco As Exception
            Console.WriteLine("                              Input not accepted, must be a number!")
            Console.WriteLine("                              Press a key to continue")
            Console.ReadKey()
            Console.Clear()
            BoardDisplay()
            YcoAsk2()
        End Try
    End Sub

    Sub Game()
        Do Until Hits >= 9 Or Hits2 >= 9 Or winner1 = 1 Or winner2 = 1
            BoardDisplay()
            Console.WriteLine("                              Player 1: Please enter valid coordinates, (1-5)")
            XcoAsk()
            YcoAsk()
            While Xco <= 0 Or Xco > 5 Or Yco <= 0 Or Yco > 5
                Console.WriteLine("                              Player 1: Please enter valid coordinates, (1-5)")
                XcoAsk()
                YcoAsk()
            End While
            While Board1(Xco, Yco) = "X" Or Board1(Xco, Yco) = "O"
                Console.WriteLine("                              You already attacked that plot")
                XcoAsk()
                YcoAsk()
            End While
            If Positions2(Xco, Yco) = "D" Or Positions2(Xco, Yco) = "S" Or Positions2(Xco, Yco) = "C" Then
                Board1(Xco, Yco) = "X"
                Hits += 1
                yesno = 1
            ElseIf Positions2(Xco, Yco) = "~" Then
                Board1(Xco, Yco) = "O"
            Else
                Console.WriteLine("                              You already attacked that plot")
                XcoAsk()
                YcoAsk()
            End If
            Console.Clear()
            If yesno = 1 Then
                Console.WriteLine("You Hit a SHIP!!!")
            Else
                Console.WriteLine("MISSED HA L")
            End If
            yesno = 0
            If Hits >= 9 Then
                winner1 = 1
            End If
            BoardDisplay()
            Console.WriteLine("                              Player 2: Please enter valid coordinates, (1-5)")
            XcoAsk2()
            YcoAsk2()
            While Xco <= 0 Or Xco > 5 Or Yco <= 0 Or Yco > 5
                Console.WriteLine("                              Player 2: Please enter valid coordinates, (1-5)")
                XcoAsk2()
                YcoAsk2()
            End While
            While Board2(Xco, Yco) = "X" Or Board2(Xco, Yco) = "O"
                Console.WriteLine("                              You already attacked that plot")
                XcoAsk2()
                YcoAsk2()
            End While
            If Positions1(Xco, Yco) = "D" Then
                Board2(Xco, Yco) = "D"
                Hits2 += 1
                yesno = 1
            ElseIf Positions1(Xco, Yco) = "S" Then
                Board2(Xco, Yco) = "S"
                Hits2 += 1
                yesno = 1
            ElseIf Positions1(Xco, Yco) = "C" Then
                Board2(Xco, Yco) = "C"
                Hits2 += 1
                yesno = 1
            ElseIf Positions1(Xco, Yco) = "~" Then
                Board2(Xco, Yco) = "O"
            End If
            Console.Clear()
            If yesno = 1 Then
                Console.WriteLine("You Hit a SHIP!!!")
            Else
                Console.WriteLine("MISSED HA L")
            End If
            yesno = 0
            If Hits2 >= 9 Then
                winner2 = 1
            End If
        Loop
        Console.Clear()

        If winner1 = 1 Then
            BoardDisplay()
            Console.WriteLine("                              Player 1 is the winner!")
        ElseIf winner2 = 1 Then
            BoardDisplay()
            Console.WriteLine("                              Player 2 is the winner!")
        End If
    End Sub

    Sub DrawShip()
        Dim ships As Integer = 0

        Console.WriteLine("                              where would you like to place Destroyer (2 cells)")
        BoardDisplay()
        Do
            Console.WriteLine("                              enter x and y coordinate e.g '3, 4'")
            userinput = Console.ReadLine
            While Not ValidateInput(userinput)
                Console.WriteLine("                              enter VALID x and y coordinate e.g '3, 4'")
                userinput = Console.ReadLine()
            End While
            Xco = userinput.Split(",")(0)
            Yco = userinput.Split(",")(1)
            If Positions1(Xco, Yco) = "~" Then
                If ships = 0 Then
                    Positions1(Xco, Yco) = "D"
                    ships += 1
                Else
                    If checklawgamboD1() Then
                        Positions1(Xco, Yco) = "D"
                        ships += 1
                    Else
                        'tannesh
                    End If
                End If
            Else
                Console.WriteLine("                              You cannot overlap ships.")
            End If
            BoardDisplay()
        Loop Until ships = 2
        ships = 0
        Console.WriteLine("                              where would you like to place Submarine (3 cells)")
        BoardDisplay()
        Do
            Console.WriteLine("                              enter x and y coordinate e.g '3, 4'")
            userinput = Console.ReadLine()
            Xco = userinput.Split(",")(0)
            Yco = userinput.Split(",")(1)
            If Positions1(Xco, Yco) = "~" Then
                If ships = 0 Then
                    Positions1(Xco, Yco) = "S"
                    ships += 1
                Else
                    If checklawgamboS1() Then
                        Positions1(Xco, Yco) = "S"
                        ships += 1
                    Else
                        'tannesh
                    End If
                End If
            Else
                Console.WriteLine("                              You cannot overlap ships.")
            End If
            BoardDisplay()
        Loop Until ships = 3
        ships = 0
        Console.WriteLine("                              where would you like to place Cruiser (4 cells)")
        BoardDisplay()
        Do
            Console.WriteLine("                              enter x and y coordinate e.g '3, 4'")
            userinput = Console.ReadLine()
            Xco = userinput.Split(",")(0)
            Yco = userinput.Split(",")(1)
            If Positions1(Xco, Yco) = "~" Then
                If ships = 0 Then
                    Positions1(Xco, Yco) = "C"
                    ships += 1
                Else
                    If checklawgamboC1() Then
                        Positions1(Xco, Yco) = "C"
                        ships += 1
                    Else
                        'tannesh
                    End If
                End If
            Else
                Console.WriteLine("                              You cannot overlap ships.")
            End If
            BoardDisplay()
        Loop Until ships = 4
        Console.WriteLine("                              Are you happy with this result (i dont care)")
        Console.ReadLine()
        Console.Clear()
        ships = 0
        player = 2
        Console.WriteLine("                              where would you like to place Destroyer (2 cells)")
        BoardDisplay()
        Do
            Console.WriteLine("                              enter x and y coordinate e.g '3, 4'")
            userinput = Console.ReadLine()
            Xco = userinput.Split(",")(0)
            Yco = userinput.Split(",")(1)
            If Positions2(Xco, Yco) = "~" Then
                If ships = 0 Then
                    Positions2(Xco, Yco) = "D"
                    ships += 1
                Else
                    If checklawgamboD2() Then
                        Positions2(Xco, Yco) = "D"
                        ships += 1
                    Else
                        'tannesh
                    End If
                End If
            Else
                Console.WriteLine("                              You cannot overlap ships.")
            End If
            BoardDisplay()
        Loop Until ships = 2
        ships = 0
        Console.WriteLine("                              where would you like to place Submarine (3 cells)")
        BoardDisplay()
        Do
            Console.WriteLine("                              enter x and y coordinate e.g '3, 4'")
            userinput = Console.ReadLine()
            Xco = userinput.Split(",")(0)
            Yco = userinput.Split(",")(1)
            If Positions2(Xco, Yco) = "~" Then
                If ships = 0 Then
                    Positions2(Xco, Yco) = "S"
                    ships += 1
                Else
                    If checklawgamboS2() Then
                        Positions2(Xco, Yco) = "S"
                        ships += 1
                    Else
                        'tannesh
                    End If
                End If
            Else
                Console.WriteLine("                              You cannot overlap ships.")
            End If
            BoardDisplay()
        Loop Until ships = 3
        ships = 0
        Console.WriteLine("                              where would you like to place Cruiser (4 cells)")
        BoardDisplay()
        Do
            Console.WriteLine("                              enter x and y coordinate e.g '3, 4'")
            userinput = Console.ReadLine()
            While Not ValidateInput(userinput)
                Console.WriteLine("                              enter VALID x and y coordinate e.g '3, 4'")
                userinput = Console.ReadLine()
            End While
            Xco = userinput.Split(",")(0)
                Yco = userinput.Split(",")(1)
                If Positions2(Xco, Yco) = "~" Then
                    If ships = 0 Then
                        Positions2(Xco, Yco) = "C"
                        ships += 1
                    Else
                        If checklawgamboC2() Then
                            Positions2(Xco, Yco) = "C"
                            ships += 1
                        Else
                            'tannesh
                        End If
                    End If
                Else
                    Console.WriteLine("                              You cannot overlap ships.")
                End If
                BoardDisplay()
        Loop Until ships = 4
        Console.WriteLine("                              Are you happy with this result (i dont care)")
        Console.ReadLine()
        Console.Clear()
        player = 3
    End Sub
    Function checklawgamboD1()
        If Positions1(Xco - 1, Yco) = "D" Or Positions1(Xco + 1, Yco) = "D" Or Positions1(Xco, Yco - 1) = "D" Or Positions1(Xco, Yco + 1) = "D" Then
            Return True
        Else
            Console.WriteLine("                              Please place in a plot near original position")
            Return False
        End If
    End Function
    Function checklawgamboS1()
        If Positions1(Xco - 1, Yco) = "S" Or Positions1(Xco + 1, Yco) = "S" Or Positions1(Xco, Yco - 1) = "S" Or Positions1(Xco, Yco + 1) = "S" Then
            Return True
        Else
            Console.WriteLine("                              Please place in a plot near original position")
            Return False
        End If
    End Function
    Function checklawgamboC1()
        If Positions1(Xco - 1, Yco) = "C" Or Positions1(Xco + 1, Yco) = "C" Or Positions1(Xco, Yco - 1) = "C" Or Positions1(Xco, Yco + 1) = "C" Then
            Return True
        Else
            Console.WriteLine("                              Please place in a plot near original position")
            Return False
        End If
    End Function
    Function checklawgamboD2()
        If Positions2(Xco - 1, Yco) = "D" Or Positions2(Xco + 1, Yco) = "D" Or Positions2(Xco, Yco - 1) = "D" Or Positions2(Xco, Yco + 1) = "D" Then
            Return True
        Else
            Console.WriteLine("                              Please place in a plot near original position")
            Return False
        End If
    End Function
    Function checklawgamboS2()
        If Positions2(Xco - 1, Yco) = "S" Or Positions2(Xco + 1, Yco) = "S" Or Positions2(Xco, Yco - 1) = "S" Or Positions2(Xco, Yco + 1) = "S" Then
            Return True
        Else
            Console.WriteLine("                              Please place in a plot near original position")
            Return False
        End If
    End Function
    Function checklawgamboC2()
        If Positions2(Xco - 1, Yco) = "C" Or Positions2(Xco + 1, Yco) = "C" Or Positions2(Xco, Yco - 1) = "C" Or Positions2(Xco, Yco + 1) = "C" Then
            Return True
        Else
            Console.WriteLine("                              Please place in a plot near original position")
            Return False
        End If
    End Function
    Function ValidateInput(str As String)
        Dim retVal As Boolean = False
        Dim myInt As Integer
        If str.IndexOf(",") > 0 Then
            If str.Split(",").Length = 2 Then
                Try
                    If Integer.TryParse(str.Split(",")(0).Trim(), myInt) And Integer.TryParse(str.Split(",")(1).Trim(), myInt) Then
                        retVal = True
                    Else
                        retVal = False
                    End If
                Catch ex As Exception
                    retVal = False
                End Try
            Else
                retVal = False
            End If
        Else
            retVal = False
        End If
        Return retVal
    End Function



End Module