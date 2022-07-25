Imports System.Data.OleDb

Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub DropDownList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownList.SelectedIndexChanged

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim dtt As New DataTable
        Dim dss As New DataSet
        Dim daa As New OleDbDataAdapter
        Dim connection As OleDbConnection = New OleDbConnection()
        connection.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\PC\Desktop\TestDB.accdb"
        daa = New OleDbDataAdapter("select * from POWERSQL where ID = " + DropDownList.Text, connection)
        connection.Open()
        dss.Tables.Add(dtt)
        daa.Fill(dtt)
        connection.Close()
        DataGridView1.DataSource = dss.Tables(0)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim fr2 As Form2
        fr2 = New Form2()
        If fr2.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Dim id As String = fr2.id
            Dim fname As String = fr2.fname
            Dim lname As String = fr2.lname
            Dim country As String = fr2.country
            Dim phone As String = fr2.phone
            Dim conn As OleDbConnection = New OleDbConnection()
            conn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\PC\Desktop\TestDB.accdb"
            Using comd As New OleDb.OleDbCommand("INSERT INTO POWERSQL ([ID], [FirstName], [LastName], [Country], [Phone]) VALUES (@ID, @FirstName, @LastName, @Country, @Phone)", conn)
                comd.Parameters.AddWithValue("@ID", id)
                comd.Parameters.AddWithValue("@FirstName", fname)
                comd.Parameters.AddWithValue("@LastName", lname)
                comd.Parameters.AddWithValue("@Country", country)
                comd.Parameters.AddWithValue("@Phone", phone)
                conn.Open()
                Try
                    comd.ExecuteNonQuery()
                    MsgBox("Record Appended", MsgBoxStyle.Information, "Successfully Added!")
                Catch ex As Exception
                    MsgBox(ex.ToString())
                End Try
            End Using
            conn.Close()
        End If

    End Sub
    Shared dt As New DataTable
    Shared ds As New DataSet
    Shared da As New OleDbDataAdapter
    Sub LoadDB()
        Dim connection As OleDbConnection = New OleDbConnection()
        connection.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\PC\Desktop\TestDB.accdb"
        da = New OleDbDataAdapter("select * from POWERSQL", connection)
        connection.Open()
        ds.Tables.Add(dt)
        da.Fill(dt)
        connection.Close()
        DataGridView1.DataSource = ds.Tables(0)
        DropDownList.DataSource = ds.Tables(0)
        DropDownList.ValueMember = "ID"
        Dim btn As New DataGridViewButtonColumn()
        DataGridView1.Columns.Add(btn)
        btn.HeaderText = "Print"
        btn.Text = "Print"
        btn.Name = "btn"
        btn.UseColumnTextForButtonValue = True
    End Sub
    Private Sub DataGridView1_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        MsgBox("button clicked")
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        LoadDB()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim dt As New DataTable
        Dim ds As New DataSet
        Dim da As New OleDbDataAdapter
        Dim conn As OleDbConnection = New OleDbConnection()
        conn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\PC\Desktop\TestDB.accdb"
        Using comd As New OleDb.OleDbCommand("delete from POWERSQL where ID =@id", conn)
            comd.Parameters.AddWithValue("@id", DropDownList.Text)
            conn.Open()
            Try
                comd.ExecuteNonQuery()
                MsgBox("Record Deleted", MsgBoxStyle.Information, "Successfully Deleted!")
            Catch ex As Exception
                MsgBox(ex.ToString())
            End Try
        End Using
        conn.Close()
        LoadDB()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim cryRpt As New ReportDocument
        cryRpt.Load("CrystalReport1.rpt")
        CrystalReportViewer1.ReportSource = cryRpt
        CrystalReportViewer1.Refresh()
        'Dim fr3 As Form3
        'Dim index As Integer = Integer.Parse(DropDownList.Text) - 1
        'fr3 = New Form3(Form1.ds.Tables(0).Rows(index)(0).ToString(), Form1.ds.Tables(0).Rows(index)(1).ToString(), Form1.ds.Tables(0).Rows(index)(2).ToString(), Form1.ds.Tables(0).Rows(index)(3).ToString(), Form1.ds.Tables(0).Rows(index)(4).ToString())
        'fr3.Show()
        'Dim dt As New DataTable
        'Dim ds As New DataSet
        'Dim da As New OleDbDataAdapter
        'Dim conn As OleDbConnection = New OleDbConnection()
        'conn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\PC\Desktop\TestDB.accdb"
        'Using comd As New OleDb.OleDbCommand("update POWERSQL set FirstName = @f where ID =@id", conn)
        '    comd.Parameters.AddWithValue("@id", DropDownList.Text)
        '    conn.Open()
        '    Try
        '        comd.ExecuteNonQuery()
        '        MsgBox("Record Updated", MsgBoxStyle.Information, "Successfully Updated!")
        '    Catch ex As Exception
        '        MsgBox(ex.ToString())
        '    End Try
        'End Using
        'conn.Close()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim dt As New DataTable
        Dim ds As New DataSet
        Dim da As New OleDbDataAdapter
        Dim conn As OleDbConnection = New OleDbConnection()
        conn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\PC\Desktop\loginDB.accdb"
        da = New OleDbDataAdapter("select password from loginTable where username = '" + TextBox1.Text + "'", conn)
        conn.Open()
        ds.Tables.Add(dt)
        da.Fill(dt)
        conn.Close()
        Dim pass As String = ds.Tables(0).Rows(0)(0).ToString()
        If pass = TextBox2.Text Then
            DropDownList.Visible = True
            Button1.Visible = True
            Button2.Visible = True
            Button3.Visible = True
            Button4.Visible = True
            Button5.Visible = True
            DataGridView1.Visible = True
            MsgBox("Login Successfully")
        Else
            MsgBox("Login Failed")
        End If
    End Sub
End Class
