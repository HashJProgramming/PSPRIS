Imports System.Data.SQLite
Public Class Add_Resident
    Private Sub BunifuButton1_Click(sender As Object, e As EventArgs) Handles BunifuButton1.Click
        Try

            com = New SQLiteCommand
            With com
                .Connection = con
                .CommandText = "INSERT INTO `Resident_Info` (`Firstname`, `Lastname`, `Middlename`, `Gender`, `Age`, `Birthdate`, `Address`, `Contact`, `Email`) VALUES (@1, @2, @3, @4, @5,@6, @7, @8, @9)"

                .Parameters.AddWithValue("@1", BunifuTextBox1.Text)
                .Parameters.AddWithValue("@2", BunifuTextBox2.Text)
                .Parameters.AddWithValue("@3", BunifuTextBox3.Text)
                .Parameters.AddWithValue("@4", BunifuTextBox4.Text)
                .Parameters.AddWithValue("@5", BunifuTextBox5.Text)
                .Parameters.AddWithValue("@6", BunifuTextBox6.Text)
                .Parameters.AddWithValue("@7", BunifuTextBox7.Text)
                .Parameters.AddWithValue("@8", BunifuTextBox8.Text)
                .Parameters.AddWithValue("@9", BunifuTextBox9.Text)

                .ExecuteNonQuery()
                MessageBox.Show("Success!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information)

                BunifuTextBox1.Clear()
                BunifuTextBox2.Clear()
                BunifuTextBox3.Clear()
                BunifuTextBox4.Clear()
                BunifuTextBox5.Clear()
                BunifuTextBox6.Clear()
                BunifuTextBox7.Clear()
                BunifuTextBox8.Clear()
                BunifuTextBox9.Clear()
                Close()
            End With
        Catch ex As Exception
            MessageBox.Show("Error!" & ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub

    Private Sub BunifuButton2_Click(sender As Object, e As EventArgs) Handles BunifuButton2.Click
        Try
            BunifuTextBox1.Clear()
            BunifuTextBox2.Clear()
            BunifuTextBox3.Clear()
            BunifuTextBox4.Clear()
            BunifuTextBox5.Clear()
            BunifuTextBox6.Clear()
            BunifuTextBox7.Clear()
            BunifuTextBox8.Clear()
            BunifuTextBox9.Clear()
        Catch ex As Exception

        End Try
    End Sub
End Class