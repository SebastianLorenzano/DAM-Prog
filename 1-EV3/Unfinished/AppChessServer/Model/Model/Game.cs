using Newtonsoft.Json;

namespace Model
{
    public class Game
    {
        public long codGame { get; set; }
        public long codUserWhites { get; set; }
        public long codUserBlacks { get; set; }
        public Board board { get; set; } = new Board();

        public string Serialize()
        {
            var settings = new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented
            };
            settings.Converters.Add(new PieceConverter());
            return JsonConvert.SerializeObject(this, settings);
        }
        public static Game Deserialize(string json)
        {
            var settings = new JsonSerializerSettings();
            settings.Converters.Add(new PieceConverter());
            return JsonConvert.DeserializeObject<Game>(json, settings);
        }

        public static List<Game> DeserializeList(string json)
        {
            var settings = new JsonSerializerSettings();
            settings.Converters.Add(new PieceConverter());
            List<GameSerialized> list = JsonConvert.DeserializeObject<List<GameSerialized>>(json, settings);
            return GameSerialized.Deserialize(list);
        }
    }

    public class GameSerialized
    {
        public long codGame { get; set; }
        public long codUserWhites { get; set; }
        public long codUserBlacks { get; set; }
        public string board { get; set; }



        public static GameSerialized Serialize(Game game)
        {
            return new GameSerialized()
            {
                codGame = game.codGame,
                codUserWhites = game.codUserWhites,
                codUserBlacks = game.codUserBlacks,
                board = game.board.JsonSerialize()
            };
        }

        public static List<GameSerialized> Serialize(List<Game> list)
        {
            var result = new List<GameSerialized>();
            if (list == null)
                return result;
            foreach (var game in list)
            {
                result.Add(Serialize(game));
            }
            return result;
        }

        public Game Deserialize()
        {
            var settings = new JsonSerializerSettings();
            settings.Converters.Add(new PieceConverter());
            var boardDeserialized = Board.JsonDeserialize(board);
            return new Game()
            {
                codGame = codGame,
                codUserWhites = codUserWhites,
                codUserBlacks = codUserBlacks,
                board = boardDeserialized
            };

        }

        public static List<Game> Deserialize(List<GameSerialized> list)
        {
            var result = new List<Game>();
            foreach (var game in list)
            {
                result.Add(game.Deserialize());
            }
            return result;

        }
    }


}

