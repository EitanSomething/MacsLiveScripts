dim HomeTeamColor as String
dim GraphicFolder as String  ="C:\Users\MacsLive\Documents\BroadcastFiles\Graphics\Scoreboards\2024-25\"

dim TeamData as new system.xml.xmlDocument
Dim fs = new FileStream("C:\Users\MacsLive\Documents\BroadcastFiles\DataFiles\TeamData.xml", FileMode.Open, FileAccess.Read)
TeamData.Load(fs)

dim HomeSchoolFolder as String = TeamData.selectSingleNode("/Teams/Home").InnerXML
dim AwaySchoolFolder as String = TeamData.selectSingleNode("/Teams/Away").InnerXML

dim HomeColor as String = TeamData.selectSingleNode("/Teams/" & HomeSchoolFolder  &"/HomeColors/color").InnerXML
dim HomeContrastColor as String= TeamData.selectSingleNode("/Teams/" & HomeSchoolFolder  &"/HomeColors/contrastColor").InnerXML
dim HomeRank as String = TeamData.selectSingleNode("/Teams/" & HomeSchoolFolder  &"/rank").InnerXML
dim HomeWins as String = TeamData.selectSingleNode("/Teams/" & HomeSchoolFolder  &"/wins").InnerXML
dim HomeLosses as String = TeamData.selectSingleNode("/Teams/" & HomeSchoolFolder  &"/losses").InnerXML
dim HomeConfRecord as String = TeamData.selectSingleNode("/Teams/" & HomeSchoolFolder  &"/ConfRecord").InnerXML
dim HomeRecord as String = "(" & HomeWins & "-" & HomeLosses & HomeConfRecord & ")"

dim HomeTeamName as String = TeamData.selectSingleNode("/Teams/" & HomeSchoolFolder  & "/TeamName").InnerXML
dim HomeSchoolName as String = TeamData.selectSingleNode("/Teams/" & HomeSchoolFolder  & "/SchoolName").InnerXML
dim HomeSchoolAbbreviation as String = TeamData.selectSingleNode("/Teams/" & HomeSchoolFolder  & "/SchoolAbbreviation").InnerXML

API.Function("SetText", Input:="TeamComparison", SelectedName :="Home Name.Text", Value:=HomeSchoolName)


API.Function("SetText", Input:="TeamComparison", SelectedName :="Away Name.Text", Value:=AwaySchoolName)


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