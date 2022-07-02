Imports System.Data.SQLite
Module Database
    Public con As SQLiteConnection
    Public com As SQLiteCommand
    Public dr As SQLiteDataReader
    Public DatabaseSQL As String = "DATA SOURCE =" & Application.StartupPath & "\Database.db; VERSION=3"
    Public adapter As New SQLiteDataAdapter
    Public datatale As New DataTable
    Public list As ListViewItem
    Public Selected = ""

    Sub Connection()
        Try

            con = New SQLiteConnection(DatabaseSQL)
            con.Open()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Sub showform(ByVal panel As Form)
        Dashboard.Panel2.Controls.Clear()
        panel.TopLevel = False
        Dashboard.Panel2.Controls.Add(panel)
        panel.Show()
        If Dashboard.Panel2.Visible = False Then
            Dashboard.Panel2.Visible = True
        End If

    End Sub


    Sub Dashboard_Stats()
        Try
            If con.State = ConnectionState.Closed Then
                Database.Connection()
            End If

            com = New SQLiteCommand
            With com
                .Connection = con
                .CommandText = "SELECT COUNT(`ID`) FROM `Resident_Info` WHERE `Gender` LIKE 'MALE'"
                Stats.Label1.Text = .ExecuteScalar().ToString()
            End With

            com = New SQLiteCommand
            With com
                .Connection = con
                .CommandText = "SELECT COUNT(`ID`) FROM `Resident_Info` WHERE `Gender` LIKE 'FEMALE'"
                Stats.Label2.Text = .ExecuteScalar().ToString()
            End With

            com = New SQLiteCommand
            With com
                .Connection = con
                .CommandText = "SELECT COUNT(`ID`) FROM `Resident_Info`"
                Stats.Label3.Text = .ExecuteScalar().ToString()
            End With

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub


    Sub ActiveCase()
        Try
            If con.State = ConnectionState.Closed Then
                Database.Connection()
            End If

            Stats.ListView1.Items.Clear()

            com = New SQLiteCommand
            With com
                .Connection = con
                .CommandText = "SELECT * FROM `Complains` WHERE `Status` LIKE '%ACTIVE%'"
                dr = com.ExecuteReader()
                While dr.Read
                    list = Stats.ListView1.Items.Add(dr("ID").ToString)
                    list.SubItems.Add(dr("Firstname").ToString)
                    list.SubItems.Add(dr("Lastname").ToString)
                    list.SubItems.Add(dr("Middlename").ToString)
                    list.SubItems.Add(dr("Complain").ToString)
                    list.SubItems.Add(dr("Complain_Datetime").ToString)
                    list.SubItems.Add(dr("Status").ToString)
                End While
                dr.Close()
            End With


            View_Complains.ListView1.Items.Clear()
            com = New SQLiteCommand
            With com
                .Connection = con
                .CommandText = "SELECT * FROM `Complains`"
                dr = com.ExecuteReader()
                While dr.Read
                    list = View_Complains.ListView1.Items.Add(dr("ID").ToString)
                    list.SubItems.Add(dr("Firstname").ToString)
                    list.SubItems.Add(dr("Lastname").ToString)
                    list.SubItems.Add(dr("Middlename").ToString)
                    list.SubItems.Add(dr("Complain").ToString)
                    list.SubItems.Add(dr("Complain_Datetime").ToString)
                    list.SubItems.Add(dr("Status").ToString)
                End While
                dr.Close()


                .Connection = con
                .CommandText = "SELECT COUNT(`ID`) FROM `Complains` WHERE `Status` LIKE 'ACTIVE'"
                View_Complains.Label2.Text = .ExecuteScalar().ToString()

                .Connection = con
                .CommandText = "SELECT COUNT(`ID`) FROM `Complains` WHERE `Status` LIKE 'RESOLVE'"
                View_Complains.Label3.Text = .ExecuteScalar().ToString()

            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub ViewResidents()
        Try
            If con.State = ConnectionState.Closed Then
                Database.Connection()
            End If

            View_Residents.ListView1.Items.Clear()

            com = New SQLiteCommand
            With com
                .Connection = con
                .CommandText = "SELECT * FROM `Resident_Info`"
                dr = com.ExecuteReader()
                While dr.Read
                    list = View_Residents.ListView1.Items.Add(dr("ID").ToString)
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
End Module
