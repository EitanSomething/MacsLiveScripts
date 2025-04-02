dim HomeTeamColor as String
dim GraphicFolder as String  ="C:\Users\MacsLive\Documents\BroadcastFiles\Graphics\Scoreboards\2024-25\"

dim TeamData as new system.xml.xmlDocument
Dim fs = new FileStream("C:\Users\MacsLive\Documents\BroadcastFiles\DataFiles\TeamData.xml", FileMode.Open, FileAccess.Read)
TeamData.Load(fs)

dim HomeSchoolFolder as String = TeamData.selectSingleNode("/Teams/Home").InnerXML
dim AwaySchoolFolder as String = TeamData.selectSingleNode("/Teams/Away").InnerXML
dim AwayColor as String = TeamData.selectSingleNode("/Teams/" & AwaySchoolFolder  &"/AwayColors/color").InnerXML
dim AwayContrastColor as String= TeamData.selectSingleNode("/Teams/" & AwaySchoolFolder  &"/AwayColors/contrastColor").InnerXML

dim AwayRecord as String = ""

dim HomeColor as String = TeamData.selectSingleNode("/Teams/" & HomeSchoolFolder  &"/HomeColors/color").InnerXML
dim HomeContrastColor as String= TeamData.selectSingleNode("/Teams/" & HomeSchoolFolder  &"/HomeColors/contrastColor").InnerXML
dim HomeRecord as String = ""

dim HomeSchoolName as String = TeamData.selectSingleNode("/Teams/" & HomeSchoolFolder  & "/SchoolName").InnerXML
dim HomeSchoolAbbreviation as String = TeamData.selectSingleNode("/Teams/" & HomeSchoolFolder  & "/SchoolAbbreviation").InnerXML

dim AwaySchoolName as String = TeamData.selectSingleNode("/Teams/" & AwaySchoolFolder  & "/SchoolName").InnerXML
dim AwaySchoolAbbreviation as String = TeamData.selectSingleNode("/Teams/" & AwaySchoolFolder  & "/SchoolAbbreviation").InnerXML

dim HomeWins as String = TeamData.selectSingleNode("/Teams/" & HomeSchoolFolder  & "/wins").InnerXML
dim HomeLosses as String = TeamData.selectSingleNode("/Teams/" & HomeSchoolFolder  & "/losses").InnerXML
dim AwayWins as String = TeamData.selectSingleNode("/Teams/" & AwaySchoolFolder  & "/wins").InnerXML
dim AwayLosses as String = TeamData.selectSingleNode("/Teams/" & AwaySchoolFolder  & "/losses").InnerXML
dim AwayConfWins as String = TeamData.selectSingleNode("/Teams/" & AwaySchoolFolder & "/ConfWins").InnerXML
dim AwayConfLosses as String = TeamData.selectSingleNode("/Teams/" & AwaySchoolFolder & "/ConfLosses").InnerXML
dim AwayConfAbbrev as String = TeamData.selectSingleNode("/Teams/" & AwaySchoolFolder & "/ConfAbbrev").InnerXML
dim AwayConfName as String = TeamData.selectSingleNode("/Teams/" & AwaySchoolFolder & "/ConfName").InnerXML

dim HomeConfWins as String = TeamData.selectSingleNode("/Teams/" & HomeSchoolFolder & "/ConfWins").InnerXML
dim HomeConfLosses as String = TeamData.selectSingleNode("/Teams/" & HomeSchoolFolder & "/ConfLosses").InnerXML
dim HomeConfAbbrev as String = TeamData.selectSingleNode("/Teams/" & HomeSchoolFolder & "/ConfAbbrev").InnerXML
dim HomeConfName as String = TeamData.selectSingleNode("/Teams/" & HomeSchoolFolder & "/ConfName").InnerXML

dim HomeRecord as String = ""
dim AwayRecord as String = ""
If ShowRecords Then
    If ShowConferenceRecord Then
        AwayRecord = "(" & AwayWins & "-" & AwayLosses & ", " & AwayConfWins & "-" & AwayConfLosses & " " & AwayConfAbbrev & ")"
        HomeRecord = "(" & HomeWins & "-" & HomeLosses & ", " & HomeConfWins & "-" & HomeConfLosses & " " & HomeConfAbbrev & ")"

    Else
        AwayRecord = "(" & AwayWins & "-" & AwayLosses & ")"
        HomeRecord = "(" & HomeWins & "-" & HomeLosses & ")"
    End If
End If    
API.Function("SetText", Input:="TeamComparison", SelectedName :="Home Name.Text", Value:=HomeSchoolAbbreviation)

API.Function("SetText", Input:="TeamComparison", SelectedName :="Away Name.Text", Value:=AwaySchoolAbbreviation)


API.Function("SetText", Input:="TeamComparison", SelectedName :="Home Record.Text", Value:=HomeRecord)
API.Function("SetText", Input:="TeamComparison", SelectedName :="Away Record.Text", Value:=AwayRecord)


API.Function("SetColor", Input:="TeamComparison", SelectedName :="Home Color.Fill.Color", Value:=HomeColor)
API.Function("SetColor", Input:="TeamComparison", SelectedName :="Away Color.Fill.Color", Value:=AwayColor)

API.Function("SetColor", Input:="TeamComparison", SelectedName :="Home Contrast.Fill.Color", Value:=HomeContrastColor)
API.Function("SetColor", Input:="TeamComparison", SelectedName :="Away Contrast.Fill.Color", Value:=AwayContrastColor)

API.Function("SetImage", Input:="TeamComparison", SelectedName :="Home Logo.Source", Value:=GraphicFolder &  "Default-ScoreBug.png")
API.Function("SetImage", Input:="TeamComparison", SelectedName :="Away Logo.Source",Value:=GraphicFolder & "Default-ScoreBug.png")
Sleep(1000)
API.Function("SetImage", Input:="TeamComparison", SelectedName :="Home Logo.Source", Value:=GraphicFolder & HomeSchoolFolder & "\" & HomeSchoolFolder & "-Stats.png")
API.Function("SetImage", Input:="TeamComparison", SelectedName :="Away Logo.Source",Value:=GraphicFolder & AwaySchoolFolder & "\" & AwaySchoolFolder & "-Stats.png")
API.Function("SetImage", Input:="TeamComparison", SelectedName :="Away Logo.Source",Value:=GraphicFolder & AwaySchoolFolder & "\" & AwaySchoolFolder & "-Stats.png")