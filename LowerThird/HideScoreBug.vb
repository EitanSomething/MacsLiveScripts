API.Function("SetTextVisibleOff", Input:="Scorebug", SelectedName:="RevealAwayName.Text")
API.Function("SetTextVisibleOff", Input:="Scorebug", SelectedName:="RevealHomeName.Text")
API.Function("SetTextVisibleOff", Input:="Scorebug", SelectedName:="Away Name.Text")
API.Function("SetTextVisibleOff", Input:="Scorebug", SelectedName:="Home Name.Text")
Sleep(100)
API.Function("TitleBeginAnimation", Input:="Scorebug", Value:="TransitionOut")
Sleep(1200)
API.Function("LayerOff", Input:="Lower Third",  Value:="1")



