Imports System.Text.RegularExpressions

Public Class MainForm

    Protected Friend WithEvents WebBrowserRead As New WebBrowser

    Private Flag_Done As Boolean = False
    Private CleanMsgCountdown As Integer = 0

    '等待網頁讀取完成
    Private Function Loading(ByRef [web] As WebBrowser, Optional ByVal TimeOutSec As Integer = 10) As Boolean
        Dim WBTimeOut As Date = Now
        Do Until [web].ReadyState = WebBrowserReadyState.Complete Or DateDiff("s", WBTimeOut, Now) >= TimeOutSec
            Application.DoEvents()
        Loop
        If DateDiff("s", WBTimeOut, Now) >= TimeOutSec Then
            [web].Stop()
            Return False
        Else
            Return True
        End If
    End Function

    Private Sub Delay(delay_time As Long)
        Dim Start As Integer = Environment.TickCount()
        Do
            If Environment.TickCount() - Start > delay_time Then Exit Do
            Application.DoEvents()
        Loop
    End Sub

    Sub CopyTextToClipboard(ByVal Text As String, Optional ByVal Quiet As Boolean = False)
        Clipboard.SetText(Text, TextDataFormat.Text)
        If Not Quiet Then
            If Clipboard.GetText = Text Then
                Label_msgOutput.ForeColor = Color.DarkGreen
                Label_msgOutput.Font = New Font(Label_msgOutput.Font, FontStyle.Bold)
                Label_msgOutput.Text = "資料已成功複製!"
            Else
                Label_msgOutput.ForeColor = Color.Firebrick
                Label_msgOutput.Font = New Font(Label_msgOutput.Font, FontStyle.Bold)
                Label_msgOutput.Text = "資料複製失敗!"
            End If
            CleanMsgCountdown = 30 'ms
            Timer_UI.Enabled = True
        End If
    End Sub

    Private Sub WebBrowserRead_ProgressChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.WebBrowserProgressChangedEventArgs) Handles WebBrowserRead.ProgressChanged
        If e.MaximumProgress <> 0 And e.MaximumProgress >= e.CurrentProgress And Not Flag_Done Then
            PBar.Value = Convert.ToInt32(100 * e.CurrentProgress / e.MaximumProgress)
        Else
            With PBar
                .Value = 100
                .Visible = True
            End With
        End If
    End Sub

    Private Sub MainForm_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown
        GetData()
    End Sub

    Private Function HTTPGet(URL As String, Optional PageEncode As String = "UTF-8") As String
        Dim Req As Net.WebRequest
        Dim ReceiveStream As IO.Stream
        Dim encode As System.Text.Encoding
        Dim sr As IO.StreamReader
        Dim result As Net.WebResponse

        Req = Net.WebRequest.Create(URL)
        result = Req.GetResponse()
        ReceiveStream = result.GetResponseStream
        encode = System.Text.Encoding.GetEncoding(PageEncode)
        sr = New IO.StreamReader(ReceiveStream, encode)
        Return sr.ReadToEnd() '抓網頁的原始檔
    End Function

    Private Sub GetData(Optional ByVal DataDate As String = "")
        Dim Data() As String
        Dim i As Short
        Dim no As Short = 0
        Dim Flag_ID As String = ""
        Dim Flag_Success As Boolean

        Flag_Done = False

        Button_GetData.Enabled = False
        Button_CopyID.Enabled = False
        Button_CopyPW.Enabled = False
        Button_CopyKey.Enabled = False
        Label_DataDate.Text = "正在取得資料..."

        DBList.Clear()
        With DBList
            .View = View.Details
            .GridLines = True
            .Columns.Clear()
            .Columns.Add("#", 20, HorizontalAlignment.Left)
            .Columns.Add("帳號", 100, HorizontalAlignment.Left)
            .Columns.Add("密碼", 70, HorizontalAlignment.Left)
            .Columns.Add("序號", 200, HorizontalAlignment.Left)
            .Refresh()
        End With

        If DataDate = "" Then
            WebBrowserRead.Navigate("http://www.trynod32.com/")
        Else
            Dim Tmp As Date
            Tmp = DateAdd(DateInterval.Day, 1, CDate(DataDate))
            WebBrowserRead.Navigate("http://www.trynod32.com/search?updated-max=" & Tmp.Year & "-" & Tmp.Month & "-" & Tmp.Day & "T00:00:00%2B00:00&max-results=1")
        End If

        If Loading(WebBrowserRead, 6) Then
            Label_DataDate.Text = "載入網頁完成, 嘗試取得資料..."
        Else
            Label_DataDate.Text = "中斷載入網頁, 嘗試取得資料..."
        End If


        '擷取Web網頁內的Html項目
        For Each [HtmlElement] As HtmlElement In WebBrowserRead.Document.All

            '擷取DIV-Body
            If [HtmlElement].TagName = "DIV" And [HtmlElement].GetAttribute("ID") Like "post-body-*" Then
                Data = Split(Replace(Trim([HtmlElement].OuterText), Chr(10), ""), Chr(13))
                For i = LBound(Data) To UBound(Data)
                    If Data(i) Like "Username:*" Then
                        Flag_ID = Replace(Data(i), "Username:", "")
                        Flag_Success = True
                        Flag_Done = True
                    ElseIf Data(i) Like "Password:*" Then
                        If Flag_ID <> "" Then
                            Dim AccountItem As ListViewItem
                            no += 1
                            AccountItem = DBList.Items.Add(no)
                            AccountItem.SubItems.Add(Trim(Flag_ID))
                            AccountItem.SubItems.Add(Trim(Replace(Data(i), "Password:", "")))
                            AccountItem.SubItems.Add("等候轉換")
                            Flag_ID = ""
                        End If
                    End If
                Next
            End If

            '擷取資料日期
            If [HtmlElement].TagName = "H2" And [HtmlElement].OuterText Like "*年*月*日星期*" Then
                Label_DataDate.Text = "取得資料完成 (時間: " & [HtmlElement].OuterText & " )"
                DataDateChoose.Value = CDate(Mid([HtmlElement].OuterText, 1, InStr([HtmlElement].OuterText, "星期") - 1))
            End If
        Next

        If Not Flag_Success Then
            Label_DataDate.Text = "無法取得資料"
            PBar.Value = 0
            Button_GetData.Enabled = True
            Exit Sub
        ElseIf (Not Label_DataDate.Text Like "取得資料完成*") And Flag_Success And Flag_Done Then
            Label_DataDate.Text = "取得資料完成"
            PBar.Value = 100
        End If

        For i = 0 To DBList.Items.Count - 1
            If DBList.Items.Item(i).SubItems(3).Text = "等候轉換" Then
                DBList.Items.Item(i).SubItems(3).Text = "轉換中..."
                Application.DoEvents()
                Dim LicenseKey As String = GetLicenseKey(DBList.Items.Item(i).SubItems(1).Text, DBList.Items.Item(i).SubItems(2).Text)
                DBList.Items.Item(i).SubItems(3).Text = IIf(LicenseKey = "", "失敗", LicenseKey)
            End If
        Next

        Label_DataDate.Text = "取得資料完成"
        PBar.Value = 100
        Application.DoEvents()
        Button_GetData.Enabled = True
    End Sub

    Private Function GetLicenseKey(ByVal ID As String, ByVal PW As String) As String
        'ID
        '<input name="ctl00$body$txtUsername" type="text" id="body_txtUsername" />
        'PW
        '<input name="ctl00$body$txtPassword" type="password" id="body_txtPassword" />
        'Submit
        '<input type="submit" name="ctl00$body$btnConvert" value="轉換" onclick="javascript:WebForm_DoPostBackWithOptions(new WebForm_PostBackOptions(&quot;ctl00$body$btnConvert&quot;, &quot;&quot;, true, &quot;Convert&quot;, &quot;&quot;, false, false))" id="body_btnConvert" />

        WebBrowserRead.Navigate("https://my.eset.com/convert")

        If Loading(WebBrowserRead, 6) Then
            Label_DataDate.Text = "載入網頁完成, 嘗試轉換資料..."
        Else
            Label_DataDate.Text = "中斷載入網頁, 嘗試轉換資料..."
        End If

        WebBrowserRead.Document.GetElementById("body_txtUsername").SetAttribute("value", ID)
        WebBrowserRead.Document.GetElementById("body_txtPassword").SetAttribute("value", PW)
        WebBrowserRead.Document.GetElementById("body_btnConvert").InvokeMember("click")
        Label_DataDate.Text = "正在等候網頁回應..."

        Delay(2000)

        If Loading(WebBrowserRead, 6) Then
            Label_DataDate.Text = "載入網頁完成, 嘗試截取資料..."
        Else
            Label_DataDate.Text = "中斷載入網頁, 嘗試截取資料..."
        End If
        Application.DoEvents()
        '<span id="body_lblLicenseKey">XXXX-XXXX-XXXX-XXXX-XXXX</span>
        Dim rgx As New Regex("^[A-Z0-9]{4}-[A-Z0-9]{4}-[A-Z0-9]{4}-[A-Z0-9]{4}-[A-Z0-9]{4}$")
        Dim result As String = ""
        Try
            result = Trim(WebBrowserRead.Document.GetElementById("body_lblLicenseKey").OuterText)
            If (Not result = "") And rgx.IsMatch(result) Then
                Return result
            Else
                Return ""
            End If
        Catch ex As Exception
            Return ""
        End Try
    End Function

    Private Sub MainForm_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        WebBrowserRead.ScriptErrorsSuppressed = True
        Me.MaximizeBox = False
        Label_msgOutput.Text = ""
    End Sub

    Private Sub Button_GetData_Click(sender As System.Object, e As System.EventArgs) Handles Button_GetData.Click
        GetData(DataDateChoose.Value.ToString)
    End Sub

    Private Sub DBList_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles DBList.SelectedIndexChanged
        Button_CopyID.Enabled = True
        Button_CopyPW.Enabled = True
        Dim rgx As New Regex("^[A-Z0-9]{4}-[A-Z0-9]{4}-[A-Z0-9]{4}-[A-Z0-9]{4}-[A-Z0-9]{4}$")
        Button_CopyKey.Enabled = rgx.IsMatch(DBList.FocusedItem.SubItems(3).Text)
    End Sub

    Private Sub Button_CopyID_Click(sender As System.Object, e As System.EventArgs) Handles Button_CopyID.Click
        CopyTextToClipboard(DBList.FocusedItem.SubItems(1).Text)
    End Sub

    Private Sub Button_CopyPW_Click(sender As System.Object, e As System.EventArgs) Handles Button_CopyPW.Click
        CopyTextToClipboard(DBList.FocusedItem.SubItems(2).Text)
    End Sub

    Private Sub Button_CopyKey_Click(sender As Object, e As EventArgs) Handles Button_CopyKey.Click
        CopyTextToClipboard(DBList.FocusedItem.SubItems(3).Text)
    End Sub

    Private Sub Timer_UI_Tick(sender As Object, e As EventArgs) Handles Timer_UI.Tick
        If CleanMsgCountdown > 0 Then
            CleanMsgCountdown -= 1
        Else
            Label_msgOutput.Text = ""
            CleanMsgCountdown = 0
            Timer_UI.Enabled = False
        End If
    End Sub

    Private Sub OpenWebpage(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked, LinkLabel2.LinkClicked, LinkLabel3.LinkClicked
        Try
            Process.Start(CType(sender, LinkLabel).Tag.ToString)
        Catch ex As Exception
        End Try
    End Sub
End Class
