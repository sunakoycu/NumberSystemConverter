Public Class Form1
    Dim decNumber As Integer
    Dim decCheck As Boolean
    Private Sub bConvert_Click(sender As Object, e As EventArgs) Handles bConvert.Click
        If tbDecimal.Text <> "" Then
            validateNum()
            If decCheck = True Then
                decNumber = CInt(tbDecimal.Text)
                toBinary()
                toHexa()
                toOctal()
            Else
                MessageBox.Show("Invalid Input")
            End If
            
        End If
    End Sub

    Private Sub bClear_Click(sender As Object, e As EventArgs) Handles bClear.Click
        clear()
    End Sub

    Private Sub clear()
        tbDecimal.Text = ""
        tbBinary.Text = ""
        tbHexa.Text = ""
        tbOctal.Text = ""
    End Sub

    Private Sub validateNum()
        Dim decSize As Integer
        Dim decChar As String
        Dim notDec As Integer
        decSize = tbDecimal.Text.Length - 1
        notDec = 0

        For count As Integer = 0 To decSize
            decChar = tbDecimal.Text.Substring(count, 1)
            If Not IsNumeric(decChar) Then
                notDec += 1
            End If
        Next

        If notDec > 0 Then
            decCheck = False
        Else
            decCheck = True
        End If

    End Sub

    Private Sub toBinary()
        Dim binString As String
        Dim binStringFinal As String
        Dim dividend As Integer
        Dim quotient As Integer
        Dim remainder As Integer
        Dim quotientCheck As Boolean = True
        dividend = CInt(tbDecimal.Text)

        Do While quotientCheck = True
            quotient = Math.Floor(dividend / 2)
            remainder = dividend Mod 2
            dividend = quotient
            binString = binString & CStr(remainder)
            If quotient = 0 Then
                quotientCheck = False
            End If
        Loop

        For count As Integer = binString.Length - 1 To 0 Step -1
            binStringFinal = binStringFinal & binString.Substring(count, 1)
        Next
        tbBinary.Text = binStringFinal
    End Sub

    Private Sub toHexa()
        tbHexa.Text = Hex(decNumber)
    End Sub
    Private Sub toOctal()
        Dim octString As String
        Dim octStringFinal As String
        Dim dividend As Integer
        Dim quotient As Integer
        Dim remainder As Integer
        Dim quotientCheck As Boolean = True
        dividend = CInt(tbDecimal.Text)

        Do While quotientCheck = True
            quotient = Math.Floor(dividend / 8)
            remainder = dividend Mod 8
            dividend = quotient
            octString = octString & CStr(remainder)
            If quotient = 0 Then
                quotientCheck = False
            End If
        Loop

        For count As Integer = octString.Length - 1 To 0 Step -1
            octStringFinal = octStringFinal & octString.Substring(count, 1)
        Next
        tbOctal.Text = octStringFinal
    End Sub
End Class
