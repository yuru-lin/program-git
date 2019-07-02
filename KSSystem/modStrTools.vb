' 發展單位：風禹科技驗證有限公司
' 撰寫人：鄭子璉(Tzu-Lien, Cheng, 璉璉) ，成大水博肄，微軟最有價值專家
' Web: http://tlcheng.twbbs.org/TLCheng/ E-Mail: qvb3377@ms5.hinet.net
'http://tlcheng.twbbs.org/TLCheng/Net/NetList.aspx?Action=Function&Module=7&Function=15
'http://tlcheng.twbbs.org/TLCheng/Net/NetList.aspx?Action=Module&Module=6
' --------------------------------------------------------------------------------------

Imports System
Imports System.Text

Module modStrTools
#Region "Windows API 宣告"
    <Runtime.InteropServices.DllImport("Kernel32.dll")> _
     Private Function WideCharToMultiByte( _
     ByVal CodePage As Integer, _
     ByVal dwFlags As Integer, _
     ByVal lpWideCharStr As Byte(), _
     ByVal cchWideChar As Integer, _
     <Runtime.InteropServices.In(), Runtime.InteropServices.Out()> ByVal lpMultiByteStr As Byte(), _
     ByVal cchMultiByte As Integer, _
     ByVal lpDefaultChar As Integer, _
     ByVal lpUsedDefaultChar As Integer _
      ) As Integer
    End Function

    'Private Declare Function MultiByteToWideChar Lib "kernel32" (ByVal CodePage As Integer, ByVal dwFlags As Integer, ByVal lpMultiByteStr As Any, ByVal cchMultiByte As Integer, ByVal lpWideCharStr As Any, ByVal cchWideChar As Integer) As Integer
    <Runtime.InteropServices.DllImport("Kernel32.dll")> _
     Private Function MultiByteToWideChar( _
     ByVal CodePage As Integer, _
     ByVal dwFlags As Integer, _
     ByVal lpMultiByteStr As Byte(), _
     ByVal cchMultiByte As Integer, _
     <Runtime.InteropServices.In(), Runtime.InteropServices.Out()> ByVal lpWideCharStr As Byte(), _
     ByVal cchWideChar As Integer _
      ) As Integer
    End Function

#End Region

    Public Enum enuStandardCodePages As Integer
        SCP_CP_ACP = 0    ' 預設為 ANSI 字碼頁
        SCP_CP_OEMCP = 1      ' 預設為 OEM 字碼頁
        SCP_CP_MACCP = 2      ' 
        SCP_CP_THREAD_ACP = 3     ' 目前執行緒的 ANSI 字碼頁
        SCP_CP_SYMBO = 42     ' SYMBOL 轉譯
        SCP_ibm852 = 852      ' Central European (DOS)
        SCP_ibm866 = 866      ' Cyrillic (DOS)
        SCP_windows_874 = 874     ' Thai
        SCP_Japanese = 932    ' 日文
        SCP_cseucpkdfmtjapanese = 932     ' Japanese (EUC)
        SCP_csiso2022jp = 932     ' Japanese (JIS_Allow 1 byte Kana)
        SCP_csshiftjis = 932      ' Shift_JIS
        SCP_extended_unix_code_packed_format_for_japanese = 932   ' Japanese (EUC)
        SCP_iso_2022_jp = 932     ' Japanese (JIS)
        SCP_ms_kanji = 932    ' Shift_JIS
        SCP_shift_jis = 932   ' Shift_JIS
        SCP_x_euc = 932   ' Japanese (EUC)
        SCP_x_euc_jp = 932    ' Japanese (EUC)
        SCP_x_sjis = 932      ' Shift_JIS
        SCP_chinese = 936     ' 簡體中文
        SCP_csgb2312 = 936    ' Chinese Simplified (GB2312)
        SCP_csiso58gb231280 = 936     ' Chinese Simplified (GB2312)
        SCP_gb_2312_80 = 936      ' Chinese Simplified (GB2312)
        SCP_gb2312 = 936      ' Chinese Simplified (GB2312)
        SCP_hz_gb_2312 = 936      ' Chinese Simplified (HZ)
        SCP_iso_ir_58 = 936   ' Chinese Simplified (GB2312)
        SCP_cseuckr = 949     ' Korean
        SCP_csksc56011987 = 949   ' Korean
        SCP_euc_kr = 949      ' Korean
        SCP_iso_ir_149 = 949      ' Korean
        SCP_korean = 949      ' 韓文
        SCP_ks_c_5601 = 949   ' Korean
        SCP_ks_c_5601_1987 = 949      ' Korean
        SCP_ks_c_5601_1989 = 949      ' Korean
        SCP_ksc_5601 = 949    ' Korean
        SCP_ksc5601 = 949     ' Korean
        SCP_big5 = 950    ' 繁體中文 (BIG5)
        SCP_csbig5 = 950      ' 繁體中文 (BIG5)
        SCP_x_x_big5 = 950    ' 繁體中文 (BIG5)
        SCP_CP_Default_Windows = 1200     ' Windows
        SCP_CP_Little_Endian_Unicode = 1200   ' Windows
        SCP_CP_UTF_16LE = 1200    ' Windows
        SCP_CP_Big_Endian_Unicode = 1201      ' 
        SCP_CP_UTF_16BE = 1201    ' 
        SCP_windows_1250 = 1250   ' Central European (Windows)
        SCP_x_cp1250 = 1250   ' Central European (Windows)
        SCP_windows_1251 = 1251   ' Cyrillic (Windows)
        SCP_x_cp1251 = 1251   ' Cyrillic (Windows)
        SCP_ansi_x3_4_1968 = 1252     ' Western
        SCP_ansi_x3_4_1986 = 1252     ' Western
        SCP_ascii = 1252      ' Western
        SCP_cp367 = 1252      ' Western
        SCP_cp819 = 1252      ' Western
        SCP_csascii = 1252    ' Western
        SCP_ibm367 = 1252     ' Western
        SCP_ibm819 = 1252     ' Western
        SCP_iso_646_irv_1991 = 1252   ' Western
        SCP_iso_8859_1 = 28591    ' Western
        SCP_iso_8859_1_1987 = 1252    ' Western
        SCP_iso_ir_100 = 1252     ' Western
        SCP_iso_ir_6 = 1252   ' Western
        SCP_iso646_us = 1252      ' Western
        SCP_iso8859_1 = 28591     ' Western
        SCP_latin1 = 1252     ' Western
        SCP_us = 1252     ' Western
        SCP_us_ascii = 1252   ' Western
        SCP_windows_1252 = 1252   ' Western
        SCP_windows_1253 = 1253   ' Greek (Windows)
        SCP_windows_1254 = 1254   ' Turkish (Windows)
        SCP_csisolatinhebrew = 1255   ' Hebrew (ISO_Visual)
        SCP_hebrew = 1255     ' Hebrew
        SCP_iso_8859_8 = 1255     ' Hebrew (ISO_Visual)
        SCP_iso_8859_8_1988 = 1255    ' Hebrew (ISO_Visual)
        SCP_iso_ir_138 = 1255     ' Hebrew (ISO_Visual)
        SCP_windows_1255 = 1255   ' Hebrew
        SCP_windows_1256 = 1256   ' Arabic
        SCP_windows_1257 = 1257   ' Baltic (Windows)
        SCP_windows_1258 = 1258   ' Vietnamese
        SCP_CP_ASCII = 20127      ' 
        SCP_cskoi8r = 20866   ' Cyrillic (KOI8_R)
        SCP_koi8_r = 20866    ' Cyrillic (KOI8_R)
        SCP_csisolatin2 = 28592   ' Central European (ISO)
        SCP_iso_8859_2 = 28592    ' Central European (ISO)
        SCP_iso_8859_2_1987 = 28592   ' Central European (ISO)
        SCP_iso_ir_101 = 28592    ' Central European (ISO)
        SCP_iso8859_2 = 28592     ' Central European (ISO)
        SCP_l2 = 28592    ' Central European (ISO)
        SCP_latin2 = 28592    ' Central European (ISO)
        SCP_csiso2022kr = 50225   ' Korean (ISO)
        SCP_iso_2022_kr = 50225   ' Korean (ISO)
        SCP_CP_GB18030 = 54936    ' 簡體中文
        SCP_CP_UTF7 = 65000   ' Unicode (UTF_7)
        SCP_CP_UTF8 = 65001   ' Unicode (UTF_8)
    End Enum

    Public Enum enuChineseFlags
        CF_Default = 0
        CF_Little = 0
        CF_Big = 1
        CF_Number = 2
        CF_Unit = 4
        CF_Little_Unit = 8
        CF_Big_Unit = 16
        CF_KeepZero = 32

        CF_Add_Comma = 65536

        CF_Unit_Little = CF_Unit Or CF_Little
        CF_Unit_Big = CF_Unit Or CF_Big
        CF_Number_Little = CF_Number Or CF_Little
        CF_Number_Big = CF_Number Or CF_Big

    End Enum


    Private Enum enuChineseStringIndex
        CSI_Default = 0
        CSI_Unit_Little = 1
        CSI_Unit_Big = 2
        CSI_Number_Little = 3
        CSI_Number_Big = 4
    End Enum

    Private m_ChineseNumber As Object

    Public Function StringANSItoUnicode(ByVal strANSI As String, Optional ByVal CodePageFlags As enuStandardCodePages = enuStandardCodePages.SCP_CP_ACP) As String
        Dim arrBytes() As Byte = StringToBytes(strANSI)
        Dim arrInteger() As Object = ByteToVariant(arrBytes, VariantType.Array Or VariantType.Short)
        Dim ibd, ubd As Integer
        ubd = UBound(arrInteger)
        ReDim arrBytes(ubd)

        For ibd = 0 To ubd
            arrBytes(ibd) = arrInteger(ibd)
        Next

        Return BytesToString(arrBytes, CodePageFlags)
    End Function

    Public Function myMultiByteToWideChar(ByVal lpString As Object, Optional ByVal CodePageFlags As enuStandardCodePages = enuStandardCodePages.SCP_CP_UTF8) As String
        Dim cbWChar, rtnInteger As Integer
        Dim tBytes(), strBytes() As Byte
        ReDim tBytes(0)

        Select Case VarType(lpString)
            Case VariantType.Array Or VariantType.Byte
                strBytes = lpString
            Case VariantType.String
                strBytes = StringToBytes(lpString & Chr(0))
            Case Else
                Return Nothing
        End Select

        cbWChar = MultiByteToWideChar(CodePageFlags, 0, strBytes, -1, tBytes, 0)

        ReDim tBytes((cbWChar - 1) * 2 - 1)
        rtnInteger = MultiByteToWideChar(CodePageFlags, 0, strBytes, -1, tBytes, cbWChar - 1)

        Return BytesToString(tBytes)
    End Function

    Public Function myWideCharToMultiByte(ByVal lpString As Object, Optional ByVal wFlags As enuStandardCodePages = enuStandardCodePages.SCP_CP_UTF8) As Byte()
        ' 測試 UniCode 轉 UTF-8, Byte陣列長未確實運算
        Dim strBytes(), tBytes() As Byte
        Dim cbByte, rtnInteger As Integer

        cbByte = Len(lpString) * 4
        ReDim tBytes(cbByte - 1)

        Select Case VarType(lpString)
            Case VariantType.Array Or VariantType.Byte
                strBytes = lpString
            Case VariantType.String
                strBytes = StringToBytes(lpString)
            Case Else
                Return tBytes
        End Select
        rtnInteger = WideCharToMultiByte(wFlags, 0, strBytes, Len(lpString), tBytes, cbByte, 0, 0)
        ReDim Preserve tBytes(rtnInteger - 1)

        Return tBytes
    End Function

    Public Function MyBase64Encode(ByVal objValue As Object, Optional ByVal bBigEndian As Boolean = False) As String
        If IsNothing(objValue) Then
            Return Nothing
        Else
            Return BytesToString(MyBase64EncodeBytes(ObjectToByte(objValue), bBigEndian), enuStandardCodePages.SCP_ascii)
        End If
    End Function

    Public Function MyBase64EncodeBytes(ByVal arrBytes As Byte(), Optional ByVal bBigEndian As Boolean = False) As Byte()
        If IsNothing(arrBytes) Then
            Return Nothing
        Else
            Dim strBase64 As String
            strBase64 = System.Convert.ToBase64String(arrBytes)
            Return StringToBytes(strBase64, enuStandardCodePages.SCP_ascii)
        End If
    End Function

    Public Function MyBase64DecodeBytes(ByVal arrBytes As Byte(), Optional ByVal bBigEndian As Boolean = False) As Byte()
        If IsNothing(arrBytes) Then
            Return Nothing
        Else
            Return System.Convert.FromBase64String(BytesToString(arrBytes, enuStandardCodePages.SCP_ascii))
        End If
    End Function

    Public Function MyBase64Decode(ByVal objValue As Object, Optional ByVal nVarType As VariantType = VariantType.String, Optional ByVal bBigEndian As Boolean = False) As Object
        If IsNothing(objValue) Then
            Return objValue
        Else
            Dim arrBytes() As Byte
            Select Case VarType(objValue)
                Case VariantType.String
                    arrBytes = StringToBytes(objValue, enuStandardCodePages.SCP_CP_ASCII)
                Case (VariantType.Array Or VariantType.Byte)
                    arrBytes = objValue
                Case Else
                    arrBytes = ObjectToByte(objValue)
            End Select
            Dim rtnObject As Object = MyBase64DecodeBytes(arrBytes)
            If IsNothing(rtnObject) Then
                Return rtnObject
            Else
                Return ByteToVariant(rtnObject, nVarType, bBigEndian)
            End If
        End If
    End Function

    Public Function SplitMixDelimiterString(ByVal strSource As String, Optional ByVal strDelimiter As String = " ", Optional ByVal bChangeVariant As Boolean = False) As Object
        ' 適用於 CommandLine、CSV 單行
        'Dim ibc, ubc, ibr, ubr, ibt, lbt, ubt As Integer
        Dim ibc, ubc, ubr, ibt, ubt As Integer

        Dim arrCol(), arrTemp() As String
        Dim arrRow() As Object

        ubr = 0
        ReDim arrRow(0)

        ' 處理字串符號分隔
        arrCol = Split(Trim(strSource), """")
        ubc = UBound(arrCol)

        ' 處理分隔符號
        For ibc = 0 To ubc Step 2
            If Len(arrCol(ibc)) > 0 Then
                arrTemp = Split(arrCol(ibc), strDelimiter)
                ubt = UBound(arrTemp)
                If bChangeVariant Then
                    If ibc = 0 Then
                        arrRow(ubr) = CVariant(arrTemp(0))
                    Else
                        arrRow(ubr) &= arrTemp(0)
                    End If
                Else
                    arrRow(ubr) &= arrTemp(0)
                End If
                ReDim Preserve arrRow(ubr + ubt)
                For ibt = 1 To ubt
                    If bChangeVariant Then
                        If ibc < ubc And ibt = ubt Then
                            arrRow(ubr + ibt) = arrTemp(ibt)
                        Else
                            arrRow(ubr + ibt) = CVariant(arrTemp(ibt))
                        End If
                    Else
                        arrRow(ubr + ibt) = arrTemp(ibt)
                    End If
                Next
                ubr += ubt
            Else
                If ibc > 0 Then
                    arrRow(ubr) &= """"
                End If
            End If
            If ibc < ubc Then
                arrRow(ubr) &= arrCol(ibc + 1)
            End If
        Next

        Return arrRow
    End Function

    Public Function GetRightPlacesOfDecimal(ByVal vValue As Object) As Integer
        ' 取得小數點右方位數
        Dim strValue As String = CStr(vValue)
        Dim nLoc As Integer = InStr(strValue, ".")
        If nLoc > 0 Then
            nLoc = Len(strValue) - nLoc
        End If
        Return nLoc
    End Function

    Public Function GetChineseDateTime(ByVal sDateTime As String) As Date
        Dim lbc, ubc, sLoc, eLoc, nLen, iUnit As Integer
        Dim addHour As Double

        Dim m_strYear As String() = Split("秒,分,時,日,月,年", ",")
        lbc = LBound(m_strYear)
        ubc = UBound(m_strYear)

        sDateTime = Replace(sDateTime, "民國", "")
        If InStr(sDateTime, "下午") Then
            addHour += 12
        Else
            addHour = 0
        End If
        sDateTime = Replace(sDateTime, "下午", "")

        Dim arrDateTime(ubc) As Double

        sLoc = 1
        nLen = Len(sDateTime)

        For iUnit = ubc To lbc Step -1
            eLoc = InStr(sLoc, sDateTime, m_strYear(iUnit))
            If eLoc > 0 Then
                arrDateTime(iUnit) = GetChineseNumber(Mid(sDateTime, sLoc, eLoc - sLoc))
                sLoc = eLoc + 1
            End If
            If sLoc > nLen Then
                Exit For
            End If
        Next

        Return DateSerial(arrDateTime(5) + 1911, arrDateTime(4), arrDateTime(3)) + TimeSerial(arrDateTime(2) + addHour, arrDateTime(1), arrDateTime(0))

    End Function

    Private Function SetChineseNumberInit() As Object

        Dim m_strUnit As String() = Split("個,萬,億,兆,京,垓,杼,穰,溝,澗,正,載,極,恆河沙,阿僧祇,那由他,不可思議,無量,大數", ",")       ' 10 ^ 4, 8, 12, 16, 20, 24, 28, 32, 36, 40, 44, 48, 52, 56, 60, 64, 68, 72
        Dim m_strUnitLittle As String() = Split("個,十,百,千", ",")
        Dim m_strUnitBig As String() = Split("個,拾,佰,仟", ",")
        Dim m_strNumLittle As String() = Split("○,一,二,三,四,五,六,七,八,九", ",")
        Dim m_strNumBig As String() = Split("零,壹,貳,參,肆,伍,陸,柒,捌,玖", ",")

        SetChineseNumberInit = MyArray(m_strUnit, m_strUnitLittle, m_strUnitBig, m_strNumLittle, m_strNumBig)

    End Function

    Public Function SetChineseNumber(ByVal vNumber As Object, Optional ByVal lFlags As enuChineseFlags = enuChineseFlags.CF_Default) As String
        Dim sNumber As String
        Dim arrRep, arrUnit, arr10k As Object
        Dim ibc, ubc, nLoc As Integer

        Dim m_ChineseNumber As Object = SetChineseNumberInit()

        If lFlags And (enuChineseFlags.CF_Little_Unit Or enuChineseFlags.CF_Big_Unit) Then
            lFlags = lFlags And (CInt(-1) Xor lFlags.CF_Add_Comma)
        End If

        sNumber = vNumber.ToString
        If lFlags And enuChineseFlags.CF_Add_Comma Then
            Dim sFmt As String = "#,##0"
            If InStr(sNumber, ".") > 0 Then
                sFmt &= "." & New String("0", Len(sNumber) - InStr(sNumber, "."))
            End If
            sNumber = CDec(vNumber).ToString(sFmt)
        End If

        If lFlags And enuChineseFlags.CF_Number_Big Then
            arrRep = m_ChineseNumber(enuChineseStringIndex.CSI_Number_Big)
        Else
            arrRep = m_ChineseNumber(enuChineseStringIndex.CSI_Number_Little)
        End If

        ubc = UBound(arrRep)
        For ibc = 0 To ubc
            sNumber = Replace(sNumber, CStr(ibc), arrRep(ibc))
        Next


        If lFlags And enuChineseFlags.CF_Add_Comma Then
            sNumber = Replace(sNumber, ",", "、")
        ElseIf lFlags And (enuChineseFlags.CF_Little_Unit Or enuChineseFlags.CF_Big_Unit) Then
            Dim tNumber As String

            If lFlags And enuChineseFlags.CF_Big_Unit Then
                arrUnit = m_ChineseNumber(enuChineseStringIndex.CSI_Unit_Big)
            Else
                arrUnit = m_ChineseNumber(enuChineseStringIndex.CSI_Unit_Little)
            End If
            arr10k = m_ChineseNumber(enuChineseStringIndex.CSI_Default)
            arr10k(0) = ""

            nLoc = InStr(sNumber, ".")
            If nLoc = 0 Then
                ubc = Len(sNumber)
            Else
                ubc -= nLoc - 1
            End If

            tNumber = ""
            For ibc = 1 To ubc
                If (lFlags And enuChineseFlags.CF_KeepZero) > 0 Or Mid(sNumber, ibc, 1) <> arrRep(0) Then
                    arrUnit(0) = arr10k((ubc - ibc) \ 4)
                    tNumber &= Mid(sNumber, ibc, 1) & arrUnit((ubc - ibc) Mod 4)
                End If
            Next
            If nLoc = 0 Then
                sNumber = tNumber
            Else
                sNumber = tNumber & Mid(sNumber, nLoc)
            End If
        End If

        sNumber = Replace(sNumber, ".", "‧")

        Return sNumber

    End Function

    Public Function GetChineseNumber(ByVal sNumber As String, Optional ByVal lFlags As enuChineseFlags = enuChineseFlags.CF_Default) As Double
        Dim i, lbc, ubc, iUnit, nPower, nNextFlags, sLoc, eLoc, nLen As Integer
        Dim m_CN, m_RP As Object
        Dim tValue, tConf As Double
        Dim nIndex As Integer

        If Not IsArray(m_ChineseNumber) Then
            m_ChineseNumber = SetChineseNumberInit()
        End If

        If lFlags = enuChineseFlags.CF_Default Then
            sNumber = Replace(sNumber, "廿", "二十")
            sNumber = Replace(sNumber, "卅", "三十")
            sNumber = Replace(sNumber, "、", "")

            For i = 1 To 3 Step 2
                m_CN = m_ChineseNumber(i)
                lbc = LBound(m_CN)
                ubc = UBound(m_CN)

                m_RP = m_ChineseNumber(i + 1)
                For iUnit = lbc To ubc
                    sNumber = Replace(sNumber, m_RP(iUnit), m_CN(iUnit))
                Next
            Next
        End If

        tValue = 0

        Select Case lFlags
            Case enuChineseFlags.CF_Default
                nPower = 4
                nNextFlags = enuChineseFlags.CF_Unit_Little
                nIndex = enuChineseStringIndex.CSI_Default
            Case enuChineseFlags.CF_Unit_Little, enuChineseFlags.CF_Unit_Big
                nPower = 1
                nNextFlags = enuChineseFlags.CF_Number_Little
                nIndex = enuChineseStringIndex.CSI_Unit_Little + (lFlags And enuChineseFlags.CF_Big)
            Case enuChineseFlags.CF_Number_Little, enuChineseFlags.CF_Number_Big
                nIndex = enuChineseStringIndex.CSI_Number_Little + (lFlags And enuChineseFlags.CF_Big)
        End Select

        m_CN = m_ChineseNumber(nIndex)
        lbc = LBound(m_CN)
        ubc = UBound(m_CN)

        sLoc = 1
        nLen = Len(sNumber)
        Select Case lFlags
            Case enuChineseFlags.CF_Default, enuChineseFlags.CF_Unit_Little, enuChineseFlags.CF_Unit_Big
                For iUnit = ubc To lbc Step -1
                    eLoc = InStr(sLoc, sNumber, m_CN(iUnit))
                    If eLoc > 0 Then
                        If eLoc = sLoc Then
                            tConf = 1
                        Else
                            tConf = GetChineseNumber(Mid(sNumber, sLoc, eLoc - sLoc), nNextFlags)
                        End If

                        On Error Resume Next
                        tValue += tConf * CDec(10 ^ (nPower * iUnit))
                        If Err.Number = 6 Then
                            Err.Clear()
                            tValue += tConf * CDbl(10 ^ (nPower * iUnit))
                        End If
                        On Error GoTo 0

                        sLoc = eLoc + 1
                    ElseIf iUnit = lbc Then
                        tValue += GetChineseNumber(Mid(sNumber, sLoc), nNextFlags)
                    End If
                    If sLoc > nLen Then
                        Exit For
                    End If
                Next
            Case enuChineseFlags.CF_Number_Little, enuChineseFlags.CF_Number_Big
                For iUnit = lbc To ubc
                    sNumber = Replace(sNumber, m_CN(iUnit), CStr(iUnit))
                Next
                tValue += Val(sNumber)
        End Select

        Return tValue
    End Function

    Public Function GetDataNumericFormat(ByVal vData, ByVal sFormat) As String
        Dim sLoc, eLoc, hLoc, ibf, lbf, ubf As Integer
        Dim midFormat, fmtData As String
        Dim fmt As Object
        Dim sOutput As String = ""
        Dim nStart As Integer = 1

        Do
            sLoc = InStr(nStart, sFormat, "{")
            If sLoc > 0 Then
                eLoc = InStr(sLoc + 1, sFormat, "}")
                If eLoc > 0 Then
                    midFormat = Mid(sFormat, sLoc + 1, eLoc - sLoc - 1)
                    hLoc = InStr(LCase(midFormat), "&h")

                    If hLoc > 0 Then
                        fmt = Split(midFormat, ";")
                        lbf = LBound(fmt)
                        ubf = UBound(fmt)

                        For ibf = lbf To ubf
                            hLoc = InStr(LCase(fmt(ibf)), "&h")
                            If hLoc > 0 Then
                                fmtData &= Mid(fmt(ibf), 1, hLoc - 1) & Hex(CLng(myFormatNumeric(vData, Mid(fmt(ibf), hLoc + 2))))
                            Else
                                fmtData &= myFormatNumeric(vData, fmt(ibf))
                            End If
                        Next
                    Else
                        fmtData = myFormatNumeric(vData, midFormat)
                    End If
                    sOutput &= Mid(sFormat, nStart, sLoc - nStart) & fmtData
                    nStart = eLoc + 1
                Else
                    sOutput &= Mid(sFormat, nStart, sLoc - nStart) & "{"
                    nStart = sLoc + 1
                End If
            Else
                sOutput &= Mid(sFormat, nStart)
            End If
        Loop Until sLoc = 0

        GetDataNumericFormat = sOutput

    End Function

    Public Function myFormatNumeric(ByVal vData As Double, ByVal strFormat As String) As String
        If IsNothing(vData) Then
            Return Nothing
        ElseIf strFormat = "" Then
            Return CStr(vData)
        Else
            Dim sDot, sCommon As String()
            Dim ubd, ubc, nLen, nLoc, ic, nDot As Integer
            Dim sNumeric As Object
            Dim sAddFirst As String

            sDot = Split(strFormat, ".")            ' 偵測小數點
            ubd = UBound(sDot)

            If ubd > 0 Then
                sNumeric = CStr(Math.Round(vData, Len(sDot(1))))
                If InStr(sNumeric, ".") = 0 Then
                    sNumeric &= "."
                End If
            Else
                sNumeric = CStr(Math.Round(vData, 0))
            End If
            sNumeric = Split(sNumeric, ".")         ' 偵測小數點

            sCommon = Split(sDot(0), ",")           ' 偵測逗號
            ubc = UBound(sCommon)

            If ubc > 0 Then
                nLen = Len(sNumeric(0))
                nLoc = ((nLen - 1) Mod 3) + 1

                For ic = 1 To (nLen - 1) \ 3
                    sNumeric(0) = Left(sNumeric(0), nLoc) & "," & Mid(sNumeric(0), nLoc + 1)
                    nLoc += 4
                Next
            End If
            nLen = Len(sNumeric(0))
            nDot = Len(sDot(0))

            If nDot > nLen Then
                sAddFirst = Left(sDot(0), nDot - nLen)
                sAddFirst = Replace(sAddFirst, "#", "")
                sAddFirst = Replace(sAddFirst, ",", "")

                sNumeric(0) = sAddFirst & sNumeric(0)
            End If

            If ubd > 0 Then
                nLen = Len(sNumeric(1))
                nDot = Len(sDot(1))

                sNumeric(1) &= Mid(sDot(1), nLen + 1, nDot - nLen)
                sNumeric(1) = Replace(sNumeric(1), "#", "")
            End If

            Return Join(sNumeric, ".")
        End If
    End Function

    Public Function GetDataDateFormat(ByVal vDate As Date, ByVal sFormat As String) As String
        Dim sLoc, eLoc, hLoc, ibf, lbf, ubf As Integer
        Dim midFormat, fmtDate As String
        Dim fmt As Object
        Dim sOutput As String = ""
        Dim nStart As Integer = 1

        Do
            sLoc = InStr(nStart, sFormat, "[")
            If sLoc > 0 Then
                eLoc = InStr(sLoc + 1, sFormat, "]")
                If eLoc > 0 Then
                    midFormat = Mid(sFormat, sLoc + 1, eLoc - sLoc - 1)
                    hLoc = InStr(LCase(midFormat), "&h")

                    If hLoc > 0 Then
                        fmt = Split(midFormat, ";")
                        lbf = LBound(fmt)
                        ubf = UBound(fmt)

                        For ibf = lbf To ubf
                            hLoc = InStr(LCase(fmt(ibf)), "&h")
                            If hLoc > 0 Then
                                'fmtDate &= Mid(fmt(ibf), 1, hLoc - 1) & Hex(CLng(Format(vDate, Mid(fmt(ibf), hLoc + 2))))
                                fmtDate &= Mid(fmt(ibf), 1, hLoc - 1) & Hex(CLng(vDate.ToString(Mid(fmt(ibf), hLoc + 2))))
                            Else
                                fmtDate &= Format(vDate, fmt(ibf))
                            End If
                        Next
                    Else
                        'fmtDate = Format(vDate, midFormat)
                        fmtDate = vDate.ToString(midFormat)
                    End If
                    sOutput &= Mid(sFormat, nStart, sLoc - nStart) & fmtDate
                    nStart = eLoc + 1
                Else
                    sOutput &= Mid(sFormat, nStart, sLoc - nStart) & "["
                    nStart = sLoc + 1
                End If
            Else
                sOutput &= Mid(sFormat, nStart)
            End If
        Loop Until sLoc = 0

        Return sOutput

    End Function

    Public Function GetContinueString(ByVal strSource As String, ByVal strFind As String) As String
        Dim sLoc As Integer = InStr(strSource, strFind)
        If sLoc > 0 Then
            Dim ibl, nLen As Integer
            Dim sReturn As String

            nLen = Len(strFind)
            If sLoc + nLen > Len(strSource) Then
                sReturn = Mid(strSource, sLoc)
            Else
                For ibl = sLoc + nLen To Len(strSource) Step nLen
                    If Mid(strSource, ibl, nLen) <> strFind Then
                        sReturn = Mid(strSource, sLoc, ibl - sLoc)
                        Exit For
                    ElseIf ibl + nLen >= Len(strSource) Then
                        sReturn = Mid(strSource, sLoc)
                    End If
                Next
            End If

            Return sReturn
        Else
            Return ""
        End If
    End Function

    Public Function GetSubStringFromFind(ByVal strSource As String, ByVal strFormat As String, ByVal strFind As String) As String
        Dim sLoc, nLen As Integer
        sLoc = InStr(strFormat, strFind)
        nLen = Len(strFind)

        If sLoc > 0 Then
            Return Mid(strSource, sLoc, nLen)
        Else
            Return ""
        End If
    End Function

    Public Function GetDateFromString(ByVal strSource As String, ByVal strFormat As String) As Date
        Dim nYear, nMonth, nDay, nHour, nMinute, nSecond As Integer
        'Dim sLoc, nLen As Integer

        Dim strItem As String

        ' nYear
        strItem = GetContinueString(LCase(strFormat), "e")
        If strItem <> "" Then
            nYear = CInt(GetSubStringFromFind(strSource, LCase(strFormat), strItem)) + 1911
        Else
            strItem = GetContinueString(LCase(strFormat), "y")
            If strItem <> "" Then
                nYear = CInt(GetSubStringFromFind(strSource, LCase(strFormat), strItem))
                If Len(strItem) = 2 Then
                    nYear += 2000
                End If
            End If
        End If

        ' nMonth
        strItem = GetContinueString(strFormat, "M")
        If strItem <> "" Then
            nMonth = CInt(GetSubStringFromFind(strSource, strFormat, strItem))
        End If

        ' nDay
        strItem = GetContinueString(LCase(strFormat), "d")
        If strItem <> "" Then
            nDay = CInt(GetSubStringFromFind(strSource, LCase(strFormat), strItem))
        End If

        ' nHour
        strItem = GetContinueString(LCase(strFormat), "h")
        If strItem <> "" Then
            nHour = CInt(GetSubStringFromFind(strSource, LCase(strFormat), strItem))
        End If

        ' nMinute
        strItem = GetContinueString(LCase(strFormat), "n")
        If strItem <> "" Then
            nMinute = CInt(GetSubStringFromFind(strSource, LCase(strFormat), strItem))
        Else
            strItem = GetContinueString(strFormat, "m")
            If strItem <> "" Then
                nMinute = CInt(GetSubStringFromFind(strSource, strFormat, strItem))
            End If
        End If

        ' nSecond
        strItem = GetContinueString(LCase(strFormat), "s")
        If strItem <> "" Then
            nSecond = CInt(GetSubStringFromFind(strSource, LCase(strFormat), strItem))
        End If

        Return New DateTime(nYear, nMonth, nDay, nHour, nMinute, nSecond)
    End Function

    Public Function InstrString(ByVal objSource As Object, Optional ByVal strDelimiter As Object = " ", Optional ByVal nCount As Object = Nothing, Optional ByVal bContinue As Object = False, Optional ByVal ChangeVariant As Object = False) As Object
        ' 開發日期：2004/08/19、最後修改日期：2004/08/19
        ' 允許各變數使用陣列
        ' objSource 陣列：遞回呼叫本函數，使其可同時傳回多個分隔陣列
        ' strDelimiter陣列：允許多種分隔字串，第一層陣列將不同分隔方式將分隔成不同格，第二層陣列將將不同分隔方式分隔成同格，且多個分隔符號視為連續
        ' nCount陣列：若為陣列，維度必須與 objSource相同，Nothing 傳回所有分隔陣列，0 及正數傳回某格之值，負值傳回0~該值之範圍陣列（如-5 -> arrReturn(0 To 5)）
        ' bContinue 陣列：若為陣列，維度必須與 objSource相同，True判斷連續分隔視為同一個
        ' ChangeVariant 陣列：若為陣列，維度必須與 objSource相同，True將字串轉換為Variant

        ' 範例
        'Dim strOutput As Object
        'Dim ibr, ibc As Integer
        'strOutput = InstrString(MyArray("Name, , Date" & vbNewLine & ",Hi", "1, ; Null; ; 2004/3/15,,True, Nothing"), MyArray(MyArray(", ", "; "), vbNewLine, ",", ";"), MyArray(-2, Nothing), MyArray(True, False), MyArray(False, True))
        'For ibr = 0 To UBound(strOutput)
        '   For ibc = 0 To UBound(strOutput(ibr))
        '      Debug.WriteLine(ibr & " " & ibc & ":" & strOutput(ibr)(ibc) & "(" & TypeName(strOutput(ibr)(ibc)))
        '   Next
        'Next
        ' 傳回
        '0 0:Name(String
        '0 1: Date(String
        '0 2: (String
        '1 0:1(Double
        '1 1:(DBNull
        '1 2:2004/3/15(Date
        '1 3:(String
        '1 4:True(Boolean
        '1 5:(Nothing

        Dim ibs As Integer

        If IsArray(objSource) Then
            Dim arrReturn(UBound(objSource)) As Object
            Dim aCount, aContinue, aVariant As Object

            For ibs = 0 To UBound(objSource)
                If IsArray(nCount) Then aCount = nCount(ibs) Else aCount = nCount
                If IsArray(bContinue) Then aContinue = bContinue(ibs) Else aContinue = bContinue
                If IsArray(ChangeVariant) Then aVariant = ChangeVariant(ibs) Else aVariant = ChangeVariant

                arrReturn(ibs) = InstrString(objSource(ibs), strDelimiter, aCount, aContinue, aVariant)
            Next

            Return arrReturn
        Else
            Dim arrDelimiter(), arrReturn() As Object
            Dim nLen, ibr, ubr As Integer
            Dim strReturn As String()
            Dim strSource As String = CStr(objSource)

            If IsArray(strDelimiter) Then
                ubr = UBound(strDelimiter)
                ReDim arrDelimiter(ubr)

                For ibs = 0 To ubr
                    If IsArray(strDelimiter(ibs)) Then
                        arrDelimiter(ibs) = strDelimiter(ibs)(0)

                        For ibr = 1 To UBound(strDelimiter(ibs))
                            strSource = Replace(strSource, strDelimiter(ibs)(ibr), arrDelimiter(ibs))
                        Next

                        Do
                            nLen = Len(strSource)
                            strSource = Replace(strSource, arrDelimiter(ibs) & arrDelimiter(ibs), arrDelimiter(ibs))
                        Loop Until nLen = Len(strSource)
                    Else
                        arrDelimiter(ibs) = strDelimiter(ibs)
                    End If
                Next

            Else
                arrDelimiter = MyArray(strDelimiter)
            End If

            If bContinue Then
                For ibs = 0 To UBound(arrDelimiter)
                    Do
                        nLen = Len(strSource)
                        strSource = Replace(strSource, arrDelimiter(ibs) & arrDelimiter(ibs), arrDelimiter(ibs))
                    Loop Until nLen = Len(strSource)
                Next
            End If

            For ibs = 1 To UBound(arrDelimiter)
                strSource = Replace(strSource, arrDelimiter(ibs), arrDelimiter(0))
            Next

            strReturn = Split(strSource, arrDelimiter(0))

            ubr = UBound(strReturn)
            ReDim arrReturn(ubr)

            If ChangeVariant Then
                For ibs = 0 To ubr
                    arrReturn(ibs) = CVariant(strReturn(ibs))
                Next
            Else
                For ibs = 0 To ubr
                    arrReturn(ibs) = strReturn(ibs)
                Next
            End If

            If IsNothing(nCount) Then
                Return arrReturn
            Else
                nCount = CInt(nCount)

                If nCount >= 0 Then
                    Return arrReturn(nCount)
                Else
                    nCount = -nCount
                    ReDim Preserve arrReturn(nCount)
                    Return arrReturn
                End If
            End If
        End If

    End Function

    Public Function MidAdvance(ByVal SourceString As String, ByVal StartString As String, ByVal EndString As String) As String
        Dim sn, en, nLen As Integer
        nLen = Len(StartString)
        sn = InStr(SourceString, StartString)
        en = InStr(sn + nLen, SourceString, EndString)

        If sn = 0 Or en = 0 Then
            MidAdvance = vbNullString
        Else
            MidAdvance = Mid(SourceString, sn + nLen, en - (sn + nLen))
        End If

    End Function

    Public Function MyLen(ByVal vString As String) As Integer

        Dim arrBytes As Byte()

        arrBytes = StringToBytes(vString)
        arrBytes = BytesChangeCodePages(arrBytes, enuStandardCodePages.SCP_CP_Default_Windows, enuStandardCodePages.SCP_big5)

        Return UBound(arrBytes) + 1

    End Function

    Public Function MyMid(ByVal vString As String, ByVal iStart As Integer, Optional ByVal iLength As Integer = 0) As String

        Dim srcBytes, dstBytes As Byte()
        Dim ubb As Integer

        srcBytes = StringToBytes(vString)
        srcBytes = BytesChangeCodePages(srcBytes, enuStandardCodePages.SCP_CP_Default_Windows, enuStandardCodePages.SCP_big5)

        ubb = UBound(srcBytes)

        If iLength = 0 Then
            iLength = ubb + 1 - iStart + 1
        ElseIf (iStart + iLength - 1) >= (ubb + 1) Then
            iLength = ubb + 1 - iStart + 1
        End If

        ReDim dstBytes(iLength - 1)

        Array.Copy(srcBytes, iStart - 1, dstBytes, 0, iLength)

        srcBytes = BytesChangeCodePages(dstBytes, enuStandardCodePages.SCP_big5, enuStandardCodePages.SCP_CP_Default_Windows)

        Return BytesToString(srcBytes)

    End Function

    Public Function CVariant(ByVal strSource As Object) As Object

        If IsNothing(strSource) Or LCase(Trim(strSource)) = "nothing" Then
            CVariant = Nothing
        ElseIf IsDBNull(strSource) Or LCase(Trim(strSource)) = "null" Then
            CVariant = DBNull.Value
        ElseIf IsNumeric(strSource) Then
            CVariant = CDbl(strSource)
        ElseIf IsDate(strSource) Then
            CVariant = CDate(strSource)
        ElseIf IsBoolean(strSource) Then
            CVariant = CBool(strSource)
        Else
            CVariant = strSource
        End If

    End Function

    Public Function IsBoolean(ByVal vBool) As Boolean

        Dim tBool As Boolean

        IsBoolean = True

        Try
            tBool = CBool(vBool)
        Catch ex As Exception
            IsBoolean = False
        End Try

    End Function

    Public Function StringChangeCodePages(ByVal srcString As String, Optional ByVal srcCodePage As enuStandardCodePages = enuStandardCodePages.SCP_big5, Optional ByVal dstCodePage As enuStandardCodePages = enuStandardCodePages.SCP_CP_Default_Windows) As String

        Dim arrBytes As Byte()

        arrBytes = StringToBytes(srcString, srcCodePage)
        arrBytes = BytesChangeCodePages(arrBytes, srcCodePage, dstCodePage)
        Return BytesToString(arrBytes, dstCodePage)
        'Return BytesToString(arrBytes, enuStandardCodePages.SCP_CP_Default_Windows)

    End Function

    Public Function BytesChangeCodePages(ByVal arrBytes As Byte(), Optional ByVal srcCodePage As enuStandardCodePages = enuStandardCodePages.SCP_big5, Optional ByVal dstCodePage As enuStandardCodePages = enuStandardCodePages.SCP_CP_Default_Windows) As Byte()

        Dim srcEncoding As Encoding = Encoding.GetEncoding(srcCodePage)
        Dim dstEncoding As Encoding = Encoding.GetEncoding(dstCodePage)
        Return Encoding.Convert(srcEncoding, dstEncoding, arrBytes)

    End Function

    Public Function Big5ToUnicode(ByVal arrBytes As Byte()) As Byte()

        ' 繁體中文 (Big5) 字碼頁為 950
        'Dim Big5Encoding As Encoding = Encoding.GetEncoding(950)
        'Return Encoding.Convert(Big5Encoding, Encoding.Unicode, arrBytes)
        Return BytesChangeCodePages(arrBytes)

    End Function

    Public Function BytesToString(ByVal arrBytes As Byte(), Optional ByVal dstCodePage As enuStandardCodePages = enuStandardCodePages.SCP_CP_Default_Windows) As String

        Dim uniDecoder As Encoding = Encoding.GetEncoding(dstCodePage)
        Return uniDecoder.GetString(arrBytes)

    End Function

    Public Function StringToBytes(ByVal srcString As String, Optional ByVal dstCodePage As enuStandardCodePages = enuStandardCodePages.SCP_CP_Default_Windows) As Byte()

        Dim uniDecoder As Encoding = Encoding.GetEncoding(dstCodePage)
        Return uniDecoder.GetBytes(srcString)

    End Function

    Public Function GetCodePages(ByVal strCodePage As String) As Integer
        Return Encoding.GetEncoding(strCodePage).CodePage
    End Function

    Public Function MyArray(ByVal ParamArray arrVar())
        Return arrVar
    End Function

    Public Function ObjectToHex(ByVal hObj As Object, Optional ByVal bBigEndian As Boolean = False) As String
        Dim arrByte As Byte() = ObjectToByte(hObj, bBigEndian)
        Return ByteToHex(arrByte)
    End Function

    Public Function ByteToHex(ByVal arrByte As Byte()) As String
        Dim ibb, ubb As Integer
        Dim rtnString, bytString As String

        ubb = UBound(arrByte)
        For ibb = 0 To ubb
            bytString = Hex(arrByte(ibb))
            If Len(bytString) = 1 Then
                bytString = "0" & bytString
            End If
            rtnString &= bytString
        Next

        Return rtnString
    End Function

    Public Function ObjectToByte(ByVal hObj As Object, Optional ByVal bBigEndian As Boolean = False) As Byte()
        Dim arrByte As Byte()

        If IsArray(hObj) Then
            Dim arrSingle As Byte()
            Dim nBytes As Integer = -1
            Dim ibb, ubs As Integer

            If VarType(hObj) = (VariantType.Array Or VariantType.Byte) Then
                ubs = UBound(hObj)
                ReDim arrByte(ubs)
                Array.Copy(hObj, 0, arrByte, 0, ubs + 1)
            Else
                For ibb = 0 To UBound(hObj)
                    arrSingle = ObjectToByte(hObj(ibb), bBigEndian)
                    ubs = UBound(arrSingle)
                    nBytes += ubs + 1
                    ReDim Preserve arrByte(nBytes)

                    Array.Copy(arrSingle, 0, arrByte, nBytes - ubs, ubs + 1)
                Next
            End If

        Else
            Dim nVarType As TypeCode = hObj.GetTypeCode()

            Select Case nVarType
                Case TypeCode.String, TypeCode.Char
                    arrByte = StringToBytes(hObj)
                Case TypeCode.DateTime
                    arrByte = ObjectToByte(hObj.Ticks, bBigEndian)
                Case TypeCode.Byte
                    ReDim arrByte(0)
                    arrByte(0) = hObj
                Case Else
                    Dim memStream As New System.IO.MemoryStream
                    Dim binWriter As New System.IO.BinaryWriter(memStream)

                    binWriter.Write(hObj)
                    binWriter.Close()
                    arrByte = memStream.ToArray()
                    memStream.Close()

                    If bBigEndian Then
                        Array.Reverse(arrByte)
                    End If
            End Select

        End If

        Return arrByte
    End Function

    Public Function ByteToObject(ByVal arrByte As Byte(), Optional ByVal nVarType As TypeCode = TypeCode.Int32, Optional ByVal bBigEndian As Boolean = False) As Object
        Dim hObj As Object

        Select Case nVarType
            Case TypeCode.String, TypeCode.Char
                hObj = BytesToString(arrByte)
            Case Else
                If bBigEndian Then
                    Array.Reverse(arrByte)
                End If

                Dim memStream As New System.IO.MemoryStream
                memStream.Write(arrByte, 0, UBound(arrByte) + 1)
                memStream.Seek(0, IO.SeekOrigin.Begin)
                Dim binRead As New System.IO.BinaryReader(memStream)

                With binRead
                    Select Case nVarType
                        Case TypeCode.Boolean
                            hObj = .ReadBoolean()
                        Case TypeCode.Byte
                            hObj = .ReadByte()
                        Case TypeCode.Char
                            hObj = .ReadChar()
                        Case TypeCode.DateTime
                            hObj = New DateTime(.ReadInt64())
                        Case TypeCode.Decimal
                            hObj = .ReadDecimal()
                        Case TypeCode.Double
                            hObj = .ReadDouble()
                        Case TypeCode.Int16
                            hObj = .ReadInt16()
                        Case TypeCode.Int32
                            hObj = .ReadInt32()
                        Case TypeCode.Int64
                            hObj = .ReadInt64()
                        Case TypeCode.SByte
                            hObj = .ReadSByte()
                        Case TypeCode.Single
                            hObj = .ReadSingle()
                        Case TypeCode.String
                            hObj = .ReadString()
                        Case TypeCode.UInt16
                            hObj = .ReadUInt16()
                        Case TypeCode.UInt32
                            hObj = .ReadUInt32()
                        Case TypeCode.UInt64
                            hObj = .ReadUInt64()
                    End Select
                End With

                binRead.Close()
                memStream.Close()
        End Select

        Return hObj
    End Function

    Public Function HexToObject(ByVal strHex As String, Optional ByVal nVarType As TypeCode = TypeCode.Int32, Optional ByVal bBigEndian As Boolean = False) As Object
        Return ByteToObject(HexToByte(strHex), nVarType, bBigEndian)
    End Function

    Public Function HexToByte(ByVal strHex As String) As Byte()
        Dim ibb As Integer
        Dim nBytes As Integer = -Int(-CDbl(Len(strHex)) / 2) - 1
        Dim arrByte(nBytes) As Byte

        For ibb = 0 To nBytes
            arrByte(ibb) = CByte("&H" & Mid(strHex, ibb * 2 + 1, 2))
        Next

        Return arrByte
    End Function

    Public Function HexToVariant(ByVal strHex As String, Optional ByVal nVarType As VariantType = VariantType.Integer, Optional ByVal bBigEndian As Boolean = False) As Object
        Return ByteToVariant(HexToByte(strHex), nVarType, bBigEndian)
    End Function

    Public Function ByteToVariant(ByVal arrByte As Byte(), Optional ByVal nVarType As VariantType = VariantType.Integer, Optional ByVal bBigEndian As Boolean = False) As Object
        Dim hObj As Object

        If IsNothing(arrByte) Then
            Return Nothing
        ElseIf nVarType = (VariantType.Array Or VariantType.Byte) Then
            Return arrByte
        ElseIf nVarType And VariantType.Array Then
            Dim ibb, ubs As Integer
            nVarType = nVarType - VariantType.Array
            Dim nBytes As Integer = GetByteOfVariantType(nVarType)
            Dim arrSingle(nBytes) As Byte
            ubs = -Int(-CDbl((UBound(arrByte) + 1)) / nBytes) - 1
            Dim rtnObj(ubs) As Object

            For ibb = 0 To ubs
                Array.Copy(arrByte, ibb * nBytes, arrSingle, 0, nBytes)
                rtnObj(ibb) = ByteToVariant(arrSingle, nVarType, bBigEndian)
            Next

            hObj = rtnObj
        Else
            Dim nBytes As Integer = GetByteOfVariantType(nVarType)
            Select Case nVarType
                Case VariantType.String, VariantType.Char
                    hObj = BytesToString(arrByte)
                Case Else
                    If bBigEndian Then
                        Array.Reverse(arrByte)
                    End If

                    If UBound(arrByte) < nBytes - 1 Then
                        ReDim Preserve arrByte(nBytes - 1)
                    End If

                    Dim memStream As New System.IO.MemoryStream
                    memStream.Write(arrByte, 0, UBound(arrByte) + 1)
                    memStream.Seek(0, IO.SeekOrigin.Begin)
                    Dim binRead As New System.IO.BinaryReader(memStream)

                    With binRead
                        Select Case nVarType
                            Case VariantType.Boolean
                                hObj = .ReadBoolean()
                            Case VariantType.Byte
                                hObj = .ReadByte()
                            Case VariantType.Char
                                hObj = .ReadChar()
                            Case VariantType.Date
                                hObj = DateTime.FromOADate(.ReadDouble())
                            Case VariantType.Decimal
                                hObj = .ReadDecimal()
                            Case VariantType.Double
                                hObj = .ReadDouble()
                            Case VariantType.Short
                                hObj = .ReadInt16()
                            Case VariantType.Integer
                                hObj = .ReadInt32()
                            Case VariantType.Long
                                hObj = .ReadInt64()
                            Case VariantType.Single
                                hObj = .ReadSingle()
                            Case VariantType.String
                                hObj = .ReadString()
                        End Select
                    End With

                    binRead.Close()
                    memStream.Close()
            End Select
        End If

        Return hObj
    End Function

    Public Function GetByteOfTypeCode(ByVal wFlags As TypeCode) As Integer
        Dim nByte As Integer         ' 十六進位轉變數
        Select Case wFlags
            Case TypeCode.Boolean, TypeCode.Byte, TypeCode.SByte
                nByte = 1
            Case TypeCode.Char, TypeCode.Int16, TypeCode.UInt16
                nByte = 2
            Case TypeCode.Int32, TypeCode.Single, TypeCode.Object, TypeCode.UInt32
                nByte = 4
            Case TypeCode.Double, TypeCode.Int64, TypeCode.UInt64
                nByte = 8
            Case TypeCode.String
            Case TypeCode.Decimal
                nByte = 16               ' 兩位保留
            Case Else
        End Select
        Return nByte
    End Function

    Public Function GetByteOfVariantType(ByVal wFlags As VariantType) As Integer
        Dim nByte As Integer         ' 十六進位轉變數
        Select Case wFlags
            Case VariantType.Boolean, VariantType.Byte
                nByte = 1
            Case VariantType.Char, VariantType.Error, VariantType.Short
                nByte = 2
            Case VariantType.Integer, VariantType.Single, VariantType.Object
                nByte = 4
            Case VariantType.Currency, VariantType.Date, VariantType.Double, VariantType.Long
                nByte = 8
            Case VariantType.String
            Case VariantType.Decimal, VariantType.Variant
                nByte = 16               ' 兩位保留
            Case Else
        End Select
        Return nByte
    End Function

    Public Function GetMIMEBytes(ByVal strMIME As Object) As Byte()
        If IsArray(strMIME) Then
            Dim allBytes, arrByte As Byte()
            'Dim ibb, ubb, nCount, nByte As Integer
            Dim ibb, nCount As Integer

            ReDim allBytes(-1)

            nCount = -1
            For ibb = 0 To UBound(strMIME)
                arrByte = GetMIMEBytes(strMIME(ibb))
                BytesAdd(allBytes, arrByte)

                'ubb = UBound(arrByte)
                'nByte = nCount + ubb + 1

                'ReDim Preserve allBytes(nByte)
                'Array.Copy(arrByte, 0, allBytes, nCount + 1, ubb + 1)

                'nCount = nByte
            Next

            Return allBytes
        Else
            strMIME = Replace(strMIME, vbTab, "")
            Dim strEncode, strCode, strReturn As String
            Dim chkString = Split(strMIME, "?")
            Dim arrBytes As Byte()
            'Dim ibs, ubs, iCode As Integer
            Dim ibs, ubs As Integer

            ubs = UBound(chkString)

            If chkString(0) = "=" And chkString(ubs) = "=" Then
                strEncode = chkString(1)
                strCode = chkString(2)
                strReturn = chkString(3)
                For ibs = 4 To ubs - 1
                    strReturn &= "?" & chkString(ibs)
                Next

                Select Case LCase(strCode)
                    Case "b"
                        arrBytes = Base64DecodeByte(strReturn)
                    Case "q"
                        arrBytes = QPDecodeByte(strReturn)
                        'arrBytes = StringToBytes(myQPCodeConvStr(strReturn))
                End Select
            Else
                Return Nothing
            End If
            Return arrBytes
        End If
    End Function

    Public Function GetMIMEString(ByVal strMIME As Object) As Object
        Dim strEncode, strCode, strReturn As String
        Dim sgnMIME As String
        If IsArray(strMIME) Then
            sgnMIME = strMIME(0)
        Else
            sgnMIME = strMIME
        End If
        Dim chkString = Split(sgnMIME, "?")
        Dim arrBytes As Byte()
        Dim ibs, ubs, iCode As Integer
        ubs = UBound(chkString)

        If chkString(0) = "=" And chkString(ubs) = "=" Then
            strEncode = chkString(1)
            strCode = chkString(2)
            strReturn = chkString(3)
            For ibs = 4 To ubs - 1
                strReturn &= "?" & chkString(ibs)
            Next

            arrBytes = GetMIMEBytes(strMIME)
            If IsNothing(arrBytes) Then
                Return ""
            End If

            'arrBytes = Base64DecodeByte(strReturn)
            iCode = GetCodePages(strEncode)

            If iCode = GetCodePages("iso-8859-1") Then
                iCode = enuStandardCodePages.SCP_big5
            End If

            strReturn = BytesToString(arrBytes, iCode)
            strReturn = Replace(strReturn, Chr(0), "")
        Else
            strReturn = ""
        End If
        Return strReturn
    End Function

    Public Function Base64DecodeByte(ByVal base64String As String) As Byte()
        ' Decodes a base-64 encoded string (BSTR type).
        ' 1999 - 2004 Antonin Foller, http://www.pstruh.cz
        ' 1.01 - solves problem with Access And 'Compare Database' (InStr)
        'rfc1521
        '1999 Antonin Foller, PSTRUH Software, http://pstruh.cz
        Const Base64 = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/"
        Dim dataLength As Integer
        Dim groupBegin As Integer
        ', sOut, groupBegin
        Dim nCount As Integer = -1
        Dim arrByte() As Byte

        'remove white spaces, If any
        base64String = Replace(base64String, vbCrLf, "")
        base64String = Replace(base64String, vbTab, "")
        base64String = Replace(base64String, " ", "")

        'The source must consists from groups with Len of 4 chars
        dataLength = Len(base64String)
        If dataLength Mod 4 <> 0 Then
            Err.Raise(1, "Base64Decode", "Base64字串長度應為 4 的倍數。")
            Exit Function
        End If


        ' Now decode each group:
        For groupBegin = 1 To dataLength Step 4
            Dim numDataBytes, nGroup, CharCounter, thisData As Integer
            'Dim thisChar, pOut As String
            Dim thisChar As String

            ' Each data group encodes up To 3 actual bytes.
            numDataBytes = 3
            nGroup = 0

            For CharCounter = 0 To 3
                ' Convert each character into 6 bits of data, And add it To
                ' an integer For temporary storage.  If a character is a '=', there
                ' is one fewer data byte.  (There can only be a maximum of 2 '=' In
                ' the whole string.)

                thisChar = Mid(base64String, groupBegin + CharCounter, 1)

                If thisChar = "=" Then
                    numDataBytes = numDataBytes - 1
                    thisData = 0
                Else
                    thisData = InStr(1, Base64, thisChar, vbBinaryCompare) - 1
                End If
                If thisData = -1 Then
                    Err.Raise(2, "Base64Decode", "在 Base64 字串內有錯誤字串。")
                    Exit Function
                End If

                nGroup = 64 * nGroup + thisData
            Next

            nCount = nCount + 3
            ReDim Preserve arrByte(nCount)
            arrByte(nCount - 2) = nGroup \ 65536
            arrByte(nCount - 1) = (nGroup And 65535) \ 256
            arrByte(nCount - 0) = nGroup Mod 256

            'add numDataBytes characters To out string
        Next

        Return arrByte
    End Function

    Public Sub BytesAdd(ByRef bSource As Byte(), ByRef bAdd As Byte())
        Dim uba As Integer = UBound(bAdd)
        Dim ubs As Integer = UBound(bSource)
        Dim nCount As Integer

        nCount = ubs + uba + 1

        ReDim Preserve bSource(nCount)
        Array.Copy(bAdd, 0, bSource, ubs + 1, uba + 1)

        'Return bSource
    End Sub


    Public Function ArrayAdd(ByVal bSource As Object, ByVal bAdd As Object)
        Dim uba As Integer = UBound(bAdd)
        Dim ubs As Integer = UBound(bSource)
        Dim nCount As Integer

        nCount = ubs + uba + 1

        ReDim Preserve bSource(nCount)
        Array.Copy(bAdd, 0, bSource, ubs + 1, uba + 1)

        Return bSource
    End Function

    Public Function QPNormalStringByte(ByVal str As String) As Byte()
        If Len(str) > 0 Then
            str = Replace(str, "_", " ")
            Return StringToBytes(str, enuStandardCodePages.SCP_big5)
        Else
            Return Nothing
        End If
    End Function

    Public Function QPDecodeByte(ByVal hString As String, Optional ByVal SpaceString As String = "=") As Byte()
        Dim i, nLoc As Integer
        Dim tStr As String
        Dim arrSplit = Split(hString, SpaceString)
        Dim allBytes, arrByte As Byte()
        Dim ubs As Integer = UBound(arrSplit)
        ReDim allBytes(-1)

        i = 0

        If Len(arrSplit(i)) > 0 Then
            arrByte = QPNormalStringByte(arrSplit(i))
            BytesAdd(allBytes, arrByte)
        End If

        Do Until i >= ubs
            i = i + 1
            tStr = arrSplit(i)

            If tStr = "" Then
                Exit Do
            Else
                ReDim arrByte(0)
                If Len(tStr) > 2 Then
                    arrByte(0) = CByte("&H" & Left(tStr, 2))

                    If Mid(tStr, 3, 1) <> "_" Then
                        ReDim Preserve arrByte(1)
                        arrByte(1) = Asc(Mid(tStr, 3, 1))
                        nLoc = 4
                    Else
                        nLoc = 3
                    End If

                    BytesAdd(allBytes, arrByte)

                    tStr = Mid(tStr, nLoc)
                    If Len(tStr) > 0 Then
                        arrByte = QPNormalStringByte(tStr)
                        BytesAdd(allBytes, arrByte)
                    End If
                Else
                    arrByte(0) = CByte("&H" & tStr)
                    BytesAdd(allBytes, arrByte)
                End If
            End If
        Loop

        Return allBytes

    End Function

    Public Function myQPCodeConvStr(ByVal hString As String, Optional ByVal SpaceString As String = "=", Optional ByVal dstCodePage As enuStandardCodePages = enuStandardCodePages.SCP_big5) As String
        Dim i, nLoc As Integer
        Dim tStr, tHex, tStr2 As String
        Dim arrSplit As Object = Split(hString, SpaceString)
        Dim ubs As Integer = UBound(arrSplit)
        Dim allBytes, arrByte As Byte()
        Dim lNewLine As Integer = Len(vbNewLine)
        Dim nextStr As String
        ReDim allBytes(-1)

        i = -1

        Do Until i >= ubs
            i = i + 1
            tStr = arrSplit(i)

            If Left(tStr, lNewLine) = vbNewLine Then
                tStr = Mid(tStr, lNewLine + 1)
            End If

            If tStr = "" Then
            ElseIf tStr = vbNewLine Then
            ElseIf Left(tStr, lNewLine) = vbNewLine Then
                myQPCodeConvStr &= BytesToString(allBytes, dstCodePage) & Mid(tStr, lNewLine + 1)
                ReDim allBytes(-1)
            ElseIf InStr("0123456789abcdef", LCase(Left(tStr, 1))) = 0 Then
                Dim bAddStr As Boolean = True
                If Len(tStr) = 1 Then
                    Select Case tStr
                        Case "0" To "~"
                            ReDim Preserve allBytes(UBound(allBytes) + 1)
                            allBytes(UBound(allBytes)) = Asc(tStr)
                            bAddStr = False
                    End Select
                End If
                If UBound(allBytes) >= 0 Then
                    myQPCodeConvStr &= BytesToString(allBytes, dstCodePage)
                    ReDim allBytes(-1)
                End If

                If bAddStr Then
                    myQPCodeConvStr &= tStr
                End If
            Else
                ReDim arrByte(0)

                If Len(tStr) > 2 Then
                    nLoc = 3
                    On Error Resume Next
                    arrByte(0) = CByte("&H" & Left(tStr, 2))

                    If Err.Number = 0 Then
                        If arrByte(0) > 127 Then
                            nextStr = Mid(tStr, 3, 1)
                            Select Case nextStr
                                Case "0" To "~"
                                    ReDim Preserve arrByte(1)
                                    arrByte(1) = Asc(Mid(tStr, 3, 1))
                                    nLoc = 4
                            End Select
                        End If

                        BytesAdd(allBytes, arrByte)
                    Else
                        Err.Clear()
                    End If
                    On Error GoTo 0

                    tStr = Mid(tStr, nLoc)
                    If Len(tStr) > 0 Then
                        myQPCodeConvStr &= BytesToString(allBytes, dstCodePage) & tStr
                        ReDim allBytes(-1)
                    End If
                Else
                    tStr = Trim(tStr)
                    If Len(tStr) = 1 Then
                        Select Case tStr
                            Case "0" To "~"
                                arrByte(0) = Asc(tStr)
                            Case Else
                                arrByte(0) = CByte("&H" & tStr)
                        End Select
                    Else
                        arrByte(0) = CByte("&H" & tStr)
                    End If
                    BytesAdd(allBytes, arrByte)
                End If
            End If
        Loop

        If UBound(allBytes) >= 0 Then
            myQPCodeConvStr &= BytesToString(allBytes, dstCodePage)
            ReDim allBytes(-1)
        End If

    End Function

End Module