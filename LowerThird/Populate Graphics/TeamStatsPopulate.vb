dim GraphicFolder as String  ="C:\Users\MacsLive\Documents\BroadcastFiles\Graphics\Scoreboards\2024-25\"

dim TeamData as new system.xml.xmlDocument
Dim fs = new FileStream("C:\Users\MacsLive\Documents\BroadcastFiles\DataFiles\TeamData.xml", FileMode.Open, FileAccess.Read)
TeamData.Load(fs)

dim HomeSchoolFolder as String = TeamData.selectSingleNode("/Teams/Home").InnerXML
dim AwaySchoolFolder as String = TeamData.selectSingleNode("/Teams/Away").InnerXML

dim AwayContrastColor as String= TeamData.selectSingleNode("/Teams/" & AwaySchoolFolder  &"/AwayColors/contrastColor").InnerXML

dim HomeContrastColor as String= TeamData.selectSingleNode("/Teams/" & HomeSchoolFolder  &"/HomeColors/contrastColor").InnerXML


API.Function("SetColor", Input:="TeamStatsScoreBug", SelectedName :="Home Contrast.Fill.Color", Value:=HomeContrastColor)
API.Function("SetColor", Input:="TeamStatsScoreBug", SelectedName :="Away Contrast.Fill.Color", Value:=AwayContrastColor)

