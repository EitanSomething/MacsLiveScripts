dim HomeTeamColor as String
dim GraphicFolder as String  ="C:\Users\MacsLive\Documents\BroadcastFiles\Graphics\Scoreboards\2024-25\"

dim TeamData as new system.xml.xmlDocument
Dim fs = new FileStream("C:\Users\MacsLive\Documents\BroadcastFiles\DataFiles\TeamData.xml", FileMode.Open, FileAccess.Read)
TeamData.Load(fs)
dim GameLocation as String = TeamData.selectSingleNode("/Teams/Location").InnerXML

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

dim AwayColor as String = TeamData.selectSingleNode("/Teams/" & AwaySchoolFolder  &"/AwayColors/color").InnerXML
dim AwayContrastColor as String= TeamData.selectSingleNode("/Teams/" & AwaySchoolFolder  &"/AwayColors/contrastColor").InnerXML
dim AwayRank as String = TeamData.selectSingleNode("/Teams/" & AwaySchoolFolder  &"/rank").InnerXML


dim AwayWins as String = TeamData.selectSingleNode("/Teams/" & AwaySchoolFolder  & "/wins").InnerXML
dim AwayLosses as String = TeamData.selectSingleNode("/Teams/" & AwaySchoolFolder  & "/losses").InnerXML
dim AwayConfRecord as String = TeamData.selectSingleNode("/Teams/" & AwaySchoolFolder & "/ConfRecord").InnerXML
dim AwayRecord as String = "(" & AwayWins & "-" & AwayLosses & AwayConfRecord & ")"

dim AwayTeamName as String = TeamData.selectSingleNode("/Teams/" & AwaySchoolFolder & "/TeamName").InnerXML
dim AwaySchoolName as String = TeamData.selectSingleNode("/Teams/" & AwaySchoolFolder  & "/SchoolName").InnerXML
dim AwaySchoolAbbreviation as String = TeamData.selectSingleNode("/Teams/" & AwaySchoolFolder  & "/SchoolAbbreviation").InnerXML

API.Function("SetText", Input:="Scorebug", SelectedName :="RevealAwayName.Text", Value:=HomeSchoolName)
API.Function("SetText", Input:="Scorebug", SelectedName :="Home Name.Text", Value:=HomeSchoolName)
API.Function("SetText", Input:="Scorebug", SelectedName :="Home Team Name.Text", Value:=HomeSchoolName)


API.Function("SetText", Input:="Scorebug", SelectedName :="RevealHomeName.Text", Value:=AwaySchoolName)
API.Function("SetText", Input:="Scorebug", SelectedName :="Away Name.Text", Value:=AwaySchoolName)
API.Function("SetText", Input:="Scorebug", SelectedName :="Away Team Name.Text", Value:=AwaySchoolName)


API.Function("SetText", Input:="Scorebug", SelectedName :="Home Record.Text", Value:=HomeRecord)
API.Function("SetText", Input:="Scorebug", SelectedName :="Away Record.Text", Value:=AwayRecord)

API.Function("SetText", Input:="Scorebug", SelectedName :="Away Ranking.Text", Value:=AwayRank)

API.Function("SetColor", Input:="Scorebug", SelectedName :="Home Color.Fill.Color", Value:=HomeColor)
API.Function("SetColor", Input:="Scorebug", SelectedName :="Away Color.Fill.Color", Value:=AwayColor)
API.Function("SetColor", Input:="Scorebug", SelectedName :="Home Contrast.Fill.Color", Value:=HomeContrastColor)
API.Function("SetColor", Input:="Scorebug", SelectedName :="Away Contrast.Fill.Color", Value:=AwayContrastColor)

API.Function("SetImage", Input:="Scorebug", SelectedName :="Home Logo.Source", Value:=GraphicFolder &  "Default-ScoreBug.png")
API.Function("SetImage", Input:="Scorebug", SelectedName :="Away Logo.Source",Value:=GraphicFolder & "Default-ScoreBug.png")
Sleep(1000)
API.Function("SetImage", Input:="Scorebug", SelectedName :="Home Logo.Source", Value:=GraphicFolder & HomeSchoolFolder & "\" & HomeSchoolFolder & "-ScoreBug.png")
API.Function("SetImage", Input:="Scorebug", SelectedName :="Away Logo.Source",Value:=GraphicFolder & AwaySchoolFolder & "\" & AwaySchoolFolder & "-ScoreBug.png")

API.Function("SetColor", Input:="Opener Graphic", SelectedName :="Home Color.Fill.Color", Value:=HomeColor)
API.Function("SetColor", Input:="Opener Graphic", SelectedName :="Away Color.Fill.Color", Value:=AwayColor)
API.Function("SetColor", Input:="Opener Graphic", SelectedName :="Home Contrast.Fill.Color", Value:=HomeContrastColor)
API.Function("SetColor", Input:="Opener Graphic", SelectedName :="Away Contrast.Fill.Color", Value:=AwayContrastColor)


API.Function("SetImage", Input:="Opener Graphic", SelectedName :="Home Logo.Source", Value:=GraphicFolder & "Default-Opener.png")
API.Function("SetImage", Input:="Opener Graphic", SelectedName :="Away Logo.Source",Value:=GraphicFolder & "Default-Opener.png")
Sleep(1000)

API.Function("SetImage", Input:="Opener Graphic", SelectedName :="Home Logo.Source", Value:=GraphicFolder & HomeSchoolFolder & "\" & HomeSchoolFolder & "-Opener.png")
API.Function("SetImage", Input:="Opener Graphic", SelectedName :="Away Logo.Source",Value:=GraphicFolder & AwaySchoolFolder & "\" &AwaySchoolFolder & "-Opener.png")
API.Function("SetText", Input:="Opener Graphic", SelectedName :="Home Record.Text", Value:=HomeRecord)
API.Function("SetText", Input:="Opener Graphic", SelectedName :="Away Record.Text", Value:=AwayRecord)
API.Function("SetText", Input:="Opener Graphic", SelectedName :="HomeSchoolName.Text", Value:=HomeSchoolAbbreviation)
API.Function("SetText", Input:="Opener Graphic", SelectedName :="AwaySchoolName.Text", Value:=AwaySchoolAbbreviation)
API.Function("SetText", Input:="Opener Graphic", SelectedName :="HomeTeamName.Text", Value:=HomeTeamName)
API.Function("SetText", Input:="Opener Graphic", SelectedName :="AwayTeamName.Text", Value:=AwayTeamName)
API.Function("SetText", Input:="Opener Graphic", SelectedName :="Game Location.Text", Value:=GameLocation)

API.Function("SetImage", Input:="Half/Final Graphic", SelectedName :="Home Logo.Source", Value:=GraphicFolder & "Default-Opener.png")
API.Function("SetImage", Input:="Half/Final Graphic", SelectedName :="Away Logo.Source",Value:=GraphicFolder & "Default-Opener.png")
Sleep(1000)

API.Function("SetImage", Input:="Half/Final Graphic", SelectedName :="Home Logo.Source", Value:=GraphicFolder & HomeSchoolFolder & "\" & HomeSchoolFolder & "-Opener.png")
API.Function("SetImage", Input:="Half/Final Graphic", SelectedName :="Away Logo.Source",Value:=GraphicFolder & AwaySchoolFolder & "\" &AwaySchoolFolder & "-Opener.png")

API.Function("SetColor", Input:="Half/Final Graphic", SelectedName :="Home Color.Fill.Color", Value:=HomeColor)
API.Function("SetColor", Input:="Half/Final Graphic", SelectedName :="Away Color.Fill.Color", Value:=AwayColor)
API.Function("SetColor", Input:="Half/Final Graphic", SelectedName :="Home Contrast.Fill.Color", Value:=HomeContrastColor)
API.Function("SetColor", Input:="Half/Final Graphic", SelectedName :="Away Contrast.Fill.Color", Value:=AwayContrastColor)

API.Function("SetText", Input:="Half/Final Graphic", SelectedName :="Away Name.Text", Value:=AwaySchoolAbbreviation & " " & AwayTeamName)
API.Function("SetText", Input:="Half/Final Graphic", SelectedName :="Home Name.Text", Value:=HomeSchoolAbbreviation  & " " & HomeTeamName)

API.Function("SetText", Input:="Half/Final Graphic", SelectedName :="Away Record.Text", Value:=AwayRecord)
API.Function("SetText", Input:="Half/Final Graphic", SelectedName :="Home Record.Text", Value:=HomeRecord)

dim Half as String = "HalfTime"
API.Function("SetText", Input:="Half/Final Graphic", SelectedName :="Half Text.Text", Value:=Half)

API.Function("LayerOff", Input:="Lower Third",  Value:="1")
API.Function("LayerOff", Input:="Lower Third",  Value:="2")


API.Function("SetColor", Input:="Half Stats Graphic", SelectedName :="Home Color.Fill.Color", Value:=HomeColor)
API.Function("SetColor", Input:="Half Stats Graphic", SelectedName :="Away Color.Fill.Color", Value:=AwayColor)
API.Function("SetColor", Input:="Half Stats Graphic", SelectedName :="Home Contrast.Fill.Color", Value:=HomeContrastColor)
API.Function("SetColor", Input:="Half Stats Graphic", SelectedName :="Away Contrast.Fill.Color", Value:=AwayContrastColor)
API.Function("SetText", Input:="Half Stats Graphic", SelectedName :="Home Name.Text", Value:=HomeSchoolAbbreviation)
API.Function("SetText", Input:="Half Stats Graphic", SelectedName :="Away Name.Text", Value:=AwaySchoolAbbreviation)

API.Function("SetImage", Input:="Half Stats Graphic", SelectedName :="Home Logo.Source", Value:=GraphicFolder & "Default-Stats.png")
API.Function("SetImage", Input:="Half Stats Graphic", SelectedName :="Away Logo.Source",Value:=GraphicFolder & "Default-Stats.png")
Sleep(1000)

API.Function("SetImage", Input:="Half Stats Graphic", SelectedName :="Home Logo.Source", Value:=GraphicFolder & HomeSchoolFolder & "\" & HomeSchoolFolder & "-Stats.png")
API.Function("SetImage", Input:="Half Stats Graphic", SelectedName :="Away Logo.Source",Value:=GraphicFolder & AwaySchoolFolder & "\" &AwaySchoolFolder & "-Stats.png")