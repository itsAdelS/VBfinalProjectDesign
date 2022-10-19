Public Class Game
    Private Sub ControlsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ControlsToolStripMenuItem.Click
        MessageBox.Show("Move the Player Left and Right with the A and D keys respectively.
                        Fire with the space bar and dodge the enemy projectiles, There are no lives. One hit and its game over!", "Controls")
    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        MessageBox.Show("This is a fan made game inspired by Classics such as Space Invaders and the Kingdom Hearts series", "About")
    End Sub

    Private Sub CloseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CloseToolStripMenuItem.Click
        Application.Exit()
    End Sub
    Private Sub RestartToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RestartToolStripMenuItem.Click
        Dim frm = New parentForm
        frm.Show()
        Me.Hide()
    End Sub
#Region "Variables"

    Dim lef As Boolean
    Dim rig As Boolean

    Dim moveAlien As Integer = 2
    Dim whichalien As Integer


    Dim aliens(11) As PictureBox
    Dim locations(11) As System.Drawing.Point
    Dim AIshot(11) As Boolean
    Dim AIshot2(11) As PictureBox

    Dim fire As Boolean
    Dim fire1 As Boolean
    Dim fire2 As Boolean
    Dim fire3 As Boolean
    Dim fire4 As Boolean
    Dim fire5 As Boolean

    Dim complete As Integer
    Dim level As Integer
    Dim score As Integer
    Dim Rand As Integer

    Dim score1 As Integer = 60
    Dim score2 As Integer = 50
    Dim score3 As Integer = 40
    Dim score4 As Integer = 30
    Dim score5 As Integer = 20

    Dim name1 As String = "CPU"
    Dim name2 As String = "CPU"
    Dim name3 As String = "CPU"
    Dim name4 As String = "CPU"
    Dim name5 As String = "CPU"

#End Region

#Region "Timers"

    Private Sub Moveplayer_Tick(sender As Object, e As EventArgs) Handles moveplayer.Tick, MyBase.Load
        moveplayer.Enabled = True
        moveplayer.Start()
        Movealiens()

        If lef = True Then
            SpaceShip.Left = SpaceShip.Left - 3
            If fire1 = False Then
                Shot1.Left = SpaceShip.Left - 3
            End If
            If fire2 = False Then
                shot2.Left = SpaceShip.Left - 3
            End If
            If fire3 = False Then
                Shot3.Left = SpaceShip.Left - 3
            End If
            If fire4 = False Then
                Shot4.Left = SpaceShip.Left - 3
            End If
            If fire5 = False Then
                Shot5.Left = SpaceShip.Left - 3
            End If
            If SpaceShip.Left < 0 Then
                SpaceShip.Left = SpaceShip.Left + 3
                restartshot.Left = restartshot.Left + 3
                If fire1 = False Then
                    Shot1.Left = SpaceShip.Left + 3
                End If
                If fire2 = False Then
                    shot2.Left = SpaceShip.Left + 3
                End If
                If fire3 = False Then
                    Shot3.Left = SpaceShip.Left + 3
                End If
                If fire4 = False Then
                    Shot4.Left = SpaceShip.Left + 3
                End If
                If fire5 = False Then
                    Shot5.Left = SpaceShip.Left + 3
                End If
            End If
        End If

        If rig = True Then
            SpaceShip.Left = SpaceShip.Left + 3
            If fire1 = False Then
                Shot1.Left = SpaceShip.Left + 3
            End If
            If fire2 = False Then
                shot2.Left = SpaceShip.Left + 3
            End If
            If fire3 = False Then
                Shot3.Left = SpaceShip.Left + 3
            End If
            If fire4 = False Then
                Shot4.Left = SpaceShip.Left + 3
            End If
            If fire5 = False Then
                Shot5.Left = SpaceShip.Left + 3
            End If
            If SpaceShip.Left > Me.Width - SpaceShip.Width Then
                SpaceShip.Left = SpaceShip.Left - 3
                restartshot.Left = restartshot.Left - 3
                If fire1 = False Then
                    Shot1.Left = Shot1.Left - 3
                End If
                If fire2 = False Then
                    shot2.Left = shot2.Left - 3
                End If
                If fire3 = False Then
                    Shot3.Left = Shot3.Left - 3
                End If
                If fire4 = False Then
                    Shot4.Left = Shot4.Left - 3
                End If
                If fire5 = False Then
                    Shot5.Left = Shot5.Left - 3
                End If
            End If
        End If

        If fire = True Then
            Checkshot()
        End If
        Moveshot()
        Movealienshots()



    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        Timer1.Stop()
        ScoreChart.Show()
        Dim outputScores As String
        outputScores = lblname1.Text & "|" & lblScore1.Text & "|" & lblname2.Text & "|" & lblScore2.Text & "|" & lblname3.Text & "|" & lblScore3.Text & "|" & lblname4.Text & "|" & lblScore4.Text & "|" & lblname5.Text & "|" & lblScore5.Text & "|" & TextBox1.Text & "|" & lblScore.Text
        My.Computer.FileSystem.WriteAllText("Scores.txt", outputScores, False)
    End Sub

#End Region

#Region "KeyPresses"
    Private Sub MovecompLeft(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.A Then
            lef = True
        End If
        If e.KeyValue = Keys.D Then
            rig = True
        End If
        If e.KeyValue = Keys.Space Then
            fire = True
        End If
    End Sub

    Private Sub MovecompStop(sender As Object, e As KeyEventArgs) Handles MyBase.KeyUp
        If e.KeyValue = Keys.A Then
            lef = False
        End If
        If e.KeyValue = Keys.D Then
            rig = False
        End If
        If e.KeyValue = Keys.Space Then
            fire = False
        End If
    End Sub

#End Region

#Region "My Subs"

    Public Sub New()

        InitializeComponent()
        CreateArray()
        Alienshotarray()
        Createscoreboard()
    End Sub

    Public Sub Resetgame()
        SpaceShip.Image = My.Resources.highwind
        score = 0
        level = 1
        complete = 0

        fire = False
        fire1 = False
        fire2 = False
        fire3 = False
        fire4 = False
        fire5 = False

        Shot1.Location = restartshot.Location
        shot2.Location = restartshot.Location
        Shot3.Location = restartshot.Location
        Shot4.Location = restartshot.Location
        Shot5.Location = restartshot.Location

        lblScore.Text = "SCORE: " & score
        lblLevel.Text = "LEVEL: " & score

        For i = 0 To 11
            aliens(i).Location = locations(i)
            aliens(i).Show()
            AIshot(i) = False
            AIshot2(i).Hide()
            AIshot2(i).Location = aliens(i).Location
            AIshot2(i).Top = AIshot2(i).Top + 105
            AIshot2(i).Left = AIshot2(i).Left + 52

        Next
        lblLose.Hide()
    End Sub
    Private Sub Createscoreboard()
        lblname1.Text = name1
        lblname2.Text = name2
        lblname3.Text = name3
        lblname4.Text = name4
        lblname5.Text = name5

        lblScore1.Text = score1
        lblScore2.Text = score2
        lblScore3.Text = score3
        lblScore4.Text = score4
        lblScore5.Text = score5

    End Sub
    Private Sub CreateArray()
        aliens(0) = alien1
        aliens(1) = alien2
        aliens(2) = alien3
        aliens(3) = alien4
        aliens(4) = alien5
        aliens(5) = alien6
        aliens(6) = alien7
        aliens(7) = alien8
        aliens(8) = alien9
        aliens(9) = alien10
        aliens(10) = alien11
        aliens(11) = alien12
        For i = 0 To 11
            locations(i) = aliens(i).Location
        Next
    End Sub

    Private Sub Alienshotarray()
        AIshot2(0) = alienshot1
        AIshot2(1) = alienshot2
        AIshot2(2) = alienshot3
        AIshot2(3) = alienshot4
        AIshot2(4) = alienshot5
        AIshot2(5) = alienshot6
        AIshot2(6) = alienshot7
        AIshot2(7) = alienshot8
        AIshot2(8) = alienshot9
        AIshot2(9) = alienshot10
        AIshot2(10) = alienshot11
        AIshot2(11) = alienshot12

    End Sub

    Private Sub Movealiens()
        For i = 0 To 11
            aliens(i).Left = aliens(i).Left + moveAlien
            If AIshot(i) = False Then
                AIshot2(i).Left = AIshot2(i).Left + moveAlien
            End If
            If aliens(i).Bounds.IntersectsWith(SpaceShip.Bounds) Then
                PlayerDead()
            End If
        Next
        If alien6.Left > Me.Width - alien6.Width Then
            moveAlien = moveAlien * -1
            For i = 0 To 11
                aliens(i).Top = aliens(i).Top + 25
                If AIshot(i) = False Then
                    AIshot2(i).Top = AIshot2(i).Top + 25
                End If

            Next
        End If
        If alien1.Left < 0 Then
            moveAlien = moveAlien * -1
            For i = 0 To 11
                aliens(i).Top = aliens(i).Top + 25
                If AIshot(i) = False Then
                    AIshot2(i).Top = AIshot2(i).Top + 25
                End If

            Next
        End If
    End Sub

    Private Sub Checkshot()
        fire = False
        If fire1 = False Then
            fire1 = True
            Shot1.Show()
            Exit Sub
        End If
        If fire2 = False Then
            fire2 = True
            shot2.Show()
            Exit Sub
        End If
        If fire3 = False Then
            fire3 = True
            Shot3.Show()
            Exit Sub
        End If
        If fire4 = False Then
            fire4 = True
            Shot4.Show()
            Exit Sub
        End If
        If fire5 = False Then
            fire5 = True
            Shot5.Show()
            Exit Sub
        End If
    End Sub

    Private Sub Moveshot()
        If fire1 = True Then
            Shot1.Top = Shot1.Top - 3
            For i = 0 To 11
                If Shot1.Bounds.IntersectsWith(aliens(i).Bounds) Then
                    whichalien = i
                    Shot1hit()
                End If
            Next
            If Shot1.Top < 0 Then
                Shot1.Hide()
                fire1 = False
                Shot1.Location = restartshot.Location
            End If
        End If
        If fire2 = True Then
            shot2.Top = shot2.Top - 3
            For i = 0 To 11
                If shot2.Bounds.IntersectsWith(aliens(i).Bounds) Then
                    whichalien = i
                    Shot2hit()
                End If
            Next
            If shot2.Top < 0 Then
                shot2.Hide()
                fire2 = False
                shot2.Location = restartshot.Location
            End If
        End If
        If fire3 = True Then
            Shot3.Top = Shot3.Top - 3
            For i = 0 To 11
                If Shot3.Bounds.IntersectsWith(aliens(i).Bounds) Then
                    whichalien = i
                    Shot3hit()
                End If
            Next
            If Shot3.Top < 0 Then
                Shot3.Hide()
                fire3 = False
                Shot3.Location = restartshot.Location
            End If
        End If
        If fire4 = True Then
            Shot4.Top = Shot4.Top - 3
            For i = 0 To 11
                If Shot4.Bounds.IntersectsWith(aliens(i).Bounds) Then
                    whichalien = i
                    Shot4hit()
                End If
            Next
            If Shot4.Top < 0 Then
                Shot4.Hide()
                fire4 = False
                Shot4.Location = restartshot.Location
            End If
        End If
        If fire5 = True Then
            Shot5.Top = Shot5.Top - 3
            For i = 0 To 11
                If Shot5.Bounds.IntersectsWith(aliens(i).Bounds) Then
                    whichalien = i
                    Shot5hit()
                End If
            Next
            If Shot5.Top < 0 Then
                Shot5.Hide()
                fire5 = False
                Shot5.Location = restartshot.Location
            End If
        End If
    End Sub


    Private Sub Shot1hit()
        fire1 = False
        Shot1.Hide()
        Shot1.Location = restartshot.Location
        aliens(whichalien).Top = aliens(whichalien).Top + 10000
        complete = complete + 1
        If complete = 12 Then
            LevelComplete()
        End If
        score = score + 1
        lblScore.Text = "SCORE: " & score
    End Sub
    Private Sub Shot2hit()
        fire2 = False
        shot2.Hide()
        shot2.Location = restartshot.Location
        aliens(whichalien).Top = aliens(whichalien).Top + 10000
        complete = complete + 1
        If complete = 12 Then
            LevelComplete()
        End If
        score = score + 1
        lblScore.Text = "SCORE: " & score
    End Sub
    Private Sub Shot3hit()
        fire3 = False
        Shot3.Hide()
        Shot3.Location = restartshot.Location
        aliens(whichalien).Top = aliens(whichalien).Top + 10000
        complete = complete + 1
        If complete = 12 Then
            LevelComplete()
        End If
        score = score + 1
        lblScore.Text = "SCORE: " & score
    End Sub
    Private Sub Shot4hit()
        fire4 = False
        Shot4.Hide()
        Shot4.Location = restartshot.Location
        aliens(whichalien).Top = aliens(whichalien).Top + 10000
        complete = complete + 1
        If complete = 12 Then
            LevelComplete()
        End If
        score = score + 1
        lblScore.Text = "SCORE: " & score
    End Sub
    Private Sub Shot5hit()
        fire5 = False
        Shot5.Hide()
        Shot5.Location = restartshot.Location
        aliens(whichalien).Top = aliens(whichalien).Top + 10000
        complete = complete + 1
        If complete = 12 Then
            LevelComplete()
        End If
        score = score + 1
        lblScore.Text = "SCORE: " & score
    End Sub

    Private Sub PlayerDead()
        moveplayer.Stop()
        SpaceShip.Image = My.Resources.dead
        lblLose.Show()
        Timer1.Enabled = True
        Timer1.Start()

    End Sub

    Private Sub LevelComplete()
        complete = 0
        level = level + 1
        lblLevel.Text = "LEVEL: " & level
        For i = 0 To 11
            aliens(i).Location = locations(i)
        Next
    End Sub
    Private Sub Movealienshots()
        For i = 0 To 11
            If AIshot(i) = False Then
                Rand = CInt(Int((1000 * Rnd()) + 1))
                If Rand = 1000 Then
                    AIshot(i) = True
                    AIshot2(i).Show()
                    If aliens(i).Top > 1000 Then
                        AIshot(i) = False
                        AIshot2(i).Hide()
                    End If
                End If
            End If
        Next
        For i = 0 To 11
            If AIshot(i) = True Then
                AIshot2(i).Top = AIshot2(i).Top + 3
                If AIshot2(i).Bounds.IntersectsWith(SpaceShip.Bounds) Then
                    PlayerDead()
                End If
                If AIshot2(i).Top > Me.Height Then
                    AIshot(i) = False
                    AIshot2(i).Hide()
                    AIshot2(i).Location = aliens(i).Location
                    AIshot2(i).Top = AIshot2(i).Top + 105
                    AIshot2(i).Left = AIshot2(i).Top + 52
                End If
            End If
        Next
    End Sub

    Private Sub Scoreboard()


        If score > score1 Then

            score5 = score4
            score4 = score3
            score3 = score2
            score2 = score1
            score1 = score
            name5 = name4
            name4 = name3
            name3 = name2
            name2 = name1
            name1 = TextBox1.Text

            lblScore1.Text = score1
            lblScore2.Text = score2
            lblScore3.Text = score3
            lblScore4.Text = score4
            lblScore5.Text = score5

            lblname1.Text = name1
            lblname2.Text = name2
            lblname3.Text = name3
            lblname4.Text = name4
            lblname5.Text = name5


            Exit Sub
        End If
        If score > score2 Then
            score5 = score4
            score4 = score3
            score3 = score2
            score2 = score
            name5 = name4
            name4 = name3
            name3 = name2
            name2 = TextBox1.Text

            lblScore2.Text = score2
            lblScore3.Text = score3
            lblScore4.Text = score4
            lblScore5.Text = score5

            lblname2.Text = name2
            lblname3.Text = name3
            lblname4.Text = name4
            lblname5.Text = name5
            Exit Sub
        End If
        If score > score3 Then
            score5 = score4
            score4 = score3
            score3 = score

            name5 = name4
            name4 = name3
            name3 = TextBox1.Text

            lblScore3.Text = score3
            lblScore4.Text = score4
            lblScore5.Text = score5

            lblname3.Text = name3
            lblname4.Text = name4
            lblname5.Text = name5
            Exit Sub
        End If
        If score > score4 Then
            score5 = score4
            score4 = score

            name5 = name4
            name4 = TextBox1.Text

            lblScore4.Text = score4
            lblScore5.Text = score5


            lblname4.Text = name4
            lblname5.Text = name5
            Exit Sub
        End If
        If score > score5 Then
            score5 = score

            name5 = TextBox1.Text

            lblScore5.Text = score5

            lblname5.Text = name5

            Exit Sub
        End If

    End Sub



    Private Sub Game_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Application.Exit()
    End Sub


#End Region

#Region "Textboxes"

    Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox1.KeyDown
        If e.KeyValue = Keys.Enter Then
            Scoreboard()
        End If

        Dim FILE_NAME As String = "Scores.txt"

        If IO.File.Exists(FILE_NAME) = True Then

            FILE_NAME = My.Computer.FileSystem.ReadAllText("Scores.txt")
            Dim strArr() As String

            strArr = FILE_NAME.Split("|")

            lblname1.Text = strArr(0)
            lblname2.Text = strArr(2)
            lblname3.Text = strArr(4)
            lblname4.Text = strArr(6)
            lblname5.Text = strArr(8)

            lblScore1.Text = strArr(1)
            lblScore2.Text = strArr(3)
            lblScore3.Text = strArr(5)
            lblScore4.Text = strArr(7)
            lblScore5.Text = strArr(9)

            TextBox1.Text = strArr(10)
            lblScore.Text = strArr(11)


        Else
            MessageBox.Show("File Does Not Exist")
        End If


    End Sub

#End Region

#Region "Buttons"
    Private Sub btnMenu_Click(sender As Object, e As EventArgs) Handles btnMenu.Click
        Dim frm = New parentForm
        frm.Show()
        Me.Hide()
    End Sub





#End Region


End Class