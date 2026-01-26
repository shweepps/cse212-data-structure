/*
 * CSE 212 Lesson 6C 
 * 
 * This code will analyze the NBA basketball data and create a table showing
 * the players with the top 10 career points.
 * 
 * Note about columns:
 * - Player ID is in column 0
 * - Points is in column 8
 * 
 * Each row represents the player's stats for a single season with a single team.
 */

using Microsoft.VisualBasic.FileIO;

public class Basketball
{
    public static void Run()
    {
        var players = new Dictionary<string, int>();

        using var reader = new TextFieldParser("basketball.csv");
        reader.TextFieldType = FieldType.Delimited;
        reader.SetDelimiters(",");

        reader.ReadFields(); 

        while (!reader.EndOfData)
        {
            var fields = reader.ReadFields()!;
            var playerId = fields[0];
            var points = int.Parse(fields[8]);

            // Build the map: playerId>totalPoints
            if (players.ContainsKey(playerId))
                players[playerId] += points;
            else
                players[playerId] = points;
        }

        //  (descending list)
        var sorted = players
            .OrderByDescending(kvp => kvp.Value)
            .ToArray();

        Console.WriteLine("Top 10 Players by Career Points");
        Console.WriteLine("-------------------------------");
        Console.WriteLine("Rank\tPlayerId\tTotalPoints");

        // display the top 10
        var topPlayers = new string[10];
        for (int i = 0; i < 10 && i < sorted.Length; i++)
        {
            topPlayers[i] = sorted[i].Key;
            Console.WriteLine($"{i + 1}\t{sorted[i].Key}\t\t{sorted[i].Value}");
        }


    }
}