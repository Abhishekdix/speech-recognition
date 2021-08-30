Imports System.Data.SqlClient

Public Class Form1
    Private myConn As SqlConnection
    Private myCmd As SqlCommand
    Private myReader As SqlDataReader
    Dim dataadapter As SqlDataAdapter
    Dim varP As String
    Dim varFiletxt As String
    Dim varBool As Boolean
    Dim strData(20) As String
    Dim varcount As Integer

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click


    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim ds As New DataSet()
        Dim dataSet As DataSet()
        varcount = 0
        varFiletxt = System.IO.File.ReadAllText("C:\Users\pc\source\repos\speechrecognition\hel.txt")
        myConn = New SqlConnection("Initial Catalog=Products;" & "Data Source=LAPTOP-N2T5OL68\SQLEXPRESS;Integrated Security=SSPI;")
        myCmd = myConn.CreateCommand
        myCmd.CommandText = "select Product_name from Product"
        myConn.Open()

        myReader = myCmd.ExecuteReader()

        Do While myReader.Read()
            varP = myReader.GetString(0)
            If varFiletxt <> "" Then
                varBool = varFiletxt.Contains(varP)
                If varBool = "True" Then
                    MsgBox("string present")
                    strData(varcount) = varP
                    Exit Do


                End If
            End If


        Loop
        myReader.Close()
        myConn.Close()


        varBool = varFiletxt.Contains("quantity")
        If varBool = "True" Then
            myCmd.CommandText = "UPDATE Product SET quantity ='" & 200 & "'  WHERE Product_name='" & strData(varcount) & "'"
            myConn.Open()
            myReader = myCmd.ExecuteReader()
            myReader.Close()
            myConn.Close()
        End If

        varBool = varFiletxt.Contains("select")
        If varBool = "True" Then
            myCmd.CommandText = "select Product_name from Product  WHERE Product_name='" & strData(varcount) & "'"
            myConn.Open()

            dataadapter.Fill(ds, "Product")

            myReader = myCmd.ExecuteReader()

            myReader.Close()
            myConn.Close()

            DataGridView1.DataSource = ds
            DataGridView1.DataMember = "Product"
        End If



    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load



        Dim startInfo As New ProcessStartInfo("cmd", "/c python.exe ../../../speech.py")
        startInfo.CreateNoWindow = True
        startInfo.WindowStyle = ProcessWindowStyle.Hidden

        Process.Start(startInfo)

        Dim filepath As String = "C:\Users\pc\source\repos\speechrecognition\endfile.txt"
        System.IO.File.WriteAllText(filepath, " ")





    End Sub
    Private Sub Form1_Exit(sender As Object, e As EventArgs) Handles MyBase.Disposed
        Dim sw As New Stopwatch
        Dim filepath As String = "C:\Users\pc\source\repos\speechrecognition\endfile.txt"
        System.IO.File.WriteAllText(filepath, "1")

        System.IO.File.WriteAllText(filepath, " ")



    End Sub

End Class