Imports System.Data.SQLite
Public Class Add_Complain
    Private Sub BunifuButton1_Click(sender As Object, e As EventArgs) Handles BunifuButton1.Click
        Try

            com = New SQLiteCommand
            With com
                .Connection = con
                .CommandText = "INSERT INTO `Complains` (`Firstname`, `Lastname`, `Middlename`, `Complainant_fullname`, `Complain`, `Complain_Datetime`, `Status`) VALUES (@1, @2, @3, @4, @5,@6, @7)"

                .Parameters.AddWithValue("@1", BunifuTextBox1.Text)
                .Parameters.AddWithValue("@2", BunifuTextBox2.Text)
                .Parameters.AddWithValue("@3", BunifuTextBox3.Text)
                .Parameters.AddWithValue("@4", BunifuTextBox4.Text)
                .Parameters.AddWithValue("@5", RichTextBox1.Text)
                .Parameters.AddWithValue("@6", DateTime.Now)
                .Parameters.AddWithValue("@7", "ACTIVE")


                .ExecuteNonQuery()
            End With

            MessageBox.Show("Success!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
            BunifuTextBox1.Clear()
            BunifuTextBox2.Clear()
            BunifuTextBox3.Clear()
            BunifuTextBox4.Clear()
            BunifuTextBox5.Clear()
            Close()
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
            RichTextBox1.Clear()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BunifuTextBox5_TextChanged(sender As Object, e As EventArgs) Handles BunifuTextBox5.TextChanged
        Try
            com = New SQLiteCommand
            With com
                .Connection = con
                .CommandText = "SELECT * FROM `Resident_info` WHERE `ID` LIKE '" & BunifuTextBox5.Text & "'"
                dr = com.ExecuteReader()
                While dr.Read
                    BunifuTextBox1.Text = dr("Firstname").ToString
                    BunifuTextBox2.Text = dr("Lastname").ToString
                    BunifuTextBox3.Text = dr("Middlename").ToString
                End While
                dr.Close()
            End With
        Catch ex As Exception
            MessageBox.Show("Error!" & ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class