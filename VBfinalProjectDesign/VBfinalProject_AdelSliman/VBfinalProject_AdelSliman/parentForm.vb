Public Class parentForm
    Private Sub btnQuit_Click(sender As Object, e As EventArgs) Handles btnQuit.Click
        Application.Exit()
    End Sub

    Private Sub btnStart_Click(sender As Object, e As EventArgs) Handles btnStart.Click
        Me.Hide()
        Dim frm = New Game
        frm.Show()
        frm.Resetgame()
    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        MessageBox.Show("This is a fan made game inspired by Classics such as Space Invaders and the Kingdom Hearts series", "About")
    End Sub

    Private Sub CloseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CloseToolStripMenuItem.Click
        Application.Exit()
    End Sub

    Private Sub ControlsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ControlsToolStripMenuItem.Click
        MessageBox.Show("Move the Player Left and Right with the A and D keys respectively.
Fire with the space bar and dodge the enemy projectiles, There are no lives. One hit and its game over!", "Controls")
    End Sub

    Private Sub HighScoresToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HighScoresToolStripMenuItem.Click
        Dim frm = New Game
        Me.Hide()
        frm.Show()

        frm.ScoreChart.Show()
    End Sub
End Class
