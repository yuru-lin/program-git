

Partial Class ReportDataSet
    Partial Class dtSPicking1DataTable

        Private Sub dtSPicking1DataTable_ColumnChanging(ByVal sender As System.Object, ByVal e As System.Data.DataColumnChangeEventArgs) Handles Me.ColumnChanging
            If (e.Column.ColumnName = Me._2200Column.ColumnName) Then
                '在此處加入使用者程式碼
            End If

        End Sub

    End Class

    Partial Class dt_加工原料肉領料單DataTable

    End Class

    Partial Class dt_KS_Z_StockApply_DetailDataTable

    End Class

    Partial Class EBStatementDataTable

    End Class

    Partial Class dtPayment3DataTable

    End Class

    Partial Class dtCSDGV4DataTable

    End Class

    Partial Class dtCarDrDetailDataTable

    End Class

End Class