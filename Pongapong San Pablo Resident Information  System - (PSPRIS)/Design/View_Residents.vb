Imports System.Data.SQLite
Public Class View_Residents
    Private Sub BunifuButton3_Click(sender As Object, e As EventArgs) Handles BunifuButton3.Click
        ViewResidents()
    End Sub

    Private Sub BunifuButton2_Click(sender As Object, e As EventArgs) Handles BunifuButton2.Click
        Try

            Dim ask As MsgBoxResult = MsgBox("Are you sure you want to delete '" & ListView1.FocusedItem.SubItems(1).Text & "?", MsgBoxStyle.YesNo)
            If ask = MsgBoxResult.Yes Then
                com = New SQLiteCommand
                With com
                    .Connection = con
                    .CommandText = "DELETE FROM `Resident_Info` WHERE ID = '" & ListView1.FocusedItem.Text & "'"
                    Stats.Label1.Text = .ExecuteNonQuery()
                End With
                MessageBox.Show("Success!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub BunifuButton1_Click(sender As Object, e As EventArgs) Handles BunifuButton1.Click
        Try
            Database.Selected = ListView1.FocusedItem.Text
            Update_Resident.BunifuTextBox1.Text = ListView1.FocusedItem.SubItems(1).Text
            Update_Resident.BunifuTextBox2.Text = ListView1.FocusedItem.SubItems(2).Text
            Update_Resident.BunifuTextBox3.Text = ListView1.FocusedItem.SubItems(3).Text
            Update_Resident.BunifuTextBox4.Text = ListView1.FocusedItem.SubItems(4).Text
            Update_Resident.BunifuTextBox5.Text = ListView1.FocusedItem.SubItems(5).Text
            Update_Resident.BunifuTextBox6.Text = ListView1.FocusedItem.SubItems(6).Text
            Update_Resident.BunifuTextBox7.Text = ListView1.FocusedItem.SubItems(7).Text
            Update_Resident.BunifuTextBox8.Text = ListView1.FocusedItem.SubItems(8).Text
            Update_Resident.BunifuTextBox9.Text = ListView1.FocusedItem.SubItems(9).Text
            Update_Resident.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub View_Residents_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ViewResidents()
    End Sub

    Private Sub BunifuTextBox1_TextChanged(sender As Object, e As EventArgs) Handles BunifuTextBox1.TextChanged
        Try
            Me.ListView1.Items.Clear()

            com = New SQLiteCommand
            With com
                .Connection = con
                .CommandText = "SELECT * FROM `Resident_Info` WHERE `Firstname` LIKE '%" & BunifuTextBox1.Text & "%' OR `Lastname` LIKE '%" & BunifuTextBox1.Text & "%' OR `Middlename` LIKE '%" & BunifuTextBox1.Text & "%'"
                dr = com.ExecuteReader()
                While dr.Read
                    list = Me.ListView1.Items.Add(dr("ID").ToString)
                    list.SubItems.Add(dr("Firstname").ToString)
                    list.SubItems.Add(dr("Lastname").ToString)
                    list.SubItems.Add(dr("Middlename").ToString)
                    list.SubItems.Add(dr("Gender").ToString)
                    list.SubItems.Add(dr("Age").ToString)
                    list.SubItems.Add(dr("Birthdate").ToString)
                    list.SubItems.Add(dr("Address").ToString)
                    list.SubItems.Add(dr("Contact").ToString)
                    list.SubItems.Add(dr("Email").ToString)
                End While
                dr.Close()

            End With

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView1.SelectedIndexChanged
        Try
            Label1.Text = "Selected : " & ListView1.FocusedItem.Text
        Catch ex As Exception

        End Try
    End Sub
End Class