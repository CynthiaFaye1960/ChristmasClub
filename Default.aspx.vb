Imports System.Data.SqlClient
Imports System
Imports System.IO
Public Class _Default
    Inherits Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

    End Sub

    Protected Sub cmdSignUp1_Click(sender As Object, e As EventArgs) Handles cmdSignUp1.Click
        Dim EmpNbr As String
        'Dim EmpNum As Integer ' = CInt(EmpNbr)
        Dim EmpName As String
        Dim StatusCode As String
        Dim CS As String = "server=bblca03;database=appworkarea;User ID=ChristmasClubRDR;Password=HoHoHo"
        Dim connection As SqlConnection
        Dim command As SqlCommand
        Dim sql As String
        Dim JobTitle As String
        Dim Salary As String

        EmpNbr = TextBox1.Text.ToString
        sql = "select * from ChristmasClub where Employee_Number ='" + EmpNbr + "'"
        connection = New SqlConnection(CS)
        Dim rdr As SqlDataReader
        connection.Open()
        command = New SqlCommand(sql)
        command.Connection = connection
        rdr = command.ExecuteReader()
        If rdr.Read Then
            If Not IsDBNull(rdr.Item(0)) Then
                EmpName = rdr.Item(3)
                StatusCode = rdr.Item(6)
                JobTitle = rdr.Item(5)
                Salary = rdr.Item(7)
            End If
        Else
            'They have entered an ID number that is not in the table
            response.redirect("notindb.aspx")

        End If
        command.Dispose()
        connection.Close()
        lblName.Text = "Employee Name: " + EmpName
        lblFTime.Text = StatusCode
        lblJobCode.Text = JobTitle
        lblSalary.Text = Salary
        Panel2.Enabled = "True"
        Panel1.Enabled = "False"

    End Sub

    Protected Sub cmdEnterAmount_Click(sender As Object, e As EventArgs) Handles cmdEnterAmount.Click
        Dim amount As String = txtAmount.Text
        'Code for all erronious entries
        Dim Withhold As Decimal = 0.00
        lblInfo.Visible = True
        lblAmount.Visible = True
        Dim OneChar As String = amount.Substring(0, 1)
        If OneChar = "$" Then
            amount = amount.Substring(1, amount.Length - 1)
        End If
        If IsNumeric(amount) Then

            Withhold = CDec(amount)
        Else
            Panel2.Enabled = "True"
            txtAmount.Text = ""
            txtAmount.Focus()

            If txtAmount.Text = String.Empty Then
                Label2.Text = "You must enter a numerical value in this box"
                Panel2.Enabled = "True"
                txtAmount.Text = ""
                txtAmount.Focus()
                Exit Sub
            End If
        Label2.Text = "You must enter a numerical value in this box"

        End If

        If Double.TryParse(txtAmount.Text, Withhold) Then

        End If
        Panel2.Enabled = "False"
        Panel3.Enabled = "True"
        Dim Employee As String = lblName.Text.ToString
        Dim EmpName As String = Employee.Substring(15)
        ' Dim AmountToWithhold As String = txtAmount.Text.ToString
        Dim Salary As String = lblSalary.Text.ToString
        Dim FullTime As String = lblFTime.Text.ToString
        Dim AmountCalc As Decimal = 0
        Dim DollarAmt As Decimal = 0.00
        'Calculate the amount they will be getting back

        '  If FullTime = "FULL" Then
        If Salary = "Monthly" Then
                'Formula for Calculation (AmountEntered * 4.333) * 11
                Dim MonthlyAmt = 0.00
                MonthlyAmt = Withhold * 4.333
                AmountCalc = MonthlyAmt * 11
                Dim PerCheck As Decimal = 0.00
                PerCheck = Math.Round(MonthlyAmt, 2)
                DollarAmt = Math.Round(AmountCalc, 2)
                'MAKE SURE AMOUNT IS DIVISIBLE BY 5 
                If Withhold Mod 5 Then
                    Label2.Text = "The amount you have entered is not divisible by 5, please try again. EX: 5, 10, 15, 20 "
                    Panel2.Enabled = "True"
                    txtAmount.Text = ""
                    txtAmount.Focus()
                    Exit Sub
                End If
                lblInfo.Text = "I, " + EmpName + " authorize the withholding in the amount of " + PerCheck.ToString + " per paycheck"
            Else
                'Formula for calculating Hourly is amountEntered * 47
                AmountCalc = (Withhold * 47)
                DollarAmt = Math.Round(AmountCalc, 2)
                If Withhold Mod 5 Then
                    Label2.Text = "The amount you have entered is not divisible by 5, please try again. EX: 5, 10, 15, 20 "
                    Panel2.Enabled = "True"
                    txtAmount.Text = ""
                    txtAmount.Focus()
                    Exit Sub
                End If
            Dim PerCheck As Decimal = Math.Round(Withhold, 2)
            lblInfo.Text = "I, " + EmpName + " authorize the withholding in the amount of " + PerCheck.ToString + " per paycheck"
            End If
            lblAmount.Text = "You will be putting back $: " + DollarAmt.ToString
        'Else
        '    'Kick them out, this is only for fulltime.
        'End If
    End Sub

    Protected Sub cmdSignUp0_Click(sender As Object, e As EventArgs) Handles cmdSignUp0.Click
        'update SQL table
        Dim RowsUpdated As Integer = 0
        Dim TodaysDate As String
        Dim D As DateTime = Now
        TodaysDate = D.ToShortDateString.ToString
        Dim amount As String = txtAmount.Text
        'Code for all erronious entries
        Dim Withhold As Decimal = 0.00
        Withhold = CDec(amount)
        Dim EID As String = TextBox1.Text.ToString
        Dim CS As String = "server=bblca03;database=appworkarea;User ID=ChristmasClubRDR;Password=HoHoHo"
        Dim Update As String = "UPDATE ChristmasClub SET SignedUP = 'Yes', SignUPDate= '" & TodaysDate & "', WithHoldAmt =  '" & Withhold & "' WHERE Employee_Number = '" & EID & "'"
        Using Con As New SqlConnection(CS)
            Using Cmd As New SqlCommand(Update, Con)
                Con.Open()
                RowsUpdated = Cmd.ExecuteNonQuery
            End Using
        End Using
        cmdSignUp0.Visible = False
        cmdChangeAmount.Visible = False
        lblAmount.Text = "Your withholding request has processed and will begin being withheld in December."
        lblAmount.ForeColor = Drawing.Color.MediumAquamarine
    End Sub

    Protected Sub cmdChangeAmount_Click(sender As Object, e As EventArgs) Handles cmdChangeAmount.Click
        txtAmount.Text = ""
        Panel3.Enabled = "False"
        Panel2.Enabled = True
        lblInfo.Visible = False
        lblAmount.Visible = False
        txtAmount.Focus()
    End Sub
End Class