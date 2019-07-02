'生產管理_排程
Module PM_Lists
    Public Function Schedule_Lists() As String
        Dim SQLQuery As String = ""
        SQLQuery = " SELECT [ID] AS '代碼',[TimeOrder] AS '代碼A',[TimePeriod] AS '類別',[TimeToTake] AS '領料' FROM [KaiShingPlug].[dbo].[UB07_TimePeriod] ORDER BY [ID] "
        Return SQLQuery
    End Function

    'Private Sub Schedule載入()
    '    Dim SQLQuery As String = ""
    '    SQLQuery = PM_Lists.Schedule_Lists()

    '    Dim DBConn As SqlConnection = Login.DBConn
    '    Try
    '        MSSQL作業 = New SqlDataAdapter(SQLQuery, DBConn)
    '        MSSQL作業.Fill(顯示資料, "Schedule")

    '        CB時段.DataSource = 顯示資料.Tables("Schedule").Copy
    '        CB時段.DisplayMember = "類別" '名稱
    '        CB時段.ValueMember = "代碼"   '編號SelectedValue
    '        CB時段.SelectedIndex = -1

    '    Catch ex As Exception
    '        MsgBox("Schedule: " & ex.Message)
    '        Exit Sub
    '    End Try
    'End Sub













End Module
