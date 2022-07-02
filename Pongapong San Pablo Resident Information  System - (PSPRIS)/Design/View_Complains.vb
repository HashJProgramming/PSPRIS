Imports System.Data.SQLite
Public Class View_Complains
    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView1.SelectedIndexChanged
        Try
            Label1.Text = "Selected : " & ListView1.FocusedItem.Text
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BunifuButton1_Click(sender As Object, e As EventArgs) Handles BunifuButton1.Click
        Try

            Dim ask As MsgBoxResult = MsgBox("Are you sure '" & ListView1.FocusedItem.SubItems(1).Text & "' case is Resolve?", MsgBoxStyle.YesNo)
            If ask = MsgBoxResult.Yes Then
                com = New SQLiteCommand
                With com
                    .Connection = con
                    .CommandText = "UPDATE `Complains`  SET `Status` = @1 WHERE ID = " & ListView1.FocusedItem.Text
                    .Parameters.AddWithValue("@1", "RESOLVE")
                    .ExecuteNonQuery()
                End With

                MessageBox.Show("Success!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception

            MessageBox.Show("Error!" & ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub

    Private Sub BunifuButton2_Click(sender As Object, e As EventArgs) Handles BunifuButton2.Click
        ActiveCase()
    End Sub

    Private Sub BunifuTextBox1_TextChanged(sender As Object, e As EventArgs) Handles BunifuTextBox1.TextChanged
        Try
            Me.ListView1.Items.Clear()
            com = New SQLiteCommand
            With com
                .Connection = con
                .CommandText = "SELECT * FROM `Complains` WHERE `Firstname` LIKE '%" & BunifuTextBox1.Text & "%' OR `Lastname` LIKE '%" & BunifuTextBox1.Text & "%' OR `Middlename` LIKE '%" & BunifuTextBox1.Text & "%'"
                dr = com.ExecuteReader()
                While dr.Read
                    list = Me.ListView1.Items.Add(dr("ID").ToString)
                    list.SubItems.Add(dr("Firstname").ToString)
                    list.SubItems.Add(dr("Lastname").ToString)
                    list.SubItems.Add(dr("Middlename").ToString)
                    list.SubItems.Add(dr("Complain").ToString)
                    list.SubItems.Add(dr("Complain_Datetime").ToString)
                    list.SubItems.Add(dr("Status").ToString)
                End While
                dr.Close()
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class