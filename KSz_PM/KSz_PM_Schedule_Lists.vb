Imports System.Data
Imports System.Data.SqlClient
Imports SF.DataAccess

Namespace Decision

    Public Class KSz_PM_Schedule_Lists

#Region "Public"

        Public m_ConnectionString As String = "" '連線字串
        Public m_ConnectTimeout As Integer = 60 '資料庫連線愈時
        Public m_ConnectType As Integer = Drivers.SQLServer   '連線類型

#End Region

        Sub New(ByVal ConnectionString As String)
            Me.m_ConnectionString = ConnectionString
        End Sub

        '清單: 年度銷售量預估(申請) 
        Public Overloads Function ListASF_Y() As DataTable
            If m_ConnectionString = "" Then
                Err.Raise(514, Me.GetType.Name & ".ListASF_Y()", "資料庫連線字串尚未設定，啟動失敗!")
                Return New DataTable
            End If

            Dim rDT As New DataTable
            Dim oDA As New SF.DataAccess
            Dim SQLComm As String = ""
            'Dim SQLCondition As String = ""

            Try
                SQLComm = ""
                SQLComm += " SELECT DataYear "
                SQLComm += " ,[Appl_UID] "
                SQLComm += " ,[Appl_DT] "
                SQLComm += " ,[Appr_UID] "
                SQLComm += " ,[Appr_DT] "
                SQLComm += " ,[IS_Price] "
                SQLComm += " ,[R_Amount] "
                SQLComm += " ,[Price_DataYM] "
                SQLComm += " ,[F_State] "
                SQLComm += " ,[Up_DT] "
                SQLComm += " FROM v_ASF_Y "
                SQLComm += " order by [DataYear] "

                oDA.ConnectTimeout = m_ConnectTimeout
                oDA.Connect(m_ConnectionString)
                oDA.ConnectType = m_ConnectType

                rDT = oDA.Query(SQLComm).Tables(0)
            Catch ex As Exception
                Err.Raise(513, ex.Source, ex.Message)

            Finally
                If Not oDA Is Nothing Then
                    oDA = Nothing
                End If
            End Try

            Return rDT

        End Function


End Namespace


'Public Class KSz_PM_Schedule_Lists

'End Class
