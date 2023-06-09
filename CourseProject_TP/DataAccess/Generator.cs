using Logic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic;
namespace DataAccess
{
    public class Generator
    {
        public static int TournamentsCount { get; } = 10;
        public static int GameSessionsCount { get; } = 10;
        static int PlayersInClubCount { get; } = 15;
        public static int ClubsCount { get; } = 2;
        public static int MaxScoreCount { get; } = 5;
        public static int GameSessionID { get; set; } = 0;
        public static List<Tournament> GenerateTournaments()
        {
            List<Tournament> tournaments = new();
            List<string> firstNames = new() { "Кубок", "Лига", "Чемпионат", "Первенство" };
            List<string> secondNames = new() { "Москвы", "Мира", "Новосибирска", "Киргизии", "Узбекистана", "России", "Киселевска", "Красноярска", "Донецка", "Новокузнецка", "Кузбасса" };
            Random r1 = new();
            Random r2 = new();
            for (int i = 0; i < TournamentsCount; i++)
            {
                Tournament tournament = new();
                
                int firstNameIndex = r1.Next(0, firstNames.Count - 1);
                int secondNameIndex = r2.Next(0, secondNames.Count - 1);
                tournament.Name = $"{firstNames[firstNameIndex]} {secondNames[secondNameIndex]}";

                tournaments.Add(tournament);
                secondNames.RemoveAt(secondNameIndex);
            }
            return tournaments;
        }
        public static List<Club> GenerateClubs()
        {
            List<string> firstNames = new List<string>() { "Мощные", "Сильные", "Добрые", "Строгие", "Злые", "Слабые", "Максимально Строгие", "Медленные" };
            List<string> secondNames = new List<string>() { "Львы", "Панды", "Манулы", "Капибары", "Тигры", "Черепахи", "Бегемоты", "Красные Панды", "Коты", "Собаки", "Обезьяны", "Слоны", "Выдры" };
            List<Club> clubs = new();
            Random r1 = new();
            Random r2 = new();

            for (int i = 0; i < ClubsCount; i++)
            {
                int firstNameIndex = r1.Next(0, firstNames.Count - 1);
                int secondNameIndex = r2.Next(0, secondNames.Count - 1);
                Club club = new($"{firstNames[firstNameIndex]} {secondNames[secondNameIndex]}");
                clubs.Add(club);
                secondNames.RemoveAt(secondNameIndex);
            }
            return clubs;
        }
        public static List<Player> GeneratePlayers()
        {
            List<Player> players = new();
            List<string> Names = new List<string>() { "Александр", "Витольд", "Степан", "Анатолий", "Марк", "Анатолий", "Андрей", "Иван", "Егор", "Владимир" };
            List<string> Surnames = new List<string>() { "Романов", "Бебров", "Артюхов", "Мартюшов", "Курбашов", "Дямик", "Папучини", "Мурсилаго", "Кадышев", "Милленис", "Дюмин", "Курчатов", "Папуас", "Сапожник", "Евреев", "Вайгант" };
            Random r = new();
            for (int i = 0; i < PlayersInClubCount; i++)
            {
                string name = Names[r.Next(0, Names.Count - 1)];
                string surname = Surnames[r.Next(0, Surnames.Count - 1)];
                Player player = new(name, surname);
                players.Add(player);
            }
            return players;
        }
        public static List<GameSession> GenerateGameSessions()
        {
            List<GameSession> gameSessions = new();
            Random r1 = new();
            Random r2 = new();
            for (int i = 0; i < GameSessionsCount ; i++)
            {
                GameSession gameSession = new();
                gameSession.FirstClubResult = r1.Next(0,MaxScoreCount);
                gameSession.SecondClubResult = r2.Next(0, MaxScoreCount);
                gameSession.Id = GameSessionID;
                GameSessionID++;
                gameSessions.Add(gameSession);
            }
            return gameSessions;
        }
    }
}
