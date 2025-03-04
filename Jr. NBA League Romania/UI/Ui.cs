using Jr._NBA_League_Romania.Service;

namespace Jr._NBA_League_Romania.UI;

public class Ui
{
    private readonly MainService _mainService = new();
    
    private bool _finished;
    private readonly Dictionary<string, Delegate> _events = new();

    public Ui()
    {
        _finished = false;
        
        _events["exit"] = Exit;
        _events["help"] = Help;
        _events["show players from team"] = ShowPlayersTeam;
        _events["show players from game"] = ShowPlayersGame;
        _events["show games"] = ShowGames;
        _events["show score"] = ShowScore;
        _events["save team"] = SaveTeam;
        _events["save game"] = SaveGame;
    }

    public void Run()
    {
        Console.WriteLine("Welcome to JR NBA League Romania");
        Console.WriteLine("Type 'help' if you want to see the list of events");
        Console.WriteLine();
        
        while (!_finished)
        {
            Console.Write(">>> ");
            var cmd = Console.ReadLine()!.Trim();
            Console.WriteLine();

            if (!_events.TryGetValue(cmd, out var @event))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                
                Console.WriteLine($"Event '{cmd}' does not exist");
                Console.WriteLine();
                
                Console.ResetColor();
                
                continue;
            }
            
            try
            {
                @event.DynamicInvoke();
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                
                Console.WriteLine();
                Console.WriteLine(e.InnerException!.Message);
                Console.WriteLine();
                
                Console.ResetColor();
            }
        }
    }

    private void Exit()
    {
        _finished = true;
    }

    private static void Help()
    {
        Console.WriteLine("Type 'exit' to exit");
        Console.WriteLine("Type 'help' to see the list of events");
        Console.WriteLine("Type 'show players from team' to show players from a team");
        Console.WriteLine("Type 'show players from game' to show players from a game");
        Console.WriteLine("Type 'show games' to show games from a period of time");
        Console.WriteLine("Type 'show score' to show score of a game");
        Console.WriteLine();
    }

    private void ShowPlayersTeam()
    {
        Console.Write("Enter team name: ");
        var teamName = Console.ReadLine();

        var players = _mainService.GetAllPlayersByTeam(teamName!);

        Console.WriteLine();
        byte index = 1;
        foreach (var player in players)
        {
            Console.WriteLine($"{index}. {player.Name}");
            index++;
        }
        Console.WriteLine();
    }

    private void ShowPlayersGame()
    {
        Console.Write("Enter team 1: ");
        var team1Name = Console.ReadLine();
        
        Console.Write("Enter team 2: ");
        var team2Name = Console.ReadLine();
        
        Console.Write("From which team would you like to see the players?(enter name): ");
        var teamName = Console.ReadLine();
        
        var players = _mainService.GetAllActivePlayersByTeamAndGame(teamName!, team1Name!, team2Name!);

        Console.WriteLine();
        byte index = 1;
        foreach (var player in players)
        {
            Console.WriteLine($"{index}. {player.Item2.Name} - {player.Item1.ActivePlayerType} - {player.Item1.NrPointsScored}");
            index++;
        }
        Console.WriteLine();
    }

    private void ShowGames()
    {
        Console.WriteLine("Format for date must be dd-MM-yyyy");
        Console.Write("Enter starting date: ");
        var startDate = DateTime.ParseExact(Console.ReadLine()!, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture);
        
        Console.Write("Enter ending date: ");
        var endDate = DateTime.ParseExact(Console.ReadLine()!, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture);
        
        var games = _mainService.GetAllGamesBetweenDates(startDate, endDate).ToList();
        
        Console.WriteLine();
        
        if (games.Count == 0)
        {
            Console.WriteLine("No games found");
            Console.WriteLine();
            return;
        }

        byte index = 1;
        foreach (var game in games)
        {
            Console.WriteLine($"{index}. {game.Item2.Item1.Name} - {game.Item2.Item2.Name} {game.Item1.DateTime}");
            index++;
        }
        Console.WriteLine();
    }

    private void ShowScore()
    {
        Console.Write("Enter team 1: ");
        var team1Name = Console.ReadLine();
        
        Console.Write("Enter team 2: ");
        var team2Name = Console.ReadLine();
        
        var score = _mainService.GetGameScore(team1Name!, team2Name!);
        
        Console.WriteLine();
        Console.WriteLine($"{team1Name} {score.Item1} - {score.Item2} {team2Name}");
        Console.WriteLine();
    }

    private void SaveTeam()
    {
        Console.Write("Enter team name: ");
        var teamName = Console.ReadLine()!;
        
        Console.Write("Enter school name: ");
        var schoolName = Console.ReadLine()!;
        
        Console.WriteLine();
        
        _mainService.SaveTeam(teamName, schoolName);
    }

    private void SaveGame()
    {
        Console.Write("Enter first team name: ");
        var team1Name = Console.ReadLine()!;
        
        Console.Write("Enter second team name: ");
        var team2Name = Console.ReadLine()!;
        
        Console.Write("Enter date and time(format dd-MM-yyyy HH:mm): ");
        var dateAndTime = Console.ReadLine()!;
        
        Console.WriteLine();
        
        _mainService.SaveGame(team1Name, team2Name, dateAndTime);
    }
}