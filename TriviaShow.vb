API.Function("SetTextVisibleOn", Input:="Trivia", SelectedName :="Question.Text")
API.Function("SetTextVisibleOff", Input:="Trivia", SelectedName :="Answer.Text")
Sleep(100)
API.Function("OverlayInput2In", Input:="Trivia")
