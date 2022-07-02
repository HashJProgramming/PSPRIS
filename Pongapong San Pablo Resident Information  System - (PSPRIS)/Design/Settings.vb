Imports System.Data.SQLite
Public Class Settings
    Private Sub BunifuButton1_Click(sender As Object, e As EventArgs) Handles BunifuButton1.Click
        Try

            If BunifuTextBox2.Text = BunifuTextBox1.Text Then
                com = New SQLiteCommand
                With com
                    .Connection = con
                    .CommandText = "UPDATE `Users`  SET `Password` = @2 WHERE ID = '1'"
                    .Parameters.AddWithValue("@2", BunifuTextBox2.Text)


                    .ExecuteNonQuery()
                    MessageBox.Show("Success!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    BunifuTextBox1.Clear()
                    BunifuTextBox2.Clear()
                    Close()
                End With
            Else
                MessageBox.Show("Password not match!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As Exception
            MessageBox.Show("Error!" & ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub
End Class