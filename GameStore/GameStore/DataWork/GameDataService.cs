using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.IO;
using System.Text.Json;
using System.Text.Unicode;
using System.Text.Encodings.Web;

namespace GameStore.DataWork
{
    static class GameDataService
    {

        public static string FILE_PATH = "D:\\GIT\\GameStore\\GameStore\\GameStore\\Data\\data.json";
        public static JsonSerializerOptions JSON_OPTIONS = new JsonSerializerOptions
        {
            Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
            WriteIndented = true
        };

        public static void AddGame(Game newGame)
        {
            try
            {
                using (StreamWriter jsonFile = new StreamWriter(FILE_PATH, true))
                {
                    string jsonDataAboutGame = JsonSerializer.Serialize<Game>(newGame, JSON_OPTIONS);
                    jsonFile.WriteLine(jsonDataAboutGame);
                }
            }
            catch (IOException e)
            {
                MessageBox.Show(e.Message + e.StackTrace);
            }
        } 
        public static void ClearFile()
        {
            try
            {
                using (StreamWriter jsonFile = new StreamWriter(FILE_PATH))
                {
                    jsonFile.WriteLine("");
                }
            }
            catch (IOException e)
            {
                MessageBox.Show(e.Message + e.StackTrace);
            }
        }
        public static List<Game> FindAll()
        {
            List<Game> games = new List<Game>();
            try
            {
                using (StreamReader jsonFile = new StreamReader(FILE_PATH))
                {
                    string bufForJsonString = "";
                    int semicolonCount = 0;
                    while (!jsonFile.EndOfStream)
                    {
                        bufForJsonString += jsonFile.ReadLine();
                        if (bufForJsonString.Length > 0 && bufForJsonString.Last() == '}')
                            semicolonCount++;
                        if (semicolonCount == 2)
                        {
                            semicolonCount = 0;
                            Game game = JsonSerializer.Deserialize<Game>(bufForJsonString);
                            bufForJsonString = "";
                            games.Add(game);
                        }
                    }
                }
            }
            catch (IOException e)
            {
                MessageBox.Show(e.Message + e.StackTrace);
            }
            return games;
        }
        public static List<Game> FindByName(string findName)
        {
            try
            {
                List<Game> resultGames = new List<Game>();
                List<Game> games = FindAll();

                if (games.Count > 0)
                {
                    foreach (var c in games)
                    {
                        if (c.FullName.Contains(findName))
                        {
                            resultGames.Add(c);
                        }
                    }
                }

                return resultGames;
            }
            catch (IOException e)
            {
                MessageBox.Show(e.Message + e.StackTrace);
            }
            return null;
        }
        public static bool RemoveGame(Game game)
        {
            try
            {
                List<Game> games = FindAll();
                if (games.Remove(game))
                {
                    ClearFile();
                    foreach (var c in games) 
                    {
                        AddGame(c);
                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (IOException e)
            {
                MessageBox.Show(e.Message + e.StackTrace);
            }
            return false;
        }
        public static bool  UpdateDataAboutGame(Game baseData, Game newData)
        {
            try
            {
                if (RemoveGame(baseData))
                {
                    AddGame(newData);
                    return true;
                }
                else 
                {
                    return false;
                }
            }
            catch (IOException e)
            {
                MessageBox.Show(e.Message + e.StackTrace);
            }
            return false;
        }
    }
}
