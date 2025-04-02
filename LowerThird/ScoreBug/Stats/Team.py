
import requests
import time
import sys
import xml.etree.ElementTree as ET 

tree = ET.parse("C:/Users/MacsLive/Documents/BroadcastFiles/DataFiles/LiveStats/LiveStats.xml") 
root = tree.getroot() 
vmix_url = ""

def _add_scorebug_stats(root):
    if len(sys.argv) > 1:
        arg = sys.argv[1]
        if arg == "3PT":
            _team_3PT(root)
        elif arg == "2PT":
            _team_2PT(root)
        elif arg == "Rebounds":
            _team_rebounds(root)
        elif arg == "Assists":
            _team_assists(root)
        elif arg == "Turnovers":
            _team_turnover(root)
        elif arg == "Steals":
            _team_steals(root)
        elif arg == "Blocks":
            _team_blocks(root)
        elif arg == "FreeThrows":
            _team_free_throws(root)
        else: 
            print("OOps")
            return
        transition_in()

# Function to send a command to vMix
def send_vmix_command(function, **params):
    try:
        response = requests.get(vmix_url, params={ "Function": function, **params })
        response.raise_for_status()  # Raise HTTPError for bad responses (4xx or 5xx)
        # print(f"vMix command '{function}' successful.")
    except requests.exceptions.RequestException as e:
        print(f"Error sending vMix command '{function}': {e}")

def transition_in():
    send_vmix_command("TitleBeginAnimation", Input="TeamStatsScoreBug", Value="TransitionIn")
    time.sleep(0.1)
    send_vmix_command("LayerOn", Input="Scorebug",  Value="2")

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
    send_vmix_command("SetText", Input="TeamStatsScoreBug", SelectedName="Title.Text", Value="3-Point Field Goals")
    send_vmix_command("SetText", Input="TeamStatsScoreBug", SelectedName="AwayStat.Text", Value=Vfg3)
    send_vmix_command("SetText", Input="TeamStatsScoreBug", SelectedName="HomeStat.Text", Value=Hfg3)
    
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

    send_vmix_command("SetText", Input="TeamStatsScoreBug", SelectedName="Title.Text", Value="2-Point Field Goals")
    send_vmix_command("SetText", Input="TeamStatsScoreBug", SelectedName="AwayStat.Text", Value=Vfg)
    send_vmix_command("SetText", Input="TeamStatsScoreBug", SelectedName="HomeStat.Text", Value=Hfg)

    
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
    send_vmix_command("SetText", Input="TeamStatsScoreBug", SelectedName="Title.Text", Value="Rebounds")
    send_vmix_command("SetText", Input="TeamStatsScoreBug", SelectedName="AwayStat.Text", Value=VRebounds)
    send_vmix_command("SetText", Input="TeamStatsScoreBug", SelectedName="HomeStat.Text", Value=HRebounds)
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
    send_vmix_command("SetText", Input="TeamStatsScoreBug", SelectedName="Title.Text", Value="Assists")
    send_vmix_command("SetText", Input="TeamStatsScoreBug", SelectedName="AwayStat.Text", Value=VAssists)
    send_vmix_command("SetText", Input="TeamStatsScoreBug", SelectedName="HomeStat.Text", Value=HAssists)

def _team_turnover(root):
    VTurn = ""
    HTurn = ""
    for team in root.findall("./team"):
        V = True if team.attrib.get("vh") == "V" else False
        team = team.find("./totals/" )
        if V: 
            VTurn = team.attrib.get("to")
        else:
            HTurn = team.attrib.get("to")
    send_vmix_command("SetText", Input="TeamStatsScoreBug", SelectedName="Title.Text", Value="Turnovers")
    send_vmix_command("SetText", Input="TeamStatsScoreBug", SelectedName="AwayStat.Text", Value=VTurn)
    send_vmix_command("SetText", Input="TeamStatsScoreBug", SelectedName="HomeStat.Text", Value=HTurn)

def _team_steals(root):
    VSteals = ""
    HSteals = ""
    for team in root.findall("./team"):
        V = True if team.attrib.get("vh") == "V" else False
        team = team.find("./totals/" )
        if V: 
            VSteals = team.attrib.get("stl")
        else:
            HSteals = team.attrib.get("stl")
    send_vmix_command("SetText", Input="TeamStatsScoreBug", SelectedName="Title.Text", Value="Steals")
    send_vmix_command("SetText", Input="TeamStatsScoreBug", SelectedName="AwayStat.Text", Value=VSteals)
    send_vmix_command("SetText", Input="TeamStatsScoreBug", SelectedName="HomeStat.Text", Value=HSteals)
def _team_blocks(root):
    VBlocks = ""
    HBlocks = ""
    for team in root.findall("./team"):
        V = True if team.attrib.get("vh") == "V" else False
        team = team.find("./totals/" )
        if V: 
            VBlocks = team.attrib.get("blk")
        else:
            HBlocks = team.attrib.get("blk")
    send_vmix_command("SetText", Input="TeamStatsScoreBug", SelectedName="Title.Text", Value="Blocks")
    send_vmix_command("SetText", Input="TeamStatsScoreBug", SelectedName="AwayStat.Text", Value=VBlocks)
    send_vmix_command("SetText", Input="TeamStatsScoreBug", SelectedName="HomeStat.Text", Value=HBlocks)
def _team_free_throws(root):
    Vft = ""
    Hft = ""
    for team in root.findall("./team"):
        V = True if team.attrib.get("vh") == "V" else False
        team = team.find("./totals/" )
        if V:
            Vft = team.attrib.get("ftm") + "/" + team.attrib.get("fta")
        else:
            Hft = team.attrib.get("ftm") + "/" + team.attrib.get("fta")
    send_vmix_command("SetText", Input="TeamStatsScoreBug", SelectedName="Title.Text", Value="Free Throws")
    send_vmix_command("SetText", Input="TeamStatsScoreBug", SelectedName="AwayStat.Text", Value=Vft)
    send_vmix_command("SetText", Input="TeamStatsScoreBug", SelectedName="HomeStat.Text", Value=Hft)
_add_scorebug_stats(root) 