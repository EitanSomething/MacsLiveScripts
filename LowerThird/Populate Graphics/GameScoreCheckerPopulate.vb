dim GraphicFolder as String  ="C:\Users\MacsLive\Documents\BroadcastFiles\Graphics\Scoreboards\2024-25\"

dim TeamData as new system.xml.xmlDocument
Dim fs = new FileStream("C:\Users\MacsLive\Documents\BroadcastFiles\DataFiles\TeamData.xml", FileMode.Open, FileAccess.Read)
TeamData.Load(fs)

dim HomeSchoolFolder as String = TeamData.selectSingleNode("/Teams/HomeGameScoreChecker").InnerXML
dim AwaySchoolFolder as String = TeamData.selectSingleNode("/Teams/AwayGameScoreChecker").InnerXML

dim AwayColor as String = TeamData.selectSingleNode("/Teams/" & AwaySchoolFolder  &"/AwayColors/color").InnerXML
dim AwayContrastColor as String= TeamData.selectSingleNode("/Teams/" & AwaySchoolFolder  &"/AwayColors/contrastColor").InnerXML

dim HomeColor as String = TeamData.selectSingleNode("/Teams/" & HomeSchoolFolder  &"/HomeColors/color").InnerXML
dim HomeContrastColor as String= TeamData.selectSingleNode("/Teams/" & HomeSchoolFolder  &"/HomeColors/contrastColor").InnerXML


API.Function("SetColor", Input:="GameScoreChecker", SelectedName :="Home Color.Fill.Color", Value:=HomeColor)
API.Function("SetColor", Input:="GameScoreChecker", SelectedName :="Away Color.Fill.Color", Value:=AwayColor)

API.Function("SetColor", Input:="GameScoreChecker", SelectedName :="Home Contrast.Fill.Color", Value:=HomeContrastColor)
API.Function("SetColor", Input:="GameScoreChecker", SelectedName :="Away Contrast.Fill.Color", Value:=AwayContrastColor)

API.Function("SetImage", Input:="GameScoreChecker", SelectedName :="Home Logo.Source", Value:=GraphicFolder &  "Default-ScoreBug.png")
API.Function("SetImage", Input:="GameScoreChecker", SelectedName :="Away Logo.Source",Value:=GraphicFolder & "Default-ScoreBug.png")
Sleep(1000)
API.Function("SetImage", Input:="GameScoreChecker", SelectedName :="Home Logo.Source", Value:=GraphicFolder & HomeSchoolFolder & "\" & HomeSchoolFolder & "-ScoreBug.png")
API.Function("SetImage", Input:="GameScoreChecker", SelectedName :="Away Logo.Source",Value:=GraphicFolder & AwaySchoolFolder & "\" & AwaySchoolFolder & "-ScoreBug.png")

dim HomeSchoolFolder2 as String = TeamData.selectSingleNode("/Teams/HomeGameScoreChecker2").InnerXML
dim AwaySchoolFolder2 as String = TeamData.selectSingleNode("/Teams/AwayGameScoreChecker2").InnerXML

dim AwayColor2 as String = TeamData.selectSingleNode("/Teams/" & AwaySchoolFolder2  &"/AwayColors/color").InnerXML
dim AwayContrastColor2 as String= TeamData.selectSingleNode("/Teams/" & AwaySchoolFolder2  &"/AwayColors/contrastColor").InnerXML

dim HomeColor2 as String = TeamData.selectSingleNode("/Teams/" & HomeSchoolFolder2  &"/HomeColors/color").InnerXML
dim HomeContrastColor2 as String= TeamData.selectSingleNode("/Teams/" & HomeSchoolFolder2  &"/HomeColors/contrastColor").InnerXML


API.Function("SetColor", Input:="GameScoreChecker2", SelectedName :="Home Color.Fill.Color", Value:=HomeColor2)
API.Function("SetColor", Input:="GameScoreChecker2", SelectedName :="Away Color.Fill.Color", Value:=AwayColor2)

API.Function("SetColor", Input:="GameScoreChecker2", SelectedName :="Home Contrast.Fill.Color", Value:=HomeContrastColor2)
API.Function("SetColor", Input:="GameScoreChecker2", SelectedName :="Away Contrast.Fill.Color", Value:=AwayContrastColor2)

API.Function("SetImage", Input:="GameScoreChecker2", SelectedName :="Home Logo.Source", Value:=GraphicFolder &  "Default-ScoreBug.png")
API.Function("SetImage", Input:="GameScoreChecker2", SelectedName :="Away Logo.Source",Value:=GraphicFolder & "Default-ScoreBug.png")
Sleep(1000)
API.Function("SetImage", Input:="GameScoreChecker2", SelectedName :="Home Logo.Source", Value:=GraphicFolder & HomeSchoolFolder2 & "\" & HomeSchoolFolder2 & "-ScoreBug.png")
API.Function("SetImage", Input:="GameScoreChecker2", SelectedName :="Away Logo.Source",Value:=GraphicFolder & AwaySchoolFolder2 & "\" & AwaySchoolFolder & "-ScoreBug.png")