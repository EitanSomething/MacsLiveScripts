dim HomeColorColor as String
dim AwayColorColor as String
dim BackColor as String

dim VmixXML as new system.xml.xmlDocument
VmixXML.loadxml(API.XML)
API.Function("SetTextVisibleOff", Input:="Scorebug", SelectedName :="Away Name.Text")
API.Function("SetTextVisibleOff", Input:="Scorebug", SelectedName :="Home Name.Text")
API.Function("SetTextVisibleOn", Input:="Scorebug", SelectedName:="RevealAwayName.Text")
API.Function("SetTextVisibleOn", Input:="Scorebug", SelectedName:="RevealHomeName.Text")
API.Function("TitleBeginAnimation", Input:="Scorebug", Value:="TransitionIn")
API.Function("LayerOff", Input:="Scorebug",  Value:="2")

Sleep(100)
API.Function("LayerOn", Input:="Lower Third",  Value:="1")
Sleep(1200)
API.Function("SetTextVisibleOn", Input:="Scorebug", SelectedName:="Away Name.Text")
API.Function("SetTextVisibleOn", Input:="Scorebug", SelectedName:="Home Name.Text")
API.Function("SetTextVisibleOff", Input:="Scorebug", SelectedName:="RevealAwayName.Text")
API.Function("SetTextVisibleOff", Input:="Scorebug", SelectedName:="RevealHomeName.Text")