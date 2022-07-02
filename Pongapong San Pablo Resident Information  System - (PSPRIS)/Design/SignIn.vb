Imports System.Data.SQLite
Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Database.Connection()
    End Sub

    Private Sub BunifuButton1_Click(sender As Object, e As EventArgs) Handles BunifuButton1.Click
        com = New SQLiteCommand
        With com
            .Connection = con
            .CommandText = "SELECT * FROM `Users` WHERE `Username` = '" & BunifuTextBox1.Text & "' AND `Password` = '" & BunifuTextBox2.Text & "'"
            dr = .ExecuteReader
            If dr.Read Then
                Me.Hide()
                Dashboard.ShowDialog()
                BunifuTextBox1.Clear()
                BunifuTextBox2.Clear()
            Else
                MessageBox.Show("Wrong Username or Password please try again.")
                Return
            End If

        End With
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        Try
            If CheckBox1.Checked = True Then
                BunifuTextBox2.PasswordChar = ""
            Else
                BunifuTextBox2.PasswordChar = "•"
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BunifuButton2_Click(sender As Object, e As EventArgs) Handles BunifuButton2.Click
        Try
            Application.Exit()
        Catch ex As Exception

        End Try
    End Sub
End Class
