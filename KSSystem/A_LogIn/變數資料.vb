Module 通用
    '------>全域變數<------
    Public Function 製造單號(ByVal DueDate As String) As String
        Dim SQLQuery As String = ""
        SQLQuery = "     SELECT 1 AS '順序1',001 AS '順序2','手Key' AS '製造單號' "
        SQLQuery += "    UNION ALL "
        SQLQuery += "    SELECT SUBSTRING(T0.[U_M03],1,1),SUBSTRING(T0.[U_M03],8,3), "
        SQLQuery += "           CAST(SUBSTRING(T0.[U_M03],1,1) AS VARCHAR(2)) + '-' + CAST(CAST(SUBSTRING(T0.[U_M03],8,3) AS INT) AS VARCHAR(3)) "
        SQLQuery += "      FROM [OWOR] T0 WITH (NOLOCK) INNER JOIN [OITM] T1 WITH (NOLOCK) ON T0.[ItemCode] = T1.[ItemCode] "
        SQLQuery += "     WHERE T0.[Status] = 'R' AND  LEFT(T0.[U_M03],1) IN ('2','3','5','6') "
        SQLQuery += "     AND CONVERT(varchar(10),T0.[DueDate],120) = '" & DueDate & "' "
        SQLQuery += "  ORDER BY 1,2 "
        Return SQLQuery
    End Function

    'Public Function 公司代碼ALL() As String
    '    Dim SQLQuery As String = ""
    '    SQLQuery = "  SELECT 'ALL' AS '公司代碼', '所有公司' AS '公司名稱' "
    '    SQLQuery += " UNION ALL"
    '    SQLQuery += " SELECT [公司代碼],[公司名稱] FROM [Payroll].[dbo].[基_公司名稱] WHERE [啟用否] = 'Y' ORDER BY [ID]"
    '    Return SQLQuery
    'End Function

    'Public Function 部門代碼() As String
    '    Dim SQLQuery As String = ""
    '    SQLQuery = "  SELECT '全部' AS '名稱', 'ALL' AS '代碼','ALL' AS '單位' "
    '    SQLQuery += " UNION ALL "
    '    SQLQuery += " SELECT [名稱],[代碼],[單位] FROM [Payroll].[dbo].[檢_部門單位] "
    '    Return SQLQuery
    'End Function



End Module


