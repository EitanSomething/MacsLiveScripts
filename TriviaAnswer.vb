API.Function("SetTextVisibleOn", Input:="Trivia", SelectedName :="Answer.Text")
API.Function("TitleBeginAnimation", Input:="Trivia", Value:="Page1")
Sleep(1000)
API.Function("SetTextVisibleOff", Input:="Trivia", SelectedName :="Question.Text")
