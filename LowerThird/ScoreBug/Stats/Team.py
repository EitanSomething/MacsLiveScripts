
import requests
import time
import sys
import xml.etree.ElementTree as ET 

tree = ET.parse("../DataFiles/GameStats.xml") 
root = tree.getroot() 
vmix_url = "http://127.0.0.1:8088/api/"

def _add_scorebug_stats(root):
    if len(sys.argv) > 1:
        arg = sys.argv[1]
        if arg == "3PT":
            _team_3PT(root)
        elif arg == "2PT":
            _team_2PT(root)
        elif arg == "Rebounds":
            _team_rebounds(root)
        elif arg == "Assist":
            _team_assists(root)
        else: 
            return
    transition_in()

# Function to send a command to vMix
def send_vmix_command(function, **params):
    try:
        response = requests.get(vmix_url, params={ "Function": function, **params })
        response.raise_for_status()  # Raise HTTPError for bad responses (4xx or 5xx)
        print(f"vMix command '{function}' successful.")
    except requests.exceptions.RequestException as e:
        print(f"Error sending vMix command '{function}': {e}")

def transition_in():
    send_vmix_command("TitleBeginAnimation", Input:="TeamStatsScoreBug", Value:="TransitionIn")
    time.sleep(0.1)
    send_vmix_command("LayerOn", Input:="ScoreBug",  Value:="1")

def _team_3PT(root):
    Vfg3 = ""
    Hfg3 = ""
    for team in root.findall("./team"):
        V = True if team.attrib.get("vh") == "V" else False
        team = team.find("./totals/" )
        if V:
            Vfg3 = team.attrib.get("fgm3") + "/" + team.attrib.get("fga3")
        else:
            Hfg3 = team.attrib.get("fgm3") + "/" + team.attrib.get("fga3")
    send_vmix_command("SetText", Input="TeamStatsScoreBug", SelectedName="Title", Value="3-Point Field Goals")
    send_vmix_command("SetText", Input="TeamStatsScoreBug", SelectedName="AwayStat", Value=Vfg3)
    send_vmix_command("SetText", Input="TeamStatsScoreBug", SelectedName="HomeStat", Value=Hfg3)
    
def _team_2PT(root):
    Vfg = ""
    Hfg = ""
    for team in root.findall("./team"):
        V = True if team.attrib.get("vh") == "V" else False
        team = team.find("./totals/" )
        if V:
            tmp_fg = team.attrib.get("fgm")
            tmp_fg3 = team.attrib.get("fgm3")
            Vfg = str(int(tmp_fg)-int(tmp_fg3)) + "/"
            tmp_fg = team.attrib.get("fga")
            tmp_fg3 = team.attrib.get("fga3")
            Vfg += str(int(tmp_fg)-int(tmp_fg3))
        else:
            tmp_fg = team.attrib.get("fgm")
            tmp_fg3 = team.attrib.get("fgm3")
            Hfg = str(int(tmp_fg)-int(tmp_fg3)) + "/"
            tmp_fg = team.attrib.get("fga")
            tmp_fg3 = team.attrib.get("fga3")
            Hfg += str(int(tmp_fg)-int(tmp_fg3))

    send_vmix_command("SetText", Input="TeamStatsScoreBug", SelectedName="Title", Value="3-Point Field Goals")
    send_vmix_command("SetText", Input="TeamStatsScoreBug", SelectedName="AwayStat", Value=Vfg)
    send_vmix_command("SetText", Input="TeamStatsScoreBug", SelectedName="HomeStat", Value=Hfg)

    
def _team_rebounds(root):
    VRebounds = ""
    HRebounds = ""
    for team in root.findall("./team"):
        V = True if team.attrib.get("vh") == "V" else False
        team = team.find("./totals/" )
        if V: 
            VRebounds = team.attrib.get("treb")
        else:
            HRebounds = team.attrib.get("treb")
    send_vmix_command("SetText", Input="TeamStatsScoreBug", SelectedName="Title", Value="Rebounds")
    send_vmix_command("SetText", Input="TeamStatsScoreBug", SelectedName="AwayStat", Value=VRebounds)
    send_vmix_command("SetText", Input="TeamStatsScoreBug", SelectedName="HomeStat", Value=HRebounds)
def _team_assists(root):
    VAssists = ""
    HAssists = ""
    for team in root.findall("./team"):
        V = True if team.attrib.get("vh") == "V" else False
        team = team.find("./totals/" )
        if V: 
            VAssists = team.attrib.get("ast")
        else:
            HAssists = team.attrib.get("ast")
    send_vmix_command("SetText", Input="TeamStatsScoreBug", SelectedName="Title", Value="Rebounds")
    send_vmix_command("SetText", Input="TeamStatsScoreBug", SelectedName="AwayStat", Value=VAssists)
    send_vmix_command("SetText", Input="TeamStatsScoreBug", SelectedName="HomeStat", Value=HAssists)

_add_scorebug_stats(root)