Public Class Form3
    Public id As String
    Public fname As String
    Public lname As String
    Public country As String
    Public phone As String

    Public Sub New(ByVal id As String, ByVal fname As String, ByVal lname As String, ByVal country As String, ByVal phone As String)
        InitializeComponent()
        Label6.Text = id
        TextBox2.Text = fname
        TextBox3.Text = lname
        TextBox4.Text = country
        TextBox5.Text = phone
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        id = Label6.Text
        fname = TextBox2.Text
        lname = TextBox3.Text
        country = TextBox4.Text
        phone = TextBox5.Text
        DialogResult = DialogResult.OK
        Close()
    End Sub
End Class