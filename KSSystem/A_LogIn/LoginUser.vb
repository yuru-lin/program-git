Module LoginUser
    '------>全域變數<------
    Public 登入系統 As String      '0.SAP登入, 1.內部系統, 2.非SAP登入
    Public IDNumber As String      'ID帳號
    Public IDName As String        'ID名字
    Public IDLog06 As String       'ID筆二層功能區
    Public IDLog08 As String       'ID筆一層功能區 0=登入凱馨系統, 1=登入內部系統, 2=福利社
    Public IDLog09 As String       'ID單位

    'ID筆一層功能區 =0, ID筆二層功能區 
    'ID筆一層功能區 =1, ID筆二層功能區 
    'ID筆一層功能區 =2, ID筆二層功能區 10= 最大權限, 20= 登入員購, 30= 使用磅秤程式

    Public DBName1 As String    '資料庫中文
    Public DBName2 As String    '資料庫英文

End Module