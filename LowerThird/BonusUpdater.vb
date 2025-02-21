dim VmixXML as new system.xml.xmlDocument
VmixXML.loadxml(API.XML)
dim HomeFoulsNum as Int32  = 0
dim AwayFoulsNum as Int32  = 0
dim HomeTimeoutsNum as Int32  = 0
dim AwayTimeoutsNum as Int32  = 0

Do While True
    VmixXML.loadxml(API.XML)
    HomeFoulsNum = Convert.toInt32(VmixXML.SelectSingleNode("//input[@title='Scorebug']/text[@name='HomeFoulsNum.Text']").InnerXML)
    AwayFoulsNum = Convert.toInt32(VmixXML.SelectSingleNode("//input[@title='Scorebug']/text[@name='AwayFoulsNum.Text']").InnerXML)
    HomeTimeoutsNum = Convert.toInt32(VmixXML.SelectSingleNode("//input[@title='Scorebug']/text[@name='HomeTimeoutsNum.Text']").InnerXML)
    AwayTimeoutsNum = Convert.toInt32(VmixXML.SelectSingleNode("//input[@title='Scorebug']/text[@name='AwayTimeoutsNum.Text']").InnerXML)

    If HomeFoulsNum = 10
        API.Function("SetText", Input:="Scorebug", SelectedName :="AwayBonusShow.Text", Value:="Bonus+")
    Else If HomeFoulsNum>=7
        API.Function("SetText", Input:="Scorebug", SelectedName :="AwayBonusShow.Text", Value:="Bonus")
    Else
        API.Function("SetText", Input:="Scorebug", SelectedName :="AwayBonusShow.Text", Value:="")
    End If
    If AwayFoulsNum = 10
        API.Function("SetText", Input:="Scorebug", SelectedName :="HomeBonusShow.Text", Value:="Bonus+")
    Else If AwayFoulsNum >=7
        API.Function("SetText", Input:="Scorebug", SelectedName :="HomeBonusShow.Text", Value:="Bonus")
    Else
        API.Function("SetText", Input:="Scorebug", SelectedName :="HomeBonusShow.Text", Value:="")
    End If

    dim HomeTimeouts as string = ""
    For index As Int32  = 1 To HomeTimeoutsNum
        If index>1       
         HomeTimeouts = HomeTimeouts + " "
        End If
        HomeTimeouts = HomeTimeouts + "_"
    Next index
    API.Function("SetText", Input:="Scorebug", SelectedName :="HomeTimeouts.Text", Value:=HomeTimeouts)
    dim AwayTimeouts as string = ""
    For index As Int32  = 1 To AwayTimeoutsNum
        If index>1       
         AwayTimeouts = AwayTimeouts + " "
        End If
        AwayTimeouts = AwayTimeouts + "_"
    Next index
    API.Function("SetText", Input:="Scorebug", SelectedName :="AwayTimeouts.Text", Value:=AwayTimeouts)

    API.Function("SetTextVisibleOn", Input:="Scorebug", SelectedName:="AwayFoulsNum.Text")
    API.Function("SetTextVisibleOn", Input:="Scorebug", SelectedName:="AwayFouls.Text")
    API.Function("SetTextVisibleOn", Input:="Scorebug", SelectedName:="HomeFoulsNum.Text")
    API.Function("SetTextVisibleOn", Input:="Scorebug", SelectedName:="HomeFouls.Text")
Sleep(500)
Loop
