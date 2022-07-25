Public Class Form2
    Public id As String
    Public fname As String
    Public lname As String
    Public country As String
    Public phone As String
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        id = TextBox1.Text
        fname = TextBox2.Text
        lname = TextBox3.Text
        country = TextBox4.Text
        phone = TextBox5.Text
        DialogResult = DialogResult.OK
        Close()
    End Sub
End Class